namespace Functional;

public static partial class EnumerableExtensions
{
	public static Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> outer.Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> outer.Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> outer.Join(await inner.AsEnumerable(), outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> (await outer).Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> (await outer).Join(await inner.AsEnumerable(), outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> (await outer).Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

	public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> (await outer).Join(await inner.AsEnumerable(), outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

	public static async IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
	{
		if (inner is null) throw new ArgumentNullException(nameof(inner));
		if (outerKeySelector is null) throw new ArgumentNullException(nameof(outerKeySelector));
		if (innerKeySelector is null) throw new ArgumentNullException(nameof(innerKeySelector));
		if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

		ILookup<TKey, TInner>? lookup = null;

		await foreach (var item in outer)
		{
			foreach (var match in (lookup ??= inner.ToLookup(innerKeySelector, comparer))[outerKeySelector.Invoke(item)])
				yield return resultSelector.Invoke(item, match);
		}
	}

	public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

	public static async IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
	{
		if (inner is null) throw new ArgumentNullException(nameof(inner));
		if (outerKeySelector is null) throw new ArgumentNullException(nameof(outerKeySelector));
		if (innerKeySelector is null) throw new ArgumentNullException(nameof(innerKeySelector));
		if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

		ILookup<TKey, TInner>? lookup = null;

		await foreach (var item in outer)
		{
			foreach (var match in (lookup ??= await inner.ToLookup(innerKeySelector, comparer))[outerKeySelector.Invoke(item)])
				yield return resultSelector.Invoke(item, match);
		}
	}

	public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(inner.AsEnumerable(), outerKeySelector, innerKeySelector, resultSelector, null);

	public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
		=> outer.Join(inner.AsEnumerable(), outerKeySelector, innerKeySelector, resultSelector, comparer);

	public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

	public static async IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
	{
		if (inner is null) throw new ArgumentNullException(nameof(inner));
		if (outerKeySelector is null) throw new ArgumentNullException(nameof(outerKeySelector));
		if (innerKeySelector is null) throw new ArgumentNullException(nameof(innerKeySelector));
		if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

		ILookup<TKey, TInner>? lookup = null;

		await foreach (var item in outer)
		{
			foreach (var match in (lookup ??= await inner.ToLookup(innerKeySelector, comparer))[outerKeySelector.Invoke(item)])
				yield return resultSelector.Invoke(item, match);
		}
	}
}
