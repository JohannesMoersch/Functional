namespace Functional;

public static partial class OptionExtensions
{
	public static async Task<TValue> ValueOrDefaultAsync<TValue>(this Option<TValue> option, Func<Task<TValue>> valueFactory)
		where TValue : notnull
		=> option.TryGetValue(out var some) ? some : await valueFactory.Invoke();

	public static async Task<TValue> ValueOrDefaultAsync<TValue>(this Task<Option<TValue>> option, Func<Task<TValue>> valueFactory)
		where TValue : notnull
		=> await (await option).ValueOrDefaultAsync(valueFactory);
}
