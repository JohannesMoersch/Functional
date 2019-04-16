using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
	public class ToCollectionTests
	{
		[Fact]
		public Task ToArray()
			=> Task
				.FromResult(new[] { 1, 2, 3 })
				.AsAsyncEnumerable()
				.ToArray()
				.Should()
				.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task ToList()
			=> Task
				.FromResult(new[] { 1, 2, 3 })
				.AsAsyncEnumerable()
				.ToList()
				.Should()
				.BeEquivalentTo(new[] { 1, 2, 3 });
	}
}
