using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
    public class FirstTests
    {
		[Fact]
		public async Task FirstEmpty()
			=> await Assert
				.ThrowsAsync<InvalidOperationException>(() =>
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.First()
				);

		[Fact]
		public async Task FirstEmptyWithPredicate()
			=> await Assert
				.ThrowsAsync<InvalidOperationException>(() =>
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.First(i => i == 0)
				);

		[Fact]
		public async Task FirstWhereNoneMatchesPredicate()
			=> await Assert
				.ThrowsAsync<InvalidOperationException>(() =>
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.First(i => i == 0)
				);

		[Fact]
		public async Task FirstWithValue()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.First()
				)
				.Should()
				.Be(1);

		[Fact]
		public async Task FirstEven()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.First(i => i % 2 == 0)
				)
				.Should()
				.Be(2);
	}
}
