namespace Functional;

public static partial class FunctionalEnumerableExtensions
{
	public static ResultPartition<TSuccess, TFailure> Partition<TSuccess, TFailure>(this IEnumerable<Result<TSuccess, TFailure>> source)
		where TSuccess : notnull
		where TFailure : notnull
	{
		var values = new ReplayableEnumerable<(bool matches, Result<TSuccess, TFailure> value)>(source.Select(value => (value.Match(_ => true, _ => false), value)));

		return new ResultPartition<TSuccess, TFailure>
		(
			values.Where(set => set.matches).Select(set => set.value.Match(success => success, failure => throw new InvalidOperationException("Expected success!"))),
			values.Where(set => !set.matches).Select(set => set.value.Match(success => throw new InvalidOperationException("Expected failure!"), failure => failure))
		);
	}

	public static async Task<ResultPartition<TSuccess, TFailure>> Partition<TSuccess, TFailure>(this Task<IEnumerable<Result<TSuccess, TFailure>>> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await source).Partition();

	public static AsyncResultPartition<TSuccess, TFailure> Partition<TSuccess, TFailure>(this IAsyncEnumerable<Result<TSuccess, TFailure>> source)
		where TSuccess : notnull
		where TFailure : notnull
	{
		var values = new ReplayableAsyncEnumerable<(bool matches, Result<TSuccess, TFailure> value)>(source.Select(value => (value.Match(_ => true, _ => false), value)));

		return new AsyncResultPartition<TSuccess, TFailure>
		(
			values.Where(set => set.matches).Select(set => set.value.Match(success => success, failure => throw new InvalidOperationException("Expected success!"))),
			values.Where(set => !set.matches).Select(set => set.value.Match(success => throw new InvalidOperationException("Expected failure!"), failure => failure))
		);
	}
}
