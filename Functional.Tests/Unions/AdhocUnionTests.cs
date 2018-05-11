using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Unions
{
    public class AdhocUnionTests
    {
		public class Match
		{
			[Fact]
			public void TwoValueMatchOne()
				=> Union
					.FromTypes<byte, sbyte>()
					.Create((byte)10)
					.Value()
					.Match(_ => true, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void TwoValueMatchTwo()
				=> Union
					.FromTypes<byte, sbyte>()
					.Create((sbyte)10)
					.Value()
					.Match(_ => false, _ => true)
					.Should()
					.BeTrue();

			[Fact]
			public void ThreeValueMatchOne()
				=> Union
					.FromTypes<byte, sbyte, ushort>()
					.Create((byte)10)
					.Value()
					.Match(_ => true, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void ThreeValueMatchTwo()
				=> Union
					.FromTypes<byte, sbyte, ushort>()
					.Create((sbyte)10)
					.Value()
					.Match(_ => false, _ => true, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void ThreeValueMatchThree()
				=> Union
					.FromTypes<byte, sbyte, ushort>()
					.Create((ushort)10)
					.Value()
					.Match(_ => false, _ => false, _ => true)
					.Should()
					.BeTrue();

			[Fact]
			public void FourValueMatchOne()
				=> Union
					.FromTypes<byte, sbyte, ushort, short>()
					.Create((byte)10)
					.Value()
					.Match(_ => true, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void FourValueMatchTwo()
				=> Union
					.FromTypes<byte, sbyte, ushort, short>()
					.Create((sbyte)10)
					.Value()
					.Match(_ => false, _ => true, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void FourValueMatchThree()
				=> Union
					.FromTypes<byte, sbyte, ushort, short>()
					.Create((ushort)10)
					.Value()
					.Match(_ => false, _ => false, _ => true, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void FourValueMatchFour()
				=> Union
					.FromTypes<byte, sbyte, ushort, short>()
					.Create((short)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => true)
					.Should()
					.BeTrue();

			[Fact]
			public void FiveValueMatchOne()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint>()
					.Create((byte)10)
					.Value()
					.Match(_ => true, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void FiveValueMatchTwo()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint>()
					.Create((sbyte)10)
					.Value()
					.Match(_ => false, _ => true, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void FiveValueMatchThree()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint>()
					.Create((ushort)10)
					.Value()
					.Match(_ => false, _ => false, _ => true, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void FiveValueMatchFour()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint>()
					.Create((short)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => true, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void FiveValueMatchFive()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint>()
					.Create((uint)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => true)
					.Should()
					.BeTrue();

			[Fact]
			public void SixValueMatchOne()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int>()
					.Create((byte)10)
					.Value()
					.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SixValueMatchTwo()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int>()
					.Create((sbyte)10)
					.Value()
					.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SixValueMatchThree()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int>()
					.Create((ushort)10)
					.Value()
					.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SixValueMatchFour()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int>()
					.Create((short)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SixValueMatchFive()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int>()
					.Create((uint)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SixValueMatchSix()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int>()
					.Create((int)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true)
					.Should()
					.BeTrue();

			[Fact]
			public void SevenValueMatchOne()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong>()
					.Create((byte)10)
					.Value()
					.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SevenValueMatchTwo()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong>()
					.Create((sbyte)10)
					.Value()
					.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SevenValueMatchThree()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong>()
					.Create((ushort)10)
					.Value()
					.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SevenValueMatchFour()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong>()
					.Create((short)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SevenValueMatchFive()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong>()
					.Create((uint)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SevenValueMatchSix()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong>()
					.Create((int)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void SevenValueMatchSeven()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong>()
					.Create((ulong)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchOne()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					.Create((byte)10)
					.Value()
					.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchTwo()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					.Create((sbyte)10)
					.Value()
					.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchThree()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					.Create((ushort)10)
					.Value()
					.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchFour()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					.Create((short)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchFive()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					.Create((uint)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchSix()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					.Create((int)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchSeven()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					.Create((ulong)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false)
					.Should()
					.BeTrue();

			[Fact]
			public void EightValueMatchEight()
				=> Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					.Create((long)10)
					.Value()
					.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true)
					.Should()
					.BeTrue();
		}

		public class Do
		{
			[Fact]
			public void TwoValueDoOne()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte>()
					  .Create((byte)10)
					  .Value()
					  .Do(_ => result = true, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void TwoValueDoTwo()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte>()
					  .Create((sbyte)10)
					  .Value()
					  .Do(_ => { }, _ => result = true);

				result.Should().BeTrue();
			}

			[Fact]
			public void ThreeValueDoOne()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort>()
					  .Create((byte)10)
					  .Value()
					  .Do(_ => result = true, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void ThreeValueDoTwo()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort>()
					  .Create((sbyte)10)
					  .Value()
					  .Do(_ => { }, _ => result = true, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void ThreeValueDoThree()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort>()
					  .Create((ushort)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => result = true);

				result.Should().BeTrue();
			}

			[Fact]
			public void FourValueDoOne()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short>()
					  .Create((byte)10)
					  .Value()
					  .Do(_ => result = true, _ => { }, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void FourValueDoTwo()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short>()
					  .Create((sbyte)10)
					  .Value()
					  .Do(_ => { }, _ => result = true, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void FourValueDoThree()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short>()
					  .Create((ushort)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => result = true, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void FourValueDoFour()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short>()
					  .Create((short)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => { }, _ => result = true);

				result.Should().BeTrue();
			}

			[Fact]
			public void FiveValueDoOne()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint>()
					  .Create((byte)10)
					  .Value()
					  .Do(_ => result = true, _ => { }, _ => { }, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void FiveValueDoTwo()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint>()
					  .Create((sbyte)10)
					  .Value()
					  .Do(_ => { }, _ => result = true, _ => { }, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void FiveValueDoThree()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint>()
					  .Create((ushort)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => result = true, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void FiveValueDoFour()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint>()
					  .Create((short)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => { }, _ => result = true, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void FiveValueDoFive()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint>()
					  .Create((uint)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => result = true);

				result.Should().BeTrue();
			}

			[Fact]
			public void SixValueDoOne()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int>()
					  .Create((byte)10)
					  .Value()
					  .Do(_ => result = true, _ => { }, _ => { }, _ => { }, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void SixValueDoTwo()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int>()
					  .Create((sbyte)10)
					  .Value()
					  .Do(_ => { }, _ => result = true, _ => { }, _ => { }, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void SixValueDoThree()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int>()
					  .Create((ushort)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => result = true, _ => { }, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void SixValueDoFour()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int>()
					  .Create((short)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => { }, _ => result = true, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void SixValueDoFive()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int>()
					  .Create((uint)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => result = true, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void SixValueDoSix()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int>()
					  .Create((int)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => result = true);

				result.Should().BeTrue();
			}

			[Fact]
			public void SevenValueDoOne()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong>()
					  .Create((byte)10)
					  .Value()
					  .Do(_ => result = true, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void SevenValueDoTwo()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong>()
					  .Create((sbyte)10)
					  .Value()
					  .Do(_ => { }, _ => result = true, _ => { }, _ => { }, _ => { }, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void SevenValueDoThree()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong>()
					  .Create((ushort)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => result = true, _ => { }, _ => { }, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void SevenValueDoFour()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong>()
					  .Create((short)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => { }, _ => result = true, _ => { }, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void SevenValueDoFive()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong>()
					  .Create((uint)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => result = true, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void SevenValueDoSix()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong>()
					  .Create((int)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => result = true, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void SevenValueDoSeven()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong>()
					  .Create((ulong)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => result = true);

				result.Should().BeTrue();
			}

			[Fact]
			public void EightValueDoOne()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					  .Create((byte)10)
					  .Value()
					  .Do(_ => result = true, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void EightValueDoTwo()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					  .Create((sbyte)10)
					  .Value()
					  .Do(_ => { }, _ => result = true, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void EightValueDoThree()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					  .Create((ushort)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => result = true, _ => { }, _ => { }, _ => { }, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void EightValueDoFour()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					  .Create((short)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => { }, _ => result = true, _ => { }, _ => { }, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void EightValueDoFive()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					  .Create((uint)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => result = true, _ => { }, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void EightValueDoSix()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					  .Create((int)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => result = true, _ => { }, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void EightValueDoSeven()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					  .Create((ulong)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => result = true, _ => { });

				result.Should().BeTrue();
			}

			[Fact]
			public void EightValueDoEight()
			{
				bool result = false;

				Union
					.FromTypes<byte, sbyte, ushort, short, uint, int, ulong, long>()
					  .Create((long)10)
					  .Value()
					  .Do(_ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => { }, _ => result = true);

				result.Should().BeTrue();
			}
		}
    }
}
