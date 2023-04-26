using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<TSource> Last<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).Last();

	public static async Task<TSource> Last<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Last(predicate);

	public static async Task<TSource> Last<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).Last();

	public static async Task<TSource> Last<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Last(predicate);
}
