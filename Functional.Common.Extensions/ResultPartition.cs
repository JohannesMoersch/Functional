using System;
using System.Collections.Generic;

namespace Functional;

public readonly struct ResultPartition<TSuccess, TFailure>
	where TSuccess : notnull
	where TFailure : notnull
{
	internal ResultPartition(IEnumerable<TSuccess> successCollection, IEnumerable<TFailure> failureCollection)
	{
		SuccessCollection = successCollection ?? throw new ArgumentNullException(nameof(successCollection));
		FailureCollection = failureCollection ?? throw new ArgumentNullException(nameof(failureCollection));
	}

	public IEnumerable<TSuccess> SuccessCollection { get; }
	public IEnumerable<TFailure> FailureCollection { get; }

	public void Deconstruct(out IEnumerable<TSuccess> successCollection, out IEnumerable<TFailure> failureCollection)
	{
		successCollection = SuccessCollection;
		failureCollection = FailureCollection;
	}
}