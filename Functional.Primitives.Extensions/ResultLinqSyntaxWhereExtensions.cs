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
		{
			if (failurePredicate == null)
				throw new ArgumentNullException(nameof(failurePredicate));

			if (result.TryGetValue(out var success, out var _) && failurePredicate.Invoke(success).TryGetValue(out var __, out var f))
				return Result.Failure<TSuccess, TFailure>(f);

			return result;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TSuccess, TFailure>> Where<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Result<Unit, TFailure>> failurePredicate)
		{
			if (failurePredicate == null)
				throw new ArgumentNullException(nameof(failurePredicate));

			var value = await result;

			if (value.TryGetValue(out var success, out var _) && failurePredicate.Invoke(success).TryGetValue(out var __, out var f))
				return Result.Failure<TSuccess, TFailure>(f);

			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TSuccess, TFailure>> Where<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<Result<Unit, TFailure>>> failurePredicate)
		{
			if (failurePredicate == null)
				throw new ArgumentNullException(nameof(failurePredicate));

			if (result.TryGetValue(out var success, out var _) && (await failurePredicate.Invoke(success)).TryGetValue(out var __, out var f))
				return Result.Failure<TSuccess, TFailure>(f);

			return result;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Result<TSuccess, TFailure>> Where<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<Result<Unit, TFailure>>> failurePredicate)
		{
			if (failurePredicate == null)
				throw new ArgumentNullException(nameof(failurePredicate));

			var value = await result;

			if (value.TryGetValue(out var success, out var _) && (await failurePredicate.Invoke(success)).TryGetValue(out var __, out var f))
				return Result.Failure<TSuccess, TFailure>(f);

			return value;
		}
	}
}
