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

	public static Task<float> Min(this IAsyncEnumerable<float> source)
		=> source.AsEnumerable().Min();

	public static Task<float?> Min(this IAsyncEnumerable<float?> source)
		=> source.AsEnumerable().Min();

	public static Task<long?> Min(this IAsyncEnumerable<long?> source)
		=> source.AsEnumerable().Min();

	public static Task<int?> Min(this IAsyncEnumerable<int?> source)
		=> source.AsEnumerable().Min();

	public static Task<double?> Min(this IAsyncEnumerable<double?> source)
		=> source.AsEnumerable().Min();

	public static Task<decimal?> Min(this IAsyncEnumerable<decimal?> source)
		=> source.AsEnumerable().Min();

	public static Task<long> Min(this IAsyncEnumerable<long> source)
		=> source.AsEnumerable().Min();

	public static Task<int> Min(this IAsyncEnumerable<int> source)
		=> source.AsEnumerable().Min();

	public static Task<double> Min(this IAsyncEnumerable<double> source)
		=> source.AsEnumerable().Min();

	public static Task<decimal> Min(this IAsyncEnumerable<decimal> source)
		=> source.AsEnumerable().Min();

	public static Task<TSource?> Min<TSource>(this IAsyncEnumerable<TSource> source)
		=> source.AsEnumerable().Min();

	public static Task<int> Min<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int> selector)
		=> source.AsEnumerable().Min(selector);

	public static Task<TResult?> Min<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, TResult> selector)
		=> source.AsEnumerable().Min(selector);

	public static Task<float> Min<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float> selector)
		=> source.AsEnumerable().Min(selector);

	public static Task<float?> Min<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float?> selector)
		=> source.AsEnumerable().Min(selector);

	public static Task<long?> Min<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long?> selector)
		=> source.AsEnumerable().Min(selector);

	public static Task<int?> Min<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int?> selector)
		=> source.AsEnumerable().Min(selector);

	public static Task<double?> Min<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double?> selector)
		=> source.AsEnumerable().Min(selector);

	public static Task<decimal?> Min<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector)
		=> source.AsEnumerable().Min(selector);

	public static Task<long> Min<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long> selector)
		=> source.AsEnumerable().Min(selector);

	public static Task<decimal> Min<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal> selector)
		=> source.AsEnumerable().Min(selector);

	public static Task<double> Min<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double> selector)
		=> source.AsEnumerable().Min(selector);
}
