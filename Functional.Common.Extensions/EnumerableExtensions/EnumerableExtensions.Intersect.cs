namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second)
		=> first.Intersect(await second);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> first.Intersect(await second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
		=> first.Intersect(await second);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> first.Intersect(await second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this IEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
		=> first.Intersect(await second.AsEnumerable());

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this IEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
		=> first.Intersect(await second.AsEnumerable(), comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> (await first).Intersect(second);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
		=> (await first).Intersect(second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> (await first).Intersect(await second);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> (await first).Intersect(await second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first).Intersect(await second);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> (await first).Intersect(await second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, IAsyncEnumerable<TSource> second)
		=> (await first).Intersect(await second.AsEnumerable());

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
		=> (await first).Intersect(await second.AsEnumerable(), comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> (await first).Intersect(second);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
		=> (await first).Intersect(second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> (await first).Intersect(await second);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> (await first).Intersect(await second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first).Intersect(await second);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> (await first).Intersect(await second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, IAsyncEnumerable<TSource> second)
		=> (await first).Intersect(await second.AsEnumerable());

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
		=> (await first).Intersect(await second.AsEnumerable(), comparer);

	public static IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second)
		=> first.Intersect(second, null);

	public static async IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
	{
		HashSet<TSource>? set = null;

		await foreach (TSource item in first)
		{
			if ((set ??= second.ToHashSet(comparer)).Remove(item))
				yield return item;
		}
	}

	public static IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, Task<IEnumerable<TSource>> second)
		=> first.Intersect(second, null);

	public static async IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
	{
		HashSet<TSource>? set = null;

		await foreach (TSource item in first)
		{
			if ((set ??= await second.ToHashSet(comparer)).Remove(item))
				yield return item;
		}
	}

	public static IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
		=> first.Intersect(second, null);

	public static IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> first.Intersect(second.AsEnumerable(), null);

	public static IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
		=> first.Intersect(second, null);

	public static async IAsyncEnumerable<TSource> Intersect<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
	{
		HashSet<TSource>? set = null;

		await foreach (TSource item in first)
		{
			if ((set ??= await second.ToHashSet(comparer)).Remove(item))
				yield return item;
		}
	}
}
