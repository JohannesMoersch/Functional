using System;
using FluentAssertions;
using Xunit;

namespace Functional.Unions.Native.Tests
{
	public class NativeUnionExtensionTests
	{
		// ── One / Two ──────────────────────────────────────────────────────

		[Fact]
		public void One_WhenFirst_ReturnsSome()
		{
			Functional.Native.Union<string, int> union = "hello";
			Functional.Option<string> opt = Functional.Native.NativeUnionExtensions.One<string, int>(union);
			opt.Match<string>(s => s, () => "none").Should().Be("hello");
		}

		[Fact]
		public void One_WhenSecond_ReturnsNone()
		{
			Functional.Native.Union<string, int> union = 42;
			Functional.Option<string> opt = Functional.Native.NativeUnionExtensions.One<string, int>(union);
			opt.Match<string>(s => s, () => "none").Should().Be("none");
		}

		[Fact]
		public void Two_WhenSecond_ReturnsSome()
		{
			Functional.Native.Union<string, int> union = 42;
			Functional.Option<int> opt = Functional.Native.NativeUnionExtensions.Two<string, int>(union);
			opt.Match<int>(i => i, () => -1).Should().Be(42);
		}

		[Fact]
		public void Two_WhenFirst_ReturnsNone()
		{
			Functional.Native.Union<string, int> union = "hello";
			Functional.Option<int> opt = Functional.Native.NativeUnionExtensions.Two<string, int>(union);
			opt.Match<int>(i => i, () => -1).Should().Be(-1);
		}

		// ── Do ──────────────────────────────────────────────────────────

		[Fact]
		public void Do_CallsCorrectAction_AndReturnsSelf()
		{
			Functional.Native.Union<string, int> union = "hi";
			string? seen = null;
			Functional.Native.Union<string, int> returned = Functional.Native.NativeUnionExtensions.Do<string, int>(union, s => seen = s, _ => { });
			seen.Should().Be("hi");
			returned.Match<string>(s => s, _ => "").Should().Be("hi");
		}

		// ── Select ──────────────────────────────────────────────────────

		[Fact]
		public void Select_TransformsFirstCase()
		{
			Functional.Native.Union<string, int> union = "hello";
			Functional.Native.Union<string, int> result = Functional.Native.NativeUnionExtensions.Select<string, int, string>(union, s => s.ToUpper());
			result.Match<string>(s => s, _ => "none").Should().Be("HELLO");
		}

		[Fact]
		public void Select_PassesThroughSecondCase()
		{
			Functional.Native.Union<string, int> union = 42;
			Functional.Native.Union<string, int> result = Functional.Native.NativeUnionExtensions.Select<string, int, string>(union, s => s.ToUpper());
			result.Match<string>(s => s, i => i.ToString()).Should().Be("42");
		}

		// ── MatchAsync ──────────────────────────────────────────────────

		[Fact]
		public async System.Threading.Tasks.Task MatchAsync_StringUnion_ReturnsCorrectly()
		{
			Functional.Native.Union<string, int> union = "hello";
			int result = await Functional.Native.NativeUnionExtensions.MatchAsync<string, int, int>(
				union,
				s => System.Threading.Tasks.Task.FromResult(s.Length),
				i => System.Threading.Tasks.Task.FromResult(i));
			result.Should().Be(5);
		}

		[Fact]
		public async System.Threading.Tasks.Task MatchAsync_IntUnion_ReturnsCorrectly()
		{
			Functional.Native.Union<string, int> union = 42;
			int result = await Functional.Native.NativeUnionExtensions.MatchAsync<string, int, int>(
				union,
				s => System.Threading.Tasks.Task.FromResult(s.Length),
				i => System.Threading.Tasks.Task.FromResult(i));
			result.Should().Be(42);
		}
	}
}
