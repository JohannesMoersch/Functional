using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().TakeWhileAsync(predicate);

	public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().TakeWhileAsync(predicate);

	public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().TakeWhileAsync(predicate);

	public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().TakeWhileAsync(predicate);

	public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
			: AsyncIteratorEnumerable.Create(() => new BasicTaskAsyncIterator<TSource, TSource>(source, async data => await predicate.Invoke(data.current) ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Stop, default)));

	public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
		=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
			: AsyncIteratorEnumerable.Create(() => new BasicTaskAsyncIterator<TSource, TSource>(source, async data => await predicate.Invoke(data.current, data.index) ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Stop, default)));
}
