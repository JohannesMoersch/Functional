namespace Functional;

public static partial class ResultExtensions
{
	public static Task<T> MatchAsync<TSuccess, TFailure, T>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<T>> onSuccessSome, Func<Task<T>> onSuccessNone, Func<TFailure, Task<T>> onFailure)
	where TSuccess : notnull
	where TFailure : notnull
	{
		if (onFailure == null)
			throw new ArgumentNullException(nameof(onFailure));

		return result.TryGetValue(out var success, out var failure)
			? success.Match(onSuccessSome, onSuccessNone)
			: onFailure.Invoke(failure);
	}

	public static async Task<T> MatchAsync<TSuccess, TFailure, T>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<T>> successSome, Func<Task<T>> successNone, Func<TFailure, Task<T>> failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).MatchAsync(successSome, successNone, failure);

	public static async Task<Result<Option<TResult>, TFailure>> MapOnSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<TResult>> map)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> result.TryGetValue(out var success, out var failure)
			? Result.Success<Option<TResult>, TFailure>(await success.MapAsync(map))
			: Result.Failure<Option<TResult>, TFailure>(failure);

	public static async Task<Result<Option<TResult>, TFailure>> MapOnSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<TResult>> map)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> await (await result).MapOnSomeAsync(map);

	public static async Task<Result<Option<TResult>, TFailure>> MapOnSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Option<TResult>>> map)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> result.TryGetValue(out var success, out var failure)
			? Result.Success<Option<TResult>, TFailure>(await success.BindAsync(map))
			: Result.Failure<Option<TResult>, TFailure>(failure);

	public static async Task<Result<Option<TResult>, TFailure>> MapOnSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Option<TResult>>> map)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> await (await result).MapOnSomeAsync(map);

	public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<TSuccess>> map)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
			? Result.Success<Option<TSuccess>, TFailure>(Option.Some(await map()))
			: result;

	public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<TSuccess>> map)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).MapOnNoneAsync(map);

	public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Option<TSuccess>>> map)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
			? Result.Success<Option<TSuccess>, TFailure>(await map())
			: result;

	public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Option<TSuccess>>> map)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).MapOnNoneAsync(map);

	public static async Task<Result<Option<TResult>, TFailure>> BindOnSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (result.TryGetValue(out var success, out var failure))
		{
			if (success.TryGetValue(out var some))
				return await bind.Invoke(some).Map(static _ => Option.Some(_));

			return Result.Success<Option<TResult>, TFailure>(Option.None<TResult>());
		}

		return Result.Failure<Option<TResult>, TFailure>(failure);
	}

	public static async Task<Result<Option<TResult>, TFailure>> BindOnSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> await (await result).BindOnSomeAsync(bind);

	public static async Task<Result<Option<TResult>, TFailure>> BindOnSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Result<Option<TResult>, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (result.TryGetValue(out var success, out var failure))
		{
			if (success.TryGetValue(out var some))
				return await bind.Invoke(some);

			return Result.Success<Option<TResult>, TFailure>(Option.None<TResult>());
		}

		return Result.Failure<Option<TResult>, TFailure>(failure);
	}

	public static async Task<Result<Option<TResult>, TFailure>> BindOnSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Result<Option<TResult>, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> await (await result).BindOnSomeAsync(bind);

	public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Result<TSuccess, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
			? await bind().Map(static _ => Option.Some(_))
			: result;
	}

	public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Result<TSuccess, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).BindOnNoneAsync(bind);

	public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Result<Option<TSuccess>, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
			? await bind()
			: result;
	}

	public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Result<Option<TSuccess>, TFailure>>> bind)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).BindOnNoneAsync(bind);

	public static async Task<Result<TSuccess, TFailure>> FailOnNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<TFailure>> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (failureFactory == null)
			throw new ArgumentNullException(nameof(failureFactory));

		if (result.TryGetValue(out var success, out var failure))
		{
			if (success.TryGetValue(out var some))
				return Result.Success<TSuccess, TFailure>(some);

			return Result.Failure<TSuccess, TFailure>(await failureFactory.Invoke());
		}

		return Result.Failure<TSuccess, TFailure>(failure);
	}

	public static async Task<Result<TSuccess, TFailure>> FailOnNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<TFailure>> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).FailOnNoneAsync(failureFactory);

	public static async Task<Result<Option<TSuccess>, TFailure>> DoOnSomeAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task> onSuccessSome)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (onSuccessSome == null)
			throw new ArgumentNullException(nameof(onSuccessSome));

		if (result.TryGetValue(out var success, out var failure) && success.TryGetValue(out var some))
			await onSuccessSome.Invoke(some);

		return result;
	}

	public static async Task<Result<Option<TSuccess>, TFailure>> DoOnSomeAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task> onSuccessSome)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).DoOnSomeAsync(onSuccessSome);

	public static async Task<Result<Option<TSuccess>, TFailure>> WhereOnSomeAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<bool>> predicate, Func<TSuccess, TFailure> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));
		if (failureFactory == null) throw new ArgumentNullException(nameof(failureFactory));

		if (result.TryGetValue(out var success, out var failure) && success.TryGetValue(out var some))
		{
			return await predicate.Invoke(some)
				? result
				: Result.Failure<Option<TSuccess>, TFailure>(failureFactory.Invoke(some));
		}

		return result;
	}

	public static async Task<Result<Option<TSuccess>, TFailure>> WhereOnSomeAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<bool>> predicate, Func<TSuccess, TFailure> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
		=> await (await result).WhereOnSomeAsync(predicate, failureFactory);

	public static async Task ApplyAsync<T, TFailure>(this Result<Option<T>, TFailure> result, Func<T, Task> onSome, Func<Task> onNone, Func<TFailure, Task> onFailure)
		where TFailure : notnull
		where T : notnull
	{
		if (onSome == null) throw new ArgumentNullException(nameof(onSome));
		if (onNone == null) throw new ArgumentNullException(nameof(onNone));
		if (onFailure == null) throw new ArgumentNullException(nameof(onFailure));

		if (result.TryGetValue(out var success, out var failure))
		{
			if (success.TryGetValue(out var some))
			{
				await onSome.Invoke(some);
			}
			else
			{
				await onNone.Invoke();
			}
		}
		else
		{
			await onFailure.Invoke(failure);
		}
	}

	public static async Task ApplyAsync<T, TFailure>(this Task<Result<Option<T>, TFailure>> result, Func<T, Task> onSome, Func<Task> onNone, Func<TFailure, Task> onFailure)
		where T : notnull
		where TFailure : notnull
		=> await (await result).ApplyAsync(onSome, onNone, onFailure);
}