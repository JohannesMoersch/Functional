using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Functional.Tests.Utilities;
using Xunit;

namespace Functional.Tests.Unions
{
	public class AdhocUnionSerializationTests
	{
		[Fact]
		public void AdhocUnionOneOfTwoCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionTwoOfTwoCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionOneOfThreeCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionTwoOfThreeCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionThreeOfThreeCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short>().Create((short)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionOneOfFourCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionTwoOfFourCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionThreeOfFourCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort>().Create((short)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionFourOfFourCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort>().Create((ushort)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionOneOfFiveCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionTwoOfFiveCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionThreeOfFiveCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int>().Create((short)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionFourOfFiveCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int>().Create((ushort)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionFiveOfFiveCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int>().Create((int)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionOneOfSixCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionTwoOfSixCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionThreeOfSixCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint>().Create((short)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionFourOfSixCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint>().Create((ushort)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionFiveOfSixCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint>().Create((int)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionSixOfSixCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint>().Create((uint)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionOneOfSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionTwoOfSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionThreeOfSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long>().Create((short)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionFourOfSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long>().Create((ushort)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionFiveOfSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long>().Create((int)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionSixOfSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long>().Create((uint)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionSevenOfSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long>().Create((long)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionOneOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionTwoOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionThreeOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((short)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionFourOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((ushort)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionFiveOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((int)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionSixOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((uint)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionSevenOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((long)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionEightOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((ulong)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}
	}
}
