namespace Functional;

public static partial class OptionQuerySyntaxExtensions
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Option<TValue> Where<TValue>(this Option<TValue> option, Func<TValue, Option<Unit>> predicate)
		where TValue : notnull
	{
		if (option.TryGetValue(out var some) && predicate.Invoke(some).TryGetValue(out _))
			return Option.Some(some);

		return Option.None<TValue>();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static async Task<Option<TValue>> Where<TValue>(this Task<Option<TValue>> option, Func<TValue, Option<Unit>> predicate)
		where TValue : notnull
	{
		if ((await option).TryGetValue(out var some) && predicate.Invoke(some).TryGetValue(out _))
			return Option.Some(some);

		return Option.None<TValue>();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static async Task<Option<TValue>> Where<TValue>(this Option<TValue> option, Func<TValue, Task<Option<Unit>>> predicate)
		where TValue : notnull
	{
		if (option.TryGetValue(out var some) && (await predicate.Invoke(some)).TryGetValue(out _))
			return Option.Some(some);

		return Option.None<TValue>();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static async Task<Option<TValue>> Where<TValue>(this Task<Option<TValue>> option, Func<TValue, Task<Option<Unit>>> predicate)
		where TValue : notnull
	{
		if ((await option).TryGetValue(out var some) && (await predicate.Invoke(some)).TryGetValue(out _))
			return Option.Some(some);

		return Option.None<TValue>();
	}
}
