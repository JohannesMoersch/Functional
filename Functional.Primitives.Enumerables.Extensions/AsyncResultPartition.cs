using System;
using System.Collections.Generic;

namespace Functional
{
	public readonly struct AsyncResultPartition<TSuccess, TFailure>
		where TSuccess : notnull
		where TFailure : notnull
	{
		internal AsyncResultPartition(IAsyncEnumerable<TSuccess> successes, IAsyncEnumerable<TFailure> failures)
		{
			Successes = successes ?? throw new ArgumentNullException(nameof(successes));
			Failures = failures ?? throw new ArgumentNullException(nameof(failures));
		}

		public IAsyncEnumerable<TSuccess> Successes { get; }
		public IAsyncEnumerable<TFailure> Failures { get; }

		public void Deconstruct(out IAsyncEnumerable<TSuccess> successes, out IAsyncEnumerable<TFailure> failures)
		{
			successes = Successes;
			failures = Failures;
		}
	}
}