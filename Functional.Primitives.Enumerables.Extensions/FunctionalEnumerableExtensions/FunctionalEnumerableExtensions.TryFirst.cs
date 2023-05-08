namespace Functional;

public static partial class FunctionalEnumerableExtensions
{
	public static Option<T> TryFirst<T>(this IEnumerable<T> source)
		where T : notnull
		=> source.TryFirst(static _ => true);

	public static Option<T> TryFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		where T : notnull
	{
		if (source is null) throw new ArgumentNullException(nameof(source));
		if (predicate is null) throw new ArgumentNullException(nameof(predicate));

		foreach (var element in source)
		{
			if (predicate.Invoke(element))
				return Option.Some(element);
		}

		return Option.None<T>();
	}

	public static async Task<Option<T>> TryFirst<T>(this Task<IEnumerable<T>> source)
		where T : notnull
		=> (await source).TryFirst();

	public static async Task<Option<T>> TryFirst<T>(this Task<IEnumerable<T>> source, Func<T, bool> predicate)
		where T : notnull
		=> (await source).TryFirst(predicate);

	public static Task<Option<T>> TryFirst<T>(this IAsyncEnumerable<T> source)
		where T : notnull
		=> source.TryFirst(static _ => true);

	public static async Task<Option<T>> TryFirst<T>(this IAsyncEnumerable<T> source, Func<T, bool> predicate)
		where T : notnull
	{
		if (source is null) throw new ArgumentNullException(nameof(source));
		if (predicate is null) throw new ArgumentNullException(nameof(predicate));

		await foreach (var element in source)
		{
			if (predicate.Invoke(element))
				return Option.Some(element);
		}

		return Option.None<T>();
	}
}
