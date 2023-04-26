using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TSource>> SkipWhile<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).SkipWhile(predicate);

	public static async Task<IEnumerable<TSource>> SkipWhile<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, bool> predicate)
		=> (await source).SkipWhile(predicate);

	public static async Task<IEnumerable<TSource>> SkipWhile<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).SkipWhile(predicate);

	public static async Task<IEnumerable<TSource>> SkipWhile<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, bool> predicate)
		=> (await source).SkipWhile(predicate);

	public static IAsyncEnumerable<TSource> SkipWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		if (predicate == null)
			throw new ArgumentNullException(nameof(predicate));

		bool skip = true;
		return AsyncIteratorEnumerable.Create(() => new BasicAsyncIterator<TSource, TSource>(source, data => (skip ? (skip = predicate.Invoke(data.current)) : false) ? (BasicIteratorContinuationType.Skip, default) : (BasicIteratorContinuationType.Take, data.current)));
	}

	public static IAsyncEnumerable<TSource> SkipWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate)
	{
		if (predicate == null)
			throw new ArgumentNullException(nameof(predicate));

		bool skip = true;
		return AsyncIteratorEnumerable.Create(() => new BasicAsyncIterator<TSource, TSource>(source, data => (skip ? (skip = predicate.Invoke(data.current, data.index)) : false) ? (BasicIteratorContinuationType.Skip, default) : (BasicIteratorContinuationType.Take, data.current)));
	}
}
