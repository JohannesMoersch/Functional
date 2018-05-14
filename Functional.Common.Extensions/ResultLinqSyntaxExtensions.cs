using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ResultLinqSyntaxExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IEnumerable<TSuccess> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return ResultEnumerable.Create
			(
				source
				.Select(value => bind
					.Invoke(value)
					.Select(obj => resultSelector.Invoke(value, obj))
				)
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IResultEnumerable<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<IEnumerable<TSuccess>> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			=> (await source).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, IEnumerable<TBind>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return ResultEnumerable.Create
			(
				result
				.Match(value => bind
					.Invoke(value)
					.Select(obj => resultSelector.Invoke(value, obj))
					.Select(Result.Success<TResult, TFailure>),
					failure => Enumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
				)
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IResultEnumerable<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, IEnumerable<TBind>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			=> (await result).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return ResultEnumerable.Create
			(
				source
				.Select(result => result
					.Bind(value => bind
						.Invoke(value)
						.Select(obj => resultSelector.Invoke(value, obj))
					)
				)
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IResultEnumerable<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<IResultEnumerable<TSuccess, TFailure>> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			=> (await source).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, IEnumerable<TBind>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return ResultEnumerable.Create
			(
				source
				.SelectMany(result => result
					.Match(value => bind
						.Invoke(value)
						.Select(obj => resultSelector.Invoke(value, obj))
						.Select(Result.Success<TResult, TFailure>),
						failure => Enumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
					)
				)
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IResultEnumerable<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<IResultEnumerable<TSuccess, TFailure>> source, Func<TSuccess, IEnumerable<TBind>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			=> (await source).SelectMany(bind, resultSelector);














































		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IResultEnumerable<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this IEnumerable<TSuccess> source, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return ResultEnumerable.Create
			(
				await Task.WhenAll(source
					.Select(value => bind
						.Invoke(value)
						.Select(obj => resultSelector.Invoke(value, obj))
					)
				)
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IResultEnumerable<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<IEnumerable<TSuccess>> source, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			=> await (await source).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<IResultEnumerable<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<IEnumerable<TBind>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return ResultEnumerable.Create
			(
				result
				.MatchAsync(async value => 
					(await bind.Invoke(value))
					.Select(obj => resultSelector.Invoke(value, obj))
					.Select(Result.Success<TResult, TFailure>),
					failure => Task.FromResult(Enumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1))
				)
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IResultEnumerable<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<IEnumerable<TBind>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			=> await (await result).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IResultEnumerable<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return ResultEnumerable.Create
			(
				await Task.WhenAll(source
					.Select(result => result
						.BindAsync(value => bind
							.Invoke(value)
							.Select(obj => resultSelector.Invoke(value, obj))
						)
					)
				)
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IResultEnumerable<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<IResultEnumerable<TSuccess, TFailure>> source, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			=> await (await source).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IResultEnumerable<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Task<IEnumerable<TBind>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return ResultEnumerable.Create
			(
				(await Task.WhenAll(source
					.Select(result => result
						.MatchAsync(async value => 
							(await bind.Invoke(value))
							.Select(obj => resultSelector.Invoke(value, obj))
							.Select(Result.Success<TResult, TFailure>),
							failure => Task.FromResult(Enumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1))
						)
					)
				))
				.SelectMany(o => o)
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IResultEnumerable<TResult, TFailure>> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<IResultEnumerable<TSuccess, TFailure>> source, Func<TSuccess, Task<IEnumerable<TBind>>> bind, Func<TSuccess, TBind, TResult> resultSelector)
			=> await (await source).SelectMany(bind, resultSelector);
	}
}
