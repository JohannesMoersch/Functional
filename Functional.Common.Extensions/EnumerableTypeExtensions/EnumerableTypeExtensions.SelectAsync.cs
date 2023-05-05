using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().SelectAsync(selector);

	public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().SelectAsync(selector);

	public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().SelectAsync(selector);

	public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().SelectAsync(selector);

	public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create((source, selector), static (o, t) => BasicTaskAsyncIterator.Create(o.source, o, async (s, _, context) => (BasicIteratorContinuationType.Take, await context.selector.Invoke(s)), t));

	public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create((source, selector), static (o, t) => BasicTaskAsyncIterator.Create(o.source, o, async (s, i, context) => (BasicIteratorContinuationType.Take, await context.selector.Invoke(s, i)), t));

	public static IAsyncEnumerable<TSource> SelectAsync<TSource>(this IEnumerable<Task<TSource>> source)
		=> source.SelectAsync(_ => _);

	public static IAsyncEnumerable<TSource> SelectAsync<TSource>(this Task<IEnumerable<Task<TSource>>> source)
		=> source.SelectAsync(_ => _);

	public static IAsyncEnumerable<TSource> SelectAsync<TSource>(this IAsyncEnumerable<Task<TSource>> source)
		=> source.SelectAsync(_ => _);
}
