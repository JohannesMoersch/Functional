using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Functional.Tests.IL
{
	public static class MemberInfoExtensions
	{
		private static readonly IReadOnlyDictionary<short, OpCode> _opCodeLookup;
		static MemberInfoExtensions()
			=> _opCodeLookup = typeof(OpCodes)
				.GetFields()
				.Select(f => f.GetValue(null))
				.OfType<OpCode>()
				.ToDictionary(opCode => opCode.Value);

		public static ParsedMethodBody GetParsedMethodBody(this ConstructorInfo constructor)
			=> ParsedMethodBody
				.Create
				(
					constructor,
					GetInstructionsFromILByteArray
					(
						constructor.GetMethodBody().GetILAsByteArray(),
						constructor.Module,
						constructor.ReflectedType.GetGenericArguments(),
						Type.EmptyTypes
					).ToArray()
				);

		public static Option<ParsedMethodBody> GetParsedMethodBody(this MethodInfo method)
			=> Option
				.FromNullable(method.GetMethodBody())
				.Map(methodBody => GetInstructionsFromILByteArray(methodBody.GetILAsByteArray(), method.Module, method.ReflectedType.GetGenericArguments(), method.GetGenericArguments()))
				.Map(instructions => ParsedMethodBody.Create(method, instructions.ToArray()));

		private static IEnumerable<Instruction> GetInstructionsFromILByteArray(byte[] bytes, Module module, Type[] typeGenerics, Type[] methodGenerics)
		{
			using (var stream = new MemoryStream(bytes))
			{
				while (stream.Position < stream.Length)
					yield return ReadInstruction(stream, module, typeGenerics, methodGenerics);
			}
		}

		private static Instruction ReadInstruction(Stream bytes, Module module, Type[] typeGenerics, Type[] methodGenerics)
		{
			short opCodeValue = (short)bytes.ReadByte();

			if (opCodeValue == 0xFE)
				opCodeValue = (short)(opCodeValue << 8 | bytes.ReadByte());

			if (!_opCodeLookup.TryGetValue(opCodeValue, out var opCode))
				throw new Exception($"OpCode with value {opCodeValue} not recognized.");

			Option<object> operand = default;
			int operandSize;
			switch (opCode.OperandType)
			{
				case OperandType.InlineSwitch:
					operandSize = ReadInt32(bytes) * 4;
					break;
				case OperandType.InlineI8:
				case OperandType.InlineR:
					operandSize = 8;
					break;
				case OperandType.InlineBrTarget:
				case OperandType.InlineField:
				case OperandType.InlineI:
				case OperandType.InlineString:
				case OperandType.InlineTok:
				case OperandType.InlineSig:
				case OperandType.ShortInlineR:
					operandSize = 4;
					break;
				case OperandType.InlineType:
					operandSize = 0;
					operand = Option.Some<object>(module.ResolveType(ReadInt32(bytes), typeGenerics, methodGenerics));
					break;
				case OperandType.InlineMethod:
					operandSize = 0;
					operand = Option.Some<object>(module.ResolveMember(ReadInt32(bytes), typeGenerics, methodGenerics));
					break;
				case OperandType.InlineVar:
					operandSize = 2;
					break;
				case OperandType.ShortInlineBrTarget:
				case OperandType.ShortInlineI:
				case OperandType.ShortInlineVar:
					operandSize = 1;
					break;
				case OperandType.InlineNone:
					operandSize = 0;
					break;
				default:
					throw new Exception($"OperandType {opCode.OperandType} unrecognized.");
			}

			for (int i = 0; i < operandSize; ++i)
				bytes.ReadByte();

			return new Instruction(opCode, operand);
		}

		private static int ReadInt32(Stream bytes)
			=> bytes.ReadByte() | (bytes.ReadByte() << 8) | (bytes.ReadByte() << 0x10) | (bytes.ReadByte() << 0x18);
	}
}
