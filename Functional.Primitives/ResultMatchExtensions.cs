using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ResultMatchExtensions
    {
		public static async Task<TResult> Match<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, TResult> success, Func<TFailure, TResult> failure)
			=> (await result).Match(success, failure);

		public static Task<TResult> MatchAsync<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task<TResult>> success, Func<TFailure, Task<TResult>> failure)
			=> result.Match(success, failure);

		public static async Task<TResult> MatchAsync<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task<TResult>> success, Func<TFailure, Task<TResult>> failure)
			=> await (await result).Match(success, failure);
	}
}
