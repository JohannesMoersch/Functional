using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static class ResultTestExtensions
	{
		public static TSuccess AssertSuccess<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
			where TSuccess : notnull
			where TFailure : notnull
			=> result.Match(s => s, f => throw new Exception("Result should be success."));

		public static async Task<TSuccess> AssertSuccess<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
			where TSuccess : notnull
			where TFailure : notnull
		   => (await result).Match(s => s, f => throw new Exception("Result should be success."));

		public static TFailure AssertFailure<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
			where TSuccess : notnull
			where TFailure : notnull
		   => result.Match(s => throw new Exception("Result should be failure."), f => f);

		public static async Task<TFailure> AssertFailure<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
			where TSuccess : notnull
			where TFailure : notnull
		   => (await result).Match(s => throw new Exception("Result should be failure."), f => f);
	}
}
