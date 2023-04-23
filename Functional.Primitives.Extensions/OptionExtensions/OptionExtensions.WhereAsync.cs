namespace Functional;

public static partial class OptionExtensions
{
	public static async Task<Option<TValue>> WhereAsync<TValue>(this Option<TValue> option, Func<TValue, Task<bool>> predicate)
		where TValue : notnull
	{
		if (predicate == null)
			throw new ArgumentNullException(nameof(predicate));

		if (option.TryGetValue(out var some))
			return Option.Create(await predicate.Invoke(some), some);

		return Option.None<TValue>();
	}

	public static async Task<Option<TValue>> WhereAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task<bool>> predicate)
		where TValue : notnull
		=> await (await option).WhereAsync(predicate);
}
