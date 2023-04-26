using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, TResult> selector)
		=> (await source).Select(selector);

	public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, TResult> selector)
		=> (await source).Select(selector);

	public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TResult> selector)
		=> (await source).Select(selector);

	public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, TResult> selector)
		=> (await source).Select(selector);

	public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, TResult> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create(() => new BasicAsyncIterator<TSource, TResult>(source, data => (BasicIteratorContinuationType.Take, selector.Invoke(data.current))));

	public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, TResult> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create(() => new BasicAsyncIterator<TSource, TResult>(source, data => (BasicIteratorContinuationType.Take, selector.Invoke(data.current, data.index))));
}
