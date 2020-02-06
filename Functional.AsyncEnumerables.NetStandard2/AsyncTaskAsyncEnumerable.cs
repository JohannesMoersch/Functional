using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class AsyncTaskAsyncEnumerable<T> : IAsyncEnumerable<T>
	{
		private readonly Task<IAsyncEnumerable<T>> _source;

		public AsyncTaskAsyncEnumerable(Task<IAsyncEnumerable<T>> source)
			=> _source = source;

		public IAsyncEnumerator<T> GetEnumerator() 
			=> new AsyncTaskAsyncEnumerator<T>(GetTaskEnumerator());

		private async Task<IAsyncEnumerator<T>> GetTaskEnumerator()
			=> (await _source).GetEnumerator();
	}
}
