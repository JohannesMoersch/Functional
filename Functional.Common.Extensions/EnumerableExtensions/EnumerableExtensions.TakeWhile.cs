using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> TakeWhile<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).TakeWhile(predicate);

	public static async Task<IEnumerable<TSource>> TakeWhile<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, bool> predicate)
		=> (await source).TakeWhile(predicate);

	public static async Task<IEnumerable<TSource>> TakeWhile<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).TakeWhile(predicate);

	public static async Task<IEnumerable<TSource>> TakeWhile<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, bool> predicate)
		=> (await source).TakeWhile(predicate);

	public static async IAsyncEnumerable<TSource> TakeWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		await foreach (var item in source)
		{
			if (!predicate.Invoke(item))
				yield break;

			yield return item;
		}
	}

	public static async IAsyncEnumerable<TSource> TakeWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		int index = 0;
		await foreach (var item in source)
		{
			if (!predicate.Invoke(item, index++))
				yield break;

			yield return item;
		}
	}
}
