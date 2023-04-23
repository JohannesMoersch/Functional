namespace Functional;

public static partial class OptionExtensions
{
	public static async Task<Option<TValue>> BindOnNoneAsync<TValue>(this Option<TValue> option, Func<Task<Option<TValue>>> bind)
		where TValue : notnull
		=> option.TryGetValue(out _) ? option : await bind();

	public static async Task<Option<TValue>> BindOnNoneAsync<TValue>(this Task<Option<TValue>> option, Func<Task<Option<TValue>>> bind)
		where TValue : notnull
		=> await (await option).BindOnNoneAsync(bind);
}
