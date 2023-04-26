using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TSource>> Concat<TSource>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second)
		=> first.Concat(await second);

	public static async Task<IEnumerable<TSource>> Concat<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
		=> first.Concat(await second);

	public static IAsyncEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
		=> AsyncIteratorEnumerable.Create(() => new ConcatAsyncIterator<TSource>(first.AsAsyncEnumerable(), second));

	public static async Task<IEnumerable<TSource>> Concat<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> (await first).Concat(second);

	public static async Task<IEnumerable<TSource>> Concat<TSource>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> (await first).Concat(await second);

	public static async Task<IEnumerable<TSource>> Concat<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first).Concat(await second);

	public static IAsyncEnumerable<TSource> Concat<TSource>(this Task<IEnumerable<TSource>> first, IAsyncEnumerable<TSource> second)
		=> AsyncIteratorEnumerable.Create(() => new ConcatAsyncIterator<TSource>(first.AsAsyncEnumerable(), second));

	public static async Task<IEnumerable<TSource>> Concat<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> (await first).Concat(second);

	public static async Task<IEnumerable<TSource>> Concat<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> (await first).Concat(await second);

	public static async Task<IEnumerable<TSource>> Concat<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first).Concat(await second);

	public static IAsyncEnumerable<TSource> Concat<TSource>(this Task<IOrderedEnumerable<TSource>> first, IAsyncEnumerable<TSource> second)
		=> AsyncIteratorEnumerable.Create(() => new ConcatAsyncIterator<TSource>(first.AsAsyncEnumerable(), second));

	public static IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second)
		=> AsyncIteratorEnumerable.Create(() => new ConcatAsyncIterator<TSource>(first, second.AsAsyncEnumerable()));

	public static IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, Task<IEnumerable<TSource>> second)
		=> AsyncIteratorEnumerable.Create(() => new ConcatAsyncIterator<TSource>(first, second.AsAsyncEnumerable()));

	public static IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
		=> AsyncIteratorEnumerable.Create(() => new ConcatAsyncIterator<TSource>(first, second.AsAsyncEnumerable()));

	public static IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
		=> AsyncIteratorEnumerable.Create(() => new ConcatAsyncIterator<TSource>(first, second));
}
