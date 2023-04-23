namespace Functional;

public static partial class OptionExtensions
{
	public static async Task<TResult> Match<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, TResult> some, Func<TResult> none)
		where TValue : notnull
		=> (await option).Match(some, none);
}
