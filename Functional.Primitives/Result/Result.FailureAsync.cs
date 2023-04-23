namespace Functional;

public static partial class Result
{
	public static async Task<Result<TSuccess, TFailure>> FailureAsync<TSuccess, TFailure>(Task<TFailure> failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> Failure<TSuccess, TFailure>(await failure);
}
