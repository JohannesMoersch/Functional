namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<TSource?> MinBy<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).MinBy(keySelector);

	public static async Task<TSource?> MinBy<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
		=> (await source).MinBy(keySelector, comparer);

	public static async Task<TSource?> MinBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).MinBy(keySelector);

	public static async Task<TSource?> MinBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
		=> (await source).MinBy(keySelector, comparer);

	public static async Task<TSource?> MinBy<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		=> (await source.AsEnumerable()).MinBy(keySelector);

	public static async Task<TSource?> MinBy<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
		=> (await source.AsEnumerable()).MinBy(keySelector, comparer);
}
