using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TSource>> SkipWhile<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).SkipWhile(predicate);

	public static async Task<IEnumerable<TSource>> SkipWhile<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, bool> predicate)
		=> (await source).SkipWhile(predicate);

	public static async Task<IEnumerable<TSource>> SkipWhile<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).SkipWhile(predicate);

	public static async Task<IEnumerable<TSource>> SkipWhile<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, bool> predicate)
		=> (await source).SkipWhile(predicate);

	public static async IAsyncEnumerable<TSource> SkipWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		bool skipping = true;
		await foreach (var item in source)
		{
			if (!skipping || !(skipping = predicate.Invoke(item)))
				yield return item;
		}
	}

	public static async IAsyncEnumerable<TSource> SkipWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		bool skipping = true;
		int index = 0;
		await foreach (var item in source)
		{
			if (!skipping || !(skipping = predicate.Invoke(item, index++)))
				yield return item;
		}
	}
}
