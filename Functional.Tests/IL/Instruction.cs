using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Functional.Tests.IL
{
	public class Instruction
	{
		public OpCode OpCode { get; }

		public Option<object> Operand { get; }

		public Instruction(OpCode opCode, Option<object> operand)
		{
			OpCode = opCode;
			Operand = operand;
		}
	}
}
