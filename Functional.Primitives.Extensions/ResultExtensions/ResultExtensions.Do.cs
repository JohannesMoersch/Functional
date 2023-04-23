namespace Functional;

public static partial class ResultExtensions
{
	public static Result<TSuccess, TFailure> Do<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Action<TSuccess> onSuccess, Action<TFailure> onFailure)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (onSuccess == null)
			throw new ArgumentNullException(nameof(onSuccess));

		if (onFailure == null)
			throw new ArgumentNullException(nameof(onFailure));

		if (result.TryGetValue(out var success, out var failure))
			onSuccess.Invoke(success);
		else
			onFailure.Invoke(failure);

		return result;
	}

	public static async Task<Result<TSuccess, TFailure>> Do<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Action<TSuccess> success, Action<TFailure> failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).Do(success, failure);

	public static Result<TSuccess, TFailure> Do<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Action<TSuccess> onSuccess)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.Do(onSuccess, static _ => { });

	public static async Task<Result<TSuccess, TFailure>> Do<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Action<TSuccess> onSuccess)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).Do(onSuccess);
}
