using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

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
}
