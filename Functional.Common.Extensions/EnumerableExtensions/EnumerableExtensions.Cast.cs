namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<TResult>> Cast<TResult>(this Task<IEnumerable> source)
		=> (await source).Cast<TResult>();

	public static async Task<IEnumerable<TResult>> Cast<TResult>(this Task<IEnumerable<object>> source)
		=> (await source).Cast<TResult>();

	public static async Task<IEnumerable<TResult>> Cast<TResult>(this Task<IOrderedEnumerable<object>> source)
		=> (await source).Cast<TResult>();

	public static async IAsyncEnumerable<TResult> Cast<TResult>(this IAsyncEnumerable<object> source)
	{
		await foreach (var item in source)
			yield return (TResult)item;
	}

	public static async Task<IEnumerable<TResult>> Cast<TSource, TResult>(this Task<IEnumerable<TSource>> source)
		=> (await source).Cast<TResult>();

	public static async Task<IEnumerable<TResult>> Cast<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).Cast<TResult>();

#pragma warning disable CS8600, CS8603 // Converting null literal or possible null value to non-nullable type. Possible null reference return.
	public static async IAsyncEnumerable<TResult> Cast<TSource, TResult>(this IAsyncEnumerable<TSource> source)
	{
		await foreach (var item in source)
			yield return (TResult)(object)item;
	}
#pragma warning restore CS8600, CS8603 // Converting null literal or possible null value to non-nullable type. Possible null reference return.
}
