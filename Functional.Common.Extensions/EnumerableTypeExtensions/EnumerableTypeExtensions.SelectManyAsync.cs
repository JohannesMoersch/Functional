using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TResult>>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create((source, selector), static (o, t) => SelectManyAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.selector.Invoke(s).AsAsyncEnumerable(), static (_, o, _) => o, t));

	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TResult>>> selector)
		=> source.AsAsyncEnumerable().SelectManyAsync(selector);

	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<IEnumerable<TResult>>> selector)
		=> source.AsAsyncEnumerable().SelectManyAsync(selector);

	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<IEnumerable<TResult>>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create((source, selector), static (o, t) => SelectManyAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, i, context) => context.selector.Invoke(s, i).AsAsyncEnumerable(), static (_, o, _) => o, t));

	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, Task<IEnumerable<TResult>>> selector)
		=> source.AsAsyncEnumerable().SelectManyAsync(selector);

	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<IEnumerable<TResult>>> selector)
		=> source.AsAsyncEnumerable().SelectManyAsync(selector);
}
