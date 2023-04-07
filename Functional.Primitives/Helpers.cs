using System;

namespace Functional
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = false)]
	internal class AllowAllocationsAttribute : Attribute { }

	internal static class ResultFactoryHelpers
	{
		[AllowAllocations]
		public static TSuccess SuccessUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
			where TSuccess : notnull
			where TFailure : notnull
			=> source.Match(static _ => _, static _ => throw new InvalidOperationException("Not a successful result!"));

		[AllowAllocations]
		public static TFailure FailureUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
			where TSuccess : notnull
			where TFailure : notnull
			=> source.Match(static _ => throw new InvalidOperationException("Not a faulted result!"), static _ => _);
	}
}
