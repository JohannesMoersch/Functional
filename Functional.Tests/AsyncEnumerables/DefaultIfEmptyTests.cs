using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
	public class DefaultIfEmptyTests
    {
		[Fact]
		public async Task DefaultWhenEmpty()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.DefaultIfEmpty()
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 0 });

		[Fact]
		public async Task DefaultWithSpecifiedValueWhenEmpty()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.DefaultIfEmpty(10)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 10 });

		[Fact]
		public async Task DefaultWithSingleValue()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.DefaultIfEmpty()
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public async Task DefaultWithSpecifiedValueWithSingleValue()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1 }).AsEnumerable())
					.DefaultIfEmpty(10)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1 });

		[Fact]
		public async Task DefaultWithTwoValues()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2 }).AsEnumerable())
					.DefaultIfEmpty()
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 2 });

		[Fact]
		public async Task DefaultWithSpecifiedValueWithTwoValues()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2 }).AsEnumerable())
					.DefaultIfEmpty(10)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 2 });
	}
}
