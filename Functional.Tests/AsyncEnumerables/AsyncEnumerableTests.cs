using FluentAssertions;

namespace Functional.Tests.AsyncEnumerables;

public class AsyncEnumerableTests
{
	[Fact]
	public Task CreateFromEnumerable()
		=> AsyncEnumerable
			.Create(GetEnumerable())
			.Should()
			.BeEquivalentTo(GetEnumerable());

	[Fact]
	public Task CreateFromTaskEnumerable()
		=> AsyncEnumerable
			.Create(GetTaskEnumerable())
			.Should()
			.BeEquivalentTo(GetEnumerable());

	[Fact]
	public Task CreateFromTaskOrderedEnumerable()
		=> AsyncEnumerable
			.Create(GetTaskOrderedEnumerable())
			.Should()
			.BeEquivalentTo(GetOrderedEnumerable());

	[Fact]
	public Task CreateFromTaskAsyncEnumerable()
		=> AsyncEnumerable
			.Create(GetTaskAsyncEnumerable())
			.Should()
			.BeEquivalentTo(GetEnumerable());

	[Fact]
	public async Task CreateFromFuncEnumerable()
	{
		int count = 0;
		var enumerable = AsyncEnumerable.Create(() => { ++count; return GetEnumerable(); });

		await enumerable.Should().BeEquivalentTo(GetEnumerable());
		await enumerable.Should().BeEquivalentTo(GetEnumerable());
		count.Should().Be(2);
	}

	[Fact]
	public async Task CreateFromFuncTaskEnumerable()
	{
		int count = 0;
		var enumerable = AsyncEnumerable.Create(() => { ++count; return GetTaskEnumerable(); });

		await enumerable.Should().BeEquivalentTo(GetEnumerable());
		await enumerable.Should().BeEquivalentTo(GetEnumerable());
		count.Should().Be(2);
	}

	[Fact]
	public async Task CreateFromFuncTaskOrderedEnumerable()
	{
		int count = 0;
		var enumerable = AsyncEnumerable.Create(() => { ++count; return GetTaskOrderedEnumerable(); });

		await enumerable.Should().BeEquivalentTo(GetEnumerable());
		await enumerable.Should().BeEquivalentTo(GetEnumerable());
		count.Should().Be(2);
	}

	[Fact]
	public async Task CreateFromFuncAsyncEnumerable()
	{
		int count = 0;
		var enumerable = AsyncEnumerable.Create(() => { ++count; return GetAsyncEnumerable(); });

		await enumerable.Should().BeEquivalentTo(GetEnumerable());
		await enumerable.Should().BeEquivalentTo(GetEnumerable());
		count.Should().Be(2);
	}

	[Fact]
	public async Task CreateFromFuncTaskAsyncEnumerable()
	{
		int count = 0;
		var enumerable = AsyncEnumerable.Create(() => { ++count; return GetTaskAsyncEnumerable(); });

		await enumerable.Should().BeEquivalentTo(GetEnumerable());
		await enumerable.Should().BeEquivalentTo(GetEnumerable());
		count.Should().Be(2);
	}

	private IEnumerable<int> GetEnumerable()
		=> new[] { 2, 1, 3 };

	private IOrderedEnumerable<int> GetOrderedEnumerable()
		=> GetEnumerable().OrderBy(i => i);

	private async IAsyncEnumerable<int> GetAsyncEnumerable()
	{
		await Task.CompletedTask;
		yield return 1;
		yield return 2;
		yield return 3;
	}

	private Task<IEnumerable<int>> GetTaskEnumerable()
		=> Task.FromResult(GetEnumerable());

	private Task<IOrderedEnumerable<int>> GetTaskOrderedEnumerable()
		=> Task.FromResult(GetOrderedEnumerable());

	private Task<IAsyncEnumerable<int>> GetTaskAsyncEnumerable()
		=> Task.FromResult(GetAsyncEnumerable());
}
