using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		public void PartitionSplit()
		{
			var (matches, nonMatches) = new[] { 1, 2, 3, 4, 5 }.Partition(i => i % 2 == 0);

			matches.Should().BeEquivalentTo(new[] { 2, 4 });
			nonMatches.Should().BeEquivalentTo(new[] { 1, 3, 5 });
		}

		[Fact]
		public void PartitionAllMatches()
		{
			var (matches, nonMatches) = new[] { 1, 2, 3, 4, 5 }.Partition(_ => true);

			matches.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
			nonMatches.Should().BeEquivalentTo(Array.Empty<int>());
		}

		[Fact]
		public void PartitionAllNonMatches()
		{
			var (matches, nonMatches) = new[] { 1, 2, 3, 4, 5 }.Partition(_ => false);

			matches.Should().BeEquivalentTo(Array.Empty<int>());
			nonMatches.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
		}
	}
}
