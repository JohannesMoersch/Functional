namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> DistinctBy<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).DistinctBy(keySelector);

	public static async Task<IEnumerable<TSource>> DistinctBy<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await source).DistinctBy(keySelector, comparer);

	public static async Task<IEnumerable<TSource>> DistinctBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).DistinctBy(keySelector);

	public static async Task<IEnumerable<TSource>> DistinctBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await source).DistinctBy(keySelector, comparer);

	public static IAsyncEnumerable<TSource> DistinctBy<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		=> source.DistinctBy(keySelector, null);

	public static async IAsyncEnumerable<TSource> DistinctBy<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
	{
		if (keySelector is null) throw new ArgumentNullException(nameof(keySelector));

		var set = new HashSet<TKey>(comparer);

		await foreach (var item in source)
		{
			if (set.Add(keySelector.Invoke(item)))
				yield return item;
		}
	}
}
