using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class AsyncTaskEnumerator<T> : IAsyncEnumerator<T>
	{
		private readonly Lazy<IEnumerator<Task<T>>> _enumerator;

		public T Current { get; private set; }

		internal AsyncTaskEnumerator(Lazy<IEnumerator<Task<T>>> enumerator)
			=> _enumerator = enumerator;

		public ValueTask DisposeAsync()
		{
			if (_enumerator.IsValueCreated)
				_enumerator.Value.Dispose();

			return default;
		}

		public async ValueTask<bool> MoveNextAsync()
		{
			var enumerator = _enumerator.Value;

			if (!enumerator.MoveNext())
				return false;

			Current = await enumerator.Current;

			return true;
		}
	}
}
