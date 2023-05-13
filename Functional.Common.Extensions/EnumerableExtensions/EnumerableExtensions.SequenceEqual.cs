namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<bool> SequenceEqual<TSource>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second)
		=> first.SequenceEqual(await second);

	public static async Task<bool> SequenceEqual<TSource>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> first.SequenceEqual(await second, comparer);

	public static async Task<bool> SequenceEqual<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
		=> first.SequenceEqual(await second);

	public static async Task<bool> SequenceEqual<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> first.SequenceEqual(await second, comparer);

	public static async Task<bool> SequenceEqual<TSource>(this IEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
		=> first.SequenceEqual(await second.AsEnumerable());

	public static async Task<bool> SequenceEqual<TSource>(this IEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
		=> first.SequenceEqual(await second.AsEnumerable(), comparer);

	public static async Task<bool> SequenceEqual<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> (await first).SequenceEqual(second);

	public static async Task<bool> SequenceEqual<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
		=> (await first).SequenceEqual(second, comparer);

	public static async Task<bool> SequenceEqual<TSource>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> (await first).SequenceEqual(await second);

	public static async Task<bool> SequenceEqual<TSource>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> (await first).SequenceEqual(await second, comparer);

	public static async Task<bool> SequenceEqual<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first).SequenceEqual(await second);

	public static async Task<bool> SequenceEqual<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> (await first).SequenceEqual(await second, comparer);

	public static async Task<bool> SequenceEqual<TSource>(this Task<IEnumerable<TSource>> first, IAsyncEnumerable<TSource> second)
		=> (await first).SequenceEqual(await second.AsEnumerable());

	public static async Task<bool> SequenceEqual<TSource>(this Task<IEnumerable<TSource>> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
		=> (await first).SequenceEqual(await second.AsEnumerable(), comparer);

	public static async Task<bool> SequenceEqual<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> (await first).SequenceEqual(second);

	public static async Task<bool> SequenceEqual<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
		=> (await first).SequenceEqual(second, comparer);

	public static async Task<bool> SequenceEqual<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> (await first).SequenceEqual(await second);

	public static async Task<bool> SequenceEqual<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> (await first).SequenceEqual(await second, comparer);

	public static async Task<bool> SequenceEqual<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first).SequenceEqual(await second);

	public static async Task<bool> SequenceEqual<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> (await first).SequenceEqual(await second, comparer);

	public static async Task<bool> SequenceEqual<TSource>(this Task<IOrderedEnumerable<TSource>> first, IAsyncEnumerable<TSource> second)
		=> (await first).SequenceEqual(await second.AsEnumerable());

	public static async Task<bool> SequenceEqual<TSource>(this Task<IOrderedEnumerable<TSource>> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
		=> (await first).SequenceEqual(await second.AsEnumerable(), comparer);

	public static async Task<bool> SequenceEqual<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second)
		=> (await first.AsEnumerable()).SequenceEqual(second);

	public static async Task<bool> SequenceEqual<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
		=> (await first.AsEnumerable()).SequenceEqual(second, comparer);

	public static async Task<bool> SequenceEqual<TSource>(this IAsyncEnumerable<TSource> first, Task<IEnumerable<TSource>> second)
		=> (await first.AsEnumerable()).SequenceEqual(await second);

	public static async Task<bool> SequenceEqual<TSource>(this IAsyncEnumerable<TSource> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> (await first.AsEnumerable()).SequenceEqual(await second, comparer);

	public static async Task<bool> SequenceEqual<TSource>(this IAsyncEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first.AsEnumerable()).SequenceEqual(await second);

	public static async Task<bool> SequenceEqual<TSource>(this IAsyncEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource>? comparer)
		=> (await first.AsEnumerable()).SequenceEqual(await second, comparer);

	public static async Task<bool> SequenceEqual<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
		=> (await first.AsEnumerable()).SequenceEqual(await second.AsEnumerable());

	public static async Task<bool> SequenceEqual<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
		=> (await first.AsEnumerable()).SequenceEqual(await second.AsEnumerable(), comparer);
}
