namespace Functional;

public static partial class EnumerableExtensions
{
	public static IEnumerable<TSource> Cached<TSource>(this IEnumerable<TSource> source)
		=> new ReplayableEnumerable<TSource>(source);

	public static async Task<IEnumerable<TSource>> Cached<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).Cached();

	public static async Task<IEnumerable<TSource>> Cached<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).Cached();

	public static IAsyncEnumerable<TSource> Cached<TSource>(this IAsyncEnumerable<TSource> source)
		=> new ReplayableAsyncEnumerable<TSource>(source);
}
