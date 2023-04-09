using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Functional
{
	internal class AsyncIteratorEnumerable<T> : IAsyncEnumerable<T>
    {
		private readonly Func<IAsyncEnumerator<T>> _iteratorFactory;

		public AsyncIteratorEnumerable(Func<IAsyncEnumerator<T>> iteratorFactory)
			=> _iteratorFactory = iteratorFactory;

		public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
			=> _iteratorFactory.Invoke();
	}

	internal static class AsyncIteratorEnumerable
	{
		public static IAsyncEnumerable<T> Create<T>(Func<IAsyncEnumerator<T>> enumeratorFactory)
			=> new AsyncIteratorEnumerable<T>(enumeratorFactory);
	}
}
