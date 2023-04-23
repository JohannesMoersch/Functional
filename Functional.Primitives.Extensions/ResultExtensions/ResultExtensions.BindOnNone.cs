namespace Functional;

public static partial class ResultExtensions
{
	public static Result<Option<TSuccess>, TFailure> BindOnNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Result<TSuccess, TFailure>> bind)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
			? bind().Map(static _ => Option.Some(_))
			: result;
	}

	public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Result<TSuccess, TFailure>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).BindOnNone(bind);

	public static Result<Option<TSuccess>, TFailure> BindOnNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Result<Option<TSuccess>, TFailure>> bind)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
			? bind()
			: result;
	}

	public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Result<Option<TSuccess>, TFailure>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).BindOnNone(bind);
}
