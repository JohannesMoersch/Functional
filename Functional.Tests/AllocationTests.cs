using System;
using System.Collections.Generic;
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
				throw new Exception($"The following members contain the box OpCode:{String.Join("", FormatMembers(members))}");
		}

		[Fact]
		public void ContainsNewArr()
		{
			var members = SearchForMembers(Assemblies, methodBody => methodBody.Instructions.Any(i => i.OpCode == OpCodes.Newarr));

			if (members.Any())
				throw new Exception($"The following members contain the newarr OpCode:{String.Join("", FormatMembers(members))}");
		}

		[Fact]
		public void ContainsNewObj()
		{
			var members = SearchForMembers(Assemblies, FilterForNewObject);

			if (members.Any())
				throw new Exception($"The following members contain the newobj OpCode:{String.Join("", FormatMembers(members))}");
		}

		private string FormatMembers(IEnumerable<(Assembly assembly, IEnumerable<(Type type, IEnumerable<ParsedMethodBody> members)> types)> members)
		{
			var builder = new StringBuilder();

			foreach (var assembly in members)
			{
				builder.Append($"\t");
				builder.AppendLine(assembly.assembly.FullName.Split(',')[0]);

				foreach (var type in assembly.types)
				{
					builder.Append($"\t\t");
					builder.AppendLine(type.type.Name);

					foreach (var member in type.members)
					{
						builder.Append($"\t\t\t");
						builder.AppendLine(member.Parent.Match(c => $"{c.Name}({GetFormattedParameters(c.GetParameters())})", m => $"{m.Name}({GetFormattedParameters(m.GetParameters())})"));
					}
				}
			}

			return builder.ToString();
		}

		private static bool FilterForNewObject(ParsedMethodBody methodBody)
		{
			var isAsyncMethod = methodBody.Parent.Match(c => false, m => m.GetCustomAttribute<AsyncStateMachineAttribute>() != null);

			for (var i = isAsyncMethod ? 1 : 0; i < methodBody.Instructions.Count; ++i)
			{
				var instruction = methodBody.Instructions[i];

				if (instruction.OpCode != OpCodes.Newobj || !instruction.Operand.OfType<ConstructorInfo>().TryGetValue(out var constructor))
					continue;

				if (constructor.DeclaringType.IsValueType || constructor.DeclaringType.IsAssignableTo(typeof(Exception)))
					continue;

				if (i < methodBody.Instructions.Count - 2 && IsStaticDelegateInstantiation(constructor, methodBody.Instructions[i + 1], methodBody.Instructions[i + 2]))
					continue;

				return true;
			}

			return false;
		}

		private static bool IsStaticDelegateInstantiation(ConstructorInfo constructor, Instruction two, Instruction three)
			=> constructor.DeclaringType.IsAssignableTo(typeof(Delegate))
				&& two.OpCode == OpCodes.Dup
				&& three.OpCode == OpCodes.Stsfld
				&& three.Operand.OfType<FieldInfo>().TryGetValue(out var field)
				&& field.Attributes.HasFlag(FieldAttributes.Static)
				&& field.DeclaringType.Name.StartsWith("<>");

		private static bool FilterForBox(ParsedMethodBody methodBody)
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
					return true;
				}
			}

			return false;
		}

		private static IEnumerable<(Assembly assembly, IEnumerable<(Type type, IEnumerable<ParsedMethodBody> members)> types)> SearchForMembers(IEnumerable<Assembly> assemblies, Func<ParsedMethodBody, bool> methodFilter)
			=>
			from assembly in assemblies
			let types =
				from type in GetTypesInAssembly(assembly)
				let members =
					from member in GetMethodBodiesFromType(type)
					where member.Parent.Match(c => !ContainsAllowAllocations(c.GetCustomAttributes()), m => !ContainsAllowAllocations(m.GetCustomAttributes()))
					where !ContainsAllowAllocations(member.Parent.Match(c => c.ReflectedType, m => m.ReflectedType).GetCustomAttributes())
					where methodFilter.Invoke(member)
					select member
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

		private static IEnumerable<ParsedMethodBody> GetMethodBodiesFromType(Type type)
			=> Enumerable
				.Empty<ParsedMethodBody>()
				.Concat(type.GetRuntimeMethods().Select(m => m.GetParsedMethodBody()).WhereSome())
				.Concat(type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Select(c => c.GetParsedMethodBody()));
	}
}
