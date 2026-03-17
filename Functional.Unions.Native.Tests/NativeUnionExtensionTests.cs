using System;
using FluentAssertions;
using Functional;
using Functional.Native;
using Xunit;

namespace Functional.Unions.Native.Tests
{
	public class NativeUnionExtensionTests
	{
		// ── One / Two ──────────────────────────────────────────────────────

		[Fact]
		public void One_WhenFirst_ReturnsSome()
		{
			Union<string, int> union = "hello";
			Option<string> opt = NativeUnionExtensions.One<string, int>(union);
			opt.Match<string>(s => s, () => "none").Should().Be("hello");
		}

		[Fact]
		public void One_WhenSecond_ReturnsNone()
		{
			Union<string, int> union = 42;
			Option<string> opt = NativeUnionExtensions.One<string, int>(union);
			opt.Match<string>(s => s, () => "none").Should().Be("none");
		}

		[Fact]
		public void Two_WhenSecond_ReturnsSome()
		{
			Union<string, int> union = 42;
			Option<int> opt = NativeUnionExtensions.Two<string, int>(union);
			opt.Match<int>(i => i, () => -1).Should().Be(42);
		}

		[Fact]
		public void Two_WhenFirst_ReturnsNone()
		{
			Union<string, int> union = "hello";
			Option<int> opt = NativeUnionExtensions.Two<string, int>(union);
			opt.Match<int>(i => i, () => -1).Should().Be(-1);
		}

		// ── Do ──────────────────────────────────────────────────────────

		[Fact]
		public void Do_CallsCorrectAction_AndReturnsSelf()
		{
			Union<string, int> union = "hi";
			string? seen = null;
			Union<string, int> returned = NativeUnionExtensions.Do<string, int>(union, s => seen = s, _ => { });
			seen.Should().Be("hi");
			returned.Match<string>(s => s, _ => "").Should().Be("hi");
		}

		// ── Select ──────────────────────────────────────────────────────

		[Fact]
		public void Select_TransformsFirstCase()
		{
			Union<string, int> union = "hello";
			IMatchableUnion<string, int> projected = NativeUnionExtensions.Select<string, int, string>(union, s => s.ToUpper());
			projected.Match<string>(s => s, _ => "none").Should().Be("HELLO");
		}

		[Fact]
		public void Select_PassesThroughSecondCase()
		{
			Union<string, int> union = 42;
			IMatchableUnion<string, int> projected = NativeUnionExtensions.Select<string, int, string>(union, s => s.ToUpper());
			projected.Match<string>(s => s, i => i.ToString()).Should().Be("42");
		}

		// ── MatchAsync ──────────────────────────────────────────────────

		[Fact]
		public async System.Threading.Tasks.Task MatchAsync_StringUnion_ReturnsCorrectly()
		{
			Union<string, int> union = "hello";
			int result = await NativeUnionExtensions.MatchAsync<string, int, int>(
				union,
				s => System.Threading.Tasks.Task.FromResult(s.Length),
				i => System.Threading.Tasks.Task.FromResult(i));
			result.Should().Be(5);
		}

		[Fact]
		public async System.Threading.Tasks.Task MatchAsync_IntUnion_ReturnsCorrectly()
		{
			Union<string, int> union = 42;
			int result = await NativeUnionExtensions.MatchAsync<string, int, int>(
				union,
				s => System.Threading.Tasks.Task.FromResult(s.Length),
				i => System.Threading.Tasks.Task.FromResult(i));
			result.Should().Be(42);
		}
	}
}
