using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static IAsyncEnumerable<TSource> WhereAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().WhereAsync(predicate);

	public static IAsyncEnumerable<TSource> WhereAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().WhereAsync(predicate);

	public static IAsyncEnumerable<TSource> WhereAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().WhereAsync(predicate);

	public static IAsyncEnumerable<TSource> WhereAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().WhereAsync(predicate);

	public static IAsyncEnumerable<TSource> WhereAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
		=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
			: AsyncIteratorEnumerable.Create((source, predicate), static (o, t) => BasicTaskAsyncIterator.Create(o.source, o, async static (s, i, context) => await context.predicate.Invoke(s, i) ? (BasicIteratorContinuationType.Take, s) : (BasicIteratorContinuationType.Skip, default), t));

	public static IAsyncEnumerable<TSource> WhereAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
			: AsyncIteratorEnumerable.Create((source, predicate), static (o, t) => BasicTaskAsyncIterator.Create(o.source, o, async static (s, _, context) => await context.predicate.Invoke(s) ? (BasicIteratorContinuationType.Take, s) : (BasicIteratorContinuationType.Skip, default), t));
}
