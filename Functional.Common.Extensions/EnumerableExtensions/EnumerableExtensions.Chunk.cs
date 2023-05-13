namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource[]>> Chunk<TSource>(this Task<IEnumerable<TSource>> source, int batchSize)
		=> (await source).Chunk(batchSize);

	public static async Task<IEnumerable<TSource[]>> Chunk<TSource>(this Task<IOrderedEnumerable<TSource>> source, int batchSize)
		=> (await source).Chunk(batchSize);

	public static async IAsyncEnumerable<TSource[]> Chunk<TSource>(this IAsyncEnumerable<TSource> source, int batchSize)
	{
		var batch = Array.Empty<TSource>();
		int count = 0;
		await foreach (var item in source)
		{
			if (count == 0)
				batch = new TSource[batchSize];

			batch[count++] = item;

			if (count == batchSize)
			{
				count = 0;
				yield return batch;
			}
		}

		if (count > 0)
		{
			if (count < batchSize)
				Array.Resize(ref batch, count);

			yield return batch;
		}
	}
}

