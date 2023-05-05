using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static IEnumerable<IReadOnlyList<TSource>> Batch<TSource>(this IEnumerable<TSource> source, int batchSize)
		=> IteratorEnumerable.Create((source, batchSize), static o => new BatchIterator<TSource>(o.source, o.batchSize));

	public static async Task<IEnumerable<IReadOnlyList<TSource>>> Batch<TSource>(this Task<IEnumerable<TSource>> source, int batchSize)
	{
		var input = await source;

		return IteratorEnumerable.Create((input, batchSize), static o => new BatchIterator<TSource>(o.input, o.batchSize));
	}

	public static async Task<IEnumerable<IReadOnlyList<TSource>>> Batch<TSource>(this Task<IOrderedEnumerable<TSource>> source, int batchSize)
	{
		var input = await source;

		return IteratorEnumerable.Create((input, batchSize), static o => new BatchIterator<TSource>(o.input, o.batchSize));
	}

	public static IAsyncEnumerable<IReadOnlyList<TSource>> Batch<TSource>(this IAsyncEnumerable<TSource> source, int batchSize)
		=> AsyncIteratorEnumerable.Create((source, batchSize), static (o, t) => new BatchAsyncIterator<TSource>(o.source, o.batchSize, t));
}
