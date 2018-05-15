using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
    public class TakeTests
    {
		[Fact]
		public async Task TakeNone()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Take(0)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public async Task TakeSome()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Take(2)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 2 });

		[Fact]
		public async Task TakeAll()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Take(1000)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public async Task TakeWhileOdd()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.TakeWhile(i => i % 2 == 1)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1 });
	}
}
