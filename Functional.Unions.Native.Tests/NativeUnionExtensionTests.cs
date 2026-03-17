using System;
using FluentAssertions;
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
			union.One().Match(s => s, () => "none").Should().Be("hello");
		}

		[Fact]
		public void One_WhenSecond_ReturnsNone()
		{
			Union<string, int> union = 42;
			union.One().Match(s => s, () => "none").Should().Be("none");
		}

		[Fact]
		public void Two_WhenSecond_ReturnsSome()
		{
			Union<string, int> union = 42;
			union.Two().Match(i => i, () => -1).Should().Be(42);
		}

		[Fact]
		public void Two_WhenFirst_ReturnsNone()
		{
			Union<string, int> union = "hello";
			union.Two().Match(i => i, () => -1).Should().Be(-1);
		}

		// ── Do ──────────────────────────────────────────────────────────

		[Fact]
		public void Do_CallsCorrectAction_AndReturnsSelf()
		{
			Union<string, int> union = "hi";
			string? seen = null;
			var returned = union.Do(s => seen = s, _ => { });
			seen.Should().Be("hi");
			returned.Match(s => s, _ => "").Should().Be("hi");
		}

		// ── Select ──────────────────────────────────────────────────────

		[Fact]
		public void Select_TransformsFirstCase()
		{
			Union<string, int> union = "hello";
			var result = (from s in union select s.ToUpper()).Match(s => s, _ => "none");
			result.Should().Be("HELLO");
		}

		[Fact]
		public void Select_PassesThroughSecondCase()
		{
			Union<string, int> union = 42;
			var result = (from s in union select s.ToUpper()).Match(s => s, i => i.ToString());
			result.Should().Be("42");
		}

		// ── MatchAsync ──────────────────────────────────────────────────

		[Fact]
		public async System.Threading.Tasks.Task MatchAsync_StringUnion_ReturnsCorrectly()
		{
			Union<string, int> union = "hello";
			var result = await union.MatchAsync(
				s => System.Threading.Tasks.Task.FromResult(s.Length),
				i => System.Threading.Tasks.Task.FromResult(i));
			result.Should().Be(5);
		}

		[Fact]
		public async System.Threading.Tasks.Task MatchAsync_IntUnion_ReturnsCorrectly()
		{
			Union<string, int> union = 42;
			var result = await union.MatchAsync(
				s => System.Threading.Tasks.Task.FromResult(s.Length),
				i => System.Threading.Tasks.Task.FromResult(i));
			result.Should().Be(42);
		}
	}
}
