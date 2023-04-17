namespace Functional;

[EditorBrowsable(EditorBrowsableState.Never)]
public static partial class ResultAsyncExtensions
{
	public static async Task<Result<TResult, TFailure>> MapAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<TResult>> map)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (map == null)
			throw new ArgumentNullException(nameof(map));

		if (result.TryGetValue(out var success, out var failure))
			return Result.Success<TResult, TFailure>(await map.Invoke(success));
		
		return Result.Failure<TResult, TFailure>(failure);
	}

	public static async Task<Result<TResult, TFailure>> MapAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<TResult>> map)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> await (await result).MapAsync(map);

	public static async Task<Result<TSuccess, TFailure>> WhereAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<bool>> predicate, Func<TSuccess, Task<TFailure>> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (predicate == null)
			throw new ArgumentNullException(nameof(predicate));

		if (failureFactory == null)
			throw new ArgumentNullException(nameof(failureFactory));

		if (result.TryGetValue(out var success, out var failure))
			return await predicate.Invoke(success) ? Result.Success<TSuccess, TFailure>(success) : Result.Failure<TSuccess, TFailure>(await failureFactory.Invoke(success));

		return Result.Failure<TSuccess, TFailure>(failure);
	}

	public static async Task<Result<TSuccess, TFailure>> WhereAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<bool>> predicate, Func<TSuccess, Task<TFailure>> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).WhereAsync(predicate, failureFactory);

	public static async Task<Result<TSuccess, TResult>> MapOnFailureAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TFailure, Task<TResult>> mapFailure)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (mapFailure == null)
			throw new ArgumentNullException(nameof(mapFailure));

		if (result.TryGetValue(out var success, out var failure))
			return Result.Success<TSuccess, TResult>(success);
		
		return Result.Failure<TSuccess, TResult>(await mapFailure.Invoke(failure));
	}

	public static async Task<Result<TSuccess, TResult>> MapOnFailureAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, Task<TResult>> mapFailure)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> await (await result).MapOnFailureAsync(mapFailure);

	public static async Task<Result<TResult, TFailure>> BindAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (result.TryGetValue(out var success, out var failure))
			return await bind.Invoke(success);

		return Result.Failure<TResult, TFailure>(failure);
	}

	public static async Task<Result<TResult, TFailure>> BindAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> await (await result).BindAsync(bind);

	public static async Task<Result<TSuccess, TResult>> BindOnFailureAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TFailure, Task<Result<TSuccess, TResult>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (bind == null) throw new ArgumentNullException(nameof(bind));

		return !result.TryGetValue(out var success, out var failure)
			? await bind.Invoke(failure)
			: Result.Success<TSuccess, TResult>(success);
	}

	public static async Task<Result<TSuccess, TResult>> BindOnFailureAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, Task<Result<TSuccess, TResult>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> await (await result).BindOnFailureAsync(bind);

	public static async Task<Result<TSuccess, TFailure>> DoAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task> onSuccess, Func<TFailure, Task> onFailure)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (onSuccess == null)
			throw new ArgumentNullException(nameof(onSuccess));

		if (onFailure == null)
			throw new ArgumentNullException(nameof(onFailure));

		if (result.TryGetValue(out var success, out var failure))
			await onSuccess.Invoke(success);
		else
			await onFailure.Invoke(failure);

		return result;
	}

	public static async Task<Result<TSuccess, TFailure>> DoAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task> success, Func<TFailure, Task> failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).DoAsync(success, failure);

	public static Task<Result<TSuccess, TFailure>> DoAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task> success)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.DoAsync(success, static _ => Task.CompletedTask);

	public static async Task<Result<TSuccess, TFailure>> DoAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task> success)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).DoAsync(success, static _ => Task.CompletedTask);

	public static Task<Result<TSuccess, TFailure>> DoOnFailureAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TFailure, Task> failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.DoAsync(static _ => Task.CompletedTask, failure);

	public static async Task<Result<TSuccess, TFailure>> DoOnFailureAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, Task> failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).DoAsync(static _ => Task.CompletedTask, failure);

	public static Task ApplyAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task> success, Func<TFailure, Task> failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.DoAsync(success, failure);

	public static Task ApplyAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task> success, Func<TFailure, Task> failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.DoAsync(success, failure);

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
