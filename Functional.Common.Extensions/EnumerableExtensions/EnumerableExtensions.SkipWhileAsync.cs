namespace Functional;

public static partial class EnumerableExtensions
{
	public static async IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		bool skipping = true;
		foreach (var item in source)
		{
			if (!skipping || !(skipping = await predicate.Invoke(item)))
				yield return item;
		}
	}

	public static async IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		bool skipping = true;
		int index = 0;
		foreach (var item in source)
		{
			if (!skipping || !(skipping = await predicate.Invoke(item, index++)))
				yield return item;
		}
	}

	public static async IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		bool skipping = true;
		foreach (var item in await source)
		{
			if (!skipping || !(skipping = await predicate.Invoke(item)))
				yield return item;
		}
	}

	public static async IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		bool skipping = true;
		int index = 0;
		foreach (var item in await source)
		{
			if (!skipping || !(skipping = await predicate.Invoke(item, index++)))
				yield return item;
		}
	}

	public static IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.AsEnumerable().SkipWhileAsync(predicate);

	public static IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate)
		=> source.AsEnumerable().SkipWhileAsync(predicate);

	public static async IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		bool skipping = true;
		await foreach (var item in source)
		{
			if (!skipping || !(skipping = await predicate.Invoke(item)))
				yield return item;
		}
	}

	public static async IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		bool skipping = true;
		int index = 0;
		await foreach (var item in source)
		{
			if (!skipping || !(skipping = await predicate.Invoke(item, index++)))
				yield return item;
		}
	}
}
