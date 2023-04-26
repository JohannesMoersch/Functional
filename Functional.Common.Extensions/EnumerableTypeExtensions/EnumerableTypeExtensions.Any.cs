using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<bool> Any<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).Any();

	public static async Task<bool> Any<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Any(predicate);

	public static async Task<bool> Any<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).Any();

	public static async Task<bool> Any<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Any(predicate);

	public static async Task<bool> Any<TSource>(this IAsyncEnumerable<TSource> source)
		=> await (source ?? throw new ArgumentNullException(nameof(source))).GetAsyncEnumerator().MoveNextAsync();

	public static async Task<bool> Any<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		if (source == null)
			throw new ArgumentNullException(nameof(source));

		var enumerator = source.GetAsyncEnumerator();

		var value = false;

		while (!value && await enumerator.MoveNextAsync())
			value = predicate.Invoke(enumerator.Current);

		return value;
	}
}
