using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> AsyncIteratorEnumerable.Create((first, second, resultSelector), static (o, t) => new ZipTaskAsyncIterator<TFirst, TSecond, TResult>(o.first.AsAsyncEnumerable(), o.second, o.resultSelector, t));

	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> AsyncIteratorEnumerable.Create((first, second, resultSelector), static (o, t) => new ZipTaskAsyncIterator<TFirst, TSecond, TResult>(o.first.AsAsyncEnumerable(), o.second, o.resultSelector, t));

	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> AsyncIteratorEnumerable.Create((first, second, resultSelector), static (o, t) => new ZipTaskAsyncIterator<TFirst, TSecond, TResult>(o.first, o.second.AsAsyncEnumerable(), o.resultSelector, t));

	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> AsyncIteratorEnumerable.Create((first, second, resultSelector), static (o, t) => new ZipTaskAsyncIterator<TFirst, TSecond, TResult>(o.first, o.second.AsAsyncEnumerable(), o.resultSelector, t));

	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> AsyncIteratorEnumerable.Create((first, second, resultSelector), static (o, t) => new ZipTaskAsyncIterator<TFirst, TSecond, TResult>(o.first, o.second, o.resultSelector, t));
}
