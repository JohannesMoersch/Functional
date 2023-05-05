using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> AsyncIteratorEnumerable.Create((first, second, resultSelector), static (o, t) => new ZipAsyncIterator<TFirst, TSecond, TResult>(o.first.AsAsyncEnumerable(), o.second, o.resultSelector, t));

	public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> AsyncIteratorEnumerable.Create((first, second, resultSelector), static (o, t) => new ZipAsyncIterator<TFirst, TSecond, TResult>(o.first.AsAsyncEnumerable(), o.second, o.resultSelector, t));

	public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> AsyncIteratorEnumerable.Create((first, second, resultSelector), static (o, t) => new ZipAsyncIterator<TFirst, TSecond, TResult>(o.first, o.second.AsAsyncEnumerable(), o.resultSelector, t));

	public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> AsyncIteratorEnumerable.Create((first, second, resultSelector), static (o, t) => new ZipAsyncIterator<TFirst, TSecond, TResult>(o.first, o.second.AsAsyncEnumerable(), o.resultSelector, t));

	public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> (await first).Zip(second, resultSelector);

	public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> first.Zip(await second, resultSelector);

	public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> (await first).Zip(await second, resultSelector);

	public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> AsyncIteratorEnumerable.Create((first, second, resultSelector), static (o, t) => new ZipAsyncIterator<TFirst, TSecond, TResult>(o.first, o.second, o.resultSelector, t));

	public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IOrderedEnumerable<TFirst>> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> (await first).Zip(second, resultSelector);

	public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, Task<IOrderedEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> first.Zip(await second, resultSelector);

	public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IOrderedEnumerable<TFirst>> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> (await first).Zip(await second, resultSelector);

	public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, Task<IOrderedEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> (await first).Zip(await second, resultSelector);

	public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IOrderedEnumerable<TFirst>> first, Task<IOrderedEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> (await first).Zip(await second, resultSelector);
}
