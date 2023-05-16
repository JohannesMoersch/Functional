namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> TakeLast<TSource>(this Task<IEnumerable<TSource>> source, int count)
		=> (await source).TakeLast(count);

	public static async Task<IEnumerable<TSource>> TakeLast<TSource>(this Task<IOrderedEnumerable<TSource>> source, int count)
		=> (await source).TakeLast(count);

	public static async Task<IEnumerable<TSource>> TakeLast<TSource>(this IAsyncEnumerable<TSource> source, int count)
		=> (await source.AsEnumerable()).TakeLast(count);
}
