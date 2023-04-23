namespace Functional;

public static partial class OptionExtensions
{
	public static Option<TValue> OfType<TValue>(this Option<object> option)
		where TValue : notnull
		=> option.TryGetValue(out var some) ? (some is TValue value ? Option.Some(value) : Option.None<TValue>()) : Option.None<TValue>();

	public static async Task<Option<TValue>> OfType<TValue>(this Task<Option<object>> option)
		where TValue : notnull
		=> (await option).OfType<TValue>();
}
