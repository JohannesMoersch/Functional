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

		private string FormatMembers(IEnumerable<(Assembly assembly, IEnumerable<(Type type, IEnumerable<(ParsedMethodBody parsedMethodBody, Type operandType)> members)> types)> members)
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

					foreach (var (parsedMethodBody, operandType) in type.members)
					{
						builder.Append($"                  ");
						builder.AppendLine(parsedMethodBody.Parent.Match(c => $"{c.Name}({GetFormattedParameters(c.GetParameters())}) -> {operandType.Name}", p => $"{p.Name} -> {operandType.Name}", m => $"{m.Name}({GetFormattedParameters(m.GetParameters())}) -> {operandType.Name}"));
					}
				}
			}

			return builder.ToString();
		}

		private static Option<Type> FilterForNewObject(ParsedMethodBody methodBody)
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

				return declaringType;
			}

			return Option.None();
		}

		private static Option<Type> FilterForNewArray(ParsedMethodBody methodBody)
		{
			foreach (var instruction in methodBody.Instructions)
			{
				if (instruction.OpCode != OpCodes.Newarr)
					continue;

				return instruction.Operand.OfType<Type>();
			}

			return Option.None();
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

		private static Option<Type> FilterForBox(ParsedMethodBody methodBody)
		{
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

					return instruction.Operand.OfType<Type>();
				}
			}
			
			return Option.None();
		}

		private static IEnumerable<(Assembly assembly, IEnumerable<(Type type, IEnumerable<(ParsedMethodBody parsedMethodBody, Type operandType)> members)> types)> SearchForMembers(IEnumerable<Assembly> assemblies, Func<ParsedMethodBody, Option<Type>> methodFilter)
			=>
			from assembly in assemblies
			let types =
				from type in GetTypesInAssembly(assembly)
				where !ContainsAllowAllocations(type.GetCustomAttributes<Attribute>())
				let members =
					(
						from member in GetMemberBodiesFromType(type)
						let memberAttributes = member.Parent.Match(c => c.GetCustomAttributes(), p => p.GetCustomAttributes(), m => m.GetCustomAttributes())
						where !ContainsAllowAllocations(memberAttributes)
						from operandType in methodFilter.Invoke(member)
						select (member, operandType)
					)
					.WhereSome()
				where members.Any()
				select (type, members)
			where types.Any()
			select (assembly, types);

		private static string GetFormattedParameters(ParameterInfo[] parameters)
			=> String.Join(", ", parameters.Select(p => p.ParameterType.Name));

		private static bool ContainsAllowAllocations(IEnumerable<Attribute> attributes)
			=> attributes.Any(att => att.GetType().FullName == "Functional.AllowAllocationsAttribute");

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
