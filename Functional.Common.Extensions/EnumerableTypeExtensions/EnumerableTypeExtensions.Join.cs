using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> (await outer).Join(inner, outerKeySelector, innerKeySelector, resultSelector);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(await inner, outerKeySelector, innerKeySelector, resultSelector);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> (await outer).Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> outer.Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> (await outer).Join(inner, outerKeySelector, innerKeySelector, resultSelector);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(await inner, outerKeySelector, innerKeySelector, resultSelector);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> (await outer).Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> outer.Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
}
