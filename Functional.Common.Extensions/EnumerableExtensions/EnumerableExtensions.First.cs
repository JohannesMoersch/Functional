namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<TSource> First<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).First();

	public static async Task<TSource> First<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).First(predicate);

	public static async Task<TSource> First<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).First();

	public static async Task<TSource> First<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).First(predicate);

	public static async Task<TSource> First<TSource>(this IAsyncEnumerable<TSource> source)
	{
		if (source == null)
			throw new ArgumentNullException(nameof(source));

		var enumerator = source.GetAsyncEnumerator();

		return (await enumerator.MoveNextAsync()) ? enumerator.Current : throw new InvalidOperationException("Sequence contains no elements");
	}

	public static Task<TSource> First<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
		=> source.Where(predicate).First();
}
