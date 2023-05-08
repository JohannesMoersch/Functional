using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> Distinct<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).Distinct();

	public static async Task<IEnumerable<TSource>> Distinct<TSource>(this Task<IEnumerable<TSource>> source, IEqualityComparer<TSource> comparer)
		=> (await source).Distinct(comparer);

	public static async Task<IEnumerable<TSource>> Distinct<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).Distinct();

	public static async Task<IEnumerable<TSource>> Distinct<TSource>(this Task<IOrderedEnumerable<TSource>> source, IEqualityComparer<TSource> comparer)
		=> (await source).Distinct(comparer);

	public static IAsyncEnumerable<TSource> Distinct<TSource>(this IAsyncEnumerable<TSource> source)
		=> source.Distinct(EqualityComparer<TSource>.Default);

	public static async IAsyncEnumerable<TSource> Distinct<TSource>(this IAsyncEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
	{
		var set = new HashSet<TSource>(comparer);

		await foreach (var item in source)
		{
			if (set.Add(item))
				yield return item;
		}
	}
}
