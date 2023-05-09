namespace Functional;

public static partial class OptionEnumerableQuerySyntaxExtensions
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IOptionEnumerable<TResult> Select<TSuccess, TResult>(this IOptionEnumerable<TSuccess> source, Func<TSuccess, TResult> selector)
		where TSuccess : notnull
		where TResult : notnull
	{
		if (selector == null)
			throw new ArgumentNullException(nameof(selector));

		return source
			.Select(result => result
				.Match(
					success => Option.Some(selector.Invoke(success)),
					Option.None<TResult>
				)
			)
			.AsOptionEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncOptionEnumerable<TResult> Select<TSuccess, TResult>(this IAsyncOptionEnumerable<TSuccess> source, Func<TSuccess, TResult> selector)
		where TSuccess : notnull
		where TResult : notnull
	{
		if (selector == null)
			throw new ArgumentNullException(nameof(selector));

		return source
			.Select(result => result
				.Match(
					success => Option.Some(selector.Invoke(success)),
					Option.None<TResult>
				)
			)
			.AsAsyncOptionEnumerable();
	}
}