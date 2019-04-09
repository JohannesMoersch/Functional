using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Functional.Tests.Enumerables
{
	public class PartitionTests
	{
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
