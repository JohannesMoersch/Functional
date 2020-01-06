using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ObsoleteResultExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .Success() instead.")]
		public static Option<TSuccess> ToOption<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
			=> result.Success();

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .Success() instead.")]
		public static Task<Option<TSuccess>> ToOption<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
			=> result.Success();

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .TryMap() instead.")]
		public static Result<TResult, TFailure> TrySelect<TSuccess, TResult, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, TResult> successFactory, Func<Exception, TFailure> failureFactory)
			=> result.TryMap(successFactory, failureFactory);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .TryMap() instead.")]
		public static Result<TResult, Exception> TrySelect<TSuccess, TResult>(this Result<TSuccess, Exception> result, Func<TSuccess, TResult> successFactory)
			=> result.TryMap(successFactory);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .TryMap() instead.")]
		public static Task<Result<TResult, TFailure>> TrySelect<TSuccess, TResult, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, TResult> successFactory, Func<Exception, TFailure> failureFactory)
			=> result.TryMap(successFactory, failureFactory);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .TryMap() instead.")]
		public static Task<Result<TResult, Exception>> TrySelect<TSuccess, TResult>(this Task<Result<TSuccess, Exception>> result, Func<TSuccess, TResult> successFactory)
			=> result.TryMap(successFactory);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapAsync() instead.")]
		public static Task<Result<TResult, TFailure>> SelectAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<TResult>> map)
			=> result.MapAsync(map);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapAsync() instead.")]
		public static Task<Result<TResult, TFailure>> SelectAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<TResult>> map)
			=> result.MapAsync(map);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .TryMapAsync() instead.")]
		public static Task<Result<TResult, TFailure>> TrySelectAsync<TSuccess, TResult, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<TResult>> successFactory, Func<Exception, TFailure> failureFactory)
			=> result.TryMapAsync(successFactory, failureFactory);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .TryMapAsync() instead.")]
		public static Task<Result<TResult, Exception>> TrySelectAsync<TSuccess, TResult>(this Result<TSuccess, Exception> result, Func<TSuccess, Task<TResult>> successFactory)
			=> result.TryMapAsync(successFactory);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .TryMapAsync() instead.")]
		public static Task<Result<TResult, TFailure>> TrySelectAsync<TSuccess, TResult, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<TResult>> successFactory, Func<Exception, TFailure> failureFactory)
			=> result.TryMapAsync(successFactory, failureFactory);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .TryMapAsync() instead.")]
		public static Task<Result<TResult, Exception>> TrySelectAsync<TSuccess, TResult>(this Task<Result<TSuccess, Exception>> result, Func<TSuccess, Task<TResult>> successFactory)
			=> result.TryMapAsync(successFactory);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnSomeAsync() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<TResult>> select)
			=> result.MapOnSomeAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnSomeAsync() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<TResult>> select)
			=> result.MapOnSomeAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnSomeAsync() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Option<TResult>>> select)
			=> result.MapOnSomeAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnSomeAsync() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Option<TResult>>> select)
			=> result.MapOnSomeAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnNoneAsync() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> SelectIfNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<TSuccess>> select)
			=> result.MapOnNoneAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnNoneAsync() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> SelectIfNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<TSuccess>> select)
			=> result.MapOnNoneAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnNoneAsync() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> SelectIfNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Option<TSuccess>>> select)
			=> result.MapOnNoneAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnNoneAsync() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> SelectIfNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Option<TSuccess>>> select)
			=> result.MapOnNoneAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnSome() instead.")]
		public static Result<Option<TResult>, TFailure> SelectIfSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, TResult> select)
			=> result.MapOnSome(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnSome() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> SelectIfSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, TResult> select)
			=> result.MapOnSome(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnSome() instead.")]
		public static Result<Option<TResult>, TFailure> SelectIfSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Option<TResult>> select)
			=> result.MapOnSome(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnSome() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> SelectIfSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Option<TResult>> select)
			=> result.MapOnSome(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnNone() instead.")]
		public static Result<Option<TSuccess>, TFailure> SelectIfNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess> select)
			=> result.MapOnNone(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnNone() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> SelectIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess> select)
			=> result.MapOnNone(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnNone() instead.")]
		public static Result<Option<TSuccess>, TFailure> SelectIfNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Option<TSuccess>> select)
			=> result.MapOnNone(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnNone() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> SelectIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Option<TSuccess>> select)
			=> result.MapOnNone(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnFailure() instead.")]
		public static Result<TSuccess, TFailure> BindIfFailure<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TFailure, Result<TSuccess, TFailure>> bind)
			=> result.BindOnFailure(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnFailure() instead.")]
		public static Task<Result<TSuccess, TFailure>> BindIfFailure<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, Result<TSuccess, TFailure>> bind)
			=> result.BindOnFailure(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnFailureAsync() instead.")]
		public static Task<Result<TSuccess, TFailure>> BindIfFailureAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TFailure, Task<Result<TSuccess, TFailure>>> bind)
			=> result.BindOnFailureAsync(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnFailureAsync() instead.")]
		public static Task<Result<TSuccess, TFailure>> BindIfFailureAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, Task<Result<TSuccess, TFailure>>> bind)
			=> result.BindOnFailureAsync(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnFailure() instead.")]
		public static Result<TSuccess, TResult> MapFailure<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TFailure, TResult> mapFailure)
			=> result.MapOnFailure(mapFailure);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnFailure() instead.")]
		public static Task<Result<TSuccess, TResult>> MapFailure<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, TResult> mapFailure)
			=> result.MapOnFailure(mapFailure);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnFailureAsync() instead.")]
		public static Task<Result<TSuccess, TResult>> MapFailureAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TFailure, Task<TResult>> mapFailure)
			=> result.MapOnFailureAsync(mapFailure);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapOnFailureAsync() instead.")]
		public static Task<Result<TSuccess, TResult>> MapFailureAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TFailure, Task<TResult>> mapFailure)
			=> result.MapOnFailureAsync(mapFailure);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnSome() instead.")]
		public static Result<Option<TResult>, TFailure> BindIfSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Result<TResult, TFailure>> bind)
			=> result.BindOnSome(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnSome() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> BindIfSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Result<TResult, TFailure>> bind)
			=> result.BindOnSome(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnSome() instead.")]
		public static Result<Option<TResult>, TFailure> BindIfSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Result<Option<TResult>, TFailure>> bind)
			=> result.BindOnSome(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnSome() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> BindIfSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Result<Option<TResult>, TFailure>> bind)
			=> result.BindOnSome(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnNone() instead.")]
		public static Result<Option<TSuccess>, TFailure> BindIfNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Result<TSuccess, TFailure>> bind)
			=> result.BindOnNone(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnNone() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> BindIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Result<TSuccess, TFailure>> bind)
			=> result.BindOnNone(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnNone() instead.")]
		public static Result<Option<TSuccess>, TFailure> BindIfNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Result<Option<TSuccess>, TFailure>> bind)
			=> result.BindOnNone(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnNone() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> BindIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Result<Option<TSuccess>, TFailure>> bind)
			=> result.BindOnNone(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .FailOnNone() instead.")]
		public static Result<TSuccess, TFailure> FailureIfNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TFailure> failureFactory)
			=> result.FailOnNone(failureFactory);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .FailOnNone() instead.")]
		public static Task<Result<TSuccess, TFailure>> FailureIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TFailure> failureFactory)
			=> result.FailOnNone(failureFactory);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .DoOnSome() instead.")]
		public static Result<Option<TSuccess>, TFailure> DoIfSome<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Action<TSuccess> onSuccessSome)
			=> result.DoOnSome(onSuccessSome);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .DoOnSome() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> DoIfSome<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Action<TSuccess> onSuccessSome)
			=> result.DoOnSome(onSuccessSome);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .ApplyOnSome() instead.")]
		public static void ApplyIfSome<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Action<TSuccess> onSuccessSome)
			=> result.ApplyOnSome(onSuccessSome);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .ApplyOnSome() instead.")]
		public static Task ApplyIfSome<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Action<TSuccess> onSuccessSome)
			=> result.ApplyOnSome(onSuccessSome);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnSomeAsync() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> BindIfSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
			=> result.BindOnSomeAsync(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnSomeAsync() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> BindIfSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Result<TResult, TFailure>>> bind)
			=> result.BindOnSomeAsync(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnSomeAsync() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> BindIfSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Result<Option<TResult>, TFailure>>> bind)
			=> result.BindOnSomeAsync(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnSomeAsync() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> BindIfSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Result<Option<TResult>, TFailure>>> bind)
			=> result.BindOnSomeAsync(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnNoneAsync() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> BindIfNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Result<TSuccess, TFailure>>> bind)
			=> result.BindOnNoneAsync(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnNoneAsync() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> BindIfNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Result<TSuccess, TFailure>>> bind)
			=> result.BindOnNoneAsync(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnNoneAsync() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> BindIfNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Result<Option<TSuccess>, TFailure>>> bind)
			=> result.BindOnNoneAsync(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .BindOnNoneAsync() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> BindIfNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Result<Option<TSuccess>, TFailure>>> bind)
			=> result.BindOnNoneAsync(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .FailOnNoneAsync() instead.")]
		public static Task<Result<TSuccess, TFailure>> FailureIfNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<TFailure>> failureFactory)
			=> result.FailOnNoneAsync(failureFactory);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .FailOnNoneAsync() instead.")]
		public static Task<Result<TSuccess, TFailure>> FailureIfNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<TFailure>> failureFactory)
			=> result.FailOnNoneAsync(failureFactory);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .DoOnSomeAsync() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> DoIfSomeAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task> onSuccessSome)
			=> result.DoOnSomeAsync(onSuccessSome);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .DoOnSomeAsync() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> DoIfSomeAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task> onSuccessSome)
			=> result.DoOnSomeAsync(onSuccessSome);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .ApplyOnSomeAsync() instead.")]
		public static Task ApplyIfSomeAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task> onSuccessSome)
			=> result.ApplyOnSomeAsync(onSuccessSome);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .ApplyOnSomeAsync() instead.")]
		public static Task ApplyIfSomeAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task> onSuccessSome)
			=> result.ApplyOnSomeAsync(onSuccessSome);
	}
}
