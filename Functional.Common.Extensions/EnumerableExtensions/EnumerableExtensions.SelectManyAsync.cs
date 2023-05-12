namespace Functional;

public static partial class EnumerableExtensions
{
	public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TResult>>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		foreach (var item in source)
		{
			foreach (var innerItem in await selector.Invoke(item))
				yield return innerItem;
		}
	}

	public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, Task<IEnumerable<TResult>>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		int count = 0;
		foreach (var item in source)
		{
			foreach (var innerItem in await selector.Invoke(item, count++))
				yield return innerItem;
		}
	}

	public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<IOrderedEnumerable<TResult>>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		foreach (var item in source)
		{
			foreach (var innerItem in await selector.Invoke(item))
				yield return innerItem;
		}
	}

	public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, Task<IOrderedEnumerable<TResult>>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		int count = 0;
		foreach (var item in source)
		{
			foreach (var innerItem in await selector.Invoke(item, count++))
				yield return innerItem;
		}
	}

	public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<IEnumerable<TResult>>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		foreach (var item in await source)
		{
			foreach (var innerItem in await selector.Invoke(item))
				yield return innerItem;
		}
	}

	public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<IEnumerable<TResult>>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		int count = 0;
		foreach (var item in await source)
		{
			foreach (var innerItem in await selector.Invoke(item, count++))
				yield return innerItem;
		}
	}

	public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<IOrderedEnumerable<TResult>>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		foreach (var item in await source)
		{
			foreach (var innerItem in await selector.Invoke(item))
				yield return innerItem;
		}
	}

	public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<IOrderedEnumerable<TResult>>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		int count = 0;
		foreach (var item in await source)
		{
			foreach (var innerItem in await selector.Invoke(item, count++))
				yield return innerItem;
		}
	}

	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<IEnumerable<TResult>>> selector)
		=> source.AsEnumerable().SelectManyAsync(selector);

	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, Task<IEnumerable<TResult>>> selector)
		=> source.AsEnumerable().SelectManyAsync(selector);

	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<IOrderedEnumerable<TResult>>> selector)
		=> source.AsEnumerable().SelectManyAsync(selector);

	public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, Task<IOrderedEnumerable<TResult>>> selector)
		=> source.AsEnumerable().SelectManyAsync(selector);

	public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TResult>>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		await foreach (var item in source)
		{
			foreach (var innerItem in await selector.Invoke(item))
				yield return innerItem;
		}
	}

	public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<IEnumerable<TResult>>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		int count = 0;
		await foreach (var item in source)
		{
			foreach (var innerItem in await selector.Invoke(item, count++))
				yield return innerItem;
		}
	}

	public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<IOrderedEnumerable<TResult>>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		await foreach (var item in source)
		{
			foreach (var innerItem in await selector.Invoke(item))
				yield return innerItem;
		}
	}

	public static async IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<IOrderedEnumerable<TResult>>> selector)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		int count = 0;
		await foreach (var item in source)
		{
			foreach (var innerItem in await selector.Invoke(item, count++))
				yield return innerItem;
		}
	}
}
