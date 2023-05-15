using System.Linq;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second, Func<TSource, TKey> keySelector)
		=> first.UnionBy(await second, keySelector);

	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> first.UnionBy(await second, keySelector, comparer);

	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, Func<TSource, TKey> keySelector)
		=> first.UnionBy(await second, keySelector);

	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> first.UnionBy(await second, keySelector, comparer);

	public static IAsyncEnumerable<TSource> UnionBy<TSource, TKey>(this IEnumerable<TSource> first, IAsyncEnumerable<TSource> second, Func<TSource, TKey> keySelector)
		=> first.UnionBy(second, keySelector, null);

	public static async IAsyncEnumerable<TSource> UnionBy<TSource, TKey>(this IEnumerable<TSource> first, IAsyncEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
	{
		var set = new HashSet<TKey>(comparer);

		foreach (var item in first)
			if (set.Add(keySelector.Invoke(item))) yield return item;

		await foreach (var item in second)
			if (set.Add(keySelector.Invoke(item))) yield return item;
	}

	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector)
		=> (await first).UnionBy(second, keySelector);

	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await first).UnionBy(second, keySelector, comparer);

	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, Func<TSource, TKey> keySelector)
		=> (await first).UnionBy(await second, keySelector);

	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await first).UnionBy(await second, keySelector, comparer);

	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, Func<TSource, TKey> keySelector)
		=> (await first).UnionBy(await second, keySelector);

	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await first).UnionBy(await second, keySelector, comparer);

	public static IAsyncEnumerable<TSource> UnionBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, IAsyncEnumerable<TSource> second, Func<TSource, TKey> keySelector)
		=> first.UnionBy(second, keySelector, null);

	public static async IAsyncEnumerable<TSource> UnionBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, IAsyncEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
	{
		var set = new HashSet<TKey>(comparer);

		foreach (var item in await first)
			if (set.Add(keySelector.Invoke(item))) yield return item;

		await foreach (var item in second)
			if (set.Add(keySelector.Invoke(item))) yield return item;
	}

	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector)
		=> (await first).UnionBy(second, keySelector);

	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await first).UnionBy(second, keySelector, comparer);

	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, Func<TSource, TKey> keySelector)
		=> (await first).UnionBy(await second, keySelector);

	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await first).UnionBy(await second, keySelector, comparer);

	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, Func<TSource, TKey> keySelector)
		=> (await first).UnionBy(await second, keySelector);

	public static async Task<IEnumerable<TSource>> UnionBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await first).UnionBy(await second, keySelector, comparer);

	public static IAsyncEnumerable<TSource> UnionBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, IAsyncEnumerable<TSource> second, Func<TSource, TKey> keySelector)
		=> first.AsEnumerable().UnionBy(second, keySelector);

	public static IAsyncEnumerable<TSource> UnionBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, IAsyncEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> first.AsEnumerable().UnionBy(second, keySelector, comparer);

	public static IAsyncEnumerable<TSource> UnionBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector)
		=> first.UnionBy(second, keySelector, null);

	public static async IAsyncEnumerable<TSource> UnionBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
	{
		var set = new HashSet<TKey>(comparer);

		await foreach (var item in first)
			if (set.Add(keySelector.Invoke(item))) yield return item;

		foreach (var item in second)
			if (set.Add(keySelector.Invoke(item))) yield return item;
	}

	public static IAsyncEnumerable<TSource> UnionBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, Task<IEnumerable<TSource>> second, Func<TSource, TKey> keySelector)
		=> first.UnionBy(second, keySelector, null);

	public static async IAsyncEnumerable<TSource> UnionBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, Task<IEnumerable<TSource>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
	{
		var set = new HashSet<TKey>(comparer);

		await foreach (var item in first)
			if (set.Add(keySelector.Invoke(item))) yield return item;

		foreach (var item in await second)
			if (set.Add(keySelector.Invoke(item))) yield return item;
	}

	public static IAsyncEnumerable<TSource> UnionBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, Func<TSource, TKey> keySelector)
		=> first.UnionBy(second.AsEnumerable(), keySelector, null);

	public static IAsyncEnumerable<TSource> UnionBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> first.UnionBy(second.AsEnumerable(), keySelector, comparer);

	public static IAsyncEnumerable<TSource> UnionBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, Func<TSource, TKey> keySelector)
		=> first.UnionBy(second, keySelector, null);

	public static async IAsyncEnumerable<TSource> UnionBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
	{
		var  set = new HashSet<TKey>(comparer);
		
		await foreach (var item in first)
			if (set.Add(keySelector.Invoke(item))) yield return item;

		await foreach (var item in second)
			if (set.Add(keySelector.Invoke(item))) yield return item;
	}
}
