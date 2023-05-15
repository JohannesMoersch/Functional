namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<TSource?> SingleOrDefault<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).SingleOrDefault();

	public static async Task<TSource?> SingleOrDefault<TSource>(this Task<IEnumerable<TSource>> source, TSource defaultValue)
		=> (await source).SingleOrDefault(defaultValue);

	public static async Task<TSource?> SingleOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).SingleOrDefault(predicate);

	public static async Task<TSource?> SingleOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate, TSource defaultValue)
		=> (await source).SingleOrDefault(predicate, defaultValue);

	public static async Task<TSource?> SingleOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).SingleOrDefault();

	public static async Task<TSource?> SingleOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, TSource defaultValue)
		=> (await source).SingleOrDefault(defaultValue);

	public static async Task<TSource?> SingleOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).SingleOrDefault(predicate);

	public static async Task<TSource?> SingleOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate, TSource defaultValue)
		=> (await source).SingleOrDefault(predicate, defaultValue);

	public static Task<TSource?> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source)
		=> source.SingleOrDefault(default(TSource));

	public static async Task<TSource?> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source, TSource defaultValue)
	{
		if (source == null)
			throw new ArgumentNullException(nameof(source));

		var enumerator = source.GetAsyncEnumerator();

		if (!await enumerator.MoveNextAsync())
			return default;

		var result = enumerator.Current;

		if (await enumerator.MoveNextAsync())
			throw new InvalidOperationException("Sequence contains more than one element");

		return result;
	}

	public static Task<TSource?> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
		=> source.Where(predicate).SingleOrDefault(default(TSource));

	public static Task<TSource?> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue)
		=> source.Where(predicate).SingleOrDefault(defaultValue);
}
