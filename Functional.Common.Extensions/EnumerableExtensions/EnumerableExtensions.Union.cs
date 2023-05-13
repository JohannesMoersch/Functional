namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> Union<TSource>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second)
		=> first.Union(await second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> first.Union(await second, comparer);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
		=> first.Union(await second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> first.Union(await second, comparer);

	public static IAsyncEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
		=> first.Union(second, null);

	public static async IAsyncEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
	{
		HashSet<TSource> set = new HashSet<TSource>(comparer);

		foreach (var item in first)
			if (set.Add(item)) yield return item;

		await foreach (var item in second)
			if (set.Add(item)) yield return item;
	}

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> (await first).Union(second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
		=> (await first).Union(second, comparer);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> (await first).Union(await second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> (await first).Union(await second, comparer);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first).Union(await second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> (await first).Union(await second, comparer);

	public static IAsyncEnumerable<TSource> Union<TSource>(this Task<IEnumerable<TSource>> first, IAsyncEnumerable<TSource> second)
		=> first.Union(second, null);

	public static async IAsyncEnumerable<TSource> Union<TSource>(this Task<IEnumerable<TSource>> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
	{
		HashSet<TSource> set = new HashSet<TSource>(comparer);

		foreach (var item in await first)
			if (set.Add(item)) yield return item;

		await foreach (var item in second)
			if (set.Add(item)) yield return item;
	}

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> (await first).Union(second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
		=> (await first).Union(second, comparer);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> (await first).Union(await second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> (await first).Union(await second, comparer);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first).Union(await second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> (await first).Union(await second, comparer);

	public static IAsyncEnumerable<TSource> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, IAsyncEnumerable<TSource> second)
		=> first.AsEnumerable().Union(second);

	public static IAsyncEnumerable<TSource> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
		=> first.AsEnumerable().Union(second, comparer);

	public static IAsyncEnumerable<TSource> Union<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second)
		=> first.Union(second, null);

	public static async IAsyncEnumerable<TSource> Union<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
	{
		HashSet<TSource> set = new HashSet<TSource>(comparer);

		await foreach (var item in first)
			if (set.Add(item)) yield return item;

		foreach (var item in second)
			if (set.Add(item)) yield return item;
	}

	public static IAsyncEnumerable<TSource> Union<TSource>(this IAsyncEnumerable<TSource> first, Task<IEnumerable<TSource>> second)
		=> first.Union(second, null);

	public static async IAsyncEnumerable<TSource> Union<TSource>(this IAsyncEnumerable<TSource> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
	{
		HashSet<TSource> set = new HashSet<TSource>(comparer);

		await foreach (var item in first)
			if (set.Add(item)) yield return item;

		foreach (var item in await second)
			if (set.Add(item)) yield return item;
	}

	public static IAsyncEnumerable<TSource> Union<TSource>(this IAsyncEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
		=> first.Union(second.AsEnumerable(), null);

	public static IAsyncEnumerable<TSource> Union<TSource>(this IAsyncEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> first.Union(second.AsEnumerable(), null);

	public static IAsyncEnumerable<TSource> Union<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
		=> first.Union(second, null);

	public static async IAsyncEnumerable<TSource> Union<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
	{
		HashSet<TSource> set = new HashSet<TSource>(comparer);
		
		await foreach (var item in first)
			if (set.Add(item)) yield return item;

		await foreach (var item in second)
			if (set.Add(item)) yield return item;
	}
}
