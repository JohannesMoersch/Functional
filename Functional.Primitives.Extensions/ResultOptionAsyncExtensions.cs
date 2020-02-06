using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static partial class ResultOptionAsyncExtensions
	{
		public static async Task<Result<Option<TResult>, TFailure>> MapOnSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<TResult>> map)
			=> result.TryGetValue(out var success, out var failure)
				? Result.Success<Option<TResult>, TFailure>(await success.MapAsync(map))
				: Result.Failure<Option<TResult>, TFailure>(failure);

		public static async Task<Result<Option<TResult>, TFailure>> MapOnSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<TResult>> map)
			=> await (await result).MapOnSomeAsync(map);

		public static async Task<Result<Option<TResult>, TFailure>> MapOnSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Option<TResult>>> map)
			=> result.TryGetValue(out var success, out var failure)
				? Result.Success<Option<TResult>, TFailure>(await success.BindAsync(map))
				: Result.Failure<Option<TResult>, TFailure>(failure);

		public static async Task<Result<Option<TResult>, TFailure>> MapOnSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Option<TResult>>> map)
			=> await (await result).MapOnSomeAsync(map);

		public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<TSuccess>> map)
			=> result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? Result.Success<Option<TSuccess>, TFailure>(Option.Some(await map()))
				: result;

		public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<TSuccess>> map)
			=> await (await result).MapOnNoneAsync(map);

		public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Option<TSuccess>>> map)
			=> result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? Result.Success<Option<TSuccess>, TFailure>(await map())
				: result;

		public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Option<TSuccess>>> map)
			=> await (await result).MapOnNoneAsync(map);

		public static async Task<Result<Option<TResult>, TFailure>> BindOnSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
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

		public static async Task<Result<Option<TResult>, TFailure>> BindOnSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
			=> await (await result).BindOnSomeAsync(bind);

		public static async Task<Result<Option<TResult>, TFailure>> BindOnSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Result<Option<TResult>, TFailure>>> bind)
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
			=> await (await result).BindOnSomeAsync(bind);

		public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Result<TSuccess, TFailure>>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? await bind().Map(DelegateCache<TSuccess>.Some)
				: result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Result<TSuccess, TFailure>>> bind)
			=> await (await result).BindOnNoneAsync(bind);

		public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Result<Option<TSuccess>, TFailure>>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? await bind()
				: result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Result<Option<TSuccess>, TFailure>>> bind)
			=> await (await result).BindOnNoneAsync(bind);

		public static async Task<Result<TSuccess, TFailure>> FailOnNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<TFailure>> failureFactory)
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
			=> await (await result).FailOnNoneAsync(failureFactory);

		public static async Task<Result<Option<TSuccess>, TFailure>> DoOnSomeAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task> onSuccessSome)
		{
			if (onSuccessSome == null)
				throw new ArgumentNullException(nameof(onSuccessSome));

			if (result.TryGetValue(out var success, out var failure) && success.TryGetValue(out var some))
				await onSuccessSome.Invoke(some);

			return result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> DoOnSomeAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task> onSuccessSome)
			=> await (await result).DoOnSomeAsync(onSuccessSome);
	}
}