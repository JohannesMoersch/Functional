namespace Functional;

public static partial class ResultExtensions
{
	public static async Task<Result<Option<TSuccess>, TFailure>> WhereOnSomeAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<bool>> predicate, Func<TSuccess, TFailure> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));
		if (failureFactory == null) throw new ArgumentNullException(nameof(failureFactory));

		if (result.TryGetValue(out var success, out var failure) && success.TryGetValue(out var some))
		{
			return await predicate.Invoke(some)
				? result
				: Result.Failure<Option<TSuccess>, TFailure>(failureFactory.Invoke(some));
		}

		return result;
	}

	public static async Task<Result<Option<TSuccess>, TFailure>> WhereOnSomeAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<bool>> predicate, Func<TSuccess, TFailure> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).WhereOnSomeAsync(predicate, failureFactory);
}
