namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<TSource?> FirstOrDefault<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).FirstOrDefault();

	public static async Task<TSource> FirstOrDefault<TSource>(this Task<IEnumerable<TSource>> source, TSource defaultValue)
		=> (await source).FirstOrDefault(defaultValue);

	public static async Task<TSource?> FirstOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).FirstOrDefault(predicate);

	public static async Task<TSource> FirstOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate, TSource defaultValue)
		=> (await source).FirstOrDefault(predicate, defaultValue);

	public static async Task<TSource?> FirstOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).FirstOrDefault();

	public static async Task<TSource> FirstOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, TSource defaultValue)
		=> (await source).FirstOrDefault(defaultValue);

	public static async Task<TSource?> FirstOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).FirstOrDefault(predicate);

	public static async Task<TSource> FirstOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate, TSource defaultValue)
		=> (await source).FirstOrDefault(predicate, defaultValue);

	public static Task<TSource?> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source)
		=> source.FirstOrDefault(default(TSource));

	public static async Task<TSource> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source, TSource defaultValue)
	{
		if (source == null)
			throw new ArgumentNullException(nameof(source));

		var enumerator = source.GetAsyncEnumerator();

		return (await enumerator.MoveNextAsync()) ? enumerator.Current : defaultValue;
	}

	public static Task<TSource?> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
		=> source.Where(predicate).FirstOrDefault(default(TSource));

	public static Task<TSource> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue)
		=> source.Where(predicate).FirstOrDefault(defaultValue);
}
