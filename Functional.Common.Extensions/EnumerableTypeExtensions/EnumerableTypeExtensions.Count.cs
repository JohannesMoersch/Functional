using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Collections;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<int> Count<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).Count();

	public static async Task<int> Count<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Count(predicate);

	public static async Task<int> Count<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).Count();

	public static async Task<int> Count<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Count(predicate);

	public static Task<int> Count<TSource>(this IAsyncEnumerable<TSource> source)
		=> source.Count(static _ => true);

	public static async Task<int> Count<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		int count = 0;

		await foreach (var item in source)
		{
			if (predicate.Invoke(item))
				++count;
		}

		return count;
	}
}
