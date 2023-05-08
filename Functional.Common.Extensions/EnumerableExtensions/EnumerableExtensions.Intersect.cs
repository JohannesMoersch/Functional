using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> (await first).Intersect(second);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second)
		=> first.Intersect(await second);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> (await first).Intersect(await second);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
		=> (await first).Intersect(second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> first.Intersect(await second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> (await first).Intersect(await second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
		=> (await first).Intersect(second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> first.Intersect(await second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> (await first).Intersect(await second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> (await first).Intersect(await second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> (await first).Intersect(await second, comparer);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> (await first).Intersect(second);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
		=> first.Intersect(await second);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> (await first).Intersect(await second);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first).Intersect(await second);

	public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first).Intersect(await second);
}
