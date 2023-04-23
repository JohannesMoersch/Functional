namespace Functional;

public static partial class OptionExtensions
{
	public static Option<TValue> DoOnNone<TValue>(this Option<TValue> option, Action @do)
		where TValue : notnull
		=> option.Do(static _ => { }, @do);

	public static async Task<Option<TValue>> DoOnNone<TValue>(this Task<Option<TValue>> option, Action @do)
		where TValue : notnull
		=> (await option).DoOnNone(@do);
}
