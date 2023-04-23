namespace Functional;

public static partial class OptionExtensions
{
	public static TValue? ValueOrDefault<TValue>(this Option<TValue> option)
		where TValue : notnull
		=> option.TryGetValue(out var some) ? some : default;

	public static TValue ValueOrDefault<TValue>(this Option<TValue> option, TValue defaultValue)
		where TValue : notnull
		=> option.TryGetValue(out var some) ? some : defaultValue;

	public static async Task<TValue?> ValueOrDefault<TValue>(this Task<Option<TValue>> option)
		where TValue : notnull
		=> (await option).ValueOrDefault();

	public static async Task<TValue> ValueOrDefault<TValue>(this Task<Option<TValue>> option, TValue defaultValue)
		where TValue : notnull
		=> (await option).ValueOrDefault(defaultValue);

	public static TValue ValueOrDefault<TValue>(this Option<TValue> option, Func<TValue> valueFactory)
		where TValue : notnull
		=> option.TryGetValue(out var some) ? some : valueFactory.Invoke();

	public static async Task<TValue> ValueOrDefault<TValue>(this Task<Option<TValue>> option, Func<TValue> valueFactory)
		where TValue : notnull
		=> (await option).ValueOrDefault(valueFactory);

	public static IEnumerable<TValue> ValueOrEmpty<TValue>(this Option<IEnumerable<TValue>> option)
		=> option.ValueOrDefault(Enumerable.Empty<TValue>());

	public static async Task<IEnumerable<TValue>> ValueOrEmpty<TValue>(this Task<Option<IEnumerable<TValue>>> option)
		=> (await option).ValueOrEmpty();
}
