namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, Task<IEnumerable<TKey>> second, Func<TSource, TKey> keySelector)
		=> first.ExceptBy(await second, keySelector);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, Task<IEnumerable<TKey>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> first.ExceptBy(await second, keySelector, comparer);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TKey>> second, Func<TSource, TKey> keySelector)
		=> first.ExceptBy(await second, keySelector);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TKey>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> first.ExceptBy(await second, keySelector, comparer);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IAsyncEnumerable<TKey> second, Func<TSource, TKey> keySelector)
		=> first.ExceptBy(await second.AsEnumerable(), keySelector);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IAsyncEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> first.ExceptBy(await second.AsEnumerable(), keySelector, comparer);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector)
		=> (await first).ExceptBy(second, keySelector);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await first).ExceptBy(second, keySelector, comparer);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TKey>> second, Func<TSource, TKey> keySelector)
		=> (await first).ExceptBy(await second, keySelector);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TKey>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await first).ExceptBy(await second, keySelector, comparer);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TKey>> second, Func<TSource, TKey> keySelector)
		=> (await first).ExceptBy(await second, keySelector);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TKey>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await first).ExceptBy(await second, keySelector, comparer);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, IAsyncEnumerable<TKey> second, Func<TSource, TKey> keySelector)
		=> (await first).ExceptBy(await second.AsEnumerable(), keySelector);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IEnumerable<TSource>> first, IAsyncEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await first).ExceptBy(await second.AsEnumerable(), keySelector, comparer);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector)
		=> (await first).ExceptBy(second, keySelector);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await first).ExceptBy(second, keySelector, comparer);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TKey>> second, Func<TSource, TKey> keySelector)
		=> (await first).ExceptBy(await second, keySelector);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TKey>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await first).ExceptBy(await second, keySelector, comparer);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TKey>> second, Func<TSource, TKey> keySelector)
		=> (await first).ExceptBy(await second, keySelector);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TKey>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await first).ExceptBy(await second, keySelector, comparer);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, IAsyncEnumerable<TKey> second, Func<TSource, TKey> keySelector)
		=> (await first).ExceptBy(await second.AsEnumerable(), keySelector);

	public static async Task<IEnumerable<TSource>> ExceptBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> first, IAsyncEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> (await first).ExceptBy(await second.AsEnumerable(), keySelector, comparer);

	public static IAsyncEnumerable<TSource> ExceptBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector)
		=> first.ExceptBy(second, keySelector, null);

	public static async IAsyncEnumerable<TSource> ExceptBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
	{
		HashSet<TKey>? set = null;

		await foreach (TSource item in first)
		{
			if ((set ??= second.ToHashSet(comparer)).Add(keySelector.Invoke(item)))
				yield return item;
		}
	}

	public static IAsyncEnumerable<TSource> ExceptBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, Task<IEnumerable<TKey>> second, Func<TSource, TKey> keySelector)
		=> first.ExceptBy(second, keySelector, null);

	public static async IAsyncEnumerable<TSource> ExceptBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, Task<IEnumerable<TKey>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
	{
		HashSet<TKey>? set = null;

		await foreach (TSource item in first)
		{
			if ((set ??= await second.ToHashSet(comparer)).Add(keySelector.Invoke(item)))
				yield return item;
		}
	}

	public static IAsyncEnumerable<TSource> ExceptBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, Task<IOrderedEnumerable<TKey>> second, Func<TSource, TKey> keySelector)
		=> first.ExceptBy(second.AsEnumerable(), keySelector, null);

	public static IAsyncEnumerable<TSource> ExceptBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, Task<IOrderedEnumerable<TKey>> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
		=> first.ExceptBy(second.AsEnumerable(), keySelector, comparer);

	public static IAsyncEnumerable<TSource> ExceptBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TKey> second, Func<TSource, TKey> keySelector)
		=> first.ExceptBy(second, keySelector, null);

	public static async IAsyncEnumerable<TSource> ExceptBy<TSource, TKey>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
	{
		HashSet<TKey>? set = null;

		await foreach (TSource item in first)
		{
			if ((set ??= await second.ToHashSet(comparer)).Add(keySelector.Invoke(item)))
				yield return item;
		}
	}
}
