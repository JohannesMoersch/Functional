namespace Functional;

public static partial class EnumerableExtensions
{
	public static async IAsyncEnumerable<TSource> AppendAsync<TSource>(this IEnumerable<TSource> source, Task<TSource> element)
	{
		foreach (var item in source)
			yield return item;

		yield return await element;
	}

	public static async IAsyncEnumerable<TSource> AppendAsync<TSource>(this Task<IEnumerable<TSource>> source, Task<TSource> element)
	{
		foreach (var item in await source)
			yield return item;

		yield return await element;
	}

	public static async IAsyncEnumerable<TSource> AppendAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Task<TSource> element)
	{
		foreach (var item in await source)
			yield return item;

		yield return await element;
	}

	public static async IAsyncEnumerable<TSource> AppendAsync<TSource>(this IAsyncEnumerable<TSource> source, Task<TSource> element)
	{
		await foreach (var item in source)
			yield return item;

		yield return await element;
	}
}
