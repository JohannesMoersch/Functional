namespace Functional;

public static partial class ResultExtensions
{
	public static Task<Result<TSuccess, TFailure>> DoOnFailureAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TFailure, Task> failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.DoAsync(static _ => Task.CompletedTask, failure);

	public static async Task<Result<TSuccess, TFailure>> DoOnFailureAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, Task> failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).DoAsync(static _ => Task.CompletedTask, failure);
}
