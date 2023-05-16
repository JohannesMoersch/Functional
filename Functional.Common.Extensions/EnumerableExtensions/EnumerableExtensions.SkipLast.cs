namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> SkipLast<TSource>(this Task<IEnumerable<TSource>> source, int count)
		=> (await source).SkipLast(count);

	public static async Task<IEnumerable<TSource>> SkipLast<TSource>(this Task<IOrderedEnumerable<TSource>> source, int count)
		=> (await source).SkipLast(count);

	public static IAsyncEnumerable<TSource> SkipLast<TSource>(this IAsyncEnumerable<TSource> source, int count)
		=> count > 0
			? SkipLastIterator(source, count)
			: source.Skip(0);

	private static async IAsyncEnumerable<TSource> SkipLastIterator<TSource>(IAsyncEnumerable<TSource> source, int count)
	{
		var queue = new Queue<TSource>();

		await foreach (var item in source)
		{
			if (queue.Count == count)
				yield return queue.Dequeue();

			queue.Enqueue(item);
		}
	}
}
