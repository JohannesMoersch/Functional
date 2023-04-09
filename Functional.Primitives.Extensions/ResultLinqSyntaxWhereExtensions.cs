using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ResultLinqSyntaxWhereExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Result<TSuccess, TFailure> Where<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Result<Unit, TFailure>> failurePredicate)
			where TSuccess : notnull
			where TFailure : notnull
		{
			if (failurePredicate == null)
				throw new ArgumentNullException(nameof(failurePredicate));
			if (result.TryGetValue(out var success, out _) && !failurePredicate.Invoke(success).TryGetValue(out _, out var f))
				return Result.Failure<TSuccess, TFailure>(f);

			return result;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TSuccess, TFailure>> Where<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Result<Unit, TFailure>> failurePredicate)
			where TSuccess : notnull
			where TFailure : notnull
		{
			if (failurePredicate == null)
				throw new ArgumentNullException(nameof(failurePredicate));

			var value = await result;

			if (value.TryGetValue(out var success, out _) && !failurePredicate.Invoke(success).TryGetValue(out _, out var f))
				return Result.Failure<TSuccess, TFailure>(f);

			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TSuccess, TFailure>> Where<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<Result<Unit, TFailure>>> failurePredicate)
			where TSuccess : notnull
			where TFailure : notnull
		{
			if (failurePredicate == null)
				throw new ArgumentNullException(nameof(failurePredicate));

			if (result.TryGetValue(out var success, out _) && !(await failurePredicate.Invoke(success)).TryGetValue(out _, out var f))
				return Result.Failure<TSuccess, TFailure>(f);

			return result;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TSuccess, TFailure>> Where<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<Result<Unit, TFailure>>> failurePredicate)
			where TSuccess : notnull
			where TFailure : notnull
		{
			if (failurePredicate == null)
				throw new ArgumentNullException(nameof(failurePredicate));

			var value = await result;

			if (value.TryGetValue(out var success, out _) && !(await failurePredicate.Invoke(success)).TryGetValue(out _, out var f))
				return Result.Failure<TSuccess, TFailure>(f);

			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<TSuccess, TFailure> Where<TSuccess, TFailure>(this IEnumerable<TSuccess> source, Func<TSuccess, Result<Unit, TFailure>> failurePredicate)
			where TSuccess : notnull
			where TFailure : notnull
			=> source
				.Select(success => failurePredicate
					.Invoke(success)
					.Map(_ => success)
				)
				.AsResultEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TSuccess, TFailure> Where<TSuccess, TFailure>(this IEnumerable<TSuccess> source, Func<TSuccess, Task<Result<Unit, TFailure>>> failurePredicate)
			where TSuccess : notnull
			where TFailure : notnull
			=> source
				.SelectAsync(success => failurePredicate
					.Invoke(success)
					.Map(_ => success)
				)
				.AsAsyncResultEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TSuccess, TFailure> Where<TSuccess, TFailure>(this IAsyncEnumerable<TSuccess> source, Func<TSuccess, Result<Unit, TFailure>> failurePredicate)
			where TSuccess : notnull
			where TFailure : notnull
			=> source
				.Select(success => failurePredicate
					.Invoke(success)
					.Map(_ => success)
				)
				.AsAsyncResultEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TSuccess, TFailure> Where<TSuccess, TFailure>(this IAsyncEnumerable<TSuccess> source, Func<TSuccess, Task<Result<Unit, TFailure>>> failurePredicate)
			where TSuccess : notnull
			where TFailure : notnull
			=> source
				.SelectAsync(success => failurePredicate
					.Invoke(success)
					.Map(_ => success)
				)
				.AsAsyncResultEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<TSuccess, TFailure> Where<TSuccess, TFailure>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Result<Unit, TFailure>> failurePredicate)
			where TSuccess : notnull
			where TFailure : notnull
			=> source
				.Select(value => value
					.Bind(success => failurePredicate
						.Invoke(success)
						.Map(_ => success)
					)
				)
				.AsResultEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TSuccess, TFailure> Where<TSuccess, TFailure>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Task<Result<Unit, TFailure>>> failurePredicate)
			where TSuccess : notnull
			where TFailure : notnull
			=> source
				.SelectAsync(value => value
					.BindAsync(success => failurePredicate
						.Invoke(success)
						.Map(_ => success)
					)
				)
				.AsAsyncResultEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TSuccess, TFailure> Where<TSuccess, TFailure>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Result<Unit, TFailure>> failurePredicate)
			where TSuccess : notnull
			where TFailure : notnull
			=> source
				.Select(value => value
					.Bind(success => failurePredicate
						.Invoke(success)
						.Map(_ => success)
					)
				)
				.AsAsyncResultEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TSuccess, TFailure> Where<TSuccess, TFailure>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Task<Result<Unit, TFailure>>> failurePredicate)
			where TSuccess : notnull
			where TFailure : notnull
			=> source
				.SelectAsync(value => value
					.BindAsync(success => failurePredicate
						.Invoke(success)
						.Map(_ => success)
					)
				)
				.AsAsyncResultEnumerable();
	}
}
