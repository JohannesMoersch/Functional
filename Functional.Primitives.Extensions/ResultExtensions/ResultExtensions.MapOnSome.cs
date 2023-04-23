namespace Functional;

public static partial class ResultExtensions
{
	public static Result<Option<TResult>, TFailure> MapOnSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, TResult> map)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> result.TryGetValue(out var success, out var failure)
			? Result.Success<Option<TResult>, TFailure>(success.Map(map))
			: Result.Failure<Option<TResult>, TFailure>(failure);

	public static async Task<Result<Option<TResult>, TFailure>> MapOnSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, TResult> map)
		where TResult : notnull
		where TFailure : notnull
		where TSuccess : notnull
		=> (await result).MapOnSome(map);

	public static Result<Option<TResult>, TFailure> MapOnSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Option<TResult>> map)
		where TResult : notnull
		where TFailure : notnull
		where TSuccess : notnull
		=> result.TryGetValue(out var success, out var failure)
			? Result.Success<Option<TResult>, TFailure>(success.Bind(map))
			: Result.Failure<Option<TResult>, TFailure>(failure);

	public static async Task<Result<Option<TResult>, TFailure>> MapOnSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Option<TResult>> map)
		where TResult : notnull
		where TFailure : notnull
		where TSuccess : notnull
		=> (await result).MapOnSome(map);
}
