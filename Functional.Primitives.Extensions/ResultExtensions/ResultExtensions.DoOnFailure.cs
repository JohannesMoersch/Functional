namespace Functional;

public static partial class ResultExtensions
{
	public static Result<TSuccess, TFailure> DoOnFailure<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Action<TFailure> onFailure)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.Do(static _ => { }, onFailure);

	public static async Task<Result<TSuccess, TFailure>> DoOnFailure<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Action<TFailure> onFailure)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await result).DoOnFailure(onFailure);
}
