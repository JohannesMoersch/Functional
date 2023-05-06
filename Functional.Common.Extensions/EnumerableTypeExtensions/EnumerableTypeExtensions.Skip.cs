using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TSource>> Skip<TSource>(this Task<IEnumerable<TSource>> source, int count)
		=> (await source).Skip(count);

	public static async Task<IEnumerable<TSource>> Skip<TSource>(this Task<IOrderedEnumerable<TSource>> source, int count)
		=> (await source).Skip(count);

	public static async IAsyncEnumerable<TSource> Skip<TSource>(this IAsyncEnumerable<TSource> source, int count)
	{
		int index = 0;
		await foreach (var item in source)
		{
			if (index++ >= count)
				yield return item;
		}
	}
}
