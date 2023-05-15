	namespace Functional;

public static partial class EnumerableExtensions
{
	public static async IAsyncEnumerable<TSource> PrependAsync<TSource>(this IEnumerable<TSource> source, Task<TSource> element)
	{
		yield return await element;

		foreach (var item in source)
			yield return item;
	}

	public static async IAsyncEnumerable<TSource> PrependAsync<TSource>(this Task<IEnumerable<TSource>> source, Task<TSource> element)
	{
		yield return await element;

		foreach (var item in await source)
			yield return item;
	}

	public static async IAsyncEnumerable<TSource> PrependAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Task<TSource> element)
	{
		yield return await element;

		foreach (var item in await source)
			yield return item;
	}

	public static async IAsyncEnumerable<TSource> PrependAsync<TSource>(this IAsyncEnumerable<TSource> source, Task<TSource> element)
	{
		yield return await element;

		await foreach (var item in source)
			yield return item;
	}
}
