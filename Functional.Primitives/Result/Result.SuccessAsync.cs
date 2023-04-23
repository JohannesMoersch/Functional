namespace Functional;

public static partial class Result
{
	public static async Task<Result<TSuccess, TFailure>> SuccessAsync<TSuccess, TFailure>(Task<TSuccess> success)
		where TSuccess : notnull
		where TFailure : notnull
		=> Success<TSuccess, TFailure>(await success);
}
