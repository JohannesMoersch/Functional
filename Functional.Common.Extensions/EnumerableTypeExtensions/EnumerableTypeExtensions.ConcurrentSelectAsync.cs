using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector, int maxConcurrency)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector, int maxConcurrency)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<TResult>> selector, int maxConcurrency)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<TResult>> selector, int maxConcurrency)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<TResult>> selector, int maxConcurrency)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, Task<TResult>> selector, int maxConcurrency)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
		=> source.ConcurrentSelectAsync(selector, Int32.MaxValue);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TResult>> selector, int maxConcurrency)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create(() => new ConcurrentSelectAsyncIterator<TSource, TResult>(source, (o, _) => selector.Invoke(o), maxConcurrency));

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector)
		=> source.ConcurrentSelectAsync(selector, Int32.MaxValue);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector, int maxConcurrency)
		=> AsyncIteratorEnumerable.Create(() => new ConcurrentSelectAsyncIterator<TSource, TResult>(source, selector, maxConcurrency));
}
