using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static void Apply<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		foreach (var item in source)
			action.Invoke(item);
	}

	public static void Apply<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		var index = 0;
		foreach (var item in source)
			action.Invoke(item, index++);
	}

	public static async Task Apply<TSource>(this Task<IEnumerable<TSource>> source, Action<TSource> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		foreach (var item in await source)
			action.Invoke(item);
	}

	public static async Task Apply<TSource>(this Task<IEnumerable<TSource>> source, Action<TSource, int> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		var index = 0;
		foreach (var item in await source)
			action.Invoke(item, index++);
	}

	public static async Task Apply<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		var enumerator = source.GetAsyncEnumerator();

		while (await enumerator.MoveNextAsync())
			action.Invoke(enumerator.Current);
	}

	public static async Task Apply<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource, int> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		var enumerator = source.GetAsyncEnumerator();

		var index = 0;
		while (await enumerator.MoveNextAsync())
		{
			action.Invoke(enumerator.Current, index);
			++index;
		}
	}
}
