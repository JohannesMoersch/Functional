using System;

namespace Functional
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = false)]
	internal class AllowAllocationsAttribute : Attribute { }

	internal static class DelegateCache<T>
	{
		public static readonly Func<T, T> Passthrough = x => x;
	}

	internal static class ResultFactoryHelpers
	{
		public static TSuccess SuccessUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
			=> source.Match(DelegateCache<TSuccess>.Passthrough, _ => throw new InvalidOperationException("Not a successful result!"));

		public static TFailure FailureUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
			=> source.Match(_ => throw new InvalidOperationException("Not a faulted result!"), DelegateCache<TFailure>.Passthrough);
	}
}
