namespace Functional;

public static partial class ResultQuerySyntaxExtensions
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Result<TResult, TFailure> Select<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, TResult> selector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> result.Map(selector);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Task<Result<TResult, TFailure>> Select<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, TResult> selector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> result.Map(selector);
}
