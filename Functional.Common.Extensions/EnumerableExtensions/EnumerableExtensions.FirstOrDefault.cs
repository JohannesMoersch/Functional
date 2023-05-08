using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<TSource?> FirstOrDefault<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).FirstOrDefault();

	public static async Task<TSource?> FirstOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).FirstOrDefault(predicate);

	public static async Task<TSource?> FirstOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).FirstOrDefault();

	public static async Task<TSource?> FirstOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).FirstOrDefault(predicate);

	public static async Task<TSource?> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source)
	{
		if (source == null)
			throw new ArgumentNullException(nameof(source));

		var enumerator = source.GetAsyncEnumerator();

		return (await enumerator.MoveNextAsync()) ? enumerator.Current : default;
	}

	public static Task<TSource?> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
		=> source.Where(predicate).FirstOrDefault();
}
