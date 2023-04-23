namespace Functional;

public static partial class ResultExtensions
{
	public static async Task<Result<Option<TResult>, TFailure>> MapOnSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<TResult>> map)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> result.TryGetValue(out var success, out var failure)
			? Result.Success<Option<TResult>, TFailure>(await success.MapAsync(map))
			: Result.Failure<Option<TResult>, TFailure>(failure);

	public static async Task<Result<Option<TResult>, TFailure>> MapOnSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<TResult>> map)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> await (await result).MapOnSomeAsync(map);

	public static async Task<Result<Option<TResult>, TFailure>> MapOnSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Option<TResult>>> map)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> result.TryGetValue(out var success, out var failure)
			? Result.Success<Option<TResult>, TFailure>(await success.BindAsync(map))
			: Result.Failure<Option<TResult>, TFailure>(failure);

	public static async Task<Result<Option<TResult>, TFailure>> MapOnSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Option<TResult>>> map)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> await (await result).MapOnSomeAsync(map);
}
