	namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> Prepend<TSource>(this Task<IEnumerable<TSource>> source, TSource element)
		=> (await source).Prepend(element);

	public static async Task<IEnumerable<TSource>> Prepend<TSource>(this Task<IOrderedEnumerable<TSource>> source, TSource element)
		=> (await source).Prepend(element);

	public static async IAsyncEnumerable<TSource> Prepend<TSource>(this IAsyncEnumerable<TSource> source, TSource element)
	{
		yield return element;

		await foreach (var item in source)
			yield return item;
	}
}
