using System;
using System.Collections.Generic;

namespace Functional;

public readonly struct ResultAsyncPartition<TSuccess, TFailure>
	where TSuccess : notnull
	where TFailure : notnull
{
	internal ResultAsyncPartition(IReadOnlyCollection<TSuccess> successCollection, IReadOnlyCollection<TFailure> failureCollection)
	{
		SuccessCollection = successCollection ?? throw new ArgumentNullException(nameof(successCollection));
		FailureCollection = failureCollection ?? throw new ArgumentNullException(nameof(failureCollection));
	}

	public IReadOnlyCollection<TSuccess> SuccessCollection { get; }
	public IReadOnlyCollection<TFailure> FailureCollection { get; }

	public void Deconstruct(out IReadOnlyCollection<TSuccess> successCollection, out IReadOnlyCollection<TFailure> failureCollection)
	{
		successCollection = SuccessCollection;
		failureCollection = FailureCollection;
	}
}