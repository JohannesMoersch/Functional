namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<Option<T>> TryLastAsync<T>(this IEnumerable<T> source, Func<T, Task<bool>> predicate)
		where T : notnull
	{
		if (source is null) throw new ArgumentNullException(nameof(source));
		if (predicate is null) throw new ArgumentNullException(nameof(predicate));

		var result = Option.None<T>();

		foreach (var element in source)
		{
			if (await predicate.Invoke(element))
				result = Option.Some(element);
		}

		return result;
	}

	public static async Task<Option<T>> TryLastAsync<T>(this Task<IEnumerable<T>> source, Func<T, Task<bool>> predicate)
		where T : notnull
		=> await (await source).TryLastAsync(predicate);

	public static async Task<Option<T>> TryLastAsync<T>(this IAsyncEnumerable<T> source, Func<T, Task<bool>> predicate)
		where T : notnull
	{
		if (source is null) throw new ArgumentNullException(nameof(source));
		if (predicate is null) throw new ArgumentNullException(nameof(predicate));

		var result = Option.None<T>();

		await foreach (var element in source)
		{
			if (await predicate.Invoke(element))
				result = Option.Some(element);
		}

		return result;
	}
}
