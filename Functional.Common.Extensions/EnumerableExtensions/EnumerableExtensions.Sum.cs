namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<int> Sum(this Task<IEnumerable<int>> source)
		=> (await source).Sum();

	public static async Task<long> Sum(this Task<IEnumerable<long>> source)
		=> (await source).Sum();

	public static async Task<float> Sum(this Task<IEnumerable<float>> source)
		=> (await source).Sum();

	public static async Task<double> Sum(this Task<IEnumerable<double>> source)
		=> (await source).Sum();

	public static async Task<decimal> Sum(this Task<IEnumerable<decimal>> source)
		=> (await source).Sum();

	public static async Task<int?> Sum(this Task<IEnumerable<int?>> source)
		=> (await source).Sum();

	public static async Task<long?> Sum(this Task<IEnumerable<long?>> source)
		=> (await source).Sum();

	public static async Task<float?> Sum(this Task<IEnumerable<float?>> source)
		=> (await source).Sum();

	public static async Task<double?> Sum(this Task<IEnumerable<double?>> source)
		=> (await source).Sum();

	public static async Task<decimal?> Sum(this Task<IEnumerable<decimal?>> source)
		=> (await source).Sum();

	public static async Task<int> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int> selector)
		=> (await source).Sum(selector);

	public static async Task<long> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long> selector)
		=> (await source).Sum(selector);

	public static async Task<float> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float> selector)
		=> (await source).Sum(selector);

	public static async Task<double> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double> selector)
		=> (await source).Sum(selector);

	public static async Task<decimal> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal> selector)
		=> (await source).Sum(selector);

	public static async Task<int?> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int?> selector)
		=> (await source).Sum(selector);

	public static async Task<long?> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, long?> selector)
		=> (await source).Sum(selector);

	public static async Task<float?> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, float?> selector)
		=> (await source).Sum(selector);

	public static async Task<double?> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, double?> selector)
		=> (await source).Sum(selector);

	public static async Task<decimal?> Sum<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, decimal?> selector)
		=> (await source).Sum(selector);

	public static async Task<int> Sum(this Task<IOrderedEnumerable<int>> source)
		=> (await source).Sum();

	public static async Task<long> Sum(this Task<IOrderedEnumerable<long>> source)
		=> (await source).Sum();

	public static async Task<float> Sum(this Task<IOrderedEnumerable<float>> source)
		=> (await source).Sum();

	public static async Task<double> Sum(this Task<IOrderedEnumerable<double>> source)
		=> (await source).Sum();

	public static async Task<decimal> Sum(this Task<IOrderedEnumerable<decimal>> source)
		=> (await source).Sum();

	public static async Task<int?> Sum(this Task<IOrderedEnumerable<int?>> source)
		=> (await source).Sum();

	public static async Task<long?> Sum(this Task<IOrderedEnumerable<long?>> source)
		=> (await source).Sum();

	public static async Task<float?> Sum(this Task<IOrderedEnumerable<float?>> source)
		=> (await source).Sum();

	public static async Task<double?> Sum(this Task<IOrderedEnumerable<double?>> source)
		=> (await source).Sum();

	public static async Task<decimal?> Sum(this Task<IOrderedEnumerable<decimal?>> source)
		=> (await source).Sum();

	public static async Task<int> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int> selector)
		=> (await source).Sum(selector);

	public static async Task<long> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long> selector)
		=> (await source).Sum(selector);

	public static async Task<float> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float> selector)
		=> (await source).Sum(selector);

	public static async Task<double> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double> selector)
		=> (await source).Sum(selector);

	public static async Task<decimal> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal> selector)
		=> (await source).Sum(selector);

	public static async Task<int?> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int?> selector)
		=> (await source).Sum(selector);

	public static async Task<long?> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long?> selector)
		=> (await source).Sum(selector);

	public static async Task<float?> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float?> selector)
		=> (await source).Sum(selector);

	public static async Task<double?> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double?> selector)
		=> (await source).Sum(selector);

	public static async Task<decimal?> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal?> selector)
		=> (await source).Sum(selector);

	public static Task<int> Sum(this IAsyncEnumerable<int> source)
		=> source.AsEnumerable().Sum();

	public static Task<long> Sum(this IAsyncEnumerable<long> source)
		=> source.AsEnumerable().Sum();

	public static Task<float> Sum(this IAsyncEnumerable<float> source)
		=> source.AsEnumerable().Sum();

	public static Task<double> Sum(this IAsyncEnumerable<double> source)
		=> source.AsEnumerable().Sum();

	public static Task<decimal> Sum(this IAsyncEnumerable<decimal> source)
		=> source.AsEnumerable().Sum();

	public static Task<int?> Sum(this IAsyncEnumerable<int?> source)
		=> source.AsEnumerable().Sum();

	public static Task<long?> Sum(this IAsyncEnumerable<long?> source)
		=> source.AsEnumerable().Sum();

	public static Task<float?> Sum(this IAsyncEnumerable<float?> source)
		=> source.AsEnumerable().Sum();

	public static Task<double?> Sum(this IAsyncEnumerable<double?> source)
		=> source.AsEnumerable().Sum();

	public static Task<decimal?> Sum(this IAsyncEnumerable<decimal?> source)
		=> source.AsEnumerable().Sum();

	public static Task<int> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int> selector)
		=> source.AsEnumerable().Sum(selector);

	public static Task<long> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long> selector)
		=> source.AsEnumerable().Sum(selector);

	public static Task<float> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float> selector)
		=> source.AsEnumerable().Sum(selector);

	public static Task<double> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double> selector)
		=> source.AsEnumerable().Sum(selector);

	public static Task<decimal> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal> selector)
		=> source.AsEnumerable().Sum(selector);

	public static Task<int?> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int?> selector)
		=> source.AsEnumerable().Sum(selector);

	public static Task<long?> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long?> selector)
		=> source.AsEnumerable().Sum(selector);

	public static Task<float?> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float?> selector)
		=> source.AsEnumerable().Sum(selector);

	public static Task<double?> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double?> selector)
		=> source.AsEnumerable().Sum(selector);

	public static Task<decimal?> Sum<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector)
		=> source.AsEnumerable().Sum(selector);
}
