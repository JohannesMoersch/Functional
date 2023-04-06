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
using Xunit;

namespace Functional.Tests
{
	public class AllocationTests
	{
		private Assembly[] Assemblies => new[]
		{
			typeof(Option).Assembly,
			typeof(OptionExtensions).Assembly
		};

		[Fact]
		public void ContainsNewObj()
		{
			foreach (var assembly in Assemblies)
				SearchMethodsInAssembly(assembly, "contain the newobj OpCode", FilterForNewObject);
		}

		private static bool FilterForNewObject(ParsedMethodBody methodBody)
		{
			var isAsyncMethod = methodBody.Parent.Match(c => false, m => m.GetCustomAttribute<AsyncStateMachineAttribute>() != null);

			foreach (var instruction in methodBody.Instructions.Skip(isAsyncMethod ? 1 : 0).Where(i => i.OpCode == OpCodes.Newobj))
			{
				if (instruction.Operand.OfType<ConstructorInfo>().Match(constructor => !constructor.ReflectedType.IsValueType && !typeof(Exception).IsAssignableFrom(constructor.ReflectedType), () => false))
					return true;
			}

			return false;
		}

		[Fact]
		public void ContainsNewArr()
		{
			foreach (var assembly in Assemblies)
				SearchMethodsInAssembly(assembly, "contain the newarr OpCode", methodBody => methodBody.Instructions.Any(i => i.OpCode == OpCodes.Newarr));
		}

		[Fact]
		public void ContainsBox()
		{
			foreach (var assembly in Assemblies)
				SearchMethodsInAssembly(assembly, "contain the box OpCode", FilterForBox);
		}

		private static bool FilterForBox(ParsedMethodBody methodBody)
		{
			for (int i = 0; i < methodBody.Instructions.Count; ++i)
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

		private static void SearchMethodsInAssembly(Assembly assembly, string message, Func<ParsedMethodBody, bool> methodFilter)
		{
			var members = GetMethodBodiesInAssembly(assembly)
				.Where(b => b.Parent.Match(c => !ContainsAllowAllocations(c.GetCustomAttributes()), m => !ContainsAllowAllocations(m.GetCustomAttributes())))
				.Where(b => !ContainsAllowAllocations(b.Parent.Match(c => c.ReflectedType, m => m.ReflectedType).GetCustomAttributes()))
				.Where(methodFilter)
				.Select(b => (name: b.Parent.Match(c => $"{c.Name}({GetFormattedParameters(c.GetParameters())})", m => $"{m.Name}({GetFormattedParameters(m.GetParameters())})"), className: b.Parent.Match(c => c.ReflectedType.FullName, m => m.ReflectedType.FullName)))
				.Select(b => $"{Environment.NewLine}\t{b.name} in {b.className}")
				.ToArray();

			if (members.Any())
				throw new Exception($"The following members {message}:{String.Join("", members)}");
		}

		private static string GetFormattedParameters(ParameterInfo[] parameters)
			=> String.Join(", ", parameters.Select(p => p.ParameterType.Name));

		private static bool ContainsAllowAllocations(IEnumerable<Attribute> attributes)
			=> attributes.Any(att => att.GetType().FullName == "Functional.AllowAllocationsAttribute");

		private static IEnumerable<ParsedMethodBody> GetMethodBodiesInAssembly(Assembly assembly)
			=> assembly
				.GetTypes()
				.Where(t => t.FullName != "System.Runtime.CompilerServices.NullableAttribute")
				.SelectMany(GetMethodBodiesFromType);

		private static IEnumerable<ParsedMethodBody> GetMethodBodiesFromType(Type type)
			=> Enumerable
				.Empty<ParsedMethodBody>()
				.Concat(type.GetRuntimeMethods().Select(m => m.GetParsedMethodBody()).WhereSome())
				.Concat(type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Select(c => c.GetParsedMethodBody()));
	}
}
