using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Enumerables
{
	public class TraverseTests
	{
		[Fact]
		public void EnumerableTraverseSomes()
			=> new[]
			{
				Option.Some(1),
				Option.Some(2),
				Option.Some(3)
			}
			.Traverse()
			.AssertSome()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public void EnumerableTraverseNones()
			=> new[]
			{
				Option.None<int>(),
				Option.Some(2),
				Option.None<int>()
			}
			.Traverse()
			.AssertNone();

		[Fact]
		public Task TaskOfEnumerableTraverseSomes()
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
			.Traverse()
			.AssertSome()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task TaskOfEnumerableTraverseNones()
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
			.Traverse()
			.AssertNone();

		[Fact]
		public Task EnumerableOfTasksTraverseSomes()
			=> new[]
			{
				Task.FromResult(Option.Some(1)),
				Task.FromResult(Option.Some(2)),
				Task.FromResult(Option.Some(3))
			}
			.Traverse()
			.AssertSome()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task EnumerableOfTasksTraverseNones()
			=> new[]
			{
				Task.FromResult(Option.None<int>()),
				Task.FromResult(Option.Some(2)),
				Task.FromResult(Option.None<int>())
			}
			.Traverse()
			.AssertNone();

		[Fact]
		public Task AsyncEnumerableTraverseSomes()
			=> new[]
			{
				Task.FromResult(Option.Some(1)),
				Task.FromResult(Option.Some(2)),
				Task.FromResult(Option.Some(3))
			}
			.AsAsyncEnumerable()
			.Traverse()
			.AssertSome()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task AsyncEnumerableTraverseNones()
			=> new[]
			{
				Task.FromResult(Option.None<int>()),
				Task.FromResult(Option.Some(2)),
				Task.FromResult(Option.None<int>())
			}
			.AsAsyncEnumerable()
			.Traverse()
			.AssertNone();
	}
}
