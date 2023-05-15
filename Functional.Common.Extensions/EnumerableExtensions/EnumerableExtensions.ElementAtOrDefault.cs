namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<TSource?> ElementAtOrDefault<TSource>(this Task<IEnumerable<TSource>> source, int index)
		=> (await source).ElementAtOrDefault(index);

	public static async Task<TSource?> ElementAtOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Index index)
		=> (await source).ElementAtOrDefault(index);

	public static async Task<TSource?> ElementAtOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, int index)
		=> (await source).ElementAtOrDefault(index);

	public static async Task<TSource?> ElementAtOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, Index index)
		=> (await source).ElementAtOrDefault(index);

	public static async Task<TSource?> ElementAtOrDefault<TSource>(this IAsyncEnumerable<TSource> source, int index)
	{
		if (source == null)
			throw new ArgumentNullException(nameof(source));

		var enumerator = source.GetAsyncEnumerator();

		for (int i = 0; i <= index; ++i)
		{
			if (!await enumerator.MoveNextAsync())
				return default;
		}

		return enumerator.Current;
	}

	public static Task<TSource?> ElementAtOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Index index)
		=> index.IsFromEnd
			? source.AsEnumerable().ElementAtOrDefault(index)
			: source.ElementAtOrDefault(index.Value);
}
