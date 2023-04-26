using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<float?> Sum(this Task<IEnumerable<float?>> source)
		=> (await source).Sum();

	public static async Task<long?> Sum(this Task<IEnumerable<long?>> source)
		=> (await source).Sum();

	public static async Task<int?> Sum(this Task<IEnumerable<int?>> source)
		=> (await source).Sum();

	public static async Task<double?> Sum(this Task<IEnumerable<double?>> source)
		=> (await source).Sum();

	public static async Task<decimal?> Sum(this Task<IEnumerable<decimal?>> source)
		=> (await source).Sum();

	public static async Task<float> Sum(this Task<IEnumerable<float>> source)
		=> (await source).Sum();

	public static async Task<long> Sum(this Task<IEnumerable<long>> source)
		=> (await source).Sum();

	public static async Task<int> Sum(this Task<IEnumerable<int>> source)
		=> (await source).Sum();

	public static async Task<double> Sum(this Task<IEnumerable<double>> source)
		=> (await source).Sum();

	public static async Task<decimal> Sum(this Task<IEnumerable<decimal>> source)
		=> (await source).Sum();

	public static async Task<int?> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int?> selector)
		=> (await source).Sum(selector);

	public static async Task<int> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int> selector)
		=> (await source).Sum(selector);

	public static async Task<long> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long> selector)
		=> (await source).Sum(selector);

	public static async Task<decimal?> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal?> selector)
		=> (await source).Sum(selector);

	public static async Task<float> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float> selector)
		=> (await source).Sum(selector);

	public static async Task<float?> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float?> selector)
		=> (await source).Sum(selector);

	public static async Task<double> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double> selector)
		=> (await source).Sum(selector);

	public static async Task<long?> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long?> selector)
		=> (await source).Sum(selector);

	public static async Task<decimal> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal> selector)
		=> (await source).Sum(selector);

	public static async Task<double?> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double?> selector)
		=> (await source).Sum(selector);

	public static async Task<float?> Sum(this Task<IOrderedEnumerable<float?>> source)
		=> (await source).Sum();

	public static async Task<long?> Sum(this Task<IOrderedEnumerable<long?>> source)
		=> (await source).Sum();

	public static async Task<int?> Sum(this Task<IOrderedEnumerable<int?>> source)
		=> (await source).Sum();

	public static async Task<double?> Sum(this Task<IOrderedEnumerable<double?>> source)
		=> (await source).Sum();

	public static async Task<decimal?> Sum(this Task<IOrderedEnumerable<decimal?>> source)
		=> (await source).Sum();

	public static async Task<float> Sum(this Task<IOrderedEnumerable<float>> source)
		=> (await source).Sum();

	public static async Task<long> Sum(this Task<IOrderedEnumerable<long>> source)
		=> (await source).Sum();

	public static async Task<int> Sum(this Task<IOrderedEnumerable<int>> source)
		=> (await source).Sum();

	public static async Task<double> Sum(this Task<IOrderedEnumerable<double>> source)
		=> (await source).Sum();

	public static async Task<decimal> Sum(this Task<IOrderedEnumerable<decimal>> source)
		=> (await source).Sum();

	public static async Task<int?> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int?> selector)
		=> (await source).Sum(selector);

	public static async Task<int> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int> selector)
		=> (await source).Sum(selector);

	public static async Task<long> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long> selector)
		=> (await source).Sum(selector);

	public static async Task<decimal?> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal?> selector)
		=> (await source).Sum(selector);

	public static async Task<float> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float> selector)
		=> (await source).Sum(selector);

	public static async Task<float?> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float?> selector)
		=> (await source).Sum(selector);

	public static async Task<double> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double> selector)
		=> (await source).Sum(selector);

	public static async Task<long?> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long?> selector)
		=> (await source).Sum(selector);

	public static async Task<decimal> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal> selector)
		=> (await source).Sum(selector);

	public static async Task<double?> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double?> selector)
		=> (await source).Sum(selector);
}
