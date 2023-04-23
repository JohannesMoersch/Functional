namespace Functional;

public static partial class ResultExtensions
{
	public static Result<Option<TSuccess>, TFailure> Evert<TSuccess, TFailure>(this Option<Result<TSuccess, TFailure>> source)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (source.TryGetValue(out var some))
		{
			return some.TryGetValue(out var success, out var failure)
				? Result.Success<Option<TSuccess>, TFailure>(Option.Some(success))
				: Result.Failure<Option<TSuccess>, TFailure>(failure);
		}

		return Result.Success<Option<TSuccess>, TFailure>(Option.None<TSuccess>());
	}

	public static async Task<Result<Option<TSuccess>, TFailure>> Evert<TSuccess, TFailure>(this Task<Option<Result<TSuccess, TFailure>>> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await source).Evert();
}
