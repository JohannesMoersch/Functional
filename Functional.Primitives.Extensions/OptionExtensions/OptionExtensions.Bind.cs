namespace Functional;

public static partial class OptionExtensions
{
	public static Option<TResult> Bind<TValue, TResult>(this Option<TValue> option, Func<TValue, Option<TResult>> bind)
		where TValue : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (option.TryGetValue(out var some))
			return bind.Invoke(some);

		return Option.None<TResult>();
	}

	public static async Task<Option<TResult>> Bind<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Option<TResult>> bind)
		where TValue : notnull
		where TResult : notnull
		=> (await option).Bind(bind);
}
