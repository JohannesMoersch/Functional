namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).ToLookup(keySelector);

	public static async Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await source).ToLookup(keySelector, comparer);

	public static async Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		=> (await source).ToLookup(keySelector, elementSelector);

	public static async Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
		=> (await source).ToLookup(keySelector, elementSelector, comparer);

	public static async Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).ToLookup(keySelector);

	public static async Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await source).ToLookup(keySelector, comparer);

	public static async Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		=> (await source).ToLookup(keySelector, elementSelector);

	public static async Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
		=> (await source).ToLookup(keySelector, elementSelector, comparer);

	public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		=> source.AsEnumerable().ToLookup(keySelector);

	public static Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> source.AsEnumerable().ToLookup(keySelector, comparer);

	public static Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		=> source.AsEnumerable().ToLookup(keySelector, elementSelector);

	public static Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
		=> source.AsEnumerable().ToLookup(keySelector, elementSelector, comparer);
}
