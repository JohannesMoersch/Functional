using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, IEnumerable<TResult>> selector)
		=> (await source).SelectMany(selector);

	public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, IEnumerable<TResult>> selector)
		=> (await source).SelectMany(selector);

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create((source, selector), static (o, t) => SelectManyAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.selector.Invoke(s), static (_, o, _) => o, t));

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IAsyncEnumerable<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create((source, selector), static (o, t) => SelectManyAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, i, context) => context.selector.Invoke(s, i), static (_, o, _) => o, t));

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IAsyncEnumerable<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create((source, selector), static (o, t) => SelectManyAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.selector.Invoke(s), static (_, o, _) => o, t));

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, IAsyncEnumerable<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create((source, selector), static (o, t) => SelectManyAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, i, context) => context.selector.Invoke(s, i), static (_, o, _) => o, t));

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create((source, selector), static (o, t) => SelectManyAsyncIterator.Create(o.source, o, static (s, _, context) => context.selector.Invoke(s).AsAsyncEnumerable(), static (_, o, _) => o, t));

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create((source, selector), static (o, t) => SelectManyAsyncIterator.Create(o.source, o, static (s, i, context) => context.selector.Invoke(s, i).AsAsyncEnumerable(), static (_, o, _) => o, t));

	public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IEnumerable<TResult>> selector)
		=> (await source).SelectMany(selector);

	public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, IEnumerable<TResult>> selector)
		=> (await source).SelectMany(selector);

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create((source, selector), static (o, t) => SelectManyAsyncIterator.Create(o.source, o, static (s, _, context) => context.selector.Invoke(s), static (_, o, _) => o, t));

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IAsyncEnumerable<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create((source, selector), static (o, t) => SelectManyAsyncIterator.Create(o.source, o, static (s, i, context) => context.selector.Invoke(s, i), static (_, o, _) => o, t));
}
