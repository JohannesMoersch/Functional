namespace Functional;

public static partial class EnumerableExtensions
{
	public static IAsyncEnumerable<TSource> PickIntoAsync<TSource>(this IEnumerable<TSource> source, out IAsyncEnumerable<TSource> matches, Func<TSource, Task<bool>> predicate)
	{
		var partition = source.PartitionAsync(predicate);

		matches = partition.Matches;

		return partition.NonMatches;
	}

	public static IAsyncEnumerable<TSource> PickIntoAsync<TSource>(this Task<IEnumerable<TSource>> source, out IAsyncEnumerable<TSource> matches, Func<TSource, Task<bool>> predicate)
	{
		var partition = source.PartitionAsync(predicate);

		matches = partition.Matches;

		return partition.NonMatches;
	}

	public static IAsyncEnumerable<TSource> PickIntoAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, out IAsyncEnumerable<TSource> matches, Func<TSource, Task<bool>> predicate)
		=> source.AsEnumerable().PickIntoAsync(out matches, predicate);

	public static IAsyncEnumerable<TSource> PickIntoAsync<TSource>(this IAsyncEnumerable<TSource> source, out IAsyncEnumerable<TSource> matches, Func<TSource, Task<bool>> predicate)
	{
		var partition = source.PartitionAsync(predicate);

		matches = partition.Matches;

		return partition.NonMatches;
	}
}
