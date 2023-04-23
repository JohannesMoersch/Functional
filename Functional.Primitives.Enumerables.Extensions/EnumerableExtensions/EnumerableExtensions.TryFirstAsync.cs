namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<Option<T>> TryFirstAsync<T>(this IEnumerable<T> source, Func<T, Task<bool>> predicate)
		where T : notnull
	{
		if (source is null) throw new ArgumentNullException(nameof(source));
		if (predicate is null) throw new ArgumentNullException(nameof(predicate));

		foreach (var element in source)
		{
			if (await predicate.Invoke(element))
				return Option.Some(element);
		}

		return Option.None<T>();
	}

	public static async Task<Option<T>> TryFirstAsync<T>(this Task<IEnumerable<T>> source, Func<T, Task<bool>> predicate)
		where T : notnull
		=> await (await source).TryFirstAsync(predicate);

	public static async Task<Option<T>> TryFirstAsync<T>(this IAsyncEnumerable<T> source, Func<T, Task<bool>> predicate)
		where T : notnull
	{
		if (source is null) throw new ArgumentNullException(nameof(source));
		if (predicate is null) throw new ArgumentNullException(nameof(predicate));

		await foreach (var element in source)
		{
			if (await predicate.Invoke(element))
				return Option.Some(element);
		}

		return Option.None<T>();
	}
}
