namespace Functional;

public static partial class ResultExtensions
{
	public static async Task<Result<TResult, TFailure>> MapAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<TResult>> map)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (map == null)
			throw new ArgumentNullException(nameof(map));

		if (result.TryGetValue(out var success, out var failure))
			return Result.Success<TResult, TFailure>(await map.Invoke(success));

		return Result.Failure<TResult, TFailure>(failure);
	}

	public static async Task<Result<TResult, TFailure>> MapAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<TResult>> map)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> await (await result).MapAsync(map);
}
