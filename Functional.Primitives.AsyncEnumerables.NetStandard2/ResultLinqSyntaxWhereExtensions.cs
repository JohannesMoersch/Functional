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
		public static IResultEnumerable<TSuccess, TFailure> Where<TSuccess, TFailure>(this IEnumerable<TSuccess> source, Func<TSuccess, Result<Unit, TFailure>> failurePredicate)
			=> source
				.Select((Func<TSuccess, Result<TSuccess, TFailure>>)(success => (Result<TSuccess, TFailure>)ResultExtensions.Map<Unit, TFailure, TSuccess>(failurePredicate
					.Invoke((TSuccess)success)
, (Func<Unit, TSuccess>)(_ => (TSuccess)success)))
				)
				.AsResultEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TSuccess, TFailure> Where<TSuccess, TFailure>(this IEnumerable<TSuccess> source, Func<TSuccess, Task<Result<Unit, TFailure>>> failurePredicate)
			=> source
				.SelectAsync(success => failurePredicate
					.Invoke(success)
					.Map(_ => success)
				)
				.AsAsyncResultEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TSuccess, TFailure> Where<TSuccess, TFailure>(this IAsyncEnumerable<TSuccess> source, Func<TSuccess, Result<Unit, TFailure>> failurePredicate)
			=> source
				.Select(success => failurePredicate
					.Invoke(success)
					.Map(_ => success)
				)
				.AsAsyncResultEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TSuccess, TFailure> Where<TSuccess, TFailure>(this IAsyncEnumerable<TSuccess> source, Func<TSuccess, Task<Result<Unit, TFailure>>> failurePredicate)
			=> source
				.SelectAsync(success => failurePredicate
					.Invoke(success)
					.Map(_ => success)
				)
				.AsAsyncResultEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<TSuccess, TFailure> Where<TSuccess, TFailure>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Result<Unit, TFailure>> failurePredicate)
			=> source
				.Select((Func<Result<TSuccess, TFailure>, Result<TSuccess, TFailure>>)(value => value
					.Bind((Func<TSuccess, Result<TSuccess, TFailure>>)(success => (Result<TSuccess, TFailure>)ResultExtensions.Map<Unit, TFailure, TSuccess>(failurePredicate
						.Invoke((TSuccess)success)
, (Func<Unit, TSuccess>)(_ => (TSuccess)success)))
					))
				)
				.AsResultEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<TSuccess, TFailure> Where<TSuccess, TFailure>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Task<Result<Unit, TFailure>>> failurePredicate)
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
