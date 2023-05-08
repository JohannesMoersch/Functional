using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<float> Min(this Task<IEnumerable<float>> source)
		=> (await source).Min();

	public static async Task<float?> Min(this Task<IEnumerable<float?>> source)
		=> (await source).Min();

	public static async Task<long?> Min(this Task<IEnumerable<long?>> source)
		=> (await source).Min();

	public static async Task<int?> Min(this Task<IEnumerable<int?>> source)
		=> (await source).Min();

	public static async Task<double?> Min(this Task<IEnumerable<double?>> source)
		=> (await source).Min();

	public static async Task<decimal?> Min(this Task<IEnumerable<decimal?>> source)
		=> (await source).Min();

	public static async Task<long> Min(this Task<IEnumerable<long>> source)
		=> (await source).Min();

	public static async Task<int> Min(this Task<IEnumerable<int>> source)
		=> (await source).Min();

	public static async Task<double> Min(this Task<IEnumerable<double>> source)
		=> (await source).Min();

	public static async Task<decimal> Min(this Task<IEnumerable<decimal>> source)
		=> (await source).Min();

	public static async Task<TSource?> Min<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).Min();

	public static async Task<int> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int> selector)
		=> (await source).Min(selector);

	public static async Task<TResult?> Min<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, TResult> selector)
		=> (await source).Min(selector);

	public static async Task<float> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float> selector)
		=> (await source).Min(selector);

	public static async Task<float?> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float?> selector)
		=> (await source).Min(selector);

	public static async Task<long?> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long?> selector)
		=> (await source).Min(selector);

	public static async Task<int?> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int?> selector)
		=> (await source).Min(selector);

	public static async Task<double?> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double?> selector)
		=> (await source).Min(selector);

	public static async Task<decimal?> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal?> selector)
		=> (await source).Min(selector);

	public static async Task<long> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long> selector)
		=> (await source).Min(selector);

	public static async Task<decimal> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal> selector)
		=> (await source).Min(selector);

	public static async Task<double> Min<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double> selector)
		=> (await source).Min(selector);

	public static async Task<float> Min(this Task<IOrderedEnumerable<float>> source)
		=> (await source).Min();

	public static async Task<float?> Min(this Task<IOrderedEnumerable<float?>> source)
		=> (await source).Min();

	public static async Task<long?> Min(this Task<IOrderedEnumerable<long?>> source)
		=> (await source).Min();

	public static async Task<int?> Min(this Task<IOrderedEnumerable<int?>> source)
		=> (await source).Min();

	public static async Task<double?> Min(this Task<IOrderedEnumerable<double?>> source)
		=> (await source).Min();

	public static async Task<decimal?> Min(this Task<IOrderedEnumerable<decimal?>> source)
		=> (await source).Min();

	public static async Task<long> Min(this Task<IOrderedEnumerable<long>> source)
		=> (await source).Min();

	public static async Task<int> Min(this Task<IOrderedEnumerable<int>> source)
		=> (await source).Min();

	public static async Task<double> Min(this Task<IOrderedEnumerable<double>> source)
		=> (await source).Min();

	public static async Task<decimal> Min(this Task<IOrderedEnumerable<decimal>> source)
		=> (await source).Min();

	public static async Task<TSource?> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).Min();

	public static async Task<int> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int> selector)
		=> (await source).Min(selector);

	public static async Task<TResult?> Min<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TResult> selector)
		=> (await source).Min(selector);

	public static async Task<float> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float> selector)
		=> (await source).Min(selector);

	public static async Task<float?> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float?> selector)
		=> (await source).Min(selector);

	public static async Task<long?> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long?> selector)
		=> (await source).Min(selector);

	public static async Task<int?> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int?> selector)
		=> (await source).Min(selector);

	public static async Task<double?> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double?> selector)
		=> (await source).Min(selector);

	public static async Task<decimal?> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal?> selector)
		=> (await source).Min(selector);

	public static async Task<long> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long> selector)
		=> (await source).Min(selector);

	public static async Task<decimal> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal> selector)
		=> (await source).Min(selector);

	public static async Task<double> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double> selector)
		=> (await source).Min(selector);
}
