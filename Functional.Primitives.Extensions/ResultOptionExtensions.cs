using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ResultOptionExtensions
	{
		public static T Match<TSuccess, TFailure, T>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, T> onSuccessSome, Func<T> onSuccessNone, Func<TFailure, T> onFailure)
		{
			if (onSuccessSome == null)
				throw new ArgumentNullException(nameof(onSuccessSome));

			if (onSuccessNone == null)
				throw new ArgumentNullException(nameof(onSuccessNone));

			if (onFailure == null)
				throw new ArgumentNullException(nameof(onFailure));

			return result.TryGetValue(out var success, out var failure)
				? success.Match(onSuccessSome, onSuccessNone)
				: onFailure.Invoke(failure);
		}

		public static async Task<T> Match<TSuccess, TFailure, T>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, T> successSome, Func<T> successNone, Func<TFailure, T> failure)
			=> (await result).Match(successSome, successNone, failure);

		public static Result<Option<TResult>, TFailure> MapOnSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, TResult> map)
			=> result.TryGetValue(out var success, out var failure)
				? Result.Success<Option<TResult>, TFailure>(success.Map(map))
				: Result.Failure<Option<TResult>, TFailure>(failure);

		public static async Task<Result<Option<TResult>, TFailure>> MapOnSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, TResult> map)
			=> (await result).MapOnSome(map);

		public static Result<Option<TResult>, TFailure> MapOnSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Option<TResult>> map)
			=> result.TryGetValue(out var success, out var failure)
				? Result.Success<Option<TResult>, TFailure>(success.Bind(map))
				: Result.Failure<Option<TResult>, TFailure>(failure);

		public static async Task<Result<Option<TResult>, TFailure>> MapOnSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Option<TResult>> map)
			=> (await result).MapOnSome(map);

		public static Result<Option<TSuccess>, TFailure> MapOnNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess> map)
			=> result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? Result.Success<Option<TSuccess>, TFailure>(Option.Some(map()))
				: result;

		public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess> map)
			=> (await result).MapOnNone(map);

		public static Result<Option<TSuccess>, TFailure> MapOnNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Option<TSuccess>> map)
			=> result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? Result.Success<Option<TSuccess>, TFailure>(map())
				: result;

		public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Option<TSuccess>> map)
			=> (await result).MapOnNone(map);

		public static Result<Option<TResult>, TFailure> BindOnSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Result<TResult, TFailure>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (result.TryGetValue(out var success, out var failure))
			{
				if (success.TryGetValue(out var some))
					return bind.Invoke(some).Map(DelegateCache<TResult>.Some);

				return Result.Success<Option<TResult>, TFailure>(Option.None<TResult>());
			}

			return Result.Failure<Option<TResult>, TFailure>(failure);
		}

		public static async Task<Result<Option<TResult>, TFailure>> BindOnSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Result<TResult, TFailure>> bind)
			=> (await result).BindOnSome(bind);

		public static Result<Option<TResult>, TFailure> BindOnSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Result<Option<TResult>, TFailure>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (result.TryGetValue(out var success, out var failure))
			{
				if (success.TryGetValue(out var some))
					return bind.Invoke(some);

				return Result.Success<Option<TResult>, TFailure>(Option.None<TResult>());
			}

			return Result.Failure<Option<TResult>, TFailure>(failure);
		}

		public static async Task<Result<Option<TResult>, TFailure>> BindOnSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Result<Option<TResult>, TFailure>> bind)
			=> (await result).BindOnSome(bind);

		public static Result<Option<TSuccess>, TFailure> BindOnNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Result<TSuccess, TFailure>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? bind().Map(DelegateCache<TSuccess>.Some)
				: result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Result<TSuccess, TFailure>> bind)
			=> (await result).BindOnNone(bind);

		public static Result<Option<TSuccess>, TFailure> BindOnNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Result<Option<TSuccess>, TFailure>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? bind()
				: result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Result<Option<TSuccess>, TFailure>> bind)
			=> (await result).BindOnNone(bind);

		public static Result<TSuccess, TFailure> FailOnNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TFailure> failureFactory)
		{
			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			if (result.TryGetValue(out var success, out var failure))
			{
				if (success.TryGetValue(out var some))
					return Result.Success<TSuccess, TFailure>(some);

				return Result.Failure<TSuccess, TFailure>(failureFactory.Invoke());
			}

			return Result.Failure<TSuccess, TFailure>(failure);
		}

		public static async Task<Result<TSuccess, TFailure>> FailOnNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TFailure> failureFactory)
			=> (await result).FailOnNone(failureFactory);

		public static Result<Option<TSuccess>, TFailure> DoOnSome<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Action<TSuccess> onSuccessSome)
		{
			if (onSuccessSome == null)
				throw new ArgumentNullException(nameof(onSuccessSome));

			if (result.TryGetValue(out var success, out var failure) && success.TryGetValue(out var some))
				onSuccessSome.Invoke(some);

			return result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> DoOnSome<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Action<TSuccess> onSuccessSome)
			=> (await result).DoOnSome(onSuccessSome);

		public static void ApplyOnSome<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Action<TSuccess> onSuccessSome)
			=> result.DoOnSome(onSuccessSome);

		public static Task ApplyOnSome<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Action<TSuccess> onSuccessSome)
			=> result.DoOnSome(onSuccessSome);
	}
}