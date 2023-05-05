using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TSource>> Skip<TSource>(this Task<IEnumerable<TSource>> source, int count)
		=> (await source).Skip(count);

	public static async Task<IEnumerable<TSource>> Skip<TSource>(this Task<IOrderedEnumerable<TSource>> source, int count)
		=> (await source).Skip(count);

	public static IAsyncEnumerable<TSource> Skip<TSource>(this IAsyncEnumerable<TSource> source, int count)
		=> AsyncIteratorEnumerable.Create((source, count), static (o, t) => BasicAsyncIterator.Create(o.source, o, static (s, i, context) => i >= context.count ? (BasicAsyncIterator.ContinuationType.Take, s) : (BasicAsyncIterator.ContinuationType.Skip, default), t));
}
