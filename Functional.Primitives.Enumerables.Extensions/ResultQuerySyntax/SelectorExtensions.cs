using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static partial class ResultQuerySyntax
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IEnumerable<TSuccess> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TFailure : notnull
			where TBind : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.Select(value => bind
					.Invoke(value)
					.Map(success => resultSelector.Invoke(value, success))
				)
				.AsResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IEnumerable<TSuccess> source, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TFailure : notnull
			where TBind : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.AsAsyncEnumerable()
				.SelectAsync(value => bind
					.Invoke(value)
					.Map(success => resultSelector.Invoke(value, success))
				)
				.AsAsyncResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<IEnumerable<TSuccess>> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TFailure : notnull
			where TBind : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.AsAsyncEnumerable()
				.Select(value => bind
					.Invoke(value)
					.Map(success => resultSelector.Invoke(value, success))
				)
				.AsAsyncResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<IEnumerable<TSuccess>> source, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TFailure : notnull
			where TBind : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.AsAsyncEnumerable()
				.SelectAsync(value => bind
					.Invoke(value)
					.Map(success => resultSelector.Invoke(value, success))
				)
				.AsAsyncResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IAsyncEnumerable<TSuccess> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TFailure : notnull
			where TBind : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.Select(value => bind
					.Invoke(value)
					.Map(success => resultSelector.Invoke(value, success))
				)
				.AsAsyncResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IAsyncEnumerable<TSuccess> source, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TFailure : notnull
			where TBind : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.SelectAsync(value => bind
					.Invoke(value)
					.Map(success => resultSelector.Invoke(value, success))
				)
				.AsAsyncResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, IEnumerable<TBind>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.SelectMany(result => result
					.Match(success =>
						bind
						.Invoke(success)
						.Select(obj => resultSelector.Invoke(success, obj))
						.Select(Result.Success<TResult, TFailure>),
						failure => Enumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
					)
				)
				.AsResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Task<IEnumerable<TBind>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.AsAsyncEnumerable()
				.SelectMany(result => result
					.Match(success =>
						bind
						.Invoke(success)
						.AsAsyncEnumerable()
						.Select(obj => resultSelector.Invoke(success, obj))
						.Select(Result.Success<TResult, TFailure>),
						failure => AsyncEnumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
					)
				)
				.AsAsyncResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, IAsyncEnumerable<TBind>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.SelectMany(result => result
					.Match(success =>
						bind
						.Invoke(success)
						.Select(obj => resultSelector.Invoke(success, obj))
						.Select(Result.Success<TResult, TFailure>),
						failure => AsyncEnumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
					)
				)
				.AsAsyncResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TBind : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.Select(result => result
					.Match(success =>
						bind
						.Invoke(success)
						.Map(value => resultSelector.Invoke(success, value)),
						Result.Failure<TResult, TFailure>
					)
				)
				.AsResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TBind : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.AsAsyncEnumerable()
				.SelectAsync(result => result
					.MatchAsync(success =>
						bind
						.Invoke(success)
						.Map(value => resultSelector.Invoke(success, value)),
						failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure))
					)
				)
				.AsAsyncResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, IEnumerable<TBind>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.SelectMany(result => result
					.Match(success =>
						bind
						.Invoke(success)
						.Select(obj => resultSelector.Invoke(success, obj))
						.Select(Result.Success<TResult, TFailure>),
						failure => Enumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
					)
				)
				.AsAsyncResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Task<IEnumerable<TBind>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.SelectMany(result => result
					.Match(success =>
						bind
						.Invoke(success)
						.AsAsyncEnumerable()
						.Select(obj => resultSelector.Invoke(success, obj))
						.Select(Result.Success<TResult, TFailure>),
						failure => AsyncEnumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
					)
				)
				.AsAsyncResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, IAsyncEnumerable<TBind>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.SelectMany(result => result
					.Match(success =>
						bind
						.Invoke(success)
						.Select(obj => resultSelector.Invoke(success, obj))
						.Select(Result.Success<TResult, TFailure>),
						failure => AsyncEnumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
					)
				)
				.AsAsyncResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TBind : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.Select(result => result
					.Match(success =>
						bind
						.Invoke(success)
						.Map(value => resultSelector.Invoke(success, value)),
						Result.Failure<TResult, TFailure>
					)
				)
				.AsAsyncResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TBind : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return source
				.SelectAsync(result => result
					.MatchAsync(success =>
						bind
						.Invoke(success)
						.Map(value => resultSelector.Invoke(success, value)),
						failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure))
					)
				)
				.AsAsyncResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> source, Func<TSuccess, IEnumerable<TBind>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
			=> Enumerable.Repeat(source, 1).AsResultEnumerable().SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> source, Func<TSuccess, Task<IEnumerable<TBind>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
			=> Enumerable.Repeat(source, 1).AsResultEnumerable().SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> source, Func<TSuccess, IAsyncEnumerable<TBind>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
			=> Enumerable.Repeat(source, 1).AsResultEnumerable().SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> source, Func<TSuccess, IEnumerable<TBind>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
			=> AsyncEnumerable.Repeat(source, 1).AsAsyncResultEnumerable().SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> source, Func<TSuccess, Task<IEnumerable<TBind>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
			=> AsyncEnumerable.Repeat(source, 1).AsAsyncResultEnumerable().SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> source, Func<TSuccess, IAsyncEnumerable<TBind>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
			=> AsyncEnumerable.Repeat(source, 1).AsAsyncResultEnumerable().SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<TResult, TFailure> Select<TSuccess, TResult, TFailure>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, TResult> selector)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
		{
			if (selector == null)
				throw new ArgumentNullException(nameof(selector));

			return source
				.Select(result => result
					.Match(
						success => Result.Success<TResult, TFailure>(selector.Invoke(success)),
						Result.Failure<TResult, TFailure>
					)
				)
				.AsResultEnumerable();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TResult, TFailure> Select<TSuccess, TResult, TFailure>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, TResult> selector)
			where TSuccess : notnull
			where TFailure : notnull
			where TResult : notnull
		{
			if (selector == null)
				throw new ArgumentNullException(nameof(selector));

			return source
				.Select(result => result
					.Match(
						success => Result.Success<TResult, TFailure>(selector.Invoke(success)),
						Result.Failure<TResult, TFailure>
					)
				)
				.AsAsyncResultEnumerable();
		}
	}
}