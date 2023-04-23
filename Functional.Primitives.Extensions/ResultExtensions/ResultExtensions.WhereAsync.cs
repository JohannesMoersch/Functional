namespace Functional;

public static partial class ResultExtensions
{
	public static async Task<Result<TSuccess, TFailure>> WhereAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<bool>> predicate, Func<TSuccess, Task<TFailure>> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (predicate == null)
			throw new ArgumentNullException(nameof(predicate));

		if (failureFactory == null)
			throw new ArgumentNullException(nameof(failureFactory));

		if (result.TryGetValue(out var success, out var failure))
			return await predicate.Invoke(success) ? Result.Success<TSuccess, TFailure>(success) : Result.Failure<TSuccess, TFailure>(await failureFactory.Invoke(success));

		return Result.Failure<TSuccess, TFailure>(failure);
	}

	public static async Task<Result<TSuccess, TFailure>> WhereAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<bool>> predicate, Func<TSuccess, Task<TFailure>> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).WhereAsync(predicate, failureFactory);
}
