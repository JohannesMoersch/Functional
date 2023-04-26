using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<TSource> Aggregate<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, TSource, TSource> func)
		=> (await source).Aggregate(func);

	public static async Task<TAccumulate> Aggregate<TSource, TAccumulate>(this Task<IEnumerable<TSource>> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
		=> (await source).Aggregate(seed, func);

	public static async Task<TResult> Aggregate<TSource, TAccumulate, TResult>(this Task<IEnumerable<TSource>> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
		=> (await source).Aggregate(seed, func, resultSelector);

	public static async Task<TSource> Aggregate<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TSource, TSource> func)
		=> (await source).Aggregate(func);

	public static async Task<TAccumulate> Aggregate<TSource, TAccumulate>(this Task<IOrderedEnumerable<TSource>> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
		=> (await source).Aggregate(seed, func);

	public static async Task<TResult> Aggregate<TSource, TAccumulate, TResult>(this Task<IOrderedEnumerable<TSource>> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
		=> (await source).Aggregate(seed, func, resultSelector);
}
