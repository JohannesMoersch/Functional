namespace Functional;

public static partial class ResultExtensions
{
	public static Result<Option<TSuccess>, TFailure> WhereOnSome<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));
		if (failureFactory == null) throw new ArgumentNullException(nameof(failureFactory));

		if (result.TryGetValue(out var success, out var failure) && success.TryGetValue(out var some))
		{
			return predicate.Invoke(some)
				? result
				: Result.Failure<Option<TSuccess>, TFailure>(failureFactory.Invoke(some));
		}

		return result;
	}

	public static async Task<Result<Option<TSuccess>, TFailure>> WhereOnSome<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).WhereOnSome(predicate, failureFactory);
}
