using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
    public class ElementAtTests
    {
		[Fact]
		public async Task ElementAtEmpty()
			=> await Assert
				.ThrowsAsync<ArgumentOutOfRangeException>(() =>
					AsyncEnumerable
					.Create(Task.FromResult(Array.Empty<int>()).AsEnumerable())
					.ElementAt(0)
				);

		[Fact]
		public async Task ElementAtOutOfRange()
			=> await Assert
				.ThrowsAsync<ArgumentOutOfRangeException>(() =>
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.ElementAt(5)
				);

		[Fact]
		public async Task ElementAtInRange()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.ElementAt(1)
				)
				.Should()
				.Be(2);
	}
}
