using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
	public class FirstOrDefaultTests
	{
		[Fact]
		public async Task FirstEmpty()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.FirstOrDefault()
				)
				.Should()
				.Be(0);

		[Fact]
		public async Task FirstEmptyWithPredicate()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.FirstOrDefault(i => i == 0)
				)
				.Should()
				.Be(0);

		[Fact]
		public async Task FirstWhereNoneMatchesPredicate()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.FirstOrDefault(i => i == 0)
				)
				.Should()
				.Be(0);

		[Fact]
		public async Task FirstWithValue()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.FirstOrDefault()
				)
				.Should()
				.Be(1);

		[Fact]
		public async Task FirstEven()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.FirstOrDefault(i => i % 2 == 0)
				)
				.Should()
				.Be(2);
	}
}
