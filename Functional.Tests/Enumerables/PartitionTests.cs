using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.Enumerables
{
	public class PartitionTests
	{
		private class Counter
		{
			public int Value { get; set; }
		}

		private IEnumerable<int> CreateEnumerable(Counter counter)
		{
			++counter.Value;
			yield return 1;
			++counter.Value;
			yield return 2;
			++counter.Value;
			yield return 3;
		}

		[Fact]
		public void PartitionEnumerableIsPartiallyEvaluated()
		{
			var counter = new Counter();
			var (matches, nonMatches) = CreateEnumerable(counter).Partition(i => i % 2 == 0);

			matches.Take(1).Should().BeEquivalentTo(new[] { 2 });
			nonMatches.Take(1).Should().BeEquivalentTo(new[] { 1 });
			counter.Value.Should().Be(2);
		}

		[Fact]
		public void PartitionEnumerableIsEvaluatedOnlyOnce()
		{
			var counter = new Counter();
			var (matches, nonMatches) = CreateEnumerable(counter).Partition(i => i % 2 == 0);

			matches.Should().BeEquivalentTo(new[] { 2 });
			matches.Should().BeEquivalentTo(new[] { 2 });
			counter.Value.Should().Be(3);
		}

		[Fact]
		public void PartitionEnumerablesCanBeEvaluatedMultipleTimes()
		{
			var (matches, nonMatches) = new[] { 1, 2, 3, 4, 5 }.Partition(i => i % 2 == 0);

			matches.Should().BeEquivalentTo(new[] { 2, 4 });
			nonMatches.Should().BeEquivalentTo(new[] { 1, 3, 5 });
			matches.Should().BeEquivalentTo(new[] { 2, 4 });
			nonMatches.Should().BeEquivalentTo(new[] { 1, 3, 5 });
		}

		[Fact]
		public void EnumerablePartitionEmpty()
		{
			var (matches, nonMatches) = Array.Empty<int>().Partition(i => i % 2 == 0);

			matches.Should().BeEquivalentTo(Array.Empty<int>());
			nonMatches.Should().BeEquivalentTo(Array.Empty<int>());
		}

		[Fact]
		public void EnumerablePartitionSplit()
		{
			var (matches, nonMatches) = new[] { 1, 2, 3, 4, 5 }.Partition(i => i % 2 == 0);

			matches.Should().BeEquivalentTo(new[] { 2, 4 });
			nonMatches.Should().BeEquivalentTo(new[] { 1, 3, 5 });
		}

		[Fact]
		public void EnumerablePartitionAllMatches()
		{
			var (matches, nonMatches) = new[] { 1, 2, 3, 4, 5 }.Partition(_ => true);

			matches.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
			nonMatches.Should().BeEquivalentTo(Array.Empty<int>());
		}

		[Fact]
		public void EnumerablePartitionAllNonMatches()
		{
			var (matches, nonMatches) = new[] { 1, 2, 3, 4, 5 }.Partition(_ => false);

			matches.Should().BeEquivalentTo(Array.Empty<int>());
			nonMatches.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
		}

		[Fact]
		public async Task TaskEnumerablePartitionEmpty()
		{
			var (matches, nonMatches) = Task.FromResult(Array.Empty<int>()).AsEnumerable().Partition(i => i % 2 == 0);

			await matches.Should().BeEquivalentTo(Array.Empty<int>());
			await nonMatches.Should().BeEquivalentTo(Array.Empty<int>());
		}

		[Fact]
		public async Task TaskEnumerablePartitionSplit()
		{
			var (matches, nonMatches) = Task.FromResult(new[] { 1, 2, 3, 4, 5 }).AsEnumerable().Partition(i => i % 2 == 0);

			await matches.Should().BeEquivalentTo(new[] { 2, 4 });
			await nonMatches.Should().BeEquivalentTo(new[] { 1, 3, 5 });
		}

		[Fact]
		public async Task TaskEnumerablePartitionAllMatches()
		{
			var (matches, nonMatches) = Task.FromResult(new[] { 1, 2, 3, 4, 5 }).AsEnumerable().Partition(_ => true);

			await matches.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
			await nonMatches.Should().BeEquivalentTo(Array.Empty<int>());
		}

		[Fact]
		public async Task TaskEnumerablePartitionAllNonMatches()
		{
			var (matches, nonMatches) = Task.FromResult(new[] { 1, 2, 3, 4, 5 }).AsEnumerable().Partition(_ => false);

			await matches.Should().BeEquivalentTo(Array.Empty<int>());
			await nonMatches.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
		}

		[Fact]
		public async Task AsyncEnumerablePartitionEmpty()
		{
			var (matches, nonMatches) = Task.FromResult(Array.Empty<int>()).AsAsyncEnumerable().Partition(i => i % 2 == 0);

			await matches.Should().BeEquivalentTo(Array.Empty<int>());
			await nonMatches.Should().BeEquivalentTo(Array.Empty<int>());
		}

		[Fact]
		public async Task AsyncEnumerablePartitionSplit()
		{
			var (matches, nonMatches) = Task.FromResult(new[] { 1, 2, 3, 4, 5 }).AsAsyncEnumerable().Partition(i => i % 2 == 0);

			await matches.Should().BeEquivalentTo(new[] { 2, 4 });
			await nonMatches.Should().BeEquivalentTo(new[] { 1, 3, 5 });
		}

		[Fact]
		public async Task AsyncEnumerablePartitionAllMatches()
		{
			var (matches, nonMatches) = Task.FromResult(new[] { 1, 2, 3, 4, 5 }).AsAsyncEnumerable().Partition(_ => true);

			await matches.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
			await nonMatches.Should().BeEquivalentTo(Array.Empty<int>());
		}

		[Fact]
		public async Task AsyncEnumerablePartitionAllNonMatches()
		{
			var (matches, nonMatches) = Task.FromResult(new[] { 1, 2, 3, 4, 5 }).AsAsyncEnumerable().Partition(_ => false);

			await matches.Should().BeEquivalentTo(Array.Empty<int>());
			await nonMatches.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
		}

		[Fact]
		public async Task EnumerablePartitionAsyncEmpty()
		{
			var (matches, nonMatches) = Array.Empty<int>().PartitionAsync(i => Task.FromResult(i % 2 == 0));

			await matches.Should().BeEquivalentTo(Array.Empty<int>());
			await nonMatches.Should().BeEquivalentTo(Array.Empty<int>());
		}

		[Fact]
		public async Task EnumerablePartitionAsyncSplit()
		{
			var (matches, nonMatches) = new[] { 1, 2, 3, 4, 5 }.PartitionAsync(i => Task.FromResult(i % 2 == 0));

			await matches.Should().BeEquivalentTo(new[] { 2, 4 });
			await nonMatches.Should().BeEquivalentTo(new[] { 1, 3, 5 });
		}

		[Fact]
		public async Task EnumerablePartitionAsyncAllMatches()
		{
			var (matches, nonMatches) = new[] { 1, 2, 3, 4, 5 }.PartitionAsync(_ => Task.FromResult(true));

			await matches.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
			await nonMatches.Should().BeEquivalentTo(Array.Empty<int>());
		}

		[Fact]
		public async Task EnumerablePartitionAsyncAllNonMatches()
		{
			var (matches, nonMatches) = new[] { 1, 2, 3, 4, 5 }.PartitionAsync(_ => Task.FromResult(false));

			await matches.Should().BeEquivalentTo(Array.Empty<int>());
			await nonMatches.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
		}

		[Fact]
		public async Task TaskEnumerablePartitionAsyncEmpty()
		{
			var (matches, nonMatches) = Task.FromResult(Array.Empty<int>()).AsEnumerable().PartitionAsync(i => Task.FromResult(i % 2 == 0));

			await matches.Should().BeEquivalentTo(Array.Empty<int>());
			await nonMatches.Should().BeEquivalentTo(Array.Empty<int>());
		}

		[Fact]
		public async Task TaskEnumerablePartitionAsyncSplit()
		{
			var (matches, nonMatches) = Task.FromResult(new[] { 1, 2, 3, 4, 5 }).AsEnumerable().PartitionAsync(i => Task.FromResult(i % 2 == 0));

			await matches.Should().BeEquivalentTo(new[] { 2, 4 });
			await nonMatches.Should().BeEquivalentTo(new[] { 1, 3, 5 });
		}

		[Fact]
		public async Task TaskEnumerablePartitionAsyncAllMatches()
		{
			var (matches, nonMatches) = Task.FromResult(new[] { 1, 2, 3, 4, 5 }).AsEnumerable().PartitionAsync(_ => Task.FromResult(true));

			await matches.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
			await nonMatches.Should().BeEquivalentTo(Array.Empty<int>());
		}

		[Fact]
		public async Task TaskEnumerablePartitionAsyncAllNonMatches()
		{
			var (matches, nonMatches) = Task.FromResult(new[] { 1, 2, 3, 4, 5 }).AsEnumerable().PartitionAsync(_ => Task.FromResult(false));

			await matches.Should().BeEquivalentTo(Array.Empty<int>());
			await nonMatches.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
		}

		[Fact]
		public async Task AsyncEnumerablePartitionAsyncEmpty()
		{
			var (matches, nonMatches) = Task.FromResult(Array.Empty<int>()).AsAsyncEnumerable().PartitionAsync(i => Task.FromResult(i % 2 == 0));

			await matches.Should().BeEquivalentTo(Array.Empty<int>());
			await nonMatches.Should().BeEquivalentTo(Array.Empty<int>());
		}

		[Fact]
		public async Task AsyncEnumerablePartitionAsyncSplit()
		{
			var (matches, nonMatches) = Task.FromResult(new[] { 1, 2, 3, 4, 5 }).AsAsyncEnumerable().PartitionAsync(i => Task.FromResult(i % 2 == 0));

			await matches.Should().BeEquivalentTo(new[] { 2, 4 });
			await nonMatches.Should().BeEquivalentTo(new[] { 1, 3, 5 });
		}

		[Fact]
		public async Task AsyncEnumerablePartitionAsyncAllMatches()
		{
			var (matches, nonMatches) = Task.FromResult(new[] { 1, 2, 3, 4, 5 }).AsAsyncEnumerable().PartitionAsync(_ => Task.FromResult(true));

			await matches.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
			await nonMatches.Should().BeEquivalentTo(Array.Empty<int>());
		}

		[Fact]
		public async Task AsyncEnumerablePartitionAsyncAllNonMatches()
		{
			var (matches, nonMatches) = Task.FromResult(new[] { 1, 2, 3, 4, 5 }).AsAsyncEnumerable().PartitionAsync(_ => Task.FromResult(false));

			await matches.Should().BeEquivalentTo(Array.Empty<int>());
			await nonMatches.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
		}
	}
}
