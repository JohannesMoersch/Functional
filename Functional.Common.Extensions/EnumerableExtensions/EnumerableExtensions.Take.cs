using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> Take<TSource>(this Task<IEnumerable<TSource>> source, int count)
		=> (await source).Take(count);

	public static async Task<IEnumerable<TSource>> Take<TSource>(this Task<IOrderedEnumerable<TSource>> source, int count)
		=> (await source).Take(count);

	public static async IAsyncEnumerable<TSource> Take<TSource>(this IAsyncEnumerable<TSource> source, int count)
	{
		if (count <= 0)
			yield break;

		int index = 0;
		await foreach (var item in source)
		{
			yield return item;
			if (++index == count)
				break;
		}
	}
}
