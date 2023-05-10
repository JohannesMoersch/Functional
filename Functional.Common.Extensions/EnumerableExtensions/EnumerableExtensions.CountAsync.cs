using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Collections;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<int> CountAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
	{
		int count = 0;

		foreach (var item in source)
		{
			if (await predicate.Invoke(item))
				++count;
		}

		return count;
	}

	public static async Task<int> CountAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
	{
		int count = 0;

		foreach (var item in await source)
		{
			if (await predicate.Invoke(item))
				++count;
		}

		return count;
	}

	public static Task<int> CountAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.AsEnumerable().CountAsync(predicate);

	public static async Task<int> CountAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
	{
		int count = 0;

		await foreach (var item in source)
		{
			if (await predicate.Invoke(item))
				++count;
		}

		return count;
	}
}
