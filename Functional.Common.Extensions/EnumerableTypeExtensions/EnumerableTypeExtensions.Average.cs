using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<decimal> Average(this Task<IEnumerable<decimal>> source)
		=> (await source).Average();

	public static async Task<float> Average(this Task<IEnumerable<float>> source)
		=> (await source).Average();

	public static async Task<double> Average(this Task<IEnumerable<int>> source)
		=> (await source).Average();

	public static async Task<double> Average(this Task<IEnumerable<long>> source)
		=> (await source).Average();

	public static async Task<decimal?> Average(this Task<IEnumerable<decimal?>> source)
		=> (await source).Average();

	public static async Task<double> Average(this Task<IEnumerable<double>> source)
		=> (await source).Average();

	public static async Task<double?> Average(this Task<IEnumerable<int?>> source)
		=> (await source).Average();

	public static async Task<double?> Average(this Task<IEnumerable<long?>> source)
		=> (await source).Average();

	public static async Task<float?> Average(this Task<IEnumerable<float?>> source)
		=> (await source).Average();

	public static async Task<double?> Average(this Task<IEnumerable<double?>> source)
		=> (await source).Average();

	public static async Task<double> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long> selector)
		=> (await source).Average(selector);

	public static async Task<decimal?> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal?> selector)
		=> (await source).Average(selector);

	public static async Task<double?> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double?> selector)
		=> (await source).Average(selector);

	public static async Task<float> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float> selector)
		=> (await source).Average(selector);

	public static async Task<double?> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long?> selector)
		=> (await source).Average(selector);

	public static async Task<float?> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float?> selector)
		=> (await source).Average(selector);

	public static async Task<double> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int> selector)
		=> (await source).Average(selector);

	public static async Task<double?> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int?> selector)
		=> (await source).Average(selector);

	public static async Task<double> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double> selector)
		=> (await source).Average(selector);

	public static async Task<decimal> Average<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal> selector)
		=> (await source).Average(selector);

	public static async Task<decimal> Average(this Task<IOrderedEnumerable<decimal>> source)
		=> (await source).Average();

	public static async Task<float> Average(this Task<IOrderedEnumerable<float>> source)
		=> (await source).Average();

	public static async Task<double> Average(this Task<IOrderedEnumerable<int>> source)
		=> (await source).Average();

	public static async Task<double> Average(this Task<IOrderedEnumerable<long>> source)
		=> (await source).Average();

	public static async Task<decimal?> Average(this Task<IOrderedEnumerable<decimal?>> source)
		=> (await source).Average();

	public static async Task<double> Average(this Task<IOrderedEnumerable<double>> source)
		=> (await source).Average();

	public static async Task<double?> Average(this Task<IOrderedEnumerable<int?>> source)
		=> (await source).Average();

	public static async Task<double?> Average(this Task<IOrderedEnumerable<long?>> source)
		=> (await source).Average();

	public static async Task<float?> Average(this Task<IOrderedEnumerable<float?>> source)
		=> (await source).Average();

	public static async Task<double?> Average(this Task<IOrderedEnumerable<double?>> source)
		=> (await source).Average();

	public static async Task<double> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long> selector)
		=> (await source).Average(selector);

	public static async Task<decimal?> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal?> selector)
		=> (await source).Average(selector);

	public static async Task<double?> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double?> selector)
		=> (await source).Average(selector);

	public static async Task<float> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float> selector)
		=> (await source).Average(selector);

	public static async Task<double?> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long?> selector)
		=> (await source).Average(selector);

	public static async Task<float?> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float?> selector)
		=> (await source).Average(selector);

	public static async Task<double> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int> selector)
		=> (await source).Average(selector);

	public static async Task<double?> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int?> selector)
		=> (await source).Average(selector);

	public static async Task<double> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double> selector)
		=> (await source).Average(selector);

	public static async Task<decimal> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal> selector)
		=> (await source).Average(selector);
}