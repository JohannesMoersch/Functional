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
		public static Result<TSuccess, TFailure> Where<TSuccess, TFailure>(this Result<TSuccess, TFailure> source, Func<TSuccess, Result<Unit, TFailure>> failurePredicate)
			=> source
				.Bind(success => failurePredicate
					.Invoke(success)
					.Select(_ => success)
				);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Result<TSuccess, TFailure>> Where<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> source, Func<TSuccess, Result<Unit, TFailure>> failurePredicate)
			=> source
				.Bind(success => failurePredicate
					.Invoke(success)
					.Select(_ => success)
				);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Result<TSuccess, TFailure>> Where<TSuccess, TFailure>(this Result<TSuccess, TFailure> source, Func<TSuccess, Task<Result<Unit, TFailure>>> failurePredicate)
			=> source
				.BindAsync(success => failurePredicate
					.Invoke(success)
					.Select(_ => success)
				);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Result<TSuccess, TFailure>> Where<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> source, Func<TSuccess, Task<Result<Unit, TFailure>>> failurePredicate)
			=> source
				.BindAsync(success => failurePredicate
					.Invoke(success)
					.Select(_ => success)
				);
	}
}
