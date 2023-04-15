using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Functional.Tests.IL;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Xunit;

namespace Functional.Tests
{
	public class AllocationTests
	{
		private record AllowAllocations(bool AllowBox, bool AllowNewArr, Type[] AllowNewObjTypes)
		{
			public AllowAllocations Merge(AllowAllocations allowAllocations)
				=> new AllowAllocations
				(
					AllowBox | allowAllocations.AllowBox, 
					AllowNewArr | allowAllocations.AllowNewArr, 
					AllowNewObjTypes.Concat(allowAllocations.AllowNewObjTypes).ToArray()
				);
		}

		private static Assembly[] Assemblies => new[]
		{
			typeof(Option).Assembly,
			typeof(OptionExtensions).Assembly
		};

		[Fact]
		public void ContainsBox()
		{
			var members = SearchForMembers(Assemblies, FilterForBox);

			if (members.Any())
				throw new Exception($"The following members contain the box OpCode:{Environment.NewLine}{String.Join("", FormatMembers(members))}");
		}

		[Fact]
		public void ContainsNewArr()
		{
			var members = SearchForMembers(Assemblies, FilterForNewArray);

			if (members.Any())
				throw new Exception($"The following members contain the newarr OpCode:{Environment.NewLine}{String.Join("", FormatMembers(members))}");
		}

		[Fact]
		public void ContainsNewObj()
		{
			var members = SearchForMembers(Assemblies, FilterForNewObject);

			if (members.Any())
				throw new Exception($"The following members contain the newobj OpCode:{Environment.NewLine}{String.Join("", FormatMembers(members))}");
		}

		private string FormatMembers(IEnumerable<(Assembly assembly, IEnumerable<(Type type, IEnumerable<(ParsedMethodBody parsedMethodBody, Type[] operandTypes)> members)> types)> members)
		{
			var builder = new StringBuilder();

			foreach (var assembly in members)
			{
				builder.Append($"      ");
				builder.AppendLine(assembly.assembly.FullName?.Split(',')[0] ?? "Unknown Assembly");

				foreach (var type in assembly.types)
				{
					builder.Append($"            ");
					builder.AppendLine(type.type.FullName);

					foreach (var (parsedMethodBody, operandTypes) in type.members)
					{
						var typeString = String.Join(", ", operandTypes.Select(t => t.Name));

						builder.Append($"                  ");
						builder.AppendLine(parsedMethodBody.Parent.Match(c => $"{c.Name}({GetFormattedParameters(c.GetParameters())}) -> {typeString}", p => $"{p.Name} -> {typeString}", m => $"{m.Name}({GetFormattedParameters(m.GetParameters())}) -> {typeString}"));
					}
				}
			}

			return builder.ToString();
		}

		private static IEnumerable<Type> FilterForNewObject(ParsedMethodBody methodBody, AllowAllocations allowAllocations)
		{
			var isAsyncMethod = methodBody.Parent.Match(c => false, p => false, m => m.GetCustomAttribute<AsyncStateMachineAttribute>() != null);

			for (var i = isAsyncMethod ? 1 : 0; i < methodBody.Instructions.Count; ++i)
			{
				var instruction = methodBody.Instructions[i];

				if (instruction.OpCode != OpCodes.Newobj)
					continue;

				if (!instruction.Operand.OfType<ConstructorInfo>().TryGetValue(out var constructor) || constructor.DeclaringType is not Type declaringType)
					continue;

				if (declaringType.IsValueType || declaringType.IsAssignableTo(typeof(Exception)))
					continue;

				if (i < methodBody.Instructions.Count - 2 && IsStaticDelegateInstantiation(constructor, methodBody.Instructions[i + 1], methodBody.Instructions[i + 2]))
					continue;

				var types = new List<Type>(declaringType.GetInterfaces());
				var next = declaringType;
				
				while (next != null)
				{
					types.Add(next);
					next = next.BaseType;
				}

				foreach (var type in types.Where(i => i.IsConstructedGenericType).ToArray())
					types.Add(type.GetGenericTypeDefinition());

				if (allowAllocations.AllowNewObjTypes.Intersect(types).Any())
					continue;

				yield return declaringType;
			}
		}

		private static IEnumerable<Type> FilterForNewArray(ParsedMethodBody methodBody, AllowAllocations allowAllocations)
		{
			if (allowAllocations.AllowNewArr)
				yield break;

			foreach (var instruction in methodBody.Instructions)
			{
				if (instruction.OpCode != OpCodes.Newarr)
					continue;

				if (instruction.Operand.OfType<Type>().TryGetValue(out var type))
					yield return type;
			}
		}

		private static bool IsStaticDelegateInstantiation(ConstructorInfo constructor, Instruction two, Instruction three)
			=> constructor.DeclaringType is Type declaringType
				&& declaringType.IsAssignableTo(typeof(Delegate))
				&& two.OpCode == OpCodes.Dup
				&& three.OpCode == OpCodes.Stsfld
				&& three.Operand.OfType<FieldInfo>().TryGetValue(out var field)
				&& field.Attributes.HasFlag(FieldAttributes.Static)
				&& field.DeclaringType is Type fieldDeclaringType
				&& fieldDeclaringType.Name.StartsWith("<>");

