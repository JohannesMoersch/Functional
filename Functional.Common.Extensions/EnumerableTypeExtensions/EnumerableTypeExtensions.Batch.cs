using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static IEnumerable<IReadOnlyList<TSource>> Batch<TSource>(this IEnumerable<TSource> source, int batchSize)
		=> IteratorEnumerable.Create(() => new BatchIterator<TSource>(source.GetEnumerator(), batchSize));

	public static async Task<IEnumerable<IReadOnlyList<TSource>>> Batch<TSource>(this Task<IEnumerable<TSource>> source, int batchSize)
	{
		var input = await source;

		return IteratorEnumerable.Create(() => new BatchIterator<TSource>(input.GetEnumerator(), batchSize));
	}

	public static async Task<IEnumerable<IReadOnlyList<TSource>>> Batch<TSource>(this Task<IOrderedEnumerable<TSource>> source, int batchSize)
	{
		var input = await source;

		return IteratorEnumerable.Create(() => new BatchIterator<TSource>(input.GetEnumerator(), batchSize));
	}

	public static IAsyncEnumerable<IReadOnlyList<TSource>> Batch<TSource>(this IAsyncEnumerable<TSource> source, int batchSize)
		=> AsyncIteratorEnumerable.Create(() => new BatchAsyncIterator<TSource>(source.GetAsyncEnumerator(), batchSize));
}
