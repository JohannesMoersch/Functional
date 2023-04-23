namespace Functional;

public static partial class ResultExtensions
{
	public static async Task<Result<TSuccess, TFailure>> DoAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task> onSuccess, Func<TFailure, Task> onFailure)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (onSuccess == null)
			throw new ArgumentNullException(nameof(onSuccess));

		if (onFailure == null)
			throw new ArgumentNullException(nameof(onFailure));

		if (result.TryGetValue(out var success, out var failure))
			await onSuccess.Invoke(success);
		else
			await onFailure.Invoke(failure);

		return result;
	}

	public static async Task<Result<TSuccess, TFailure>> DoAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task> success, Func<TFailure, Task> failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).DoAsync(success, failure);

	public static Task<Result<TSuccess, TFailure>> DoAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task> success)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.DoAsync(success, static _ => Task.CompletedTask);

	public static async Task<Result<TSuccess, TFailure>> DoAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task> success)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).DoAsync(success, static _ => Task.CompletedTask);
}
