using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.Results
{
	public class TakeAllTests
	{
		[Fact]
		public void EnumerableTakeAllSuccesses()
			=> new[]
			{
				Result.Success<int, string>(1),
				Result.Success<int, string>(2),
				Result.Success<int, string>(3)
			}
			.TakeAll()
			.AssertSuccess()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public void EnumerableTakeAllFailures()
			=> new[]
			{
				Result.Failure<int, string>("a"),
				Result.Success<int, string>(2),
				Result.Failure<int, string>("c")
			}
			.TakeAll()
			.AssertFailure()
			.Should()
			.BeEquivalentTo(new[] { "a", "c" });

		[Fact]
		public Task TaskOfEnumerableTakeAllSuccesses()
			=> Task
			.FromResult
			(
				new[]
				{
					Result.Success<int, string>(1),
					Result.Success<int, string>(2),
					Result.Success<int, string>(3)
				}
				.AsEnumerable()
			)
			.TakeAll()
			.AssertSuccess()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task TaskOfEnumerableTakeAllFailures()
			=> Task
			.FromResult
			(
				new[]
				{
					Result.Failure<int, string>("a"),
					Result.Success<int, string>(2),
					Result.Failure<int, string>("c")
				}
				.AsEnumerable()
			)
			.TakeAll()
			.AssertFailure()
			.Should()
			.BeEquivalentTo(new[] { "a", "c" });

		[Fact]
		public Task AsyncEnumerableTakeAllSuccesses()
			=> new[]
			{
				Task.FromResult(Result.Success<int, string>(1)),
				Task.FromResult(Result.Success<int, string>(2)),
				Task.FromResult(Result.Success<int, string>(3))
			}
			.AsAsyncEnumerable()
			.TakeAll()
			.AssertSuccess()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task AsyncEnumerableTakeAllFailures()
			=> new[]
			{
				Task.FromResult(Result.Failure<int, string>("a")),
				Task.FromResult(Result.Success<int, string>(2)),
				Task.FromResult(Result.Failure<int, string>("c"))
			}
			.AsAsyncEnumerable()
			.TakeAll()
			.AssertFailure()
			.Should()
			.BeEquivalentTo(new[] { "a", "c" });
	}
}
