using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Functional
{
    public static class ResultLinqSyntaxExtensions
	{

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IEnumerable<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, IEnumerable<TBind>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return result
				.Match(value => bind
					.Invoke(value)
					.Select(obj => resultSelector.Invoke(value, obj))
					.Select(Result.Success<TResult, TFailure>),
					failure => Enumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
				);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IEnumerable<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this IEnumerable<TSuccess> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.Select(value => bind
					.Invoke(value)
					.Select(obj => resultSelector.Invoke(value, obj))
				);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IEnumerable<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this IEnumerable<Result<TSuccess, TFailure>> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.Select(result => result
					.Bind(value => bind
						.Invoke(value)
						.Select(obj => resultSelector.Invoke(value, obj))
					)
				);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IEnumerable<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this IEnumerable<Result<TSuccess, TFailure>> source, Func<TSuccess, IEnumerable<TBind>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.SelectMany(result => result
					.Match(value => bind
						.Invoke(value)
						.Select(obj => resultSelector.Invoke(value, obj))
						.Select(Result.Success<TResult, TFailure>),
						failure => Enumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
					)
				);
		}
	}
}