		private static IEnumerable<Type> FilterForBox(ParsedMethodBody methodBody, AllowAllocations allowAllocations)
		{
			if (allowAllocations.AllowBox)
				yield break;

			for (var i = 0; i < methodBody.Instructions.Count; ++i)
			{
				var instruction = methodBody.Instructions[i];

				if (instruction.OpCode == OpCodes.Box)
				{
					if (instruction.Operand.OfType<Type>().Match(t => t.IsGenericParameter, () => false) && i < methodBody.Instructions.Count - 1)
					{
						var nextOpCode = methodBody.Instructions[i + 1].OpCode;

						if (nextOpCode == OpCodes.Brtrue || nextOpCode == OpCodes.Brtrue_S || nextOpCode == OpCodes.Brfalse || nextOpCode == OpCodes.Brfalse_S)
							continue;

						if (i >= 2 && nextOpCode == OpCodes.Ceq && methodBody.Instructions[i - 2].OpCode == OpCodes.Ldnull)
							continue;

						if (i < methodBody.Instructions.Count - 2 && nextOpCode == OpCodes.Ldnull && methodBody.Instructions[i + 2].OpCode == OpCodes.Ceq)
							continue;
					}

					if (instruction.Operand.OfType<Type>().TryGetValue(out var type))
						yield return type;
				}
			}
		}

		private static IEnumerable<(Assembly assembly, IEnumerable<(Type type, IEnumerable<(ParsedMethodBody parsedMethodBody, Type[] operandTypes)> members)> types)> SearchForMembers(IEnumerable<Assembly> assemblies, Func<ParsedMethodBody, AllowAllocations, IEnumerable<Type>> methodFilter)
			=>
			from assembly in assemblies
			let types =
				from type in GetTypesInAssembly(assembly)
				where !type.IsAssignableTo(typeof(Exception))
				let typeAllowAllocations = GetAllowAllocations(type.GetCustomAttributes<Attribute>())
				let members =
					(
						from member in GetMemberBodiesFromType(type)
						let memberAttributes = member.Parent.Match(c => c.GetCustomAttributes(), p => p.GetCustomAttributes(), m => m.GetCustomAttributes())
						let memberAllowAllocations = GetAllowAllocations(memberAttributes)
						let operandTypes = methodFilter.Invoke(member, typeAllowAllocations.Merge(memberAllowAllocations)).ToArray()
						from _ in Option.Create(operandTypes.Any(), Unit.Value)
						select (member, operandTypes)
					)
					.WhereSome()
				where members.Any()
				select (type, members)
			where types.Any()
			select (assembly, types);

		private static string GetFormattedParameters(ParameterInfo[] parameters)
			=> String.Join(", ", parameters.Select(p => p.ParameterType.Name));

		private static AllowAllocations GetAllowAllocations(IEnumerable<Attribute> attributes)
			=>
			(
				from att in attributes.TryFirst(att => att.GetType().FullName == "Functional.AllowAllocationsAttribute")
				let type = att.GetType()
				let allowBox = (bool?)type.GetField("AllowBox")?.GetValue(att) ?? false
				let allowNewArr = (bool?)type.GetField("AllowNewArr")?.GetValue(att) ?? false
				let allowNewObjTypes = (Type[]?)type.GetField("AllowNewObjTypes")?.GetValue(att) ?? Type.EmptyTypes
				select new AllowAllocations(allowBox, allowNewArr, allowNewObjTypes)
			)
			.ValueOrDefault(new AllowAllocations(false, false, Type.EmptyTypes));			

		private static IEnumerable<Type> GetTypesInAssembly(Assembly assembly)
			=> assembly
				.GetTypes()
				.Where(t => t.FullName != "System.Runtime.CompilerServices.NullableAttribute");

		private static IEnumerable<ParsedMethodBody> GetMemberBodiesFromType(Type type)
			=> Enumerable
				.Empty<ParsedMethodBody>()
				.Concat(GetConstructorBodiesFromType(type))
				.Concat(GetMethodBodiesFromType(type))
				.Concat(GetPropertyBodiesFromType(type));

		private static IEnumerable<ParsedMethodBody> GetConstructorBodiesFromType(Type type)
			=> type
				.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
				.Select(constructor => constructor.GetParsedMethodBody());

		private static IEnumerable<ParsedMethodBody> GetMethodBodiesFromType(Type type)
			=>
			(
				from method in type.GetRuntimeMethods()
				where !type
					.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
					.SelectMany(p => new[] { p.GetMethod, p.SetMethod })
					.Contains(method)
				from parsedMethod in method.GetParsedMethodBody()
				select parsedMethod
			)
			.WhereSome();

		private static IEnumerable<ParsedMethodBody> GetPropertyBodiesFromType(Type type)
			=> type
				.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
				.SelectMany(property => property.GetParsedMethodBody());
	}
}
