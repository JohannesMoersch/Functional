namespace Functional;

public static partial class ResultExtensions
{
	public static async Task<Result<TResult, TFailure>> TryMapAsync<TSuccess, TResult, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<TResult>> successFactory, Func<Exception, TFailure> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (successFactory == null)
			throw new ArgumentNullException(nameof(successFactory));

		if (failureFactory == null)
			throw new ArgumentNullException(nameof(failureFactory));

		if (result.TryGetValue(out var success, out var failure))
		{
			try
			{
				return Result.Success<TResult, TFailure>(await successFactory.Invoke(success));
			}
			catch (Exception ex)
			{
				return Result.Failure<TResult, TFailure>(failureFactory.Invoke(ex));
			}
		}

		return Result.Failure<TResult, TFailure>(failure);
	}

	public static Task<Result<TResult, Exception>> TryMapAsync<TSuccess, TResult>(this Result<TSuccess, Exception> result, Func<TSuccess, Task<TResult>> successFactory)
		where TSuccess : notnull
		where TResult : notnull
		=> TryMapAsync(result, successFactory, static _ => _);

	public static async Task<Result<TResult, TFailure>> TryMapAsync<TSuccess, TResult, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<TResult>> successFactory, Func<Exception, TFailure> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> await (await result).TryMapAsync(successFactory, failureFactory);

	public static async Task<Result<TResult, Exception>> TryMapAsync<TSuccess, TResult>(this Task<Result<TSuccess, Exception>> result, Func<TSuccess, Task<TResult>> successFactory)
		where TSuccess : notnull
		where TResult : notnull
		=> await (await result).TryMapAsync(successFactory, static _ => _);
}
