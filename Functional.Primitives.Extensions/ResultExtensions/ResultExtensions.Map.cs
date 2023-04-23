namespace Functional;

public static partial class ResultExtensions
{
	public static Result<TResult, TFailure> Map<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, TResult> map)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (map == null)
			throw new ArgumentNullException(nameof(map));

		if (result.TryGetValue(out var success, out var failure))
			return Result.Success<TResult, TFailure>(map.Invoke(success));

		return Result.Failure<TResult, TFailure>(failure);
	}

	public static async Task<Result<TResult, TFailure>> Map<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, TResult> map)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> (await result).Map(map);
}
