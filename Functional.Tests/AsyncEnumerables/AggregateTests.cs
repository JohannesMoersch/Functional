using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
    public class AggregateTests
    {
		[Fact]
		public async Task AggregateEmpty()
			=> await Assert
				.ThrowsAsync<InvalidOperationException>(() =>
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.Aggregate((i1, i2) => i1 + i2)
				);

		[Fact]
		public async Task AggregateEmptyWithSeed()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.Aggregate(10, (i1, i2) => i1 + i2)
				)
				.Should()
				.Be(10);

		[Fact]
		public async Task AggregateEmptyWithSeedAndResultSelector()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.Aggregate(10, (i1, i2) => i1 + i2, i => i * 2.0f)
				)
				.Should()
				.Be(20.0f);

		[Fact]
		public async Task AggregateValues()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Aggregate((i1, i2) => i1 + i2)
				)
				.Should()
				.Be(6);

		[Fact]
		public async Task AggregateValuesWithSeed()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Aggregate(10, (i1, i2) => i1 + i2)
				)
				.Should()
				.Be(16);

		[Fact]
		public async Task AggregateValuesWithSeedAndResultSelector()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Aggregate(10, (i1, i2) => i1 + i2, i => i * 2.0f)
				)
				.Should()
				.Be(32.0f);
	}
}
