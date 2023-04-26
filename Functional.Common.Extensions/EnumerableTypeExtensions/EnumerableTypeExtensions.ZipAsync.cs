using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> AsyncIteratorEnumerable.Create(() => new ZipTaskAsyncIterator<TFirst, TSecond, TResult>(first.AsAsyncEnumerable(), second, resultSelector));

	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> AsyncIteratorEnumerable.Create(() => new ZipTaskAsyncIterator<TFirst, TSecond, TResult>(first.AsAsyncEnumerable(), second, resultSelector));

	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> AsyncIteratorEnumerable.Create(() => new ZipTaskAsyncIterator<TFirst, TSecond, TResult>(first, second.AsAsyncEnumerable(), resultSelector));

	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> AsyncIteratorEnumerable.Create(() => new ZipTaskAsyncIterator<TFirst, TSecond, TResult>(first, second.AsAsyncEnumerable(), resultSelector));

	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> AsyncIteratorEnumerable.Create(() => new ZipTaskAsyncIterator<TFirst, TSecond, TResult>(first, second, resultSelector));
}
