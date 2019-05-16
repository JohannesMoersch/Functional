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

		public async Task<bool> MoveNext()
		{
			var enumerator = _asyncEnumerator ?? (_asyncEnumerator = (await _asyncEnumeratorTask));

			if (await enumerator.MoveNext())
			{
				Current = enumerator.Current;
				return true;
			}

			Current = default;
			return false;
		}
	}
}
