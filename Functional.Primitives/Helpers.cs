using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = false)]
	internal class AllowAllocationsAttribute : Attribute { }

	internal static class DelegateCache<T>
	{
		public static readonly Func<T, T> Passthrough = x => x;
	}

	internal static class DelegateCache<TIn, TOut>
	{
		private static readonly Exception _expectedSuccessException = new InvalidOperationException("Not a successful result!");
		private static readonly Exception _expectedFailureException = new InvalidOperationException("Not a faulted result!");

		public static readonly Func<TIn, TOut> ExpectedSuccess = _ => throw _expectedSuccessException;
		public static readonly Func<TIn, TOut> ExpectedFailure = _ => throw _expectedFailureException;
	}

	internal static class ResultFactoryHelpers
	{
		public static TSuccess SuccessUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
			=> source.Match(DelegateCache<TSuccess>.Passthrough, DelegateCache<TFailure, TSuccess>.ExpectedSuccess);

		public static TFailure FailureUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
			=> source.Match(DelegateCache<TSuccess, TFailure>.ExpectedFailure, DelegateCache<TFailure>.Passthrough);
	}
}
