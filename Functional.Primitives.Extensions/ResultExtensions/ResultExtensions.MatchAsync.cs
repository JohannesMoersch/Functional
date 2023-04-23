namespace Functional;

public static partial class ResultExtensions
{
	public static Task<TResult> MatchAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<TResult>> success, Func<TFailure, Task<TResult>> failure)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> result.Match(success, failure);

	public static async Task<TResult> MatchAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<TResult>> success, Func<TFailure, Task<TResult>> failure)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> await (await result).Match(success, failure);

	public static Task<T> MatchAsync<TSuccess, TFailure, T>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<T>> onSuccessSome, Func<Task<T>> onSuccessNone, Func<TFailure, Task<T>> onFailure)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (onFailure == null)
			throw new ArgumentNullException(nameof(onFailure));

		return result.TryGetValue(out var success, out var failure)
			? success.Match(onSuccessSome, onSuccessNone)
			: onFailure.Invoke(failure);
	}

	public static async Task<T> MatchAsync<TSuccess, TFailure, T>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<T>> successSome, Func<Task<T>> successNone, Func<TFailure, Task<T>> failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).MatchAsync(successSome, successNone, failure);
}
