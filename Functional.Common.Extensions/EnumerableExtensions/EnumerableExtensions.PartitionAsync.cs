namespace Functional;

public static partial class EnumerableExtensions
{
	public static AsyncPartition<T> PartitionAsync<T>(this IEnumerable<T> source, Func<T, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().PartitionAsync(predicate);

	public static AsyncPartition<T> PartitionAsync<T>(this Task<IEnumerable<T>> source, Func<T, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().PartitionAsync(predicate);

	public static AsyncPartition<T> PartitionAsync<T>(this Task<IOrderedEnumerable<T>> source, Func<T, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().PartitionAsync(predicate);

	public static AsyncPartition<T> PartitionAsync<T>(this IAsyncEnumerable<T> source, Func<T, Task<bool>> predicate)
	{
		if (predicate == null)
			throw new ArgumentNullException(nameof(predicate));

		var values = source.SelectAsync(async value => (matches: await predicate.Invoke(value), value)).Cached();

		return new AsyncPartition<T>
		(
			values.Where(set => set.matches).Select(set => set.value),
			values.Where(set => !set.matches).Select(set => set.value)
		);
	}
}
