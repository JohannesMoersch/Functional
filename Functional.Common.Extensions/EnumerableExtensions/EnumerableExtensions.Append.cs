using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> Append<TSource>(this Task<IEnumerable<TSource>> source, TSource element)
		=> (await source).Append(element);

	public static async Task<IEnumerable<TSource>> Append<TSource>(this Task<IOrderedEnumerable<TSource>> source, TSource element)
		=> (await source).Append(element);

	public static async IAsyncEnumerable<TSource> Append<TSource>(this IAsyncEnumerable<TSource> source, TSource element)
	{
		await foreach (var item in source)
			yield return item;

		yield return element;
	}
}
