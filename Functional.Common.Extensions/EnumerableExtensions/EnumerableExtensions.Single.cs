namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<TSource> Single<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).Single();

	public static async Task<TSource> Single<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Single(predicate);

	public static async Task<TSource> Single<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).Single();

	public static async Task<TSource> Single<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Single(predicate);

	public static async Task<TSource> Single<TSource>(this IAsyncEnumerable<TSource> source)
	{
		if (source == null)
			throw new ArgumentNullException(nameof(source));

		var enumerator = source.GetAsyncEnumerator();

		if (!await enumerator.MoveNextAsync())
			throw new InvalidOperationException("Sequence contains no elements");

		var result = enumerator.Current;

		if (await enumerator.MoveNextAsync())
			throw new InvalidOperationException("Sequence contains more than one element");

		return result;
	}

	public static Task<TSource> Single<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
		=> source.Where(predicate).Single();
}
