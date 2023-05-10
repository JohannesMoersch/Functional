namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TResult>> OfType<TResult>(this Task<IEnumerable> source)
		=> (await source).OfType<TResult>();

	public static async Task<IEnumerable<TResult>> OfType<TResult>(this Task<IEnumerable<object>> source)
	=> (await source).OfType<TResult>();

	public static async Task<IEnumerable<TResult>> OfType<TResult>(this Task<IOrderedEnumerable<object>> source)
		=> (await source).OfType<TResult>();

	public static async IAsyncEnumerable<TResult> OfType<TResult>(this IAsyncEnumerable<object> source)
	{
		await foreach (var item in source)
		{
			if (item is TResult result)
				yield return result;
		}
	}

	public static async Task<IEnumerable<TResult>> OfType<TSource, TResult>(this Task<IEnumerable<TSource>> source)
		=> (await source).OfType<TResult>();

	public static async Task<IEnumerable<TResult>> OfType<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).OfType<TResult>();

	public static async IAsyncEnumerable<TResult> OfType<TSource, TResult>(this IAsyncEnumerable<TSource> source)
	{
		await foreach (var item in source)
		{
			if (item is TResult result)
				yield return result;
		}
	}
}
