using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.Results
{
	public class OptionLinqSyntaxTests
	{
		[Fact]
		public Task ResultEnumerableAsyncSelect()
			=>
			(
				from num in new[] { 1, 2, 3 }
				from value in Result.Success<int, string>(num)
				select Task.FromResult(value)
			)
			.TakeUntilFailure()
			.AssertSuccess()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task ResultEnumerableEnumerableAsyncSelect()
			=>
			(
				from num in new[] { 1, 2, 3 }
				from other in new[] { 1, 2 }
				from value in Result.Success<int, string>(num * other)
				select Task.FromResult(value)
			)
			.TakeUntilFailure()
			.AssertSuccess()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 2, 4, 3, 6 });

		[Fact]
		public Task ResultAsyncEnumerableAsyncSelect()
			=>
			(
				from num in new[] { 1, 2, 3 }.AsAsyncEnumerable()
				from value in Result.Success<int, string>(num)
				select Task.FromResult(num)
			)
			.TakeUntilFailure()
			.AssertSuccess()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task ResultAsyncEnumerableEnumerableAsyncSelect()
			=>
			(
				from num in new[] { 1, 2, 3 }.AsAsyncEnumerable()
				from other in new[] { 1, 2 }
				from value in Result.Success<int, string>(num * other)
				select Task.FromResult(value)
			)
			.TakeUntilFailure()
			.AssertSuccess()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 2, 4, 3, 6 });
	}
}
