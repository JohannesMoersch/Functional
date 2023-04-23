namespace Functional;

public static partial class ResultExtensions
{
	public static Result<TSuccess, TFailure> Where<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (predicate == null)
			throw new ArgumentNullException(nameof(predicate));

		if (failureFactory == null)
			throw new ArgumentNullException(nameof(failureFactory));

		if (result.TryGetValue(out var success, out var failure))
			return predicate.Invoke(success) ? Result.Success<TSuccess, TFailure>(success) : Result.Failure<TSuccess, TFailure>(failureFactory.Invoke(success));

		return Result.Failure<TSuccess, TFailure>(failure);
	}

	public static async Task<Result<TSuccess, TFailure>> Where<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).Where(predicate, failureFactory);
}
