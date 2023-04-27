using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TSource>> Append<TSource>(this Task<IEnumerable<TSource>> source, TSource element)
		=> (await source).Append(element);

	public static async Task<IEnumerable<TSource>> Append<TSource>(this Task<IOrderedEnumerable<TSource>> source, TSource element)
		=> (await source).Append(element);

	public static IAsyncEnumerable<TSource> Append<TSource>(this IAsyncEnumerable<TSource> source, TSource element)
		=> AsyncIteratorEnumerable.Create(() => new AppendAsyncIterator<TSource>(source, element));
}
