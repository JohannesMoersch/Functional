namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IOrderedEnumerable<TSource>> OrderBy<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		=> (await source).OrderBy(keySelector, comparer);

	public static async Task<IOrderedEnumerable<TSource>> OrderBy<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).OrderBy(keySelector);

	public static async Task<IOrderedEnumerable<TSource>> OrderBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		=> (await source).OrderBy(keySelector, comparer);

	public static async Task<IOrderedEnumerable<TSource>> OrderBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).OrderBy(keySelector);

	public static async Task<IOrderedEnumerable<TSource>> OrderBy<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		=> (await source.AsEnumerable()).OrderBy(keySelector, comparer);

	public static async Task<IOrderedEnumerable<TSource>> OrderBy<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		=> (await source.AsEnumerable()).OrderBy(keySelector);
}
