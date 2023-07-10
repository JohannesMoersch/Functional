namespace Functional.Unions;

public static class EnumerableExtensions
{
	public static string Join(this IEnumerable<string> source, string separator)
		=> source.Join(separator, _ => separator, _ => _);

	public static string Join<T>(this IEnumerable<T> source, string separator, Func<T, string> selector)
		=> source.Join(separator, _ => separator, selector);

	public static string JoinWithCommas(this IEnumerable<string> source)
		=> source.JoinWithCommas(_ => _);

	public static string JoinWithCommas<T>(this IEnumerable<T> source, Func<T, string> selector)
		=> source.Join(", ", i => i == 2 ? " and " : ", and ", selector);

	public static string Join<T>(this IEnumerable<T> source, string separator, Func<int, string> lastSeparator, Func<T, string> selector)
	{
		var items = source.ToArray();
		
		var builder = new StringBuilder();

		bool first = true;
		for (int i = 0; i < items.Length; ++i)
		{
			if (!first)
				builder.Append(i == items.Length - 1 ? lastSeparator.Invoke(items.Length) : separator);
			else 
				first = false;

			builder.Append(selector.Invoke(items[i]));
		}

		return builder.ToString();
	}

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

	public static IEnumerable<T> SwapFirstAndSecondItems<T>(this IEnumerable<T> source)
		=> source
			.Skip(1)
			.Take(1)
			.Concat(source.Take(1))
			.Concat(source.Skip(2));
}
