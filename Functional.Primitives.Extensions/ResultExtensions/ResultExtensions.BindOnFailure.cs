namespace Functional;

public static partial class ResultExtensions
{
	public static Result<TSuccess, TResult> BindOnFailure<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TFailure, Result<TSuccess, TResult>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (bind == null) throw new ArgumentNullException(nameof(bind));

		return !result.TryGetValue(out var success, out var failure)
			? bind.Invoke(failure)
			: Result.Success<TSuccess, TResult>(success);
	}

	public static async Task<Result<TSuccess, TResult>> BindOnFailure<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, Result<TSuccess, TResult>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> (await result).BindOnFailure(bind);
}
