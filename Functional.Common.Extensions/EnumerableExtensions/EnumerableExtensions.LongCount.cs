using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<long> LongCount<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).LongCount();

	public static async Task<long> LongCount<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).LongCount(predicate);

	public static async Task<long> LongCount<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).LongCount();

	public static async Task<long> LongCount<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).LongCount(predicate);
}
