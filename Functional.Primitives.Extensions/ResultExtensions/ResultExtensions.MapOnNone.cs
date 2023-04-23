namespace Functional;

public static partial class ResultExtensions
{
	public static Result<Option<TSuccess>, TFailure> MapOnNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess> map)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
			? Result.Success<Option<TSuccess>, TFailure>(Option.Some(map()))
			: result;

	public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess> map)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).MapOnNone(map);

	public static Result<Option<TSuccess>, TFailure> MapOnNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Option<TSuccess>> map)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
			? Result.Success<Option<TSuccess>, TFailure>(map())
			: result;

	public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Option<TSuccess>> map)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).MapOnNone(map);
}
