namespace Functional;

public static partial class OptionExtensions
{
	public static async Task<Option<TValue>> DoOnNoneAsync<TValue>(this Option<TValue> option, Func<Task> @do)
		where TValue : notnull
		=> await option.DoAsync(static _ => Task.CompletedTask, @do);

	public static async Task<Option<TValue>> DoOnNoneAsync<TValue>(this Task<Option<TValue>> option, Func<Task> @do)
		where TValue : notnull
		=> await (await option).DoOnNoneAsync(@do);
}
