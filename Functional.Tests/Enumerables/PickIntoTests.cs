using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Enumerables
{
	public class PickIntoTests
	{
		[Fact]
		public void EnumerablePickInto()
		{
			new[] { 1, 2, 3, 4, 5 }
				.PickInto(out var evens, i => i % 2 == 0)
				.Should()
				.BeEquivalentTo(new[] { 1, 3, 5 });

			evens.Should().BeEquivalentTo(new[] { 2, 4 });
		}

		[Fact]
		public async Task TaskEnumerablePickInto()
		{
			await Task.FromResult(new[] { 1, 2, 3, 4, 5 })
				.AsEnumerable()
				.PickInto(out var evens, i => i % 2 == 0)
				.Should()
				.BeEquivalentTo(new[] { 1, 3, 5 });

			await evens.Should().BeEquivalentTo(new[] { 2, 4 });
		}

		[Fact]
		public async Task AsyncEnumerablePickInto()
		{
			await Task.FromResult(new[] { 1, 2, 3, 4, 5 })
				.AsAsyncEnumerable()
				.PickInto(out var evens, i => i % 2 == 0)
				.Should()
				.BeEquivalentTo(new[] { 1, 3, 5 });

			await evens.Should().BeEquivalentTo(new[] { 2, 4 });
		}
	}
}
