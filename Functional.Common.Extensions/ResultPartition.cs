using System;
using System.Collections.Generic;

namespace Functional;

public class ResultPartition<TSuccess, TFailure>
	where TSuccess : notnull
	where TFailure : notnull
{
	public ResultPartition(IReadOnlyCollection<TSuccess> successCollection, IReadOnlyCollection<TFailure> failureCollection)
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