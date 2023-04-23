namespace Functional;

public static partial class OptionExtensions
{
	[AllowAllocations(allowNewArr: true)]
	public static IEnumerable<T> ToEnumerable<T>(this Option<T> option)
		where T : notnull
		=> option.TryGetValue(out var value) ? new[] { value } : Enumerable.Empty<T>();

	public static async Task<IEnumerable<T>> ToEnumerable<T>(this Task<Option<T>> option)
		where T : notnull
		=> (await option).ToEnumerable();
}
