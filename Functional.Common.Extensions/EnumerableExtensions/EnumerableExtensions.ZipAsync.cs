using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
	{
		using var e1 = first.GetEnumerator();
		using var e2 = second.GetEnumerator();

		while (e1.MoveNext() && e2.MoveNext())
			yield return await resultSelector.Invoke(e1.Current, e2.Current);
	}

	public static async IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
	{
		using var e1 = first.GetEnumerator();
		using var e2 = (await second).GetEnumerator();

		while (e1.MoveNext() && e2.MoveNext())
			yield return await resultSelector.Invoke(e1.Current, e2.Current);
	}

	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, Task<IOrderedEnumerable<TSecond>> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> first.ZipAsync(second.AsEnumerable(), resultSelector);

	public static async IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
	{
		using var e1 = first.GetEnumerator();
		await using var e2 = second.GetAsyncEnumerator();

		while (e1.MoveNext() && await e2.MoveNextAsync())
			yield return await resultSelector.Invoke(e1.Current, e2.Current);
	}

	public static async IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
	{
		using var e1 = (await first).GetEnumerator();
		using var e2 = second.GetEnumerator();

		while (e1.MoveNext() && e2.MoveNext())
			yield return await resultSelector.Invoke(e1.Current, e2.Current);
	}

	public static async IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
	{
		using var e1 = (await first).GetEnumerator();
		using var e2 = (await second).GetEnumerator();

		while (e1.MoveNext() && e2.MoveNext())
			yield return await resultSelector.Invoke(e1.Current, e2.Current);
	}

	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, Task<IOrderedEnumerable<TSecond>> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> first.ZipAsync(second.AsEnumerable(), resultSelector);

	public static async IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
	{
		using var e1 = (await first).GetEnumerator();
		await using var e2 = second.GetAsyncEnumerator();

		while (e1.MoveNext() && await e2.MoveNextAsync())
			yield return await resultSelector.Invoke(e1.Current, e2.Current);
	}

	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this Task<IOrderedEnumerable<TFirst>> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> first.AsEnumerable().ZipAsync(second, resultSelector);

	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this Task<IOrderedEnumerable<TFirst>> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> first.AsEnumerable().ZipAsync(second, resultSelector);

	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this Task<IOrderedEnumerable<TFirst>> first, Task<IOrderedEnumerable<TSecond>> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> first.AsEnumerable().ZipAsync(second, resultSelector);

	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this Task<IOrderedEnumerable<TFirst>> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> first.AsEnumerable().ZipAsync(second, resultSelector);

	public static async IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
	{
		await using var e1 = first.GetAsyncEnumerator();
		using var e2 = second.GetEnumerator();

		while (await e1.MoveNextAsync() && e2.MoveNext())
			yield return await resultSelector.Invoke(e1.Current, e2.Current);
	}

	public static async IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
	{
		await using var e1 = first.GetAsyncEnumerator();
		using var e2 = (await second).GetEnumerator();

		while (await e1.MoveNextAsync() && e2.MoveNext())
			yield return await resultSelector.Invoke(e1.Current, e2.Current);
	}

	public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, Task<IOrderedEnumerable<TSecond>> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		=> first.ZipAsync(second.AsEnumerable(), resultSelector);

	public static async IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
	{
		await using var e1 = first.GetAsyncEnumerator();
		await using var e2 = second.GetAsyncEnumerator();

		while (await e1.MoveNextAsync() && await e2.MoveNextAsync())
			yield return await resultSelector.Invoke(e1.Current, e2.Current);
	}
}
