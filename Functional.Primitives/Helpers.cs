using System;

namespace Functional
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false)]
	internal class AllowAllocationsAttribute : Attribute
	{
		public readonly bool AllowBox;
		public readonly bool AllowNewArr;
		public readonly Type[] AllowNewObjTypes;

		public AllowAllocationsAttribute(bool allowBox = false, bool allowNewArr = false, params Type[] allowNewObjTypes)
		{
			AllowBox = allowBox;
			AllowNewArr = allowNewArr;
			AllowNewObjTypes = allowNewObjTypes;
		}
	}

	internal static class ResultFactoryHelpers
	{
		public static TSuccess SuccessUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
			where TSuccess : notnull
			where TFailure : notnull
			=> source.Match(static _ => _, static _ => throw new InvalidOperationException("Not a successful result!"));

		public static TFailure FailureUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
			where TSuccess : notnull
			where TFailure : notnull
			=> source.Match(static _ => throw new InvalidOperationException("Not a faulted result!"), static _ => _);
	}
}
