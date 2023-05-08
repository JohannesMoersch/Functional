using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> (await first).Union(second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second)
		=> first.Union(await second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> (await first).Union(await second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
		=> (await first).Union(second, comparer);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> first.Union(await second, comparer);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> (await first).Union(await second, comparer);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> (await first).Union(second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
		=> first.Union(await second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> (await first).Union(await second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first).Union(await second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first).Union(await second);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
		=> (await first).Union(second, comparer);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> first.Union(await second, comparer);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> (await first).Union(await second, comparer);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> (await first).Union(await second, comparer);

	public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> (await first).Union(await second, comparer);
}
