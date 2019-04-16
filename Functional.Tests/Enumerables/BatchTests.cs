using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Enumerables
{
	public class BatchTests
	{
		[Fact]
		public void FullBatchesCorrectly()
			=> new[] { 1, 2, 3, 4, 5, 6 }
				.Batch(2)
				.Should()
				.BeEquivalentTo(new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5, 6 } });

		[Fact]
		public void PartialBatchesCorrectly()
			=> new[] { 1, 2, 3, 4, 5 }
				.Batch(2)
				.Should()
				.BeEquivalentTo(new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5 } });

		[Fact]
		public void MultipleEvaluationsSuccessful()
		{
			var batch = new[] { 1, 2, 3, 4 }.Batch(2).GetEnumerator();

			batch.MoveNext().Should().BeTrue();
			batch.Current.Should().BeEquivalentTo(new[] { 1, 2 });
			batch.MoveNext().Should().BeTrue();
			batch.Current.Should().BeEquivalentTo(new[] { 3, 4 });
			batch.MoveNext().Should().BeFalse();
			batch.Current.Should().BeNull();

			batch.Reset();

			batch.MoveNext().Should().BeTrue();
			batch.Current.Should().BeEquivalentTo(new[] { 1, 2 });
			batch.MoveNext().Should().BeTrue();
			batch.Current.Should().BeEquivalentTo(new[] { 3, 4 });
			batch.MoveNext().Should().BeFalse();
			batch.Current.Should().BeNull();
		}

		[Fact]
		public Task TaskFullBatchesCorrectly()
			=> Task.FromResult(new[] { 1, 2, 3, 4, 5, 6 })
				.AsEnumerable()
				.Batch(2)
				.Should()
				.BeEquivalentTo(new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5, 6 } });

		[Fact]
		public Task TaskPartialBatchesCorrectly()
			=> Task.FromResult(new[] { 1, 2, 3, 4, 5 })
				.AsEnumerable()
				.Batch(2)
				.Should()
				.BeEquivalentTo(new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5 } });
	}
}
