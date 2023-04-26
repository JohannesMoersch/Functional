using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static Task<TSource?> SingleOrDefaultAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.AsAsyncEnumerable().SingleOrDefaultAsync(predicate);

	public static Task<TSource?> SingleOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).SingleOrDefault();
}
