namespace Functional;

public static partial class ResultExtensions
{
	public static async Task<TResult> Match<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, TResult> success, Func<TFailure, TResult> failure)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> (await result).Match(success, failure);

	public static T Match<TSuccess, TFailure, T>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, T> onSuccessSome, Func<T> onSuccessNone, Func<TFailure, T> onFailure)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (onFailure == null)
			throw new ArgumentNullException(nameof(onFailure));

		return result.TryGetValue(out var success, out var failure)
			? success.Match(onSuccessSome, onSuccessNone)
			: onFailure.Invoke(failure);
	}

	public static async Task<T> Match<TSuccess, TFailure, T>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, T> successSome, Func<T> successNone, Func<TFailure, T> failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).Match(successSome, successNone, failure);
}
