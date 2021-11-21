using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class AsyncEnumerator<T> : IAsyncEnumerator<T>
    {
		private readonly Lazy<Task<IEnumerator<T>>> _enumerator;

#pragma warning disable CS8603 // Possible null reference return.
		public T Current => _enumerator.IsValueCreated && _enumerator.Value.IsCompleted ? _enumerator.Value.Result.Current : default;
#pragma warning restore CS8603 // Possible null reference return.

		internal AsyncEnumerator(Lazy<Task<IEnumerator<T>>> enumerator)
			=> _enumerator = enumerator;

		public async ValueTask DisposeAsync()
		{
			if (_enumerator.IsValueCreated)
				(await _enumerator.Value).Dispose();
		}

		public async ValueTask<bool> MoveNextAsync()
			=> (await _enumerator.Value).MoveNext();
	}
}
