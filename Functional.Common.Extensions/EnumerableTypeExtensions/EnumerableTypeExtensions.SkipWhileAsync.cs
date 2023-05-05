using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().SkipWhileAsync(predicate);

	public static IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().SkipWhileAsync(predicate);

	public static IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().SkipWhileAsync(predicate);

	public static IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().SkipWhileAsync(predicate);

	public static IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
	{
		if (predicate == null)
			throw new ArgumentNullException(nameof(predicate));

		return AsyncIteratorEnumerable.Create((source, predicate), static (o, t) => BasicTaskAsyncIterator.Create(o.source, o, BasicTaskAsyncIterator.State.Pending, static async (s, _, context) => (await context.predicate.Invoke(s)) ? (BasicIteratorContinuationType.Take, s) : (BasicIteratorContinuationType.Start, s), t));
	}

	public static IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
	{
		if (predicate == null)
			throw new ArgumentNullException(nameof(predicate));

		return AsyncIteratorEnumerable.Create((source, predicate), static (o, t) => BasicTaskAsyncIterator.Create(o.source, o, BasicTaskAsyncIterator.State.Pending, static async (s, i, context) => (await context.predicate.Invoke(s, i)) ? (BasicIteratorContinuationType.Take, s) : (BasicIteratorContinuationType.Start, s), t));
	}
}
