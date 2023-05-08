using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).ToLookup(keySelector);

	public static async Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		=> (await source).ToLookup(keySelector, comparer);

	public static async Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		=> (await source).ToLookup(keySelector, elementSelector);

	public static async Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
		=> (await source).ToLookup(keySelector, elementSelector, comparer);

	public static async Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).ToLookup(keySelector);

	public static async Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		=> (await source).ToLookup(keySelector, comparer);

	public static async Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		=> (await source).ToLookup(keySelector, elementSelector);

	public static async Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
		=> (await source).ToLookup(keySelector, elementSelector, comparer);
}
