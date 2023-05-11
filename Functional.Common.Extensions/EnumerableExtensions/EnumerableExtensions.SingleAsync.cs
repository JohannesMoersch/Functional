using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static Task<TSource> SingleAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).Single();

	public static Task<TSource> SingleAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).Single();

	public static Task<TSource> SingleAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).Single();

	public static Task<TSource> SingleAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).Single();
}
