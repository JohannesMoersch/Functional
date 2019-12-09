using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional.Primitives.Extensions
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ObsoleteResultExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .Map() instead.")]
		public static Result<TResult, TFailure> Select<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, TResult> map)
			=> result.Map(map);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .Map() instead.")]
		public static Task<Result<TResult, TFailure>> Select<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, TResult> map)
			=> result.Map(map);

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
		[Obsolete("Please use .MapIfSomeAsync() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<TResult>> select)
			=> result.MapIfSomeAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapIfSomeAsync() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<TResult>> select)
			=> result.MapIfSomeAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapIfSomeAsync() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Task<Option<TResult>>> select)
			=> result.MapIfSomeAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapIfSomeAsync() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> SelectIfSomeAsync<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Task<Option<TResult>>> select)
			=> result.MapIfSomeAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapIfNoneAsync() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> SelectIfNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<TSuccess>> select)
			=> result.MapIfNoneAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapIfNoneAsync() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> SelectIfNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<TSuccess>> select)
			=> result.MapIfNoneAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapIfNoneAsync() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> SelectIfNoneAsync<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Task<Option<TSuccess>>> select)
			=> result.MapIfNoneAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapIfNoneAsync() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> SelectIfNoneAsync<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Task<Option<TSuccess>>> select)
			=> result.MapIfNoneAsync(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapIfSome() instead.")]
		public static Result<Option<TResult>, TFailure> SelectIfSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, TResult> select)
			=> result.MapIfSome(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapIfSome() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> SelectIfSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, TResult> select)
			=> result.MapIfSome(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapIfSome() instead.")]
		public static Result<Option<TResult>, TFailure> SelectIfSome<TSuccess, TFailure, TResult>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess, Option<TResult>> select)
			=> result.MapIfSome(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapIfSome() instead.")]
		public static Task<Result<Option<TResult>, TFailure>> SelectIfSome<TSuccess, TFailure, TResult>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess, Option<TResult>> select)
			=> result.MapIfSome(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapIfNone() instead.")]
		public static Result<Option<TSuccess>, TFailure> SelectIfNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<TSuccess> select)
			=> result.MapIfNone(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapIfNone() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> SelectIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<TSuccess> select)
			=> result.MapIfNone(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapIfNone() instead.")]
		public static Result<Option<TSuccess>, TFailure> SelectIfNone<TSuccess, TFailure>(this Result<Option<TSuccess>, TFailure> result, Func<Option<TSuccess>> select)
			=> result.MapIfNone(select);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Please use .MapIfNone() instead.")]
		public static Task<Result<Option<TSuccess>, TFailure>> SelectIfNone<TSuccess, TFailure>(this Task<Result<Option<TSuccess>, TFailure>> result, Func<Option<TSuccess>> select)
			=> result.MapIfNone(select);
	}
}
