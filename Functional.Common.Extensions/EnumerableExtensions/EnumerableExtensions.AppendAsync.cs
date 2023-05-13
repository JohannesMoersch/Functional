namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> AppendAsync<TSource>(this IEnumerable<TSource> source, Task<TSource> element)
		=> source.Append(await element);

	public static async Task<IEnumerable<TSource>> AppendAsync<TSource>(this Task<IEnumerable<TSource>> source, Task<TSource> element)
		=> (await source).Append(await element);

	public static async Task<IEnumerable<TSource>> AppendAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Task<TSource> element)
		=> (await source).Append(await element);

	public static async IAsyncEnumerable<TSource> AppendAsync<TSource>(this IAsyncEnumerable<TSource> source, Task<TSource> element)
	{
		await foreach (var item in source)
			yield return item;

		yield return await element;
	}
}
