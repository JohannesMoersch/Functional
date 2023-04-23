namespace Functional;

public static partial class ResultExtensions
{
	public static Option<TFailure> Failure<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.TryGetValue(out var success, out var failure) ? Option.None<TFailure>() : Option.Some(failure);

	public static async Task<Option<TFailure>> Failure<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).Failure();
}
