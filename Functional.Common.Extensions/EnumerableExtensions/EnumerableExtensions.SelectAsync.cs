using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().SelectAsync(selector);

	public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().SelectAsync(selector);

	public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().SelectAsync(selector);

	public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().SelectAsync(selector);

	public static async IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		await foreach (var item in source)
			yield return await selector.Invoke(item);
	}

	public static async IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		int index = 0;
		await foreach (var item in source)
			yield return await selector.Invoke(item, index++);
	}

	public static IAsyncEnumerable<TSource> SelectAsync<TSource>(this IEnumerable<Task<TSource>> source)
		=> source.SelectAsync(_ => _);

	public static IAsyncEnumerable<TSource> SelectAsync<TSource>(this Task<IEnumerable<Task<TSource>>> source)
		=> source.SelectAsync(_ => _);

	public static IAsyncEnumerable<TSource> SelectAsync<TSource>(this IAsyncEnumerable<Task<TSource>> source)
		=> source.SelectAsync(_ => _);
}
