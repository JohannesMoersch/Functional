namespace Functional.Unions;

public static class EnumerableExtensions
{
	public static string Join(this IEnumerable<string> source, string separator)
		=> source.Join(separator, _ => _);

	public static string Join<T>(this IEnumerable<T> source, string separator, Func<T, string> selector)
		=> String.Join(separator, source.Select(selector));

	public static bool TryGetFirst<T>(this IEnumerable<T> values, out T value)
		=> values.TryGetFirst(_ => true, out value);

	public static bool TryGetFirst<T>(this IEnumerable<T> values, Func<T, bool> predicate, out T value)
	{
		foreach (var item in values)
		{
			if (predicate.Invoke(item))
			{
				value = item;
				return true;
			}
		}

#pragma warning disable CS8601 // Possible null reference assignment.
		value = default;
#pragma warning restore CS8601 // Possible null reference assignment.
		return false;
	}
}
