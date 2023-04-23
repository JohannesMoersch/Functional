namespace Functional;

public static partial class ResultExtensions
{
	public static Result<TSuccess, TResult> MapOnFailure<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TFailure, TResult> mapFailure)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (mapFailure == null)
			throw new ArgumentNullException(nameof(mapFailure));

		if (result.TryGetValue(out var success, out var failure))
			return Result.Success<TSuccess, TResult>(success);

		return Result.Failure<TSuccess, TResult>(mapFailure.Invoke(failure));
	}

	public static async Task<Result<TSuccess, TResult>> MapOnFailure<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, TResult> mapFailure)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> (await result).MapOnFailure(mapFailure);
}
