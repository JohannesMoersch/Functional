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
			: AsyncIteratorEnumerable.Create(() => new BasicAsyncIterator<TSource, TSource>(source, data => predicate.Invoke(data.current, data.index) ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Skip, default)));

	public static IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
		=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
			: AsyncIteratorEnumerable.Create(() => new BasicAsyncIterator<TSource, TSource>(source, data => predicate.Invoke(data.current) ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Skip, default)));
}
