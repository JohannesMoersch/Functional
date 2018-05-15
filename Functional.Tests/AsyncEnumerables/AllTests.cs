using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
    public class AllTests
    {
		[Fact]
		public async Task AllWhenEmpty()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.All(i => i == 0)
				)
				.Should()
				.BeTrue();

		[Fact]
		public async Task AllIsTrue()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 2, 4, 6 }).AsEnumerable())
					.All(i => i % 2 == 0)
				)
				.Should()
				.BeTrue();

		[Fact]
		public async Task AllIsFalse()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 2, 3, 4 }).AsEnumerable())
					.All(i => i % 2 == 0)
				)
				.Should()
				.BeFalse();
	}
}
