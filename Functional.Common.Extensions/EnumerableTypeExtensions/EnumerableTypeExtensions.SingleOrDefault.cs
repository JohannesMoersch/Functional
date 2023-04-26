using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<TSource?> SingleOrDefault<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).SingleOrDefault();

	public static async Task<TSource?> SingleOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).SingleOrDefault(predicate);

	public static async Task<TSource?> SingleOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).SingleOrDefault();

	public static async Task<TSource?> SingleOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).SingleOrDefault(predicate);

	public static async Task<TSource?> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source)
	{
		if (source == null)
			throw new ArgumentNullException(nameof(source));

		var enumerator = source.GetAsyncEnumerator();

		if (!await enumerator.MoveNextAsync())
			return default;

		var result = enumerator.Current;

		if (await enumerator.MoveNextAsync())
			throw new InvalidOperationException("Sequence contains more than one element");

		return result;
	}

	public static Task<TSource?> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
		=> source.Where(predicate).SingleOrDefault();
}
