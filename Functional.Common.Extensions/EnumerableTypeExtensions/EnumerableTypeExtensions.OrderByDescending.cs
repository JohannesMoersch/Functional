using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IOrderedEnumerable<TSource>> OrderByDescending<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).OrderByDescending(keySelector);

	public static async Task<IOrderedEnumerable<TSource>> OrderByDescending<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		=> (await source).OrderByDescending(keySelector, comparer);

	public static async Task<IOrderedEnumerable<TSource>> OrderByDescending<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).OrderByDescending(keySelector);

	public static async Task<IOrderedEnumerable<TSource>> OrderByDescending<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
		=> (await source).OrderByDescending(keySelector, comparer);
}
