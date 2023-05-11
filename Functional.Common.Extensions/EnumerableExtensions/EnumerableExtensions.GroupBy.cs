using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TElement, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> (await source).GroupBy(keySelector, elementSelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TElement, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
		=> (await source).GroupBy(keySelector, elementSelector, resultSelector);

	public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> (await source).GroupBy(keySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
		=> (await source).GroupBy(keySelector, resultSelector);

	public static async Task<IEnumerable<IGrouping<TKey, TSource>>> GroupBy<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await source).GroupBy(keySelector, comparer);

	public static async Task<IEnumerable<IGrouping<TKey, TElement>>> GroupBy<TSource, TKey, TElement>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		=> (await source).GroupBy(keySelector, elementSelector);

	public static async Task<IEnumerable<IGrouping<TKey, TSource>>> GroupBy<TSource, TKey>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).GroupBy(keySelector);

	public static async Task<IEnumerable<IGrouping<TKey, TElement>>> GroupBy<TSource, TKey, TElement>(this Task<IEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
		=> (await source).GroupBy(keySelector, elementSelector, comparer);

	public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TElement, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> (await source).GroupBy(keySelector, elementSelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TElement, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
		=> (await source).GroupBy(keySelector, elementSelector, resultSelector);

	public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> (await source).GroupBy(keySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
		=> (await source).GroupBy(keySelector, resultSelector);

	public static async Task<IEnumerable<IGrouping<TKey, TSource>>> GroupBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await source).GroupBy(keySelector, comparer);

	public static async Task<IEnumerable<IGrouping<TKey, TElement>>> GroupBy<TSource, TKey, TElement>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		=> (await source).GroupBy(keySelector, elementSelector);

	public static async Task<IEnumerable<IGrouping<TKey, TSource>>> GroupBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
		=> (await source).GroupBy(keySelector);

	public static async Task<IEnumerable<IGrouping<TKey, TElement>>> GroupBy<TSource, TKey, TElement>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
		=> (await source).GroupBy(keySelector, elementSelector, comparer);
}
