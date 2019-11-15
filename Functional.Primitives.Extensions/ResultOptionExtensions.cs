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

		public static Result<Option<TResult>, TFailure> SelectIfSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, TResult> select)
			=> result.TryGetValue(out var success, out var failure)
				? Result.Success<Option<TResult>, TFailure>(success.Select(select))
				: Result.Failure<Option<TResult>, TFailure>(failure);

		public static async Task<Result<Option<TResult>, TFailure>> SelectIfSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, TResult> select)
			=> (await result).SelectIfSome(select);

		public static Result<Option<TResult>, TFailure> SelectIfSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Option<TResult>> select)
			=> result.TryGetValue(out var success, out var failure)
				? Result.Success<Option<TResult>, TFailure>(success.Bind(select))
				: Result.Failure<Option<TResult>, TFailure>(failure);

		public static async Task<Result<Option<TResult>, TFailure>> SelectIfSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Option<TResult>> select)
			=> (await result).SelectIfSome(select);

		public static Result<Option<TSuccess>, TFailure> SelectIfNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess> select)
			=> result.TryGetValue(out var success, out var failure) && !success.TryGetValue(out _)
				? Result.Success<Option<TSuccess>, TFailure>(Option.Some(select()))
				: result;

		public static async Task<Result<Option<TSuccess>, TFailure>> SelectIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess> select)
			=> (await result).SelectIfNone(select);

		public static Result<Option<TSuccess>, TFailure> SelectIfNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Option<TSuccess>> select)
			=> result.TryGetValue(out var success, out var failure) && !success.TryGetValue(out _)
				? Result.Success<Option<TSuccess>, TFailure>(select())
				: result;

		public static async Task<Result<Option<TSuccess>, TFailure>> SelectIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Option<TSuccess>> select)
			=> (await result).SelectIfNone(select);

		public static Result<Option<TResult>, TFailure> BindIfSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Result<TResult, TFailure>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (result.TryGetValue(out var success, out var failure))
			{
				if (success.TryGetValue(out var some))
					return bind.Invoke(some).Select(DelegateCache<TResult>.Some);

				return Result.Success<Option<TResult>, TFailure>(Option.None<TResult>());
			}

			return Result.Failure<Option<TResult>, TFailure>(failure);
		}

		public static async Task<Result<Option<TResult>, TFailure>> BindIfSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Result<TResult, TFailure>> bind)
			=> (await result).BindIfSome(bind);

		public static Result<Option<TResult>, TFailure> BindIfSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Result<Option<TResult>, TFailure>> bind)
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

		public static async Task<Result<Option<TResult>, TFailure>> BindIfSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Result<Option<TResult>, TFailure>> bind)
			=> (await result).BindIfSome(bind);

		public static Result<Option<TSuccess>, TFailure> BindIfNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Result<TSuccess, TFailure>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? bind().Select(DelegateCache<TSuccess>.Some)
				: result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> BindIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Result<TSuccess, TFailure>> bind)
			=> (await result).BindIfNone(bind);

		public static Result<Option<TSuccess>, TFailure> BindIfNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Result<Option<TSuccess>, TFailure>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? bind()
				: result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> BindIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Result<Option<TSuccess>, TFailure>> bind)
			=> (await result).BindIfNone(bind);

		public static Result<TSuccess, TFailure> FailureIfNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TFailure> failureFactory)
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

		public static async Task<Result<TSuccess, TFailure>> FailureIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TFailure> failureFactory)
			=> (await result).FailureIfNone(failureFactory);

		public static Result<TSuccess, TFailure> Do<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Action<TSuccess> onSuccess, Action<TFailure> onFailure)
		{
			if (onSuccess == null)
				throw new ArgumentNullException(nameof(onSuccess));

			if (onFailure == null)
				throw new ArgumentNullException(nameof(onFailure));

			if (result.TryGetValue(out var success, out var failure))
				onSuccess.Invoke(success);
			else
				onFailure.Invoke(failure);

			return result;
		}

		public static Result<Option<TSuccess>, TFailure> DoIfSome<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Action<TSuccess> onSuccessSome)
		{
			if (onSuccessSome == null)
				throw new ArgumentNullException(nameof(onSuccessSome));

			if (result.TryGetValue(out var success, out var failure) && success.TryGetValue(out var some))
				onSuccessSome.Invoke(some);

			return result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> DoIfSome<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Action<TSuccess> onSuccessSome)
			=> (await result).DoIfSome(onSuccessSome);

		public static void ApplyIfSome<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Action<TSuccess> action)
			=> result.DoIfSome(action);

		public static Task ApplyIfSome<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Action<TSuccess> action)
			=> result.DoIfSome(action);
	}
}