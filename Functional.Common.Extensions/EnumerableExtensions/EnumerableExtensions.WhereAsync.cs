using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async IAsyncEnumerable<TSource> WhereAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
	{
		foreach (var item in source)
		{
			if (await predicate.Invoke(item))
				yield return item;
		}
	}

	public static async IAsyncEnumerable<TSource> WhereAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
	{
		int index = 0;
		foreach (var item in source)
		{
			if (await predicate.Invoke(item, index++))
				yield return item;
		}
	}

	public static async IAsyncEnumerable<TSource> WhereAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
	{
		foreach (var item in await source)
		{
			if (await predicate.Invoke(item))
				yield return item;
		}
	}

	public static async IAsyncEnumerable<TSource> WhereAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate)
	{
		int index = 0;
		foreach (var item in await source)
		{
			if (await predicate.Invoke(item, index++))
				yield return item;
		}
	}

	public static IAsyncEnumerable<TSource> WhereAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.AsEnumerable().WhereAsync(predicate);

	public static IAsyncEnumerable<TSource> WhereAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate)
		=> source.AsEnumerable().WhereAsync(predicate);

	public static async IAsyncEnumerable<TSource> WhereAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
	{
		await foreach (var item in source)
		{
			if (await predicate.Invoke(item))
				yield return item;
		}
	}

	public static async IAsyncEnumerable<TSource> WhereAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
	{
		int index = 0;
		await foreach (var item in source)
		{
			if (await predicate.Invoke(item, index++))
				yield return item;
		}
	}
}
