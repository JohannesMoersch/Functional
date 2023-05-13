namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<TSource> Last<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).Last();

	public static async Task<TSource> Last<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Last(predicate);

	public static async Task<TSource> Last<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).Last();

	public static async Task<TSource> Last<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Last(predicate);

	public static async Task<TSource> Last<TSource>(this IAsyncEnumerable<TSource> source)
		=> (await source.AsEnumerable()).Last();

	public static async Task<TSource> Last<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
		=> (await source.AsEnumerable()).Last(predicate);
}
