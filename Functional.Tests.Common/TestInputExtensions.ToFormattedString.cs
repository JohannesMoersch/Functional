namespace Functional.Tests;

public static partial class TestInputExtensions
{
	private static string ToFormattedString<T>(this IEnumerable<T> value)
		=> $"({String.Join(", ", value.Select(i => i?.ToString() ?? "null"))})";

	private static string ToFormattedString(this Exception value)
		=> $"{value.GetType().Name} with message \"{value.Message}\"";
}
