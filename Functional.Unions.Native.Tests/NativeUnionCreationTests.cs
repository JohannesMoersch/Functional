using System;
using FluentAssertions;
using Functional.Native;
using Xunit;

namespace Functional.Unions.Native.Tests
{
	public class NativeUnionCreationTests
	{
		[Fact]
		public void ImplicitFromFirstType_CreatesUnion()
		{
			Union<string, int> union = "hello";
			union.Match(s => s, _ => "wrong").Should().Be("hello");
		}

		[Fact]
		public void ImplicitFromSecondType_CreatesUnion()
		{
			Union<string, int> union = 42;
			union.Match(_ => -1, i => i).Should().Be(42);
		}

		[Fact]
		public void ThreeWay_ImplicitFromFirst()
		{
			Union<string, int, bool> union = "hi";
			union.Match(s => s, _ => "no", _ => "no").Should().Be("hi");
		}

		[Fact]
		public void ThreeWay_ImplicitFromSecond()
		{
			Union<string, int, bool> union = 7;
			union.Match(_ => -1, i => i, _ => -1).Should().Be(7);
		}

		[Fact]
		public void ThreeWay_ImplicitFromThird()
		{
			Union<string, int, bool> union = true;
			union.Match(_ => false, _ => false, b => b).Should().BeTrue();
		}
	}
}
