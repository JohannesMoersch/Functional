using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TSource>> Take<TSource>(this Task<IEnumerable<TSource>> source, int count)
		=> (await source).Take(count);

	public static async Task<IEnumerable<TSource>> Take<TSource>(this Task<IOrderedEnumerable<TSource>> source, int count)
		=> (await source).Take(count);

	public static IAsyncEnumerable<TSource> Take<TSource>(this IAsyncEnumerable<TSource> source, int count)
		=> AsyncIteratorEnumerable.Create(() => new BasicAsyncIterator<TSource, TSource>(source, data => data.index < count ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Stop, default)));
}
