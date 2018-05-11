using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Unions
{
    public class UnionTests
    {
		public class Match
		{
			[Fact]
			public void OneValueMatchOne()
				=> Union
					.FromDefinition<OneDefinition>()
					.Create((byte)10)
					.Value()
					.Match(_ => true)
					.Should()
					.BeTrue();

			[Fact]
			public void TwoValueMatchOne()
				=> Union
					.FromDefinition<TwoDefinition>()
					.Create((byte)10)
					.Value()
					.Match(_ => true, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void TwoValueMatchTwo()
				=> Union
					.FromDefinition<TwoDefinition>()
					.Create((sbyte)10)
					.Value()
					.Match(_ => false, _ => true)
					.Should()
					.BeTrue();

			[Fact]
			public void ThreeValueMatchOne()
				=> Union
					.FromDefinition<ThreeDefinition>()
					.Create((byte)10)
					.Value()
					.Match(_ => true, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void ThreeValueMatchTwo()
				=> Union
					.FromDefinition<ThreeDefinition>()
					.Create((sbyte)10)
					.Value()
					.Match(_ => false, _ => true, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void ThreeValueMatchThree()
				=> Union
					.FromDefinition<ThreeDefinition>()
					.Create((ushort)10)
					.Value()
					.Match(_ => false, _ => false, _ => true)
					.Should()
					.BeTrue();

			[Fact]
			public void FourValueMatchOne()
				=> Union
					.FromDefinition<FourDefinition>()
					.Create((byte)10)
					.Value()
					.Match(_ => true, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void FourValueMatchTwo()
				=> Union
					.FromDefinition<FourDefinition>()
					.Create((sbyte)10)
					.Value()
					.Match(_ => false, _ => true, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void FourValueMatchThree()
				=> Union
					.FromDefinition<FourDefinition>()
					.Create((ushort)10)
					.Value()
					.Match(_ => false, _ => false, _ => true, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void FourValueMatchFour()
				=> Union
					.FromDefinition<FourDefinition>()
					.Create((short)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => true)
					.Should()
					.BeTrue();

			[Fact]
			public void FiveValueMatchOne()
				=> Union
					.FromDefinition<FiveDefinition>()
					.Create((byte)10)
					.Value()
					.Match(_ => true, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void FiveValueMatchTwo()
				=> Union
					.FromDefinition<FiveDefinition>()
					.Create((sbyte)10)
					.Value()
					.Match(_ => false, _ => true, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void FiveValueMatchThree()
				=> Union
					.FromDefinition<FiveDefinition>()
					.Create((ushort)10)
					.Value()
					.Match(_ => false, _ => false, _ => true, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void FiveValueMatchFour()
				=> Union
					.FromDefinition<FiveDefinition>()
					.Create((short)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => true, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void FiveValueMatchFive()
				=> Union
					.FromDefinition<FiveDefinition>()
					.Create((uint)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => true)
					.Should()
					.BeTrue();

			[Fact]
			public void SixValueMatchOne()
				=> Union
					.FromDefinition<SixDefinition>()
					.Create((byte)10)
					.Value()
					.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SixValueMatchTwo()
				=> Union
					.FromDefinition<SixDefinition>()
					.Create((sbyte)10)
					.Value()
					.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SixValueMatchThree()
				=> Union
					.FromDefinition<SixDefinition>()
					.Create((ushort)10)
					.Value()
					.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SixValueMatchFour()
				=> Union
					.FromDefinition<SixDefinition>()
					.Create((short)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SixValueMatchFive()
				=> Union
					.FromDefinition<SixDefinition>()
					.Create((uint)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SixValueMatchSix()
				=> Union
					.FromDefinition<SixDefinition>()
					.Create((int)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true)
					.Should()
					.BeTrue();

			[Fact]
			public void SevenValueMatchOne()
				=> Union
					.FromDefinition<SevenDefinition>()
					.Create((byte)10)
					.Value()
					.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SevenValueMatchTwo()
				=> Union
					.FromDefinition<SevenDefinition>()
					.Create((sbyte)10)
					.Value()
					.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SevenValueMatchThree()
				=> Union
					.FromDefinition<SevenDefinition>()
					.Create((ushort)10)
					.Value()
					.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SevenValueMatchFour()
				=> Union
					.FromDefinition<SevenDefinition>()
					.Create((short)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SevenValueMatchFive()
				=> Union
					.FromDefinition<SevenDefinition>()
					.Create((uint)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SevenValueMatchSix()
				=> Union
					.FromDefinition<SevenDefinition>()
					.Create((int)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SevenValueMatchSeven()
				=> Union
					.FromDefinition<SevenDefinition>()
					.Create((ulong)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchOne()
				=> Union
					.FromDefinition<EightDefinition>()
					.Create((byte)10)
					.Value()
					.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchTwo()
				=> Union
					.FromDefinition<EightDefinition>()
					.Create((sbyte)10)
					.Value()
					.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchThree()
				=> Union
					.FromDefinition<EightDefinition>()
					.Create((ushort)10)
					.Value()
					.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchFour()
				=> Union
					.FromDefinition<EightDefinition>()
					.Create((short)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchFive()
				=> Union
					.FromDefinition<EightDefinition>()
					.Create((uint)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchSix()
				=> Union
					.FromDefinition<EightDefinition>()
					.Create((int)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchSeven()
				=> Union
					.FromDefinition<EightDefinition>()
					.Create((ulong)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchEight()
				=> Union
					.FromDefinition<EightDefinition>()
					.Create((long)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true)
					.Should()
					.BeTrue();
		}
    }

	public class OneDefinition : UnionDefinition<OneDefinition, byte> { }

	public class TwoDefinition : UnionDefinition<TwoDefinition, byte, sbyte> { }

	public class ThreeDefinition : UnionDefinition<ThreeDefinition, byte, sbyte, ushort> { }

	public class FourDefinition : UnionDefinition<FourDefinition, byte, sbyte, ushort, short> { }

	public class FiveDefinition : UnionDefinition<FiveDefinition, byte, sbyte, ushort, short, uint> { }

	public class SixDefinition : UnionDefinition<SixDefinition, byte, sbyte, ushort, short, uint, int> { }

	public class SevenDefinition : UnionDefinition<SevenDefinition, byte, sbyte, ushort, short, uint, int, ulong> { }

	public class EightDefinition : UnionDefinition<EightDefinition, byte, sbyte, ushort, short, uint, int, ulong, long> { }
}
