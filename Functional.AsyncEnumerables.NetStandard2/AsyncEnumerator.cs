using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class AsyncEnumerator<T> : IAsyncEnumerator<T>
    {
		private static readonly Task<bool> _trueResult = Task.FromResult(true);

		private static readonly Task<bool> _falseResult = Task.FromResult(false);

		private readonly Lazy<Task<IEnumerator<T>>> _enumerator;

#pragma warning disable CS8603 // Possible null reference return.
		public T Current => _enumerator.IsValueCreated && _enumerator.Value.IsCompleted ? _enumerator.Value.Result.Current : default;
#pragma warning restore CS8603 // Possible null reference return.

		internal AsyncEnumerator(Lazy<Task<IEnumerator<T>>> enumerator)
			=> _enumerator = enumerator;

		public Task<bool> MoveNext()
		{
			var enumerator = _enumerator.Value;

			if (enumerator.IsCompleted)
				return enumerator.Result.MoveNext() ? _trueResult : _falseResult;

			return enumerator.ContinueWith(t => t.Result.MoveNext(), TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);
		}
	}
}
