namespace Functional;

public static partial class OptionExtensions
{
	[AllowAllocations(allowNewArr: true)]
	public static T[] ToArray<T>(this Option<T> option)
		where T : notnull
		=> option.TryGetValue(out var value) ? new[] { value } : Array.Empty<T>();

	public static async Task<T[]> ToArray<T>(this Task<Option<T>> option)
		where T : notnull
		=> (await option).ToArray();
}
