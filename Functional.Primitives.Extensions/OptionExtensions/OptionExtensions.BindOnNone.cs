namespace Functional;

public static partial class OptionExtensions
{
	public static Option<TValue> BindOnNone<TValue>(this Option<TValue> option, Func<Option<TValue>> bind)
		where TValue : notnull
		=> option.TryGetValue(out _) ? option : bind();

	public static async Task<Option<TValue>> BindOnNone<TValue>(this Task<Option<TValue>> option, Func<Option<TValue>> bind)
		where TValue : notnull
		=> (await option).BindOnNone(bind);
}
