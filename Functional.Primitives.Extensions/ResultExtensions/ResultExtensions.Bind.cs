namespace Functional;

public static partial class ResultExtensions
{
	public static Result<TResult, TFailure> Bind<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Result<TResult, TFailure>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (result.TryGetValue(out var success, out var failure))
			return bind.Invoke(success);

		return Result.Failure<TResult, TFailure>(failure);
	}

	public static async Task<Result<TResult, TFailure>> Bind<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Result<TResult, TFailure>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> (await result).Bind(bind);
}
