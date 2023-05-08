using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<TSource> ElementAt<TSource>(this Task<IEnumerable<TSource>> source, int index)
		=> (await source).ElementAt(index);

	public static async Task<TSource> ElementAt<TSource>(this Task<IOrderedEnumerable<TSource>> source, int index)
		=> (await source).ElementAt(index);

	public static async Task<TSource> ElementAt<TSource>(this IAsyncEnumerable<TSource> source, int index)
	{
		if (source == null)
			throw new ArgumentNullException(nameof(source));

		var enumerator = source.GetAsyncEnumerator();

		for (int i = 0; i <= index; ++i)
		{
			if (!await enumerator.MoveNextAsync())
				throw new ArgumentOutOfRangeException(nameof(index), "Index was out of range. Must be non-negative and less than the size of the collection.");
		}

		return enumerator.Current;
	}
}
