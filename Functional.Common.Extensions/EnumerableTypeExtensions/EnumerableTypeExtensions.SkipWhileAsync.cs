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

		bool skip = true;
		return AsyncIteratorEnumerable.Create(() => new BasicTaskAsyncIterator<TSource, TSource>(source, async data => (skip && (skip = await predicate.Invoke(data.current))) ? (BasicIteratorContinuationType.Skip, default) : (BasicIteratorContinuationType.Take, data.current)));
	}

	public static IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
	{
		if (predicate == null)
			throw new ArgumentNullException(nameof(predicate));

		bool skip = true;
		return AsyncIteratorEnumerable.Create(() => new BasicTaskAsyncIterator<TSource, TSource>(source, async data => (skip && (skip = await predicate.Invoke(data.current, data.index))) ? (BasicIteratorContinuationType.Skip, default) : (BasicIteratorContinuationType.Take, data.current)));
	}
}
