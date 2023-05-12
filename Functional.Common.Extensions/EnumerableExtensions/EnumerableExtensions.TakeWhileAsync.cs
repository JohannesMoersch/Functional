using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		foreach (var item in source)
		{
			if (!await predicate.Invoke(item))
				yield break;

			yield return item;
		}
	}

	public static async IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		int index = 0;
		foreach (var item in source)
		{
			if (!await predicate.Invoke(item, index++))
				yield break;

			yield return item;
		}
	}

	public static async IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		foreach (var item in await source)
		{
			if (!await predicate.Invoke(item))
				yield break;

			yield return item;
		}
	}

	public static async IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		int index = 0;
		foreach (var item in await source)
		{
			if (!await predicate.Invoke(item, index++))
				yield break;

			yield return item;
		}
	}

	public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.AsEnumerable().TakeWhileAsync(predicate);

	public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate)
		=> source.AsEnumerable().TakeWhileAsync(predicate);

	public static async IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		await foreach (var item in source)
		{
			if (!await predicate.Invoke(item))
				yield break;

			yield return item;
		}
	}

	public static async IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		int index = 0;
		await foreach (var item in source)
		{
			if (!await predicate.Invoke(item, index++))
				yield break;

			yield return item;
		}
	}
}
