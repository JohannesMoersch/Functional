namespace Functional;

public static partial class ResultExtensions
{
	public static TSuccess ThrowOnFailure<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TFailure, Exception> exceptionFactory)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.TryGetValue(out var success, out var failure) ? success : throw exceptionFactory.Invoke(failure);

	public static async Task<TSuccess> ThrowOnFailure<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, Exception> exceptionFactory)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).ThrowOnFailure(exceptionFactory);
}
