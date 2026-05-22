using System;
using FluentAssertions;
using Xunit;
using NativeUnion = Functional.Native.NativeUnionExtensions;

namespace Functional.Unions.Native.Tests
{
	public class NativeUnionCreationTests
	{
		[Fact]
		public void ImplicitFromFirstType_CreatesUnion()
		{
			Functional.Native.Union<string, int> union = "hello";
			string result = union.Match<string>(s => s, _ => "wrong");
			result.Should().Be("hello");
		}

		[Fact]
		public void ImplicitFromSecondType_CreatesUnion()
		{
			Functional.Native.Union<string, int> union = 42;
			int result = union.Match<int>(_ => -1, i => i);
			result.Should().Be(42);
		}

		[Fact]
		public void ThreeWay_ImplicitFromFirst()
		{
			Functional.Native.Union<string, int, bool> union = "hi";
			string result = union.Match<string>(s => s, _ => "no", _ => "no");
			result.Should().Be("hi");
		}

		[Fact]
		public void ThreeWay_ImplicitFromSecond()
		{
			Functional.Native.Union<string, int, bool> union = 7;
			int result = union.Match<int>(_ => -1, i => i, _ => -1);
			result.Should().Be(7);
		}

		[Fact]
		public void ThreeWay_ImplicitFromThird()
		{
			Functional.Native.Union<string, int, bool> union = true;
			bool result = union.Match<bool>(_ => false, _ => false, b => b);
			result.Should().BeTrue();
		}
	}
}
