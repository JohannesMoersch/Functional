using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<List<TSource>> ToList<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).ToList();

	public static async Task<List<TSource>> ToList<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).ToList();

	public static async Task<List<TSource>> ToList<TSource>(this IAsyncEnumerable<TSource> source)
	{
		if (source == null)
			throw new ArgumentNullException(nameof(source));

		var enumerator = source.GetAsyncEnumerator();

		var list = new List<TSource>();

		while (await enumerator.MoveNextAsync())
			list.Add(enumerator.Current);

		return list;
	}
}
