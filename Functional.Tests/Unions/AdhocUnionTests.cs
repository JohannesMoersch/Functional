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
