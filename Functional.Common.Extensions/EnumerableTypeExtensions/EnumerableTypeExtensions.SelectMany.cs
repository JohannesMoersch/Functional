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
			: AsyncIteratorEnumerable.Create(() => new SelectManyAsyncIterator<TSource, TResult, TResult>(source.AsAsyncEnumerable(), (o, _) => selector(o), (_, o) => o));

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IAsyncEnumerable<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create(() => new SelectManyAsyncIterator<TSource, TResult, TResult>(source.AsAsyncEnumerable(), selector, (_, o) => o));

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IAsyncEnumerable<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create(() => new SelectManyAsyncIterator<TSource, TResult, TResult>(source.AsAsyncEnumerable(), (o, _) => selector(o), (_, o) => o));

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, IAsyncEnumerable<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create(() => new SelectManyAsyncIterator<TSource, TResult, TResult>(source.AsAsyncEnumerable(), selector, (_, o) => o));

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create(() => new SelectManyAsyncIterator<TSource, TResult, TResult>(source, (o, _) => selector(o).AsAsyncEnumerable(), (_, o) => o));

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create(() => new SelectManyAsyncIterator<TSource, TResult, TResult>(source, (o, i) => selector(o, i).AsAsyncEnumerable(), (_, o) => o));

	public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IEnumerable<TResult>> selector)
		=> (await source).SelectMany(selector);

	public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, IEnumerable<TResult>> selector)
		=> (await source).SelectMany(selector);

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create(() => new SelectManyAsyncIterator<TSource, TResult, TResult>(source, (o, _) => selector(o), (_, o) => o));

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IAsyncEnumerable<TResult>> selector)
		=> selector == null ? throw new ArgumentNullException(nameof(selector))
			: AsyncIteratorEnumerable.Create(() => new SelectManyAsyncIterator<TSource, TResult, TResult>(source, selector, (_, o) => o));
}
