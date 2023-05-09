namespace Functional;

public static partial class ResultEnumerableQuerySyntaxExtensions
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IResultEnumerable<TResult, TFailure> Select<TSuccess, TResult, TFailure>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, TResult> selector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (selector == null)
			throw new ArgumentNullException(nameof(selector));

		return source
			.Select(result => result
				.Match(
					success => Result.Success<TResult, TFailure>(selector.Invoke(success)),
					Result.Failure<TResult, TFailure>
				)
			)
			.AsResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> Select<TSuccess, TResult, TFailure>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, TResult> selector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (selector == null)
			throw new ArgumentNullException(nameof(selector));

		return source
			.Select(result => result
				.Match(
					success => Result.Success<TResult, TFailure>(selector.Invoke(success)),
					Result.Failure<TResult, TFailure>
				)
			)
			.AsAsyncResultEnumerable();
	}
}