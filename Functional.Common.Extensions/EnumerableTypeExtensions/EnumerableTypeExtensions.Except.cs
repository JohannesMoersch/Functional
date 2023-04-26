using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> (await first).Except(second);

	public static async Task<IEnumerable<TSource>> Except<TSource>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second)
		=> first.Except(await second);

	public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> (await first).Except(await second);

	public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
		=> (await first).Except(second, comparer);

	public static async Task<IEnumerable<TSource>> Except<TSource>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> first.Except(await second, comparer);

	public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> (await first).Except(await second, comparer);

	public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> (await first).Except(second);

	public static async Task<IEnumerable<TSource>> Except<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
		=> first.Except(await second);

	public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> (await first).Except(await second);

	public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first).Except(await second);

	public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first).Except(await second);

	public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
		=> (await first).Except(second, comparer);

	public static async Task<IEnumerable<TSource>> Except<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> first.Except(await second, comparer);

	public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> (await first).Except(await second, comparer);

	public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> (await first).Except(await second, comparer);

	public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
		=> (await first).Except(await second, comparer);
}
