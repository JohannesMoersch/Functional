using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class ResultAsyncExtensions
    {
		public static Task<Result<TResult, TFailure>> SelectAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<TResult>> select)
		{
			if (select == null)
				throw new ArgumentNullException(nameof(select));

			return result.Match(async success => Result.Success<TResult, TFailure>(await select.Invoke(success)), failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure)));
		}

		public static async Task<Result<TResult, TFailure>> SelectAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<TResult>> select)
			=> await (await result).SelectAsync(select);

		public static Task<Result<TSuccess, TFailure>> WhereAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<bool>> predicate, Func<TSuccess, Task<TFailure>> failureFactory)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			return result.MatchAsync
				(
					async success => await predicate.Invoke(success) ? Result.Success<TSuccess, TFailure>(success) : Result.Failure<TSuccess, TFailure>(await failureFactory.Invoke(success)),
					failure => Task.FromResult(Result.Failure<TSuccess, TFailure>(failure))
				);
		}

		public static async Task<Result<TSuccess, TFailure>> WhereAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<bool>> predicate, Func<TSuccess, Task<TFailure>> failureFactory)
			=> await (await result).WhereAsync(predicate, failureFactory);

		public static Task<Result<TSuccess, TResult>> MapFailureAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TFailure, Task<TResult>> mapFailure)
		{
			if (mapFailure == null)
				throw new ArgumentNullException(nameof(mapFailure));

			return result.Match(success => Task.FromResult(Result.Success<TSuccess, TResult>(success)), async failure => Result.Failure<TSuccess, TResult>(await mapFailure.Invoke(failure)));
		}

		public static async Task<Result<TSuccess, TResult>> MapFailureAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, Task<TResult>> mapFailure)
			=> await (await result).MapFailureAsync(mapFailure);

		public static Task<Result<TResult, TFailure>> BindAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
			=> result.Match(bind, failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure)));

		public static async Task<Result<TResult, TFailure>> BindAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
			=> await (await result).BindAsync(bind);

		public static Task<Result<TSuccess, TFailure>> DoAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task> success, Func<TFailure, Task> failure)
		{
			if (success == null)
				throw new ArgumentNullException(nameof(success));

			if (failure == null)
				throw new ArgumentNullException(nameof(failure));

			return result.Match(
				async value =>
				{
					await success.Invoke(value);
					return result;
				},
				async value =>
				{
					await failure.Invoke(value);
					return result;
				});
		}

		public static async Task<Result<TSuccess, TFailure>> DoAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task> success, Func<TFailure, Task> failure)
			=> await (await result).DoAsync(success, failure);

		public static Task<Result<TSuccess, TFailure>> DoAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task> success)
			=> result.DoAsync(success, _ => Task.CompletedTask);

		public static Task<Result<TSuccess, TFailure>> DoAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task> success)
			=> result.DoAsync(success, _ => Task.CompletedTask);

		public static Task ApplyAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task> success, Func<TFailure, Task> failure)
			=> result.DoAsync(success, failure);

		public static Task ApplyAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task> success, Func<TFailure, Task> failure)
			=> result.DoAsync(success, failure);

		public static Task ApplyAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task> success)
			=> result.DoAsync(success, _ => Task.CompletedTask);

		public static Task ApplyAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task> success)
			=> result.DoAsync(success, _ => Task.CompletedTask);

		public static Task<Result<TSuccess, TFailure>> FailureIfNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<TFailure>> failureFactory)
		{
			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			return result.Match(option => option.Match(value => Task.FromResult(Result.Success<TSuccess, TFailure>(value)), async () => Result.Failure<TSuccess, TFailure>(await failureFactory.Invoke())), failure => Task.FromResult(Result.Failure<TSuccess, TFailure>(failure)));
		}

		public static async Task<Result<TSuccess, TFailure>> FailureIfNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<TFailure>> failureFactory)
			=> await (await result).FailureIfNoneAsync(failureFactory);
	}
}
