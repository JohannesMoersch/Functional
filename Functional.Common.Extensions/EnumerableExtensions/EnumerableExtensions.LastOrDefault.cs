namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<TSource?> LastOrDefault<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).LastOrDefault();

	public static async Task<TSource> LastOrDefault<TSource>(this Task<IEnumerable<TSource>> source, TSource defaultValue)
		=> (await source).LastOrDefault(defaultValue);

	public static async Task<TSource?> LastOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).LastOrDefault(predicate);

	public static async Task<TSource> LastOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate, TSource defaultValue)
		=> (await source).LastOrDefault(predicate, defaultValue);

	public static async Task<TSource?> LastOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).LastOrDefault();

	public static async Task<TSource> LastOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, TSource defaultValue)
		=> (await source).LastOrDefault(defaultValue);

	public static async Task<TSource?> LastOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).LastOrDefault(predicate);

	public static async Task<TSource> LastOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate, TSource defaultValue)
		=> (await source).LastOrDefault(predicate, defaultValue);

	public static async Task<TSource?> LastOrDefault<TSource>(this IAsyncEnumerable<TSource> source)
		=> (await source.AsEnumerable()).LastOrDefault();

	public static async Task<TSource> LastOrDefault<TSource>(this IAsyncEnumerable<TSource> source, TSource defaultValue)
		=> (await source.AsEnumerable()).LastOrDefault(defaultValue);

	public static async Task<TSource?> LastOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
		=> (await source.AsEnumerable()).LastOrDefault(predicate);

	public static async Task<TSource> LastOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue)
		=> (await source.AsEnumerable()).LastOrDefault(predicate, defaultValue);
}
