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

	public static Task<float> Max(this IAsyncEnumerable<float> source)
		=> source.AsEnumerable().Max();

	public static Task<decimal> Max(this IAsyncEnumerable<decimal> source)
		=> source.AsEnumerable().Max();

	public static Task<double> Max(this IAsyncEnumerable<double> source)
		=> source.AsEnumerable().Max();

	public static Task<int> Max(this IAsyncEnumerable<int> source)
		=> source.AsEnumerable().Max();

	public static Task<long> Max(this IAsyncEnumerable<long> source)
		=> source.AsEnumerable().Max();

	public static Task<TSource?> Max<TSource>(this IAsyncEnumerable<TSource> source)
		=> source.AsEnumerable().Max();

	public static Task<double?> Max(this IAsyncEnumerable<double?> source)
		=> source.AsEnumerable().Max();

	public static Task<int?> Max(this IAsyncEnumerable<int?> source)
		=> source.AsEnumerable().Max();

	public static Task<long?> Max(this IAsyncEnumerable<long?> source)
		=> source.AsEnumerable().Max();

	public static Task<float?> Max(this IAsyncEnumerable<float?> source)
		=> source.AsEnumerable().Max();

	public static Task<decimal?> Max(this IAsyncEnumerable<decimal?> source)
		=> source.AsEnumerable().Max();

	public static Task<int> Max<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int> selector)
		=> source.AsEnumerable().Max(selector);

	public static Task<long> Max<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long> selector)
		=> source.AsEnumerable().Max(selector);

	public static Task<decimal?> Max<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector)
		=> source.AsEnumerable().Max(selector);

	public static Task<double?> Max<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double?> selector)
		=> source.AsEnumerable().Max(selector);

	public static Task<float> Max<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float> selector)
		=> source.AsEnumerable().Max(selector);

	public static Task<long?> Max<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long?> selector)
		=> source.AsEnumerable().Max(selector);

	public static Task<float?> Max<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float?> selector)
		=> source.AsEnumerable().Max(selector);

	public static Task<double> Max<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double> selector)
		=> source.AsEnumerable().Max(selector);

	public static Task<int?> Max<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int?> selector)
		=> source.AsEnumerable().Max(selector);

	public static Task<decimal> Max<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal> selector)
		=> source.AsEnumerable().Max(selector);

	public static Task<TResult?> Max<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, TResult> selector)
		=> source.AsEnumerable().Max(selector);
}
