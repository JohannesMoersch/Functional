using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TSource>> Where<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, bool> predicate)
		=> (await source).Where(predicate);

	public static async Task<IEnumerable<TSource>> Where<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Where(predicate);

	public static async Task<IEnumerable<TSource>> Where<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, bool> predicate)
		=> (await source).Where(predicate);

	public static async Task<IEnumerable<TSource>> Where<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Where(predicate);

	public static IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate)
		=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
			: AsyncIteratorEnumerable.Create((source, predicate), static (o, t) => BasicAsyncIterator.Create(o.source, o, static (s, i, context) => context.predicate.Invoke(s, i) ? (BasicAsyncIterator.ContinuationType.Take, s) : (BasicAsyncIterator.ContinuationType.Skip, default), t));

	public static IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
		=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
			: AsyncIteratorEnumerable.Create((source, predicate), static (o, t) => BasicAsyncIterator.Create(o.source, o, static (s, _, context) => context.predicate.Invoke(s) ? (BasicAsyncIterator.ContinuationType.Take, s) : (BasicAsyncIterator.ContinuationType.Skip, default), t));
}
