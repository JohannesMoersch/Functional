using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static partial class ResultExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Result<TResult, TFailure> Select<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, TResult> map)
			=> result.Map(map);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Result<TResult, TFailure>> Select<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, TResult> map)
			=> result.Map(map);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ResultLinqSyntaxExtensions
    {
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Result<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			if (result.TryGetValue(out var success, out var failure))
			{
				if (bind.Invoke(success).TryGetValue(out var s, out var f))
					return Result.Success<TResult, TFailure>(resultSelector.Invoke(success, s));

				return Result.Failure<TResult, TFailure>(f);
			}

			return Result.Failure<TResult, TFailure>(failure);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			=> (await result).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			if (result.TryGetValue(out var success, out var failure))
			{
				if ((await bind.Invoke(success)).TryGetValue(out var s, out var f))
					return Result.Success<TResult, TFailure>(resultSelector.Invoke(success, s));

				return Result.Failure<TResult, TFailure>(f);
			}

			return Result.Failure<TResult, TFailure>(failure);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			=> await (await result).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			if (result.TryGetValue(out var success, out var failure))
			{
				if (bind.Invoke(success).TryGetValue(out var s, out var f))
					return Result.Success<TResult, TFailure>(await resultSelector.Invoke(success, s));

				return Result.Failure<TResult, TFailure>(f);
			}

			return Result.Failure<TResult, TFailure>(failure);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
			=> await (await result).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			if (result.TryGetValue(out var success, out var failure))
			{
				if ((await bind.Invoke(success)).TryGetValue(out var s, out var f))
					return Result.Success<TResult, TFailure>(await resultSelector.Invoke(success, s));

				return Result.Failure<TResult, TFailure>(f);
			}

			return Result.Failure<TResult, TFailure>(failure);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
			=> await (await result).SelectMany(bind, resultSelector);
	}
}
