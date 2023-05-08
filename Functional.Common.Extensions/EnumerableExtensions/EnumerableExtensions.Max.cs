using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<float> Max(this Task<IEnumerable<float>> source)
		=> (await source).Max();

	public static async Task<decimal> Max(this Task<IEnumerable<decimal>> source)
		=> (await source).Max();

	public static async Task<double> Max(this Task<IEnumerable<double>> source)
		=> (await source).Max();

	public static async Task<int> Max(this Task<IEnumerable<int>> source)
		=> (await source).Max();

	public static async Task<long> Max(this Task<IEnumerable<long>> source)
		=> (await source).Max();

	public static async Task<TSource?> Max<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).Max();

	public static async Task<double?> Max(this Task<IEnumerable<double?>> source)
		=> (await source).Max();

	public static async Task<int?> Max(this Task<IEnumerable<int?>> source)
		=> (await source).Max();

	public static async Task<long?> Max(this Task<IEnumerable<long?>> source)
		=> (await source).Max();

	public static async Task<float?> Max(this Task<IEnumerable<float?>> source)
		=> (await source).Max();

	public static async Task<decimal?> Max(this Task<IEnumerable<decimal?>> source)
		=> (await source).Max();

	public static async Task<int> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int> selector)
		=> (await source).Max(selector);

	public static async Task<long> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long> selector)
		=> (await source).Max(selector);

	public static async Task<decimal?> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal?> selector)
		=> (await source).Max(selector);

	public static async Task<double?> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double?> selector)
		=> (await source).Max(selector);

	public static async Task<float> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float> selector)
		=> (await source).Max(selector);

	public static async Task<long?> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long?> selector)
		=> (await source).Max(selector);

	public static async Task<float?> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float?> selector)
		=> (await source).Max(selector);

	public static async Task<double> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double> selector)
		=> (await source).Max(selector);

	public static async Task<int?> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int?> selector)
		=> (await source).Max(selector);

	public static async Task<decimal> Max<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal> selector)
		=> (await source).Max(selector);

	public static async Task<TResult?> Max<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, TResult> selector)
		=> (await source).Max(selector);

	public static async Task<float> Max(this Task<IOrderedEnumerable<float>> source)
		=> (await source).Max();

	public static async Task<decimal> Max(this Task<IOrderedEnumerable<decimal>> source)
		=> (await source).Max();

	public static async Task<double> Max(this Task<IOrderedEnumerable<double>> source)
		=> (await source).Max();

	public static async Task<int> Max(this Task<IOrderedEnumerable<int>> source)
		=> (await source).Max();

	public static async Task<long> Max(this Task<IOrderedEnumerable<long>> source)
		=> (await source).Max();

	public static async Task<TSource?> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).Max();

	public static async Task<double?> Max(this Task<IOrderedEnumerable<double?>> source)
		=> (await source).Max();

	public static async Task<int?> Max(this Task<IOrderedEnumerable<int?>> source)
		=> (await source).Max();

	public static async Task<long?> Max(this Task<IOrderedEnumerable<long?>> source)
		=> (await source).Max();

	public static async Task<float?> Max(this Task<IOrderedEnumerable<float?>> source)
		=> (await source).Max();

	public static async Task<decimal?> Max(this Task<IOrderedEnumerable<decimal?>> source)
		=> (await source).Max();

	public static async Task<int> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int> selector)
		=> (await source).Max(selector);

	public static async Task<long> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long> selector)
		=> (await source).Max(selector);

	public static async Task<decimal?> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal?> selector)
		=> (await source).Max(selector);

	public static async Task<double?> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double?> selector)
		=> (await source).Max(selector);

	public static async Task<float> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float> selector)
		=> (await source).Max(selector);

	public static async Task<long?> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long?> selector)
		=> (await source).Max(selector);

	public static async Task<float?> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float?> selector)
		=> (await source).Max(selector);

	public static async Task<double> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double> selector)
		=> (await source).Max(selector);

	public static async Task<int?> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int?> selector)
		=> (await source).Max(selector);

	public static async Task<decimal> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal> selector)
		=> (await source).Max(selector);

	public static async Task<TResult?> Max<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TResult> selector)
		=> (await source).Max(selector);
}
