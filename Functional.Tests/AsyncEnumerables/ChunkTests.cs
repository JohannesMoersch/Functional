using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
	public class ChunkTests
	{
		[Fact]
		public Task FullChunksCorrectly()
			=> Task
				.FromResult(new[] { 1, 2, 3, 4, 5, 6 })
				.AsAsyncEnumerable()
				.Chunk(2)
				.Should()
				.BeEquivalentTo(new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5, 6 } });

		[Fact]
		public Task PartialChunksCorrectly()
			=> Task
				.FromResult(new[] { 1, 2, 3, 4, 5 })
				.AsAsyncEnumerable()
				.Chunk(2)
				.Should()
				.BeEquivalentTo(new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5 } });
	}
}