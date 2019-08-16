using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ResultAsyncExtensions
	{
		public static Task<T> MatchAsync<TSuccess, TFailure, T>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<T>> successSome, Func<Task<T>> successNone, Func<TFailure, Task<T>> failure)
			=> result.MatchAsync(x => x.MatchAsync(successSome, successNone), failure);

		public static Task<T> MatchAsync<TSuccess, TFailure, T>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<T>> successSome, Func<Task<T>> successNone, Func<TFailure, Task<T>> failure)
			=> result.MatchAsync(x => x.MatchAsync(successSome, successNone), failure);

		public static async Task<Result<TResult, TFailure>> SelectAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<TResult>> select)
		{
			if (select == null)
				throw new ArgumentNullException(nameof(select));

			if (result.TryGetValue(out var success, out var failure))
				return Result.Success<TResult, TFailure>(await select.Invoke(success));
			
			return Result.Failure<TResult, TFailure>(failure);
		}

		public static async Task<Result<TResult, TFailure>> SelectAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<TResult>> select)
			=> await (await result).SelectAsync(select);

		public static Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<TResult>> select)
			=> result.SelectAsync(success => success.SelectAsync(select));

		public static async Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<TResult>> select)
			=> await (await result).SelectIfSomeAsync(select);

		public static Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Option<TResult>>> select)
			=> result.SelectAsync(success => success.BindAsync(select));

		public static async Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Option<TResult>>> select)
			=> await (await result).SelectIfSomeAsync(select);

		public static async Task<Result<TSuccess, TFailure>> WhereAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<bool>> predicate, Func<TSuccess, Task<TFailure>> failureFactory)
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
			=> await (await result).WhereAsync(predicate, failureFactory);

		public static async Task<Result<TSuccess, TResult>> MapFailureAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TFailure, Task<TResult>> mapFailure)
		{
			if (mapFailure == null)
				throw new ArgumentNullException(nameof(mapFailure));

			if (result.TryGetValue(out var success, out var failure))
				return Result.Success<TSuccess, TResult>(success);
			
			return Result.Failure<TSuccess, TResult>(await mapFailure.Invoke(failure));
		}

		public static async Task<Result<TSuccess, TResult>> MapFailureAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, Task<TResult>> mapFailure)
			=> await (await result).MapFailureAsync(mapFailure);

		public static Task<Result<TResult, TFailure>> BindAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
			=> result.Match(bind, failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure)));

		public static async Task<Result<TResult, TFailure>> BindAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
			=> await (await result).BindAsync(bind);

		public static Task<Result<Option<TResult>, TFailure>> BindIfSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
			=> result.BindAsync(success => success.MatchAsync(async value => (await bind(value)).Select(Option.Some), () => Task.FromResult(Result.Success<Option<TResult>, TFailure>(Option.None<TResult>()))));

		public static async Task<Result<Option<TResult>, TFailure>> BindIfSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
			=> await (await result).BindIfSomeAsync(bind);

		public static Task<Result<Option<TResult>, TFailure>> BindIfSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Result<Option<TResult>, TFailure>>> bind)
			=> result.BindAsync(success => success.MatchAsync(bind, () => Task.FromResult(Result.Success<Option<TResult>, TFailure>(Option.None<TResult>()))));

		public static async Task<Result<Option<TResult>, TFailure>> BindIfSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Result<Option<TResult>, TFailure>>> bind)
			=> await (await result).BindIfSomeAsync(bind);

		public static async Task<Result<TSuccess, TFailure>> DoAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task> onSuccess, Func<TFailure, Task> onFailure)
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
			=> await (await result).DoAsync(success, failure);

		public static Task<Result<TSuccess, TFailure>> DoAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task> success)
			=> result.DoAsync(success, _ => Task.CompletedTask);

		public static Task<Result<TSuccess, TFailure>> DoAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task> success)
			=> result.DoAsync(success, _ => Task.CompletedTask);

		public static Task<Result<Option<TSuccess>, TFailure>> DoIfSomeAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task> action)
			=> result.DoAsync(option => option.ApplyAsync(action));

		public static Task<Result<Option<TSuccess>, TFailure>> DoIfSomeAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task> action)
			=> result.DoAsync(option => option.ApplyAsync(action));

		public static Task ApplyAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task> success, Func<TFailure, Task> failure)
			=> result.DoAsync(success, failure);

		public static Task ApplyAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task> success, Func<TFailure, Task> failure)
			=> result.DoAsync(success, failure);

		public static Task ApplyAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task> success)
			=> result.DoAsync(success, _ => Task.CompletedTask);

		public static Task ApplyAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task> success)
			=> result.DoAsync(success, _ => Task.CompletedTask);

		public static Task ApplyIfSomeAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task> action)
			=> result.DoIfSomeAsync(action);

		public static Task ApplyIfSomeAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task> action)
			=> result.DoIfSomeAsync(action);

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

		public static async Task<Result<TResult, TFailure>> TrySelectAsync<TSuccess, TResult, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<TResult>> successFactory, Func<Exception, TFailure> failureFactory)
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

		public static Task<Result<TResult, Exception>> TrySelectAsync<TSuccess, TResult>(this Result<TSuccess, Exception> result, Func<TSuccess, Task<TResult>> successFactory)
		 => TrySelectAsync(result, successFactory, ex => ex);

		public static async Task<Result<TResult, TFailure>> TrySelectAsync<TSuccess, TResult, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<TResult>> successFactory, Func<Exception, TFailure> failureFactory)
		 => await (await result).TrySelectAsync(successFactory, failureFactory);

		public static async Task<Result<TResult, Exception>> TrySelectAsync<TSuccess, TResult>(this Task<Result<TSuccess, Exception>> result, Func<TSuccess, Task<TResult>> successFactory)
		 => await (await result).TrySelectAsync(successFactory, ex => ex);
	}
}
