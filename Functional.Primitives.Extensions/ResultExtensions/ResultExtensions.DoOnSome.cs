namespace Functional;

public static partial class ResultExtensions
{
	public static Result<Option<TSuccess>, TFailure> DoOnSome<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Action<TSuccess> onSuccessSome)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (onSuccessSome == null)
			throw new ArgumentNullException(nameof(onSuccessSome));

		if (result.TryGetValue(out var success, out var failure) && success.TryGetValue(out var some))
			onSuccessSome.Invoke(some);

		return result;
	}

	public static async Task<Result<Option<TSuccess>, TFailure>> DoOnSome<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Action<TSuccess> onSuccessSome)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).DoOnSome(onSuccessSome);
}
