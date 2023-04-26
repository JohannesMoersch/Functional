using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TSource>> Distinct<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).Distinct();

	public static async Task<IEnumerable<TSource>> Distinct<TSource>(this Task<IEnumerable<TSource>> source, IEqualityComparer<TSource> comparer)
		=> (await source).Distinct(comparer);

	public static async Task<IEnumerable<TSource>> Distinct<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).Distinct();

	public static async Task<IEnumerable<TSource>> Distinct<TSource>(this Task<IOrderedEnumerable<TSource>> source, IEqualityComparer<TSource> comparer)
		=> (await source).Distinct(comparer);
}
