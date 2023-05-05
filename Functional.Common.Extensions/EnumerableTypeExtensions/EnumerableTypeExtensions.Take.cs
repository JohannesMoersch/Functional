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
		=> AsyncIteratorEnumerable.Create((source, count), static (o, t) => BasicAsyncIterator.Create(o.source, o, static (s, i, context) => i < context.count ? (BasicAsyncIterator.ContinuationType.Take, s) : (BasicAsyncIterator.ContinuationType.Stop, default), t));
}
