namespace Functional;

public static partial class ResultExtensions
{
	public static Result<TSuccess, TFailure> FailOnNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TFailure> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (failureFactory == null)
			throw new ArgumentNullException(nameof(failureFactory));

		if (result.TryGetValue(out var success, out var failure))
		{
			if (success.TryGetValue(out var some))
				return Result.Success<TSuccess, TFailure>(some);

			return Result.Failure<TSuccess, TFailure>(failureFactory.Invoke());
		}

		return Result.Failure<TSuccess, TFailure>(failure);
	}

	public static async Task<Result<TSuccess, TFailure>> FailOnNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TFailure> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).FailOnNone(failureFactory);
}
