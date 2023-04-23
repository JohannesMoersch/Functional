namespace Functional;

public static partial class ResultExtensions
{
	public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<TSuccess>> map)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
			? Result.Success<Option<TSuccess>, TFailure>(Option.Some(await map()))
			: result;

	public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<TSuccess>> map)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).MapOnNoneAsync(map);

	public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Option<TSuccess>>> map)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
			? Result.Success<Option<TSuccess>, TFailure>(await map())
			: result;

	public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Option<TSuccess>>> map)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).MapOnNoneAsync(map);
}
