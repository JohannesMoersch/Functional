using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Functional.Tests.IL
{
	public class ParsedMethodBody
	{
		public Union<ConstructorInfo, MethodInfo> Parent { get; }

		public IReadOnlyList<Instruction> Instructions { get; }

		private ParsedMethodBody(Union<ConstructorInfo, MethodInfo> parent, Instruction[] instructions)
		{
			Parent = parent;
			Instructions = instructions;
		}

		public static ParsedMethodBody Create(ConstructorInfo constructor, Instruction[] instructions)
			=> new ParsedMethodBody(Union.FromTypes<ConstructorInfo, MethodInfo>().Create(constructor), instructions);

		public static ParsedMethodBody Create(MethodInfo method, Instruction[] instructions)
			=> new ParsedMethodBody(Union.FromTypes<ConstructorInfo, MethodInfo>().Create(method), instructions);
	}
}
