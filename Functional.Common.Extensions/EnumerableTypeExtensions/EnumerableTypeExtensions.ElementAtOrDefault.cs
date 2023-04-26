using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<TSource?> ElementAtOrDefault<TSource>(this Task<IEnumerable<TSource>> source, int index)
		=> (await source).ElementAtOrDefault(index);

	public static async Task<TSource?> ElementAtOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, int index)
		=> (await source).ElementAtOrDefault(index);

	public static async Task<TSource?> ElementAtOrDefault<TSource>(this IAsyncEnumerable<TSource> source, int index)
	{
		if (source == null)
			throw new ArgumentNullException(nameof(source));

		var enumerator = source.GetAsyncEnumerator();

		for (int i = 0; i <= index; ++i)
		{
			if (!await enumerator.MoveNextAsync())
				return default;
		}

		return enumerator.Current;
	}
}
