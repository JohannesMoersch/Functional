using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task ApplyAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		foreach (var item in source)
			await action.Invoke(item);
	}

	public static async Task ApplyAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		var index = 0;
		foreach (var item in source)
			await action.Invoke(item, index++);
	}

	public static async Task ApplyAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		foreach (var item in await source)
			await action.Invoke(item);
	}

	public static async Task ApplyAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		var index = 0;
		foreach (var item in await source)
			await action.Invoke(item, index++);
	}

	public static async Task ApplyAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		var enumerator = source.GetAsyncEnumerator();

		while (await enumerator.MoveNextAsync())
			await action.Invoke(enumerator.Current);
	}

	public static async Task ApplyAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		var enumerator = source.GetAsyncEnumerator();

		var index = 0;
		while (await enumerator.MoveNextAsync())
		{
			await action.Invoke(enumerator.Current, index);
			++index;
		}
	}
}
