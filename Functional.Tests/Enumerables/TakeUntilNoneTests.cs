using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Enumerables
{
	public class TakeUntilNoneTests
	{
		[Fact]
		public void EnumerableTakeUntilNoneSomes()
			=> new[]
			{
				Option.Some(1),
				Option.Some(2),
				Option.Some(3)
			}
			.TakeUntilNone()
			.AssertSome()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public void EnumerableTakeUntilNoneNones()
			=> new[]
			{
				Option.None<int>(),
				Option.Some(2),
				Option.None<int>()
			}
			.TakeUntilNone()
			.AssertNone();

		[Fact]
		public Task TaskOfEnumerableTakeUntilNoneSomes()
			=> Task
			.FromResult
			(
				new[]
				{
					Option.Some(1),
					Option.Some(2),
					Option.Some(3)
				}
				.AsEnumerable()
			)
			.TakeUntilNone()
			.AssertSome()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task TaskOfEnumerableTakeUntilNoneNones()
			=> Task
			.FromResult
			(
				new[]
				{
					Option.None<int>(),
					Option.Some(2),
					Option.None<int>()
				}
				.AsEnumerable()
			)
			.TakeUntilNone()
			.AssertNone();

		[Fact]
		public Task AsyncEnumerableTakeUntilNoneSomes()
			=> new[]
			{
				Task.FromResult(Option.Some(1)),
				Task.FromResult(Option.Some(2)),
				Task.FromResult(Option.Some(3))
			}
			.AsAsyncEnumerable()
			.TakeUntilNone()
			.AssertSome()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task AsyncEnumerableTakeUntilNoneNones()
			=> new[]
			{
				Task.FromResult(Option.None<int>()),
				Task.FromResult(Option.Some(2)),
				Task.FromResult(Option.None<int>())
			}
			.AsAsyncEnumerable()
			.TakeUntilNone()
			.AssertNone();
	}
}
