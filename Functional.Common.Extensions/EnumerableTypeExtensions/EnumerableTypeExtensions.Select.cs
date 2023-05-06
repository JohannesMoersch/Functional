using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, TResult> selector)
		=> (await source).Select(selector);

	public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, TResult> selector)
		=> (await source).Select(selector);

	public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TResult> selector)
		=> (await source).Select(selector);

	public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, TResult> selector)
		=> (await source).Select(selector);

	public static async IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, TResult> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		await foreach (var item in source)
			yield return selector.Invoke(item);
	}

	public static async IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, TResult> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));
		
		int index = 0;
		await foreach (var item in source)
			yield return selector.Invoke(item, index++);
	}
}
