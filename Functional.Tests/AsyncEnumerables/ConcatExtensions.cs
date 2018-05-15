using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
	public class ConcatExtensions
	{
		[Fact]
		public async Task ConcatEmptyToEmpty()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.Concat(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public async Task ConcatItemsToEmpty()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.Concat(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public async Task ConcatEmptyToItems()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Concat(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public async Task ConcatItemsToItems()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Concat(Task.FromResult(new[] { 4, 5, 6 }).AsEnumerable())
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 2, 3, 4, 5, 6 });
	}
}
