using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> (await outer).GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> outer.GroupJoin(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> (await outer).GroupJoin(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
		=> (await outer).GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector);

	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
		=> outer.GroupJoin(await inner, outerKeySelector, innerKeySelector, resultSelector);

	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
		=> (await outer).GroupJoin(await inner, outerKeySelector, innerKeySelector, resultSelector);

	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> (await outer).GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> outer.GroupJoin(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> (await outer).GroupJoin(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> (await outer).GroupJoin(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> (await outer).GroupJoin(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
		=> (await outer).GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector);

	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
		=> outer.GroupJoin(await inner, outerKeySelector, innerKeySelector, resultSelector);

	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
		=> (await outer).GroupJoin(await inner, outerKeySelector, innerKeySelector, resultSelector);

	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
		=> (await outer).GroupJoin(await inner, outerKeySelector, innerKeySelector, resultSelector);

	public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
		=> (await outer).GroupJoin(await inner, outerKeySelector, innerKeySelector, resultSelector);
}
