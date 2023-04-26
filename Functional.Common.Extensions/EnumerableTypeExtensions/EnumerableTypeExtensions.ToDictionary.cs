using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		where TKey : notnull
		=> (await source).ToDictionary(keySelector);

	public static async Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		where TKey : notnull
		=> (await source).ToDictionary(keySelector, comparer);

	public static async Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		where TKey : notnull
		=> (await source).ToDictionary(keySelector, elementSelector);

	public static async Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
		where TKey : notnull
		=> (await source).ToDictionary(keySelector, elementSelector, comparer);

	public static async Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		where TKey : notnull
		=> (await source).ToDictionary(keySelector);

	public static async Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		where TKey : notnull
		=> (await source).ToDictionary(keySelector, comparer);

	public static async Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		where TKey : notnull
		=> (await source).ToDictionary(keySelector, elementSelector);

	public static async Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
		where TKey : notnull
		=> (await source).ToDictionary(keySelector, elementSelector, comparer);
}
