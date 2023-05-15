namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<TSource?> MaxBy<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).MaxBy(keySelector);

	public static async Task<TSource?> MaxBy<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
		=> (await source).MaxBy(keySelector, comparer);

	public static async Task<TSource?> MaxBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).MaxBy(keySelector);

	public static async Task<TSource?> MaxBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
		=> (await source).MaxBy(keySelector, comparer);

	public static async Task<TSource?> MaxBy<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		=> (await source.AsEnumerable()).MaxBy(keySelector);

	public static async Task<TSource?> MaxBy<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
		=> (await source.AsEnumerable()).MaxBy(keySelector, comparer);
}
