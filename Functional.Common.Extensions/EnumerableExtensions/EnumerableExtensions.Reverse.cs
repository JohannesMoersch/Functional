using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TSource>> Reverse<TSource>(this Task<IEnumerable<TSource>> source)
			=> (await source).Reverse();

	public static async Task<IEnumerable<TSource>> Reverse<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).Reverse();
}
