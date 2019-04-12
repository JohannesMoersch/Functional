using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Unions
{
	public class UnionSerializationTests
	{
		[Fact]
		public void UnionDefinitionOneOfOneCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<OneUnionDefinition>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionOneOfTwoCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<TwoUnionDefinition>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionTwoOfTwoCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<TwoUnionDefinition>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionOneOfThreeCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<ThreeUnionDefinition>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionTwoOfThreeCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<ThreeUnionDefinition>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionThreeOfThreeCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<ThreeUnionDefinition>().Create((short)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionOneOfFourCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<FourUnionDefinition>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionTwoOfFourCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<FourUnionDefinition>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionThreeOfFourCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<FourUnionDefinition>().Create((short)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionFourOfFourCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<FourUnionDefinition>().Create((ushort)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionOneOfFiveCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<FiveUnionDefinition>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionTwoOfFiveCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<FiveUnionDefinition>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionThreeOfFiveCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<FiveUnionDefinition>().Create((short)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionFourOfFiveCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<FiveUnionDefinition>().Create((ushort)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionFiveOfFiveCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<FiveUnionDefinition>().Create((int)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionOneOfSixCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<SixUnionDefinition>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionTwoOfSixCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<SixUnionDefinition>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionThreeOfSixCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<SixUnionDefinition>().Create((short)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionFourOfSixCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<SixUnionDefinition>().Create((ushort)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionFiveOfSixCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<SixUnionDefinition>().Create((int)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionSixOfSixCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<SixUnionDefinition>().Create((uint)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionOneOfSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<SevenUnionDefinition>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionTwoOfSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<SevenUnionDefinition>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionThreeOfSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<SevenUnionDefinition>().Create((short)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionFourOfSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<SevenUnionDefinition>().Create((ushort)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionFiveOfSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<SevenUnionDefinition>().Create((int)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionSixOfSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<SevenUnionDefinition>().Create((uint)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionSevenOfSevenCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<SevenUnionDefinition>().Create((long)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionOneOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<EightUnionDefinition>().Create((sbyte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionTwoOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<EightUnionDefinition>().Create((byte)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionThreeOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<EightUnionDefinition>().Create((short)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionFourOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<EightUnionDefinition>().Create((ushort)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionFiveOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<EightUnionDefinition>().Create((int)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionSixOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<EightUnionDefinition>().Create((uint)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionSevenOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<EightUnionDefinition>().Create((long)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void UnionDefinitionEightOfEightCanSerializeAndDeserialize()
		{
			var value = Union.FromDefinition<EightUnionDefinition>().Create((ulong)64);

			SerializationUtility
				.CloneViaSerialization(value)
				.Value()
				.Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { })
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
