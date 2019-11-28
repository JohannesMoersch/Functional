using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class AsyncTaskAsyncEnumerator<T> : IAsyncEnumerator<T>
	{
		private readonly Task<IAsyncEnumerator<T>> _asyncEnumeratorTask;

		private IAsyncEnumerator<T> _asyncEnumerator;

		public T Current { get; private set; }

		public AsyncTaskAsyncEnumerator(Task<IAsyncEnumerator<T>> asyncEnumeratorTask)
			=> _asyncEnumeratorTask = asyncEnumeratorTask ?? throw new ArgumentNullException(nameof(asyncEnumeratorTask));

		public async ValueTask DisposeAsync()
			=> await (_asyncEnumerator ??= await _asyncEnumeratorTask).DisposeAsync();

		public async ValueTask<bool> MoveNextAsync()
		{
			var enumerator = _asyncEnumerator ??= await _asyncEnumeratorTask;

			if (await enumerator.MoveNextAsync())
			{
				Current = enumerator.Current;
				return true;
			}

			Current = default;
			return false;
		}
	}
}
