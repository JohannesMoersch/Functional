namespace Functional;

public static partial class OptionQuerySyntaxExtensions
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Option<TResult> Select<TValue, TResult>(this Option<TValue> option, Func<TValue, TResult> selector)
		where TValue : notnull
		where TResult : notnull
		=> option.Map(selector);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Task<Option<TResult>> Select<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, TResult> selector)
		where TValue : notnull
		where TResult : notnull
		=> option.Map(selector);
}
