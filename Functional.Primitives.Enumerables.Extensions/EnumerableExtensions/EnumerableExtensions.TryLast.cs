namespace Functional;

public static partial class EnumerableExtensions
{
	public static Option<T> TryLast<T>(this IEnumerable<T> source)
		where T : notnull
		=> source.TryLast(static _ => true);

	public static Option<T> TryLast<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		where T : notnull
	{
		if (source is null) throw new ArgumentNullException(nameof(source));
		if (predicate is null) throw new ArgumentNullException(nameof(predicate));

		var result = Option.None<T>();

		foreach (var element in source)
		{
			if (predicate.Invoke(element))
				result = Option.Some(element);
		}

		return result;
	}

	public static async Task<Option<T>> TryLast<T>(this Task<IEnumerable<T>> source)
		where T : notnull
		=> (await source).TryLast();

	public static async Task<Option<T>> TryLast<T>(this Task<IEnumerable<T>> source, Func<T, bool> predicate)
		where T : notnull
		=> (await source).TryLast(predicate);

	public static Task<Option<T>> TryLast<T>(this IAsyncEnumerable<T> source)
		where T : notnull
		=> source.TryLast(static _ => true);

	public static async Task<Option<T>> TryLast<T>(this IAsyncEnumerable<T> source, Func<T, bool> predicate)
		where T : notnull
	{
		if (source is null) throw new ArgumentNullException(nameof(source));
		if (predicate is null) throw new ArgumentNullException(nameof(predicate));

		var result = Option.None<T>();

		await foreach (var element in source)
		{
			if (predicate.Invoke(element))
				result = Option.Some(element);
		}

		return result;
	}
}
