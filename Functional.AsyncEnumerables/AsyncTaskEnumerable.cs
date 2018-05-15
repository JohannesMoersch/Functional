using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Functional
{
	internal class AsyncTaskEnumerable<T> : IAsyncEnumerable<T>
	{
		private readonly Lazy<IEnumerable<Task<T>>> _source;

		public AsyncTaskEnumerable(Func<IEnumerable<Task<T>>> source)
			=> _source = new Lazy<IEnumerable<Task<T>>>(source, LazyThreadSafetyMode.ExecutionAndPublication);

		public IAsyncEnumerator<T> GetEnumerator()
			=> new AsyncTaskEnumerator<T>(new Lazy<IEnumerator<Task<T>>>(() => _source.Value.GetEnumerator(), LazyThreadSafetyMode.PublicationOnly));
	}
}
