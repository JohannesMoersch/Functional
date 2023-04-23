namespace Functional;

public static partial class OptionExtensions
{
	public static Task<TResult> MatchAsync<TValue, TResult>(this Option<TValue> option, Func<TValue, Task<TResult>> some, Func<Task<TResult>> none)
		where TValue : notnull
		=> option.Match(some, none);

	public static async Task<TResult> MatchAsync<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<TResult>> some, Func<Task<TResult>> none)
		where TValue : notnull
		=> await (await option).Match(some, none);
}
