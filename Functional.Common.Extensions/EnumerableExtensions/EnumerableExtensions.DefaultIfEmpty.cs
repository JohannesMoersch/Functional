namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource?>> DefaultIfEmpty<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).DefaultIfEmpty();

	public static async Task<IEnumerable<TSource>> DefaultIfEmpty<TSource>(this Task<IEnumerable<TSource>> source, TSource defaultValue)
		=> (await source).DefaultIfEmpty(defaultValue);

	public static async Task<IEnumerable<TSource?>> DefaultIfEmpty<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).DefaultIfEmpty();

	public static async Task<IEnumerable<TSource>> DefaultIfEmpty<TSource>(this Task<IOrderedEnumerable<TSource>> source, TSource defaultValue)
		=> (await source).DefaultIfEmpty(defaultValue);

	public static IAsyncEnumerable<TSource?> DefaultIfEmpty<TSource>(this IAsyncEnumerable<TSource> source)
		=> source.DefaultIfEmpty(default);

	public static async IAsyncEnumerable<TSource> DefaultIfEmpty<TSource>(this IAsyncEnumerable<TSource> source, TSource defaultValue)
	{
		bool returnDefault = true;

		await foreach (var item in source)
		{
			returnDefault = false;
			yield return item;
		}

		if (returnDefault)
			yield return defaultValue;
	}
}
