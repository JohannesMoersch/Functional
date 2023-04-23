namespace Functional;

public static partial class ResultExtensions
{
	public static async Task<Result<Option<TSuccess>, TFailure>> DoOnSomeAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task> onSuccessSome)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (onSuccessSome == null)
			throw new ArgumentNullException(nameof(onSuccessSome));

		if (result.TryGetValue(out var success, out var failure) && success.TryGetValue(out var some))
			await onSuccessSome.Invoke(some);

		return result;
	}

	public static async Task<Result<Option<TSuccess>, TFailure>> DoOnSomeAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task> onSuccessSome)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).DoOnSomeAsync(onSuccessSome);
}
