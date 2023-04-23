namespace Functional;

public static partial class ResultExtensions
{
	public static bool IsSuccess<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.TryGetValue(out var success, out var failure) ? true : false;

	public static async Task<bool> IsSuccess<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).IsSuccess();
}
