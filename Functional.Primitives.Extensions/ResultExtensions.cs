using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static class ResultExtensions
	{
		public static bool IsSuccess<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
			=> result.Match(_ => true, _ => false);

		public static async Task<bool> IsSuccess<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
			=> (await result).IsSuccess();

		public static Option<TSuccess> Success<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
			=> result.Match(Option.Some, _ => Option.None<TSuccess>());

		public static Task<Option<TSuccess>> Success<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
			=> result.Match(Option.Some, _ => Option.None<TSuccess>());

		public static Option<TFailure> Failure<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
			=> result.Match(_ => Option.None<TFailure>(), Option.Some);

		public static Task<Option<TFailure>> Failure<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
			=> result.Match(_ => Option.None<TFailure>(), Option.Some);

		public static Result<TResult, TFailure> Select<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, TResult> select)
		{
			if (select == null)
				throw new ArgumentNullException(nameof(select));

			return result.Match(success => Result.Success<TResult, TFailure>(select.Invoke(success)), Result.Failure<TResult, TFailure>);
		}

		public static async Task<Result<TResult, TFailure>> Select<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, TResult> select)
			=> (await result).Select(select);

		public static Result<TSuccess, TFailure> Where<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> failureFactory)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			return result.Match
				(
					success => predicate.Invoke(success) ? Result.Success<TSuccess, TFailure>(success) : Result.Failure<TSuccess, TFailure>(failureFactory.Invoke(success)),
					Result.Failure<TSuccess, TFailure>
				);
		}

		public static async Task<Result<TSuccess, TFailure>> Where<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> failureFactory)
			=> (await result).Where(predicate, failureFactory);

		public static Result<TSuccess, TResult> MapFailure<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TFailure, TResult> mapFailure)
		{
			if (mapFailure == null)
				throw new ArgumentNullException(nameof(mapFailure));

			return result.Match(Result.Success<TSuccess, TResult>, failure => Result.Failure<TSuccess, TResult>(mapFailure.Invoke(failure)));
		}

		public static async Task<Result<TSuccess, TResult>> MapFailure<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, TResult> mapFailure)
			=> (await result).MapFailure(mapFailure);

		public static Result<TResult, TFailure> Bind<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Result<TResult, TFailure>> bind)
			=> result.Match(bind, Result.Failure<TResult, TFailure>);

		public static async Task<Result<TResult, TFailure>> Bind<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Result<TResult, TFailure>> bind)
			=> (await result).Bind(bind);

		public static Result<TSuccess, TFailure> Do<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Action<TSuccess> success, Action<TFailure> failure)
		{
			if (success == null)
				throw new ArgumentNullException(nameof(success));

			if (failure == null)
				throw new ArgumentNullException(nameof(failure));

			return result.Match(
				value =>
				{
					success.Invoke(value);
					return result;
				},
				value =>
				{
					failure.Invoke(value);
					return result;
				});
		}

		public static async Task<Result<TSuccess, TFailure>> Do<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Action<TSuccess> success, Action<TFailure> failure)
			=> (await result).Do(success, failure);

		public static Result<TSuccess, TFailure> Do<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Action<TSuccess> success)
			=> result.Do(success, _ => { });

		public static Task<Result<TSuccess, TFailure>> Do<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Action<TSuccess> success)
			=> result.Do(success, _ => { });

		public static void Apply<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Action<TSuccess> success, Action<TFailure> failure)
			=> result.Do(success, failure);

		public static Task Apply<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Action<TSuccess> success, Action<TFailure> failure)
			=> result.Do(success, failure);

		public static void Apply<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Action<TSuccess> success)
			=> result.Do(success, _ => { });

		public static Task Apply<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Action<TSuccess> success)
			=> result.Do(success, _ => { });

		public static Option<TSuccess> ToOption<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
			=> result.Match(Option.Some, _ => Option.None<TSuccess>());

		public static async Task<Option<TSuccess>> ToOption<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
			=> (await result).ToOption();

		public static Result<TSuccess, TFailure> FailureIfNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TFailure> failureFactory)
		{
			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			return result.Match(option => option.Match(Result.Success<TSuccess, TFailure>, () => Result.Failure<TSuccess, TFailure>(failureFactory.Invoke())), failure => Result.Failure<TSuccess, TFailure>(failure));
		}

		public static async Task<Result<TSuccess, TFailure>> FailureIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TFailure> failureFactory)
			=> (await result).FailureIfNone(failureFactory);

		public static Result<TResult, TFailure> TrySelect<TSuccess, TResult, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, TResult> successFactory, Func<Exception, TFailure> failureFactory)
		{
			if (successFactory == null)
				throw new ArgumentNullException(nameof(successFactory));

			if(failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			return result.Bind(success => Result.Try(() => successFactory(success), failureFactory));
		}

		public static Result<TResult, Exception> TrySelect<TSuccess, TResult>(this Result<TSuccess, Exception> result, Func<TSuccess, TResult> successFactory)
			=> TrySelect(result, successFactory, ex => ex);

		public static async Task<Result<TResult, TFailure>> TrySelect<TSuccess, TResult, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, TResult> successFactory, Func<Exception, TFailure> failureFactory)
			=> (await result).TrySelect(successFactory, failureFactory);

		public static async Task<Result<TResult, Exception>> TrySelect<TSuccess, TResult>(this Task<Result<TSuccess, Exception>> result, Func<TSuccess, TResult> successFactory)
			=> (await result).TrySelect(successFactory, ex => ex);
	}
}
