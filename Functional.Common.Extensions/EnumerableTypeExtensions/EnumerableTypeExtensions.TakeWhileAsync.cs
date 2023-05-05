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
			: AsyncIteratorEnumerable.Create((source, predicate), static (o, t) => BasicTaskAsyncIterator.Create(o.source, o, static async (s, _, context) => await context.predicate.Invoke(s) ? (BasicTaskAsyncIterator.ContinuationType.Take, s) : (BasicTaskAsyncIterator.ContinuationType.Stop, default), t));

	public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
		=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
			: AsyncIteratorEnumerable.Create((source, predicate), static (o, t) => BasicTaskAsyncIterator.Create(o.source, o, static async (s, i, context) => await context.predicate.Invoke(s, i) ? (BasicTaskAsyncIterator.ContinuationType.Take, s) : (BasicTaskAsyncIterator.ContinuationType.Stop, default), t));
}
