namespace Functional;

public static partial class OptionExtensions
{
	public static bool HasValue<TValue>(this Option<TValue> option)
		where TValue : notnull
		=> option.Match(static _ => true, static () => false);

	public static async Task<bool> HasValue<TValue>(this Task<Option<TValue>> option)
		where TValue : notnull
		=> (await option).HasValue();
}
