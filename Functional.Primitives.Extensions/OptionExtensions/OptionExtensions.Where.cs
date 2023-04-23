namespace Functional;

public static partial class OptionExtensions
{
	public static Option<TValue> Where<TValue>(this Option<TValue> option, Func<TValue, bool> predicate)
		where TValue : notnull
	{
		if (predicate == null)
			throw new ArgumentNullException(nameof(predicate));

		if (option.TryGetValue(out var some))
			return Option.Create(predicate.Invoke(some), some);

		return Option.None<TValue>();
	}

	public static async Task<Option<TValue>> Where<TValue>(this Task<Option<TValue>> option, Func<TValue, bool> predicate)
		where TValue : notnull
		=> (await option).Where(predicate);
}
