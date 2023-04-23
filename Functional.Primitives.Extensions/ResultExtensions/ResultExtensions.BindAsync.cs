namespace Functional;

public static partial class ResultExtensions
{
	public static async Task<Result<TResult, TFailure>> BindAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (result.TryGetValue(out var success, out var failure))
			return await bind.Invoke(success);

		return Result.Failure<TResult, TFailure>(failure);
	}

	public static async Task<Result<TResult, TFailure>> BindAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> await (await result).BindAsync(bind);
}
