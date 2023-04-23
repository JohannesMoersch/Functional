namespace Functional;

public static partial class OptionExtensions
{
	public static Option<TValue> Do<TValue>(this Option<TValue> option, Action<TValue> doWhenSome, Action doWhenNone)
		where TValue : notnull
	{
		if (doWhenSome == null)
			throw new ArgumentNullException(nameof(doWhenSome));

		if (doWhenNone == null)
			throw new ArgumentNullException(nameof(doWhenNone));

		if (option.TryGetValue(out var some))
			doWhenSome.Invoke(some);
		else
			doWhenNone.Invoke();

		return option;
	}

	public static async Task<Option<TValue>> Do<TValue>(this Task<Option<TValue>> option, Action<TValue> doWhenSome, Action doWhenNone)
		where TValue : notnull
		=> (await option).Do(doWhenSome, doWhenNone);

	public static Option<TValue> Do<TValue>(this Option<TValue> option, Action<TValue> @do)
		where TValue : notnull
		=> option.Do(@do, static () => { });

	public static async Task<Option<TValue>> Do<TValue>(this Task<Option<TValue>> option, Action<TValue> @do)
		where TValue : notnull
		=> (await option).Do(@do, static () => { });
}
