namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IOrderedEnumerable<TSource>> ThenBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		=> (await source).ThenBy(keySelector, comparer);

	public static async Task<IOrderedEnumerable<TSource>> ThenBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).ThenBy(keySelector);
}
