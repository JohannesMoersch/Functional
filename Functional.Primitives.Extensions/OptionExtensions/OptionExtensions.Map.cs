namespace Functional;

public static partial class OptionExtensions
{
	public static Option<TResult> Map<TValue, TResult>(this Option<TValue> option, Func<TValue, TResult> map)
		where TValue : notnull
		where TResult : notnull
	{
		if (map == null)
			throw new ArgumentNullException(nameof(map));

		if (option.TryGetValue(out var some))
			return Option.Some(map.Invoke(some));

		return Option.None<TResult>();
	}

	public static async Task<Option<TResult>> Map<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, TResult> map)
		where TValue : notnull
		where TResult : notnull
		=> (await option).Map(map);
}
