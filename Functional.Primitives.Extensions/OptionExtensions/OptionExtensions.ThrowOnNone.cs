namespace Functional;

public static partial class OptionExtensions
{
	public static TValue ThrowOnNone<TValue>(this Option<TValue> option, Func<Exception> exceptionFactory)
		where TValue : notnull
		=> option.TryGetValue(out var some) ? some : throw exceptionFactory.Invoke();

	public static async Task<TValue> ThrowOnNone<TValue>(this Task<Option<TValue>> option, Func<Exception> exceptionFactory)
		where TValue : notnull
		=> (await option).ThrowOnNone(exceptionFactory);
}
