using System.Threading.Tasks;

namespace Functional
{
	public static class ResultUtility
	{
		public static TSuccess AssertSuccess<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
			=> result.Match(s => s, f => throw new System.Exception("Result should be success."));

		public static async Task<TSuccess> AssertSuccess<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
			=> (await result).Match(s => s, f => throw new System.Exception("Result should be success."));

		public static TFailure AssertFailure<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
			=> result.Match(s => throw new System.Exception("Result should be failure."), f => f);

		public static async Task<TFailure> AssertFailure<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
			=> (await result).Match(s => throw new System.Exception("Result should be failure."), f => f);
	}
}