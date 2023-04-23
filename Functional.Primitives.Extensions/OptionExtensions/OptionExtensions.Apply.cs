namespace Functional;

public static partial class OptionExtensions
{
	public static void Apply<TValue>(this Option<TValue> option, Action<TValue> applyWhenSome, Action applyWhenNone)
		where TValue : notnull
		=> option.Do(applyWhenSome, applyWhenNone);

	public static Task Apply<TValue>(this Task<Option<TValue>> option, Action<TValue> applyWhenSome, Action applyWhenNone)
		where TValue : notnull
		=> option.Do(applyWhenSome, applyWhenNone);
}
