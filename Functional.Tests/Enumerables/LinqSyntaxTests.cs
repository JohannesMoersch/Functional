using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.Enumerables
{
	public class LinqSyntaxTests
	{
		[Fact]
		public Task EnumerableAsyncSelect()
			=>
			(
				from num in new[] { 1, 2, 3 }
				select Task.FromResult(num)
			)
			.ToArray()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task EnumerableEnumerableAsyncSelect()
			=>
			(
				from num in new[] { 1, 2, 3 }
				from other in new[] { 1, 2 }
				select Task.FromResult(num * other)
			)
			.ToArray()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 2, 4, 3, 6 });

		[Fact]
		public Task AsyncEnumerableAsyncSelect()
			=>
			(
				from num in new[] { 1, 2, 3 }.AsAsyncEnumerable()
				select Task.FromResult(num)
			)
			.ToArray()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task AsyncEnumerableEnumerableAsyncSelect()
			=>
			(
				from num in new[] { 1, 2, 3 }.AsAsyncEnumerable()
				from other in new[] { 1, 2 }
				select Task.FromResult(num * other)
			)
			.ToArray()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 2, 4, 3, 6 });
	}
}
