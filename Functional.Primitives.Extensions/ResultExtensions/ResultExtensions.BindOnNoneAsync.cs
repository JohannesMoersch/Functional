namespace Functional;

public static partial class ResultExtensions
{
	public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Result<TSuccess, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
			? await bind().Map(static _ => Option.Some(_))
			: result;
	}

	public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Result<TSuccess, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).BindOnNoneAsync(bind);

	public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Result<Option<TSuccess>, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
			? await bind()
			: result;
	}

	public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Result<Option<TSuccess>, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).BindOnNoneAsync(bind);
}
