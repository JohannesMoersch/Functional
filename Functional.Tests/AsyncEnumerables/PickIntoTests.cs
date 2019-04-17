using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
	public class PickIntoTests
	{
		[Fact]
		public async Task EnumerablePickIntoAsync()
		{
			await new[] { 1, 2, 3, 4, 5 }
				.PickIntoAsync(out var evens, i => Task.FromResult(i % 2 == 0))
				.Should()
				.BeEquivalentTo(new[] { 1, 3, 5 });

			await evens.Should().BeEquivalentTo(new[] { 2, 4 });
		}

		[Fact]
		public async Task TaskEnumerablePickIntoAsync()
		{
			await Task.FromResult(new[] { 1, 2, 3, 4, 5 })
				.AsEnumerable()
				.PickIntoAsync(out var evens, i => Task.FromResult(i % 2 == 0))
				.Should()
				.BeEquivalentTo(new[] { 1, 3, 5 });

			await evens.Should().BeEquivalentTo(new[] { 2, 4 });
		}

		[Fact]
		public async Task AsyncEnumerablePickIntoAsync()
		{
			await Task.FromResult(new[] { 1, 2, 3, 4, 5 })
				.AsAsyncEnumerable()
				.PickIntoAsync(out var evens, i => Task.FromResult(i % 2 == 0))
				.Should()
				.BeEquivalentTo(new[] { 1, 3, 5 });

			await evens.Should().BeEquivalentTo(new[] { 2, 4 });
		}
	}
}
