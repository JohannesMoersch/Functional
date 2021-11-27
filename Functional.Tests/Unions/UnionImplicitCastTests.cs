using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Unions
{
	public class UnionImplicitCastTests
	{
		[Fact]
		public void TwoUnionImplicitCastToOne()
			=> UnionTestExtensions.AssertOne<byte, sbyte>((byte)1)
				.Should()
				.Be(1);

		[Fact]
		public void TwoUnionImplicitCastToTwo()
			=> UnionTestExtensions.AssertTwo<byte, sbyte>((sbyte)1)
				.Should()
				.Be(1);

		[Fact]
		public void ThreeUnionImplicitCastToOne()
			=> UnionTestExtensions.AssertOne<byte, sbyte, ushort>((byte)1)
				.Should()
				.Be(1);

		[Fact]
		public void ThreeUnionImplicitCastToTwo()
			=> UnionTestExtensions.AssertTwo<byte, sbyte, ushort>((sbyte)1)
				.Should()
				.Be(1);

		[Fact]
		public void ThreeUnionImplicitCastToThree()
			=> UnionTestExtensions.AssertThree<byte, sbyte, ushort>((ushort)1)
				.Should()
				.Be(1);

		[Fact]
		public void FourUnionImplicitCastToOne()
			=> UnionTestExtensions.AssertOne<byte, sbyte, ushort, short>((byte)1)
				.Should()
				.Be(1);

		[Fact]
		public void FourUnionImplicitCastToTwo()
			=> UnionTestExtensions.AssertTwo<byte, sbyte, ushort, short>((sbyte)1)
				.Should()
				.Be(1);

		[Fact]
		public void FourUnionImplicitCastToThree()
			=> UnionTestExtensions.AssertThree<byte, sbyte, ushort, short>((ushort)1)
				.Should()
				.Be(1);

		[Fact]
		public void FourUnionImplicitCastToFour()
			=> UnionTestExtensions.AssertFour<byte, sbyte, ushort, short>((short)1)
				.Should()
				.Be(1);

		[Fact]
		public void FiveUnionImplicitCastToOne()
			=> UnionTestExtensions.AssertOne<byte, sbyte, ushort, short, uint>((byte)1)
				.Should()
				.Be(1);

		[Fact]
		public void FiveUnionImplicitCastToTwo()
			=> UnionTestExtensions.AssertTwo<byte, sbyte, ushort, short, uint>((sbyte)1)
				.Should()
				.Be(1);

		[Fact]
		public void FiveUnionImplicitCastToThree()
			=> UnionTestExtensions.AssertThree<byte, sbyte, ushort, short, uint>((ushort)1)
				.Should()
				.Be(1);

		[Fact]
		public void FiveUnionImplicitCastToFour()
			=> UnionTestExtensions.AssertFour<byte, sbyte, ushort, short, uint>((short)1)
				.Should()
				.Be(1);

		[Fact]
		public void FiveUnionImplicitCastToFive()
			=> UnionTestExtensions.AssertFive<byte, sbyte, ushort, short, uint>((uint)1)
				.Should()
				.Be(1);

		[Fact]
		public void SixUnionImplicitCastToOne()
			=> UnionTestExtensions.AssertOne<byte, sbyte, ushort, short, uint, int>((byte)1)
				.Should()
				.Be(1);

		[Fact]
		public void SixUnionImplicitCastToTwo()
			=> UnionTestExtensions.AssertTwo<byte, sbyte, ushort, short, uint, int>((sbyte)1)
				.Should()
				.Be(1);

		[Fact]
		public void SixUnionImplicitCastToThree()
			=> UnionTestExtensions.AssertThree<byte, sbyte, ushort, short, uint, int>((ushort)1)
				.Should()
				.Be(1);

		[Fact]
		public void SixUnionImplicitCastToFour()
			=> UnionTestExtensions.AssertFour<byte, sbyte, ushort, short, uint, int>((short)1)
				.Should()
				.Be(1);

		[Fact]
		public void SixUnionImplicitCastToFive()
			=> UnionTestExtensions.AssertFive<byte, sbyte, ushort, short, uint, int>((uint)1)
				.Should()
				.Be(1);

		[Fact]
		public void SixUnionImplicitCastToSix()
			=> UnionTestExtensions.AssertSix<byte, sbyte, ushort, short, uint, int>((int)1)
				.Should()
				.Be(1);

		[Fact]
		public void SevenUnionImplicitCastToOne()
			=> UnionTestExtensions.AssertOne<byte, sbyte, ushort, short, uint, int, ulong>((byte)1)
				.Should()
				.Be(1);

		[Fact]
		public void SevenUnionImplicitCastToTwo()
			=> UnionTestExtensions.AssertTwo<byte, sbyte, ushort, short, uint, int, ulong>((sbyte)1)
				.Should()
				.Be(1);

		[Fact]
		public void SevenUnionImplicitCastToThree()
			=> UnionTestExtensions.AssertThree<byte, sbyte, ushort, short, uint, int, ulong>((ushort)1)
				.Should()
				.Be(1);

		[Fact]
		public void SevenUnionImplicitCastToFour()
			=> UnionTestExtensions.AssertFour<byte, sbyte, ushort, short, uint, int, ulong>((short)1)
				.Should()
				.Be(1);

		[Fact]
		public void SevenUnionImplicitCastToFive()
			=> UnionTestExtensions.AssertFive<byte, sbyte, ushort, short, uint, int, ulong>((uint)1)
				.Should()
				.Be(1);

		[Fact]
		public void SevenUnionImplicitCastToSix()
			=> UnionTestExtensions.AssertSix<byte, sbyte, ushort, short, uint, int, ulong>((int)1)
				.Should()
				.Be(1);

		[Fact]
		public void SevenUnionImplicitCastToSeven()
			=> UnionTestExtensions.AssertSeven<byte, sbyte, ushort, short, uint, int, ulong>((ulong)1)
				.Should()
				.Be(1);

		[Fact]
		public void EightUnionImplicitCastToOne()
			=> UnionTestExtensions.AssertOne<byte, sbyte, ushort, short, uint, int, ulong, long>((byte)1)
				.Should()
				.Be(1);

		[Fact]
		public void EightUnionImplicitCastToTwo()
			=> UnionTestExtensions.AssertTwo<byte, sbyte, ushort, short, uint, int, ulong, long>((sbyte)1)
				.Should()
				.Be(1);

		[Fact]
		public void EightUnionImplicitCastToThree()
			=> UnionTestExtensions.AssertThree<byte, sbyte, ushort, short, uint, int, ulong, long>((ushort)1)
				.Should()
				.Be(1);

		[Fact]
		public void EightUnionImplicitCastToFour()
			=> UnionTestExtensions.AssertFour<byte, sbyte, ushort, short, uint, int, ulong, long>((short)1)
				.Should()
				.Be(1);

		[Fact]
		public void EightUnionImplicitCastToFive()
			=> UnionTestExtensions.AssertFive<byte, sbyte, ushort, short, uint, int, ulong, long>((uint)1)
				.Should()
				.Be(1);

		[Fact]
		public void EightUnionImplicitCastToSix()
			=> UnionTestExtensions.AssertSix<byte, sbyte, ushort, short, uint, int, ulong, long>((int)1)
				.Should()
				.Be(1);

		[Fact]
		public void EightUnionImplicitCastToSeven()
			=> UnionTestExtensions.AssertSeven<byte, sbyte, ushort, short, uint, int, ulong, long>((ulong)1)
				.Should()
				.Be(1);

		[Fact]
		public void EightUnionImplicitCastToEight()
			=> UnionTestExtensions.AssertEight<byte, sbyte, ushort, short, uint, int, ulong, long>((long)1)
				.Should()
				.Be(1);
	}
}
