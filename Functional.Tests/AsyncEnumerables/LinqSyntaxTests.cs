using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
    public class LinqSyntaxTests
    {
		[Fact]
		public async Task FromAsyncAndAsync()
			=>
			(
				await
				(
					from a in new[] { 1, 2, 3 }.AsAsyncEnumerable()
					from b in new[] { 4, 5, 6 }.AsAsyncEnumerable()
					select a + b
				)
				.AsEnumerable()
			)
			.Should()
			.BeEquivalentTo(new[] { 5, 6, 7, 6, 7, 8, 7, 8, 9 });

		[Fact]
		public async Task FromEnumerableAndAsync()
			=>
			(
				await
				(
					from a in new[] { 1, 2, 3 }
					from b in new[] { 4, 5, 6 }.AsAsyncEnumerable()
					select a + b
				)
				.AsEnumerable()
			)
			.Should()
			.BeEquivalentTo(new[] { 5, 6, 7, 6, 7, 8, 7, 8, 9 });

		[Fact]
		public async Task FromTaskEnumerableAndAsync()
			=>
			(
				await
				(
					from a in Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable()
					from b in new[] { 4, 5, 6 }.AsAsyncEnumerable()
					select a + b
				)
				.AsEnumerable()
			)
			.Should()
			.BeEquivalentTo(new[] { 5, 6, 7, 6, 7, 8, 7, 8, 9 });

		[Fact]
		public async Task FromAsyncAndEnumerable()
			=>
			(
				await
				(
					from a in new[] { 1, 2, 3 }.AsAsyncEnumerable()
					from b in new[] { 4, 5, 6 }
					select a + b
				)
				.AsEnumerable()
			)
			.Should()
			.BeEquivalentTo(new[] { 5, 6, 7, 6, 7, 8, 7, 8, 9 });

		[Fact]
		public async Task FromAsyncAndTaskEnumerable()
			=>
			(
				await
				(
					from a in new[] { 1, 2, 3 }.AsAsyncEnumerable()
					from b in Task.FromResult(new[] { 4, 5, 6 }).AsEnumerable()
					select a + b
				)
				.AsEnumerable()
			)
			.Should()
			.BeEquivalentTo(new[] { 5, 6, 7, 6, 7, 8, 7, 8, 9 });
	}
}
