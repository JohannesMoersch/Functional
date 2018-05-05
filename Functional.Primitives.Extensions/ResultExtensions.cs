using System;
using System.Collections.Generic;
using System.ComponentModel;
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

		public static void Apply<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Action<TSuccess> success, Action<TFailure> failure)
			=> result.Do(success, failure);

		public static Task Apply<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Action<TSuccess> success, Action<TFailure> failure)
			=> result.Do(success, failure);

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

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Result<TResult, TFailure> SelectMany<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Result<TResult, TFailure>> bind)
			=> result.Match(bind, failure => Result.Failure<TResult, TFailure>(failure));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Result<TResult, TFailure>> bind)
			=> (await result).SelectMany(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Result<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return result.Match(
				value => bind
					.Invoke(value)
					.Match(obj => Result.Success<TResult, TFailure>(resultSelector.Invoke(value, obj)), Result.Failure<TResult, TFailure>),
				Result.Failure<TResult, TFailure>
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			=> (await result).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return result.Match(
				value => bind
					.Invoke(value)
					.Match(obj => Result.Success<TResult, TFailure>(resultSelector.Invoke(value, obj)), Result.Failure<TResult, TFailure>),
				failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure))
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			=> await (await result).SelectMany(bind, resultSelector);
	}
}
