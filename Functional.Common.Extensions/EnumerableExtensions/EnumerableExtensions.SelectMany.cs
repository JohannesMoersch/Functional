namespace Functional;

public static partial class EnumerableExtensions
{
	public static async IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TResult>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		foreach (var item in source)
		{
			await foreach (var innerItem in selector.Invoke(item))
				yield return innerItem;
		}
	}

	public static async IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IAsyncEnumerable<TResult>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		int count = 0;
		foreach (var item in source)
		{
			await foreach (var innerItem in selector.Invoke(item, count++))
				yield return innerItem;
		}
	}

	public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IEnumerable<TResult>> selector)
		=> (await source).SelectMany(selector);

	public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, IEnumerable<TResult>> selector)
		=> (await source).SelectMany(selector);

	public static async IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IAsyncEnumerable<TResult>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		foreach (var item in await source)
		{
			await foreach (var innerItem in selector.Invoke(item))
				yield return innerItem;
		}
	}

	public static async IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, IAsyncEnumerable<TResult>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		int count = 0;
		foreach (var item in await source)
		{
			await foreach (var innerItem in selector.Invoke(item, count++))
				yield return innerItem;
		}
	}

	public static Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, IEnumerable<TResult>> selector)
		=> source.AsEnumerable().SelectMany(selector);

	public static Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, IEnumerable<TResult>> selector)
		=> source.AsEnumerable().SelectMany(selector);

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, IAsyncEnumerable<TResult>> selector)
		=> source.AsEnumerable().SelectMany(selector);

	public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, IAsyncEnumerable<TResult>> selector)
		=> source.AsEnumerable().SelectMany(selector);

	public static async IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		await foreach (var item in source)
		{
			foreach (var innerItem in selector.Invoke(item))
				yield return innerItem;
		}
	}

	public static async IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		int count = 0;
		await foreach (var item in source)
		{
			foreach (var innerItem in selector.Invoke(item, count++))
				yield return innerItem;
		}
	}

	public static async IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TResult>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		await foreach (var item in source)
		{
			await foreach (var innerItem in selector.Invoke(item))
				yield return innerItem;
		}
	}

	public static async IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IAsyncEnumerable<TResult>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		int count = 0;
		await foreach (var item in source)
		{
			await foreach (var innerItem in selector.Invoke(item, count++))
				yield return innerItem;
		}
	}
}
