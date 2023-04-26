namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static IAsyncEnumerable<TSource> DoAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		return source
			.SelectAsync(async item =>
			{
				await action.Invoke(item);
				return item;
			});
	}

	public static IAsyncEnumerable<TSource> DoAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		return source
			.SelectAsync(async (item, index) =>
			{
				await action.Invoke(item, index);
				return item;
			});
	}

	public static IAsyncEnumerable<TSource> DoAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		return source
			.SelectAsync(async item =>
			{
				await action.Invoke(item);
				return item;
			});
	}

	public static IAsyncEnumerable<TSource> DoAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		return source
			.SelectAsync(async (item, index) =>
			{
				await action.Invoke(item, index);
				return item;
			});
	}

	public static IAsyncEnumerable<TSource> DoAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		return source
			.SelectAsync(async item =>
			{
				await action.Invoke(item);
				return item;
			});
	}

	public static IAsyncEnumerable<TSource> DoAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		return source
			.SelectAsync(async (item, index) =>
			{
				await action.Invoke(item, index);
				return item;
			});
	}
}
