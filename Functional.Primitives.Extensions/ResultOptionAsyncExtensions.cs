using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ResultOptionAsyncExtensions
	{
		public static async Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<TResult>> select)
			=> result.TryGetValue(out var success, out var failure)
				? Result.Success<Option<TResult>, TFailure>(await success.MapAsync(select))
				: Result.Failure<Option<TResult>, TFailure>(failure);

		public static async Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<TResult>> select)
			=> await (await result).SelectIfSomeAsync(select);

		public static async Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Option<TResult>>> select)
			=> result.TryGetValue(out var success, out var failure)
				? Result.Success<Option<TResult>, TFailure>(await success.BindAsync(select))
				: Result.Failure<Option<TResult>, TFailure>(failure);

		public static async Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Option<TResult>>> select)
			=> (await result).TryGetValue(out var success, out var failure)
				? Result.Success<Option<TResult>, TFailure>(await success.BindAsync(select))
				: Result.Failure<Option<TResult>, TFailure>(failure);

		public static async Task<Result<Option<TSuccess>, TFailure>> SelectIfNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<TSuccess>> select)
			=> result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? Result.Success<Option<TSuccess>, TFailure>(Option.Some(await select()))
				: result;

		public static async Task<Result<Option<TSuccess>, TFailure>> SelectIfNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<TSuccess>> select)
			=> await (await result).SelectIfNoneAsync(select);

		public static async Task<Result<Option<TSuccess>, TFailure>> SelectIfNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Option<TSuccess>>> select)
			=> result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? Result.Success<Option<TSuccess>, TFailure>(await select())
				: result;

		public static async Task<Result<Option<TSuccess>, TFailure>> SelectIfNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Option<TSuccess>>> select)
			=> await (await result).SelectIfNoneAsync(select);

		public static async Task<Result<Option<TResult>, TFailure>> BindIfSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (result.TryGetValue(out var success, out var failure))
			{
				if (success.TryGetValue(out var some))
					return await bind.Invoke(some).Map(DelegateCache<TResult>.Some);

				return Result.Success<Option<TResult>, TFailure>(Option.None<TResult>());
			}

			return Result.Failure<Option<TResult>, TFailure>(failure);
		}

		public static async Task<Result<Option<TResult>, TFailure>> BindIfSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
			=> await (await result).BindIfSomeAsync(bind);

		public static async Task<Result<Option<TResult>, TFailure>> BindIfSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Result<Option<TResult>, TFailure>>> bind)
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

		public static async Task<Result<Option<TResult>, TFailure>> BindIfSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Result<Option<TResult>, TFailure>>> bind)
			=> await (await result).BindIfSomeAsync(bind);

		public static async Task<Result<Option<TSuccess>, TFailure>> BindIfNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Result<TSuccess, TFailure>>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? await bind().Map(DelegateCache<TSuccess>.Some)
				: result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> BindIfNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Result<TSuccess, TFailure>>> bind)
			=> await (await result).BindIfNoneAsync(bind);

		public static async Task<Result<Option<TSuccess>, TFailure>> BindIfNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Result<Option<TSuccess>, TFailure>>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? await bind()
				: result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> BindIfNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Result<Option<TSuccess>, TFailure>>> bind)
			=> await (await result).BindIfNoneAsync(bind);

		public static async Task<Result<TSuccess, TFailure>> FailureIfNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<TFailure>> failureFactory)
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

		public static async Task<Result<TSuccess, TFailure>> FailureIfNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<TFailure>> failureFactory)
			=> await (await result).FailureIfNoneAsync(failureFactory);

		public static async Task<Result<Option<TSuccess>, TFailure>> DoIfSomeAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task> onSuccessSome)
		{
			if (onSuccessSome == null)
				throw new ArgumentNullException(nameof(onSuccessSome));

			if (result.TryGetValue(out var success, out var failure) && success.TryGetValue(out var some))
				await onSuccessSome.Invoke(some);

			return result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> DoIfSomeAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task> onSuccessSome)
			=> await (await result).DoIfSomeAsync(onSuccessSome);

		public static Task ApplyIfSomeAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task> action)
			=> result.DoIfSomeAsync(action);

		public static Task ApplyIfSomeAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task> action)
			=> result.DoIfSomeAsync(action);
	}
}