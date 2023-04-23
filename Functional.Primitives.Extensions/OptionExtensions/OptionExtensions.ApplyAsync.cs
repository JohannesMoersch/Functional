namespace Functional;

public static partial class OptionExtensions
{
	public static Task ApplyAsync<TValue>(this Option<TValue> option, Func<TValue, Task> applyWhenSome, Func<Task> applyWhenNone)
		where TValue : notnull
		=> option.DoAsync(applyWhenSome, applyWhenNone);

	public static Task ApplyAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task> applyWhenSome, Func<Task> applyWhenNone)
		where TValue : notnull
		=> option.DoAsync(applyWhenSome, applyWhenNone);
}
