using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TSource>> Concat<TSource>(this IEnumerable<TSource> first, Task<IEnumerable<TSource>> second)
		=> first.Concat(await second);

	public static async Task<IEnumerable<TSource>> Concat<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
		=> first.Concat(await second);

	public static async IAsyncEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
	{
		if (second is null) throw new ArgumentNullException(nameof(second));

		foreach (var item in first)
			yield return item;

		await foreach (var item in second)
			yield return item;
	}

	public static async Task<IEnumerable<TSource>> Concat<TSource>(this Task<IEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> (await first).Concat(second);

	public static async Task<IEnumerable<TSource>> Concat<TSource>(this Task<IEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> (await first).Concat(await second);

	public static async Task<IEnumerable<TSource>> Concat<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> (await first).Concat(await second);

	public static async IAsyncEnumerable<TSource> Concat<TSource>(this Task<IEnumerable<TSource>> first, IAsyncEnumerable<TSource> second)
	{
		if (second is null) throw new ArgumentNullException(nameof(second));

		foreach (var item in await first)
			yield return item;

		await foreach (var item in second)
			yield return item;
	}

	public static Task<IEnumerable<TSource>> Concat<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second)
		=> first.AsEnumerable().Concat(second);

	public static Task<IEnumerable<TSource>> Concat<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
		=> first.AsEnumerable().Concat(second);

	public static Task<IEnumerable<TSource>> Concat<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
		=> first.AsEnumerable().Concat(second);

	public static IAsyncEnumerable<TSource> Concat<TSource>(this Task<IOrderedEnumerable<TSource>> first, IAsyncEnumerable<TSource> second)
		=> first.AsEnumerable().Concat(second);

	public static async IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second)
	{
		if (second is null) throw new ArgumentNullException(nameof(second));

		await foreach (var item in first)
			yield return item;

		foreach (var item in second)
			yield return item;
	}

	public static async IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, Task<IEnumerable<TSource>> second)
	{
		if (second is null) throw new ArgumentNullException(nameof(second));

		await foreach (var item in first)
			yield return item;

		foreach (var item in await second)
			yield return item;
	}

	public static IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
		=> first.Concat(second.AsEnumerable());

	public static async IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
	{
		if (second is null) throw new ArgumentNullException(nameof(second));

		await foreach (var item in first)
			yield return item;

		await foreach (var item in second)
			yield return item;
	}
}
