namespace Functional;

public static partial class ResultExtensions
{
	public static Option<TSuccess> Success<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.TryGetValue(out var success, out var failure) ? Option.Some(success) : Option.None<TSuccess>();

	public static async Task<Option<TSuccess>> Success<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).Success();
}
