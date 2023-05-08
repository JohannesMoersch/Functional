namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IOrderedEnumerable<TSource>> ThenByDescending<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).ThenByDescending(keySelector);

	public static async Task<IOrderedEnumerable<TSource>> ThenByDescending<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		=> (await source).ThenByDescending(keySelector, comparer);
}
