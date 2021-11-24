using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static partial class ResultOptionExtensions
	{
		public static T Match<TSuccess, TFailure, T>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, T> onSuccessSome, Func<T> onSuccessNone, Func<TFailure, T> onFailure)
			where TSuccess : notnull
			where TFailure : notnull
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
			where TSuccess : notnull
			where TFailure : notnull
			=> (await result).Match(successSome, successNone, failure);

		public static Result<Option<TResult>, TFailure> MapOnSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, TResult> map)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
			=> result.TryGetValue(out var success, out var failure)
				? Result.Success<Option<TResult>, TFailure>(success.Map(map))
				: Result.Failure<Option<TResult>, TFailure>(failure);

		public static async Task<Result<Option<TResult>, TFailure>> MapOnSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, TResult> map)
			where TResult : notnull
			where TFailure : notnull
			where TSuccess : notnull
			=> (await result).MapOnSome(map);

		public static Result<Option<TResult>, TFailure> MapOnSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Option<TResult>> map)
			where TResult : notnull
			where TFailure : notnull
			where TSuccess : notnull
			=> result.TryGetValue(out var success, out var failure)
				? Result.Success<Option<TResult>, TFailure>(success.Bind(map))
				: Result.Failure<Option<TResult>, TFailure>(failure);

		public static async Task<Result<Option<TResult>, TFailure>> MapOnSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Option<TResult>> map)
			where TResult : notnull
			where TFailure : notnull
			where TSuccess : notnull
			=> (await result).MapOnSome(map);

		public static Result<Option<TSuccess>, TFailure> MapOnNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess> map)
			where TSuccess : notnull
			where TFailure : notnull
			=> result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? Result.Success<Option<TSuccess>, TFailure>(Option.Some(map()))
				: result;

		public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess> map)
			where TSuccess : notnull
			where TFailure : notnull
			=> (await result).MapOnNone(map);

		public static Result<Option<TSuccess>, TFailure> MapOnNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Option<TSuccess>> map)
			where TSuccess : notnull
			where TFailure : notnull
			=> result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? Result.Success<Option<TSuccess>, TFailure>(map())
				: result;

		public static async Task<Result<Option<TSuccess>, TFailure>> MapOnNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Option<TSuccess>> map)
			where TSuccess : notnull
			where TFailure : notnull
			=> (await result).MapOnNone(map);

		public static Result<Option<TResult>, TFailure> BindOnSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Result<TResult, TFailure>> bind)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
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
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
			=> (await result).BindOnSome(bind);

		public static Result<Option<TResult>, TFailure> BindOnSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Result<Option<TResult>, TFailure>> bind)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
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
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
			=> (await result).BindOnSome(bind);

		public static Result<Option<TSuccess>, TFailure> BindOnNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Result<TSuccess, TFailure>> bind)
			where TSuccess : notnull
			where TFailure : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? bind().Map(DelegateCache<TSuccess>.Some)
				: result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Result<TSuccess, TFailure>> bind)
			where TSuccess : notnull
			where TFailure : notnull
			=> (await result).BindOnNone(bind);

		public static Result<Option<TSuccess>, TFailure> BindOnNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Result<Option<TSuccess>, TFailure>> bind)
			where TSuccess : notnull
			where TFailure : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			return result.TryGetValue(out var success, out _) && !success.TryGetValue(out _)
				? bind()
				: result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> BindOnNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Result<Option<TSuccess>, TFailure>> bind)
			where TSuccess : notnull
			where TFailure : notnull
			=> (await result).BindOnNone(bind);

		public static Result<TSuccess, TFailure> FailOnNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TFailure> failureFactory)
			where TSuccess : notnull
			where TFailure : notnull
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
			where TSuccess : notnull
			where TFailure : notnull
			=> (await result).FailOnNone(failureFactory);

		public static Result<Option<TSuccess>, TFailure> DoOnSome<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Action<TSuccess> onSuccessSome)
			where TSuccess : notnull
			where TFailure : notnull
		{
			if (onSuccessSome == null)
				throw new ArgumentNullException(nameof(onSuccessSome));

			if (result.TryGetValue(out var success, out var failure) && success.TryGetValue(out var some))
				onSuccessSome.Invoke(some);

			return result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> DoOnSome<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Action<TSuccess> onSuccessSome)
			where TSuccess : notnull
			where TFailure : notnull
			=> (await result).DoOnSome(onSuccessSome);

		public static Result<Option<TSuccess>, TFailure> WhereOnSome<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> failureFactory)
			where TSuccess : notnull
			where TFailure : notnull
		{
			if (predicate == null) throw new ArgumentNullException(nameof(predicate));
			if (failureFactory == null) throw new ArgumentNullException(nameof(failureFactory));

			if (result.TryGetValue(out var success, out var failure) && success.TryGetValue(out var some))
			{
				return predicate.Invoke(some)
					? result
					: Result.Failure<Option<TSuccess>, TFailure>(failureFactory.Invoke(some));
			}

			return result;
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> WhereOnSome<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> failureFactory)
			where TSuccess : notnull
			where TFailure : notnull
			=> (await result).WhereOnSome(predicate, failureFactory);

		public static Result<Option<TSuccess>, TFailure> Evert<TSuccess, TFailure>(this Option<Result<TSuccess, TFailure>> source)
			where TSuccess : notnull
			where TFailure : notnull
		{
			if (source.TryGetValue(out var some))
			{
				return some.TryGetValue(out var success, out var failure)
					? Result.Success<Option<TSuccess>, TFailure>(Option.Some(success))
					: Result.Failure<Option<TSuccess>, TFailure>(failure);
			}

			return Result.Success<Option<TSuccess>, TFailure>(Option.None<TSuccess>());
		}

		public static async Task<Result<Option<TSuccess>, TFailure>> Evert<TSuccess, TFailure>(this Task<Option<Result<TSuccess, TFailure>>> source)
			where TSuccess : notnull
			where TFailure : notnull
			=> (await source).Evert();

		public static void Apply<T, TFailure>(this Result<Option<T>, TFailure> result, Action<T> onSome, Action onNone, Action<TFailure> onFailure)
			where TFailure : notnull
			where T : notnull
		{
			if (onSome == null) throw new ArgumentNullException(nameof(onSome));
			if (onNone == null) throw new ArgumentNullException(nameof(onNone));
			if (onFailure == null) throw new ArgumentNullException(nameof(onFailure));

			if (result.TryGetValue(out var success, out var failure))
			{
				if (success.TryGetValue(out var some))
				{
					onSome.Invoke(some);
				}
				else
				{
					onNone.Invoke();
				}
			}
			else
			{
				onFailure.Invoke(failure);
			}
		}

		public static async Task Apply<T, TFailure>(this Task<Result<Option<T>, TFailure>> result, Action<T> onSome, Action onNone, Action<TFailure> onFailure)
			where T : notnull
			where TFailure : notnull
			=> (await result).Apply(onSome, onNone, onFailure);
	}
}