using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<TSource[]> ToArray<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).ToArray();

	public static async Task<TSource[]> ToArray<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).ToArray();

	public static async Task<TSource[]> ToArray<TSource>(this IAsyncEnumerable<TSource> source)
	{
		var list = await source.ToList();

		var arr = new TSource[list.Count];

		list.CopyTo(arr);

		return arr;
	}
}
