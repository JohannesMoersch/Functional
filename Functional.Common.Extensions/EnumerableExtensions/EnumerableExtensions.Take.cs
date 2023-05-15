namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> Take<TSource>(this Task<IEnumerable<TSource>> source, int count)
		=> (await source).Take(count);

	public static async Task<IEnumerable<TSource>> Take<TSource>(this Task<IEnumerable<TSource>> source, Range range)
		=> (await source).Take(range);

	public static async Task<IEnumerable<TSource>> Take<TSource>(this Task<IOrderedEnumerable<TSource>> source, int count)
		=> (await source).Take(count);

	public static async Task<IEnumerable<TSource>> Take<TSource>(this Task<IOrderedEnumerable<TSource>> source, Range range)
		=> (await source).Take(range);

	public static IAsyncEnumerable<TSource> Take<TSource>(this IAsyncEnumerable<TSource> source, int count)
		=> TakeIterator(source, 0, count);

	public static IAsyncEnumerable<TSource> Take<TSource>(this IAsyncEnumerable<TSource> source, Range range)
		=> range.Start.IsFromEnd || range.End.IsFromEnd
			? source.AsEnumerable().Take(range).AsAsyncEnumerable()
			: TakeIterator(source, range.Start.Value, range.End.Value);

	private static async IAsyncEnumerable<TSource> TakeIterator<TSource>(IAsyncEnumerable<TSource> source, int start, int end)
	{
		if (end <= start)
			yield break;

		int index = 0;
		await foreach (var item in source)
		{
			if (index++ >= start)
				yield return item;
			
			if (index == end)
				break;
		}
	}
}
