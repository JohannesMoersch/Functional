namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> Where<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Where(predicate);

	public static async Task<IEnumerable<TSource>> Where<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, bool> predicate)
		=> (await source).Where(predicate);

	public static async Task<IEnumerable<TSource>> Where<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Where(predicate);

	public static async Task<IEnumerable<TSource>> Where<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, bool> predicate)
		=> (await source).Where(predicate);

	public static async IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		await foreach (var item in source)
		{
			if (predicate.Invoke(item))
				yield return item;
		}
	}

	public static async IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		int index = 0;
		await foreach (var item in source)
		{
			if (predicate.Invoke(item, index++))
				yield return item;
		}
	}
}
