using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ResultExtensions
	{
		public static bool IsSuccess<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
			=> result.TryGetValue(out var success, out var failure) ? true : false;

		public static async Task<bool> IsSuccess<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
			=> (await result).IsSuccess();

		public static Option<TSuccess> Success<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
			=> result.TryGetValue(out var success, out var failure) ? Option.Some(success) : Option.None<TSuccess>();

		public static async Task<Option<TSuccess>> Success<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
			=> (await result).Success();

		public static Option<TFailure> Failure<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
			=> result.TryGetValue(out var success, out var failure) ? Option.None<TFailure>() : Option.Some(failure);

		public static async Task<Option<TFailure>> Failure<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
			=> (await result).Failure();

		public static T Match<TSuccess, TFailure, T>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, T> onSuccessSome, Func<T> onSuccessNone, Func<TFailure, T> onFailure)
		{
			if (onSuccessSome == null)
				throw new ArgumentNullException(nameof(onSuccessSome));

			if (onSuccessNone == null)
				throw new ArgumentNullException(nameof(onSuccessNone));

			if (onFailure == null)
				throw new ArgumentNullException(nameof(onFailure));

			if (result.TryGetValue(out var success, out var failure))
				return success.Match(onSuccessSome, onSuccessNone);

			return onFailure.Invoke(failure);
		}

		public static async Task<T> Match<TSuccess, TFailure, T>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, T> successSome, Func<T> successNone, Func<TFailure, T> failure)
			=> (await result).Match(successSome, successNone, failure);

		public static Result<TResult, TFailure> Select<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, TResult> select)
		{
			if (select == null)
				throw new ArgumentNullException(nameof(select));

			if (result.TryGetValue(out var success, out var failure))
				return Result.Success<TResult, TFailure>(select.Invoke(success));

			return Result.Failure<TResult, TFailure>(failure);
		}

		public static async Task<Result<TResult, TFailure>> Select<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, TResult> select)
			=> (await result).Select(select);

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
			=> result.Select(success => success.DefaultIfNone(select()));

		public static async Task<Result<Option<TSuccess>, TFailure>> SelectIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess> select)
			=> (await result).SelectIfNone(select);

		public static Result<Option<TSuccess>, TFailure> SelectIfNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Option<TSuccess>> select)
			=> result.Select(success => success.Match(Option.Some, select));

		public static async Task<Result<Option<TSuccess>, TFailure>> SelectIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Option<TSuccess>> select)
			=> (await result).SelectIfNone(select);

		public static Result<TSuccess, TFailure> Where<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> failureFactory)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			if (result.TryGetValue(out var success, out var failure))
				return predicate.Invoke(success) ? Result.Success<TSuccess, TFailure>(success) : Result.Failure<TSuccess, TFailure>(failureFactory.Invoke(success));

			return Result.Failure<TSuccess, TFailure>(failure);
		}

		public static async Task<Result<TSuccess, TFailure>> Where<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, bool> predicate, Func<TSuccess, TFailure> failureFactory)
			=> (await result).Where(predicate, failureFactory);

		public static Result<TSuccess, TResult> MapFailure<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TFailure, TResult> mapFailure)
		{
			if (mapFailure == null)
				throw new ArgumentNullException(nameof(mapFailure));

			if (result.TryGetValue(out var success, out var failure))
				return Result.Success<TSuccess, TResult>(success);

			return Result.Failure<TSuccess, TResult>(mapFailure.Invoke(failure));
		}

		public static async Task<Result<TSuccess, TResult>> MapFailure<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, TResult> mapFailure)
			=> (await result).MapFailure(mapFailure);

		public static Result<TResult, TFailure> Bind<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Result<TResult, TFailure>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (result.TryGetValue(out var success, out var failure))
				return bind.Invoke(success);
			
			return Result.Failure<TResult, TFailure>(failure);
		}

		public static async Task<Result<TResult, TFailure>> Bind<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Result<TResult, TFailure>> bind)
			=> (await result).Bind(bind);

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
			=> result.Bind(success => success.Match(s => Result.Success<Option<TSuccess>, TFailure>(Option.Some(s)), () => bind().Select(Option.Some)));

		public static async Task<Result<Option<TSuccess>, TFailure>> BindIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Result<TSuccess, TFailure>> bind)
			=> (await result).BindIfNone(bind);

		public static Result<Option<TSuccess>, TFailure> BindIfNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Result<Option<TSuccess>, TFailure>> bind)
			=> result.Bind(success => success.Match(s => Result.Success<Option<TSuccess>, TFailure>(Option.Some(s)), bind));

		public static async Task<Result<Option<TSuccess>, TFailure>> BindIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Result<Option<TSuccess>, TFailure>> bind)
			=> (await result).BindIfNone(bind);

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

		public static async Task<Result<TSuccess, TFailure>> Do<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Action<TSuccess> success, Action<TFailure> failure)
			=> (await result).Do(success, failure);

		public static Result<TSuccess, TFailure> Do<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Action<TSuccess> onSuccess)
			=> result.Do(onSuccess, DelegateCache<TFailure>.Void);

		public static async Task<Result<TSuccess, TFailure>> Do<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Action<TSuccess> onSuccess)
			=> (await result).Do(onSuccess);

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

		public static void Apply<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Action<TSuccess> onSuccess, Action<TFailure> onFailure)
			=> result.Do(onSuccess, onFailure);

		public static Task Apply<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Action<TSuccess> onSuccess, Action<TFailure> onFailure)
			=> result.Do(onSuccess, onFailure);

		public static void Apply<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Action<TSuccess> onSuccess)
			=> result.Do(onSuccess);

		public static Task Apply<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Action<TSuccess> onSuccess)
			=> result.Do(onSuccess);

		public static void ApplyIfSome<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Action<TSuccess> action)
			=> result.DoIfSome(action);

		public static Task ApplyIfSome<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Action<TSuccess> action)
			=> result.DoIfSome(action);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .Success() instead.")]
		public static Option<TSuccess> ToOption<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
			=> result.Success();

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .Success() instead.")]
		public static Task<Option<TSuccess>> ToOption<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
			=> result.Success();

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

		public static Result<TResult, TFailure> TrySelect<TSuccess, TResult, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, TResult> successFactory, Func<Exception, TFailure> failureFactory)
		{
			if (successFactory == null)
				throw new ArgumentNullException(nameof(successFactory));

			if(failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			if (result.TryGetValue(out var success, out var failure))
			{
				try
				{
					return Result.Success<TResult, TFailure>(successFactory.Invoke(success));
				}
				catch (Exception ex)
				{
					return Result.Failure<TResult, TFailure>(failureFactory.Invoke(ex));
				}
			}

			return Result.Failure<TResult, TFailure>(failure);
		}

		public static Result<TResult, Exception> TrySelect<TSuccess, TResult>(this Result<TSuccess, Exception> result, Func<TSuccess, TResult> successFactory)
			=> TrySelect(result, successFactory, DelegateCache<Exception>.Passthrough);

		public static async Task<Result<TResult, TFailure>> TrySelect<TSuccess, TResult, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, TResult> successFactory, Func<Exception, TFailure> failureFactory)
			=> (await result).TrySelect(successFactory, failureFactory);

		public static async Task<Result<TResult, Exception>> TrySelect<TSuccess, TResult>(this Task<Result<TSuccess, Exception>> result, Func<TSuccess, TResult> successFactory)
			=> (await result).TrySelect(successFactory, DelegateCache<Exception>.Passthrough);
	}
}
	