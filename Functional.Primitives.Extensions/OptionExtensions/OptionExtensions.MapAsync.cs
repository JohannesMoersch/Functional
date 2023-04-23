namespace Functional;

public static partial class OptionExtensions
{
	public static async Task<Option<TResult>> MapAsync<TValue, TResult>(this Option<TValue> option, Func<TValue, Task<TResult>> map)
		where TValue : notnull
		where TResult : notnull
	{
		if (map == null)
			throw new ArgumentNullException(nameof(map));

		if (option.TryGetValue(out var some))
			return Option.Some(await map.Invoke(some));

		return Option.None<TResult>();
	}

	public static async Task<Option<TResult>> MapAsync<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<TResult>> map)
		where TValue : notnull
		where TResult : notnull
		=> await (await option).MapAsync(map);
}
