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
			: AsyncIteratorEnumerable.Create((source, selector), static (o, t) => BasicAsyncIterator.Create(o.source, o, static (s, _, context) => (BasicAsyncIterator.ContinuationType.Take, context.selector.Invoke(s)), t));

	public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, TResult> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create((source, selector), static (o, t) => BasicAsyncIterator.Create(o.source, o, static (s, i, context) => (BasicAsyncIterator.ContinuationType.Take, context.selector.Invoke(s, i)), t));
}
