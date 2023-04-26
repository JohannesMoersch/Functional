using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TResult>>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create(() => new SelectManyAsyncIterator<TSource, TResult, TResult>(source, (o, _) => selector(o).AsAsyncEnumerable(), (_, o) => o));

	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TResult>>> selector)
		=> source.AsAsyncEnumerable().SelectManyAsync(selector);

	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<IEnumerable<TResult>>> selector)
		=> source.AsAsyncEnumerable().SelectManyAsync(selector);

	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<IEnumerable<TResult>>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create(() => new SelectManyAsyncIterator<TSource, TResult, TResult>(source, (o, i) => selector(o, i).AsAsyncEnumerable(), (_, o) => o));

	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, Task<IEnumerable<TResult>>> selector)
		=> source.AsAsyncEnumerable().SelectManyAsync(selector);

	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<IEnumerable<TResult>>> selector)
		=> source.AsAsyncEnumerable().SelectManyAsync(selector);
}
