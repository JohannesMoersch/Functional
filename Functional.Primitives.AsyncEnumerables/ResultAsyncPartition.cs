using System;
using System.Collections.Generic;

namespace Functional;

public readonly struct ResultAsyncPartition<TSuccess, TFailure>
	where TSuccess : notnull
	where TFailure : notnull
{
	internal ResultAsyncPartition(TSuccess[] successCollection, TFailure[] failureCollection)
	{
		SuccessCollection = successCollection ?? throw new ArgumentNullException(nameof(successCollection));
		FailureCollection = failureCollection ?? throw new ArgumentNullException(nameof(failureCollection));
	}

	public TSuccess[] SuccessCollection { get; }
	public TFailure[] FailureCollection { get; }

	public void Deconstruct(out TSuccess[] successCollection, out TFailure[] failureCollection)
	{
		successCollection = SuccessCollection;
		failureCollection = FailureCollection;
	}
}