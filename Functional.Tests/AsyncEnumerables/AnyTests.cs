using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
    public class AnyTests
    {
		[Fact]
		public async Task AnyWhenEmpty()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.Any()
				)
				.Should()
				.BeFalse();

		[Fact]
		public async Task AnyWhenNotEmpty()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Any()
				)
				.Should()
				.BeTrue();

		[Fact]
		public async Task AnyWhenEmptyWithPredicate()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.Any(i => i == 0)
				)
				.Should()
				.BeFalse();

		[Fact]
		public async Task AnyIsTrue()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Any(i => i % 2 == 0)
				)
				.Should()
				.BeTrue();

		[Fact]
		public async Task AnyIsFalse()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 3, 5 }).AsEnumerable())
					.Any(i => i % 2 == 0)
				)
				.Should()
				.BeFalse();
	}
}
