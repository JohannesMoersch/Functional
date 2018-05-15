using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
    public class WhereTests
    {
		[Fact]
		public async Task WhereOdd()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Where(i => i % 2 == 1)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 3 });

		[Fact]
		public async Task WhereIndexEven()
			=> (
					await
					AsyncEnumerable
					.Create(Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable())
					.Where((_, index) => index % 2 == 0)
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 3 });
	}
}
