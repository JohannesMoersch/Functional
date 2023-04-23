namespace Functional;

public static partial class OptionExtensions
{
	public static async Task<Option<TResult>> BindAsync<TValue, TResult>(this Option<TValue> option, Func<TValue, Task<Option<TResult>>> bind)
		where TValue : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (option.TryGetValue(out var some))
			return await bind.Invoke(some);

		return Option.None<TResult>();
	}

	public static async Task<Option<TResult>> BindAsync<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<Option<TResult>>> bind)
		where TValue : notnull
		where TResult : notnull
		=> await (await option).BindAsync(bind);
}
