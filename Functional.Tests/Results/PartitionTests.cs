using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Results;

public class PartitionTests
{
	[Fact]
	public void EnumerablePartitionAllSuccesses()
	{
		const int ITEM1 = 1;
		const int ITEM2 = 2;
		const int ITEM3 = 3;

		var (successCollection, failureCollection) = new[] {
			Result.Success<int, string>(ITEM1),
			Result.Success<int, string>(ITEM2),
			Result.Success<int, string>(ITEM3)
		}.Partition();

		successCollection.Should().BeEquivalentTo(ITEM1, ITEM2, ITEM3);
		failureCollection.Should().BeEmpty();
	}

	[Fact]
	public void EnumerablePartitionAllFailures()
	{
		const string ERROR1 = "ONE";
		const string ERROR2 = "TWO";
		const string ERROR3 = "THREE";

		var (successCollection, failureCollection) = new[] {
			Result.Failure<int, string>(ERROR1),
			Result.Failure<int, string>(ERROR2),
			Result.Failure<int, string>(ERROR3)
		}.Partition();

		successCollection.Should().BeEmpty();
		failureCollection.Should().BeEquivalentTo(ERROR1, ERROR2, ERROR3);
	}

	[Fact]
	public void EnumerablePartitionSomeSuccessesSomeFailures()
	{
		const int ITEM1 = 1;
		const int ITEM2 = 2;
		const int ITEM3 = 3;
		const string ERROR1 = "ONE";
		const string ERROR2 = "TWO";
		const string ERROR3 = "THREE";

		var (successCollection, failureCollection) = new[] {
			Result.Success<int, string>(ITEM1),
			Result.Success<int, string>(ITEM2),
			Result.Failure<int, string>(ERROR1),
			Result.Failure<int, string>(ERROR2),
			Result.Success<int, string>(ITEM3),
			Result.Failure<int, string>(ERROR3)
		}.Partition();

		successCollection.Should().BeEquivalentTo(ITEM1, ITEM2, ITEM3);
		failureCollection.Should().BeEquivalentTo(ERROR1, ERROR2, ERROR3);
	}

	[Fact]
	public async Task TaskOfEnumerablePartitionAllSuccesses()
	{
		const int ITEM1 = 1;
		const int ITEM2 = 2;
		const int ITEM3 = 3;

		var (successCollection, failureCollection) = await Task.FromResult(new[] {
			Result.Success<int, string>(ITEM1),
			Result.Success<int, string>(ITEM2),
			Result.Success<int, string>(ITEM3)
		}.AsEnumerable()).Partition();

		successCollection.Should().BeEquivalentTo(ITEM1, ITEM2, ITEM3);
		failureCollection.Should().BeEmpty();
	}

	[Fact]
	public async Task TaskOfEnumerablePartitionAllFailures()
	{
		const string ERROR1 = "ONE";
		const string ERROR2 = "TWO";
		const string ERROR3 = "THREE";

		var (successCollection, failureCollection) = await Task.FromResult(new[] {
			Result.Failure<int, string>(ERROR1),
			Result.Failure<int, string>(ERROR2),
			Result.Failure<int, string>(ERROR3)
		}.AsEnumerable()).Partition();

		successCollection.Should().BeEmpty();
		failureCollection.Should().BeEquivalentTo(ERROR1, ERROR2, ERROR3);
	}

	[Fact]
	public async Task TaskOfEnumerablePartitionSomeSuccessesSomeFailures()
	{
		const int ITEM1 = 1;
		const int ITEM2 = 2;
		const int ITEM3 = 3;
		const string ERROR1 = "ONE";
		const string ERROR2 = "TWO";
		const string ERROR3 = "THREE";

		var (successCollection, failureCollection) = await Task.FromResult(new[] {
			Result.Success<int, string>(ITEM1),
			Result.Success<int, string>(ITEM2),
			Result.Failure<int, string>(ERROR1),
			Result.Failure<int, string>(ERROR2),
			Result.Success<int, string>(ITEM3),
			Result.Failure<int, string>(ERROR3)
		}.AsEnumerable()).Partition();

		successCollection.Should().BeEquivalentTo(ITEM1, ITEM2, ITEM3);
		failureCollection.Should().BeEquivalentTo(ERROR1, ERROR2, ERROR3);
	}

	[Fact]
	public async Task EnumerableOfTasksPartitionAllSuccesses()
	{
		const int ITEM1 = 1;
		const int ITEM2 = 2;
		const int ITEM3 = 3;

		var (successCollection, failureCollection) = await new[] {
			Task.FromResult(Result.Success<int, string>(ITEM1)),
			Task.FromResult(Result.Success<int, string>(ITEM2)),
			Task.FromResult(Result.Success<int, string>(ITEM3))
		}.AsEnumerable().Partition();

		successCollection.Should().BeEquivalentTo(ITEM1, ITEM2, ITEM3);
		failureCollection.Should().BeEmpty();
	}

	[Fact]
	public async Task EnumerableOfTasksPartitionAllFailures()
	{
		const string ERROR1 = "ONE";
		const string ERROR2 = "TWO";
		const string ERROR3 = "THREE";

		var (successCollection, failureCollection) = await new[] {
			Task.FromResult(Result.Failure<int, string>(ERROR1)),
			Task.FromResult(Result.Failure<int, string>(ERROR2)),
			Task.FromResult(Result.Failure<int, string>(ERROR3))
		}.AsEnumerable().Partition();

		successCollection.Should().BeEmpty();
		failureCollection.Should().BeEquivalentTo(ERROR1, ERROR2, ERROR3);
	}

	[Fact]
	public async Task EnumerableOfTasksPartitionSomeSuccessesSomeFailures()
	{
		const int ITEM1 = 1;
		const int ITEM2 = 2;
		const int ITEM3 = 3;
		const string ERROR1 = "ONE";
		const string ERROR2 = "TWO";
		const string ERROR3 = "THREE";

		var (successCollection, failureCollection) = await new[] {
			Task.FromResult(Result.Success<int, string>(ITEM1)),
			Task.FromResult(Result.Success<int, string>(ITEM2)),
			Task.FromResult(Result.Failure<int, string>(ERROR1)),
			Task.FromResult(Result.Failure<int, string>(ERROR2)),
			Task.FromResult(Result.Success<int, string>(ITEM3)),
			Task.FromResult(Result.Failure<int, string>(ERROR3))
		}.Partition();

		successCollection.Should().BeEquivalentTo(ITEM1, ITEM2, ITEM3);
		failureCollection.Should().BeEquivalentTo(ERROR1, ERROR2, ERROR3);
	}
}