using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static Task<TSource> SingleAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().SingleAsync(predicate);

	public static Task<TSource> SingleAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().SingleAsync(predicate);

	public static Task<TSource> SingleAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).Single();
}
