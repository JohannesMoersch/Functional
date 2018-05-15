using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
    public class SkipTests
    {
		[Fact]
		public async Task SkipNone()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Skip(0)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public async Task SkipSome()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Skip(2)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 3 });

		[Fact]
		public async Task SkipAll()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Skip(1000)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public async Task SkipWhileOdd()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.SkipWhile(i => i % 2 == 1)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 2, 3 });

		[Fact]
		public async Task SkipWhileIndexLessThanOne()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.SkipWhile((_, index) => index < 1)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 2, 3 });
	}
}
