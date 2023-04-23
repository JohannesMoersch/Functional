namespace Functional;

public static partial class OptionExtensions
{
	public static async Task<Option<TValue>> DoAsync<TValue>(this Option<TValue> option, Func<TValue, Task> doWhenSome, Func<Task> doWhenNone)
		where TValue : notnull
	{
		if (doWhenSome == null)
			throw new ArgumentNullException(nameof(doWhenSome));

		if (doWhenNone == null)
			throw new ArgumentNullException(nameof(doWhenNone));

		if (option.TryGetValue(out var some))
			await doWhenSome.Invoke(some);
		else
			await doWhenNone.Invoke();

		return option;
	}

	public static async Task<Option<TValue>> DoAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task> doWhenSome, Func<Task> doWhenNone)
		where TValue : notnull
		=> await (await option).DoAsync(doWhenSome, doWhenNone);

	public static Task<Option<TValue>> DoAsync<TValue>(this Option<TValue> option, Func<TValue, Task> @do)
		where TValue : notnull
		=> option.DoAsync(@do, static () => Task.CompletedTask);

	public static async Task<Option<TValue>> DoAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task> @do)
		where TValue : notnull
		=> await (await option).DoAsync(@do, static () => Task.CompletedTask);
}
