using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
    public class ElementAtOrDefaultTests
	{
		[Fact]
		public async Task ElementAtEmpty()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.ElementAtOrDefault(0)
				)
				.Should()
				.Be(0);

		[Fact]
		public async Task ElementAtOutOfRange()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.ElementAtOrDefault(5)
				)
				.Should()
				.Be(0);

		[Fact]
		public async Task ElementAtInRange()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.ElementAtOrDefault(1)
				)
				.Should()
				.Be(2);
	}
}
