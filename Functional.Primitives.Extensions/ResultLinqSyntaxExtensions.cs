using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class ResultLinqSyntaxExtensions
    {
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

			return result.MatchAsync(
				value => bind
					.Invoke(value)
					.Match(obj => Result.Success<TResult, TFailure>(resultSelector.Invoke(value, obj)), Result.Failure<TResult, TFailure>),
				failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure))
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			=> await (await result).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
			=> result.MatchAsync(bind, failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure)));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
			=> await (await result).SelectMany(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return result.MatchAsync(
				value => bind
					.Invoke(value)
					.MatchAsync(async obj => Result.Success<TResult, TFailure>(await resultSelector.Invoke(value, obj)), failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure))),
				failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure))
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
			=> await (await result).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return result.MatchAsync(
				value => bind
					.Invoke(value)
					.MatchAsync(obj => Result.Success<TResult, TFailure>(resultSelector.Invoke(value, obj)), failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure))),
				failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure))
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
			=> await (await result).SelectMany(bind, resultSelector);
	}
}
