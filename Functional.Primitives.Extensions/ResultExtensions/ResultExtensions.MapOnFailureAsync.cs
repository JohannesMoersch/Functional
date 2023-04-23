namespace Functional;

public static partial class ResultExtensions
{
	public static async Task<Result<TSuccess, TResult>> MapOnFailureAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TFailure, Task<TResult>> mapFailure)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (mapFailure == null)
			throw new ArgumentNullException(nameof(mapFailure));

		if (result.TryGetValue(out var success, out var failure))
			return Result.Success<TSuccess, TResult>(success);

		return Result.Failure<TSuccess, TResult>(await mapFailure.Invoke(failure));
	}

	public static async Task<Result<TSuccess, TResult>> MapOnFailureAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, Task<TResult>> mapFailure)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> await (await result).MapOnFailureAsync(mapFailure);
}
