using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
	public class ZipTests
	{
		[Fact]
		public async Task ZipEmptyToEmpty()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.Zip(Task.FromResult(Array.Empty<int>()).AsEnumerable(), (i1, i2) => i1 + i2)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public async Task ZipItemsToEmpty()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.Zip(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable(), (i1, i2) => i1 + i2)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public async Task ZipEmptyToItems()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Zip(Task.FromResult(Array.Empty<int>()).AsEnumerable(), (i1, i2) => i1 + i2)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public async Task ZipItemsToItems()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Zip(Task.FromResult(new[] { 4, 5, 6 }).AsEnumerable(), (i1, i2) => i1 + i2)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 5, 7, 9 });

		[Fact]
		public async Task ZipLongerToShorter()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2 }).AsEnumerable())
					.Zip(Task.FromResult(new[] { 4, 5, 6 }).AsEnumerable(), (i1, i2) => i1 + i2)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 5, 7 });

		[Fact]
		public async Task ZipShorterToLonger()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Zip(Task.FromResult(new[] { 4, 5 }).AsEnumerable(), (i1, i2) => i1 + i2)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 5, 7 });
	}
}
