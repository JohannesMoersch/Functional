namespace Functional;

public static partial class ResultQuerySyntaxExtensions
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Result<TSuccess, TFailure> Where<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Result<Unit, TFailure>> failurePredicate)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (failurePredicate == null)
			throw new ArgumentNullException(nameof(failurePredicate));
		if (result.TryGetValue(out var success, out _) && !failurePredicate.Invoke(success).TryGetValue(out _, out var f))
			return Result.Failure<TSuccess, TFailure>(f);

		return result;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static async Task<Result<TSuccess, TFailure>> Where<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Result<Unit, TFailure>> failurePredicate)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (failurePredicate == null)
			throw new ArgumentNullException(nameof(failurePredicate));

		var value = await result;

		if (value.TryGetValue(out var success, out _) && !failurePredicate.Invoke(success).TryGetValue(out _, out var f))
			return Result.Failure<TSuccess, TFailure>(f);

		return value;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static async Task<Result<TSuccess, TFailure>> Where<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<Result<Unit, TFailure>>> failurePredicate)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (failurePredicate == null)
			throw new ArgumentNullException(nameof(failurePredicate));

		if (result.TryGetValue(out var success, out _) && !(await failurePredicate.Invoke(success)).TryGetValue(out _, out var f))
			return Result.Failure<TSuccess, TFailure>(f);

		return result;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static async Task<Result<TSuccess, TFailure>> Where<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<Result<Unit, TFailure>>> failurePredicate)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (failurePredicate == null)
			throw new ArgumentNullException(nameof(failurePredicate));

		var value = await result;

		if (value.TryGetValue(out var success, out _) && !(await failurePredicate.Invoke(success)).TryGetValue(out _, out var f))
			return Result.Failure<TSuccess, TFailure>(f);

		return value;
	}
}
