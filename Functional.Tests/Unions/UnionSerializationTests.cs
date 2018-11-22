using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Functional.Tests.Utilities;
using Xunit;

namespace Functional.Tests.Unions
{
	public class UnionSerializationTests
	{
		[Fact]
		public void UnionDefinitionOneCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<OneUnionDefinition>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionTwoCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<TwoUnionDefinition>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionThreeCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<ThreeUnionDefinition>().Create((short)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionFourCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<FiveUnionDefinition>().Create((ushort)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionFiveCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<FiveUnionDefinition>().Create((int)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionSixCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<SixUnionDefinition>().Create((uint)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<SevenUnionDefinition>().Create((long)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionEightCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<EightUnionDefinition>().Create((ulong)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionTwoCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionThreeCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short>().Create((short)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionFourCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort>().Create((ushort)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionFiveCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int>().Create((int)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionSixCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint>().Create((uint)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long>().Create((long)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void AdhocUnionEightCanSerializeAndDeserialize()
		{
			var value = Union.FromTypes<sbyte, byte, short, ushort, int, uint, long, ulong>().Create((ulong)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		public class OneUnionDefinition : UnionDefinition<OneUnionDefinition, sbyte> { }
		public class TwoUnionDefinition : UnionDefinition<TwoUnionDefinition, sbyte, byte> { }
		public class ThreeUnionDefinition : UnionDefinition<ThreeUnionDefinition, sbyte, byte, short> { }
		public class FourUnionDefinition : UnionDefinition<FourUnionDefinition, sbyte, byte, short, ushort> { }
		public class FiveUnionDefinition : UnionDefinition<FiveUnionDefinition, sbyte, byte, short, ushort, int> { }
		public class SixUnionDefinition : UnionDefinition<SixUnionDefinition, sbyte, byte, short, ushort, int, uint> { }
		public class SevenUnionDefinition : UnionDefinition<SevenUnionDefinition, sbyte, byte, short, ushort, int, uint, long> { }
		public class EightUnionDefinition : UnionDefinition<EightUnionDefinition, sbyte, byte, short, ushort, int, uint, long, ulong> { }
	}
}
