using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.Options
{
	public class OptionLinqSyntaxTests
	{
		[Fact]
		public Task OptionEnumerableAsyncSelect()
			=>
			(
				from num in new[] { 1, 2, 3 }
				from value in Option.Some(num)
				select Task.FromResult(value)
			)
			.WhereSome()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task OptionEnumerableEnumerableAsyncSelect()
			=>
			(
				from num in new[] { 1, 2, 3 }
				from other in new[] { 1, 2 }
				from value in Option.Some(num * other)
				select Task.FromResult(value)
			)
			.WhereSome()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 2, 4, 3, 6 });

		[Fact]
		public Task OptionAsyncEnumerableAsyncSelect()
			=>
			(
				from num in new[] { 1, 2, 3 }.AsAsyncEnumerable()
				from value in Option.Some(num)
				select Task.FromResult(num)
			)
			.WhereSome()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task OptionAsyncEnumerableEnumerableAsyncSelect()
			=>
			(
				from num in new[] { 1, 2, 3 }.AsAsyncEnumerable()
				from other in new[] { 1, 2 }
				from value in Option.Some(num * other)
				select Task.FromResult(value)
			)
			.WhereSome()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 2, 4, 3, 6 });
	}
}
