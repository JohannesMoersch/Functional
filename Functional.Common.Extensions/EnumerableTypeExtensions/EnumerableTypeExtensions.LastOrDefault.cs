using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<TSource?> LastOrDefault<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).LastOrDefault();

	public static async Task<TSource?> LastOrDefault<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).LastOrDefault(predicate);

	public static async Task<TSource?> LastOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).LastOrDefault();

	public static async Task<TSource?> LastOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).LastOrDefault(predicate);
}
