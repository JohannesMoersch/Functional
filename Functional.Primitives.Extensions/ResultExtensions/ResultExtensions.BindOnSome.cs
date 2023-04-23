namespace Functional;

public static partial class ResultExtensions
{
	public static Result<Option<TResult>, TFailure> BindOnSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Result<TResult, TFailure>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (result.TryGetValue(out var success, out var failure))
		{
			if (success.TryGetValue(out var some))
				return bind.Invoke(some).Map(static _ => Option.Some(_));

			return Result.Success<Option<TResult>, TFailure>(Option.None<TResult>());
		}

		return Result.Failure<Option<TResult>, TFailure>(failure);
	}

	public static async Task<Result<Option<TResult>, TFailure>> BindOnSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Result<TResult, TFailure>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> (await result).BindOnSome(bind);

	public static Result<Option<TResult>, TFailure> BindOnSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Result<Option<TResult>, TFailure>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (result.TryGetValue(out var success, out var failure))
		{
			if (success.TryGetValue(out var some))
				return bind.Invoke(some);

			return Result.Success<Option<TResult>, TFailure>(Option.None<TResult>());
		}

		return Result.Failure<Option<TResult>, TFailure>(failure);
	}

	public static async Task<Result<Option<TResult>, TFailure>> BindOnSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Result<Option<TResult>, TFailure>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> (await result).BindOnSome(bind);
}
