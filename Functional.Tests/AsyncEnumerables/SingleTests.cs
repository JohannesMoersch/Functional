using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
	public class SingleTests
    {
		[Fact]
		public async Task SingleEmpty()
			=> await Assert
				.ThrowsAsync<InvalidOperationException>(() =>
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.Single()
				);

		[Fact]
		public async Task SingleEmptyWithPredicate()
			=> await Assert
				.ThrowsAsync<InvalidOperationException>(() =>
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.Single(i => i == 0)
				);

		[Fact]
		public async Task SingleWhereNoneMatchesPredicate()
			=> await Assert
				.ThrowsAsync<InvalidOperationException>(() =>
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Single(i => i == 0)
				);

		[Fact]
		public async Task SingleWithOneValue()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1 }).AsEnumerable())
					.Single()
				)
				.Should()
				.Be(1);

		[Fact]
		public async Task SingleWithOneValueMatchingPredicate()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Single(i => i % 2 == 0)
				)
				.Should()
				.Be(2);

		[Fact]
		public async Task SingleWithTwoValues()
			=> await Assert
				.ThrowsAsync<InvalidOperationException>(() =>
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2 }).AsEnumerable())
					.Single()
				);

		[Fact]
		public async Task SingleWithTwoValuesMatchingPredicate()
			=> await Assert
				.ThrowsAsync<InvalidOperationException>(() =>
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Single(i => i % 2 == 1)
				);
	}
}
