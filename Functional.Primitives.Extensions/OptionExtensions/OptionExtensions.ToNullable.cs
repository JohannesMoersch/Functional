namespace Functional;

public static partial class OptionExtensions
{
	public static TValue? ToNullable<TValue>(this Option<TValue> option)
		where TValue : struct
		=> option.TryGetValue(out var some) ? (TValue?)some : null;

	public static async Task<TValue?> ToNullable<TValue>(this Task<Option<TValue>> option)
		where TValue : struct
		=> (await option).ToNullable();
}
