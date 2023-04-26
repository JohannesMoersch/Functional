using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TSource?>> DefaultIfEmpty<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).DefaultIfEmpty();

	public static async Task<IEnumerable<TSource>> DefaultIfEmpty<TSource>(this Task<IEnumerable<TSource>> source, TSource defaultValue)
		=> (await source).DefaultIfEmpty(defaultValue);

	public static IAsyncEnumerable<TSource?> DefaultIfEmpty<TSource>(this IAsyncEnumerable<TSource> source)
		=> AsyncIteratorEnumerable.Create(() => new DefaultIfEmptyAsyncIterator<TSource?>(source, default));

	public static IAsyncEnumerable<TSource> DefaultIfEmpty<TSource>(this IAsyncEnumerable<TSource> source, TSource defaultValue)
		=> AsyncIteratorEnumerable.Create(() => new DefaultIfEmptyAsyncIterator<TSource>(source, defaultValue));

	public static async Task<IEnumerable<TSource?>> DefaultIfEmpty<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).DefaultIfEmpty();

	public static async Task<IEnumerable<TSource>> DefaultIfEmpty<TSource>(this Task<IOrderedEnumerable<TSource>> source, TSource defaultValue)
		=> (await source).DefaultIfEmpty(defaultValue);
}
