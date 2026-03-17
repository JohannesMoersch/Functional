using System;
using FluentAssertions;
using Functional.Native;
using Xunit;

namespace Functional.Unions.Native.Tests
{
	public class NativeUnionMatchTests
	{
		[Fact]
		public void Match_StringUnion_CallsFirstFunc()
		{
			Union<string, int> union = "hello";
			int result = union.Match<int>(s => s.Length, i => i);
			result.Should().Be(5);
		}

		[Fact]
		public void Match_IntUnion_CallsSecondFunc()
		{
			Union<string, int> union = 42;
			int result = union.Match<int>(s => s.Length, i => i);
			result.Should().Be(42);
		}

		[Fact]
		public void Match_DoesNotCallUnusedBranch()
		{
			Union<string, int> union = "test";
			var called = false;
			union.Match<string>(s => s, i => { called = true; return i.ToString(); });
			called.Should().BeFalse();
		}

		[Fact]
		public void VoidMatch_StringUnion_CallsFirstAction()
		{
			Union<string, int> union = "hello";
			string? seen = null;
			union.Match((Action<string>)(s => seen = s), _ => { });
			seen.Should().Be("hello");
		}

		[Fact]
		public void VoidMatch_IntUnion_CallsSecondAction()
		{
			Union<string, int> union = 99;
			int seen = -1;
			union.Match((Action<string>)(_ => { }), i => seen = i);
			seen.Should().Be(99);
		}

		[Fact]
		public void Match_ThreeWay_CorrectBranchCalled()
		{
			Union<string, int, bool> a = "x";
			Union<string, int, bool> b = 5;
			Union<string, int, bool> c = false;

			a.Match<int>(s => 1, _ => 2, _ => 3).Should().Be(1);
			b.Match<int>(_ => 1, i => 2, _ => 3).Should().Be(2);
			c.Match<int>(_ => 1, _ => 2, _ => 3).Should().Be(3);
		}
	}
}
