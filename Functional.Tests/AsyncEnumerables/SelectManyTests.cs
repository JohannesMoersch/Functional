using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
	public class SelectManyTests
	{
		[Fact]
		public async Task SelectManyEmptyOuter()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int[]>()).AsEnumerable())
					.SelectMany(a => a)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new int[0]);

		[Fact]
		public async Task SelectManyInnerEmpty()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { Array.Empty<int>(), Array.Empty<int>() }).AsEnumerable())
					.SelectMany(a => a)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new int[0]);

		[Fact]
		public async Task SelectManyInnerMixed()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { new[] { 1, 2, 3 }, Array.Empty<int>(), new[] { 4, 5, 6 } }).AsEnumerable())
					.SelectMany(a => a)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 2, 3, 4, 5, 6 });

		[Fact]
		public async Task SelectManyInnerAsync()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable().AsAsyncEnumerable(), Array.Empty<int>().AsAsyncEnumerable(), Task.FromResult(new[] { 4, 5, 6 }).AsEnumerable().AsAsyncEnumerable() }).AsEnumerable())
					.SelectMany(a => a)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 2, 3, 4, 5, 6 });
	}
}
