using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<int> Count<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).Count();

	public static async Task<int> Count<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Count(predicate);

	public static async Task<int> Count<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).Count();

	public static async Task<int> Count<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).Count(predicate);
}
