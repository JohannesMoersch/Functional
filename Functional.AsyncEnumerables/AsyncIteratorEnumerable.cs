using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
    public class AsyncIteratorEnumerable<T> : IAsyncEnumerable<T>
    {
		private readonly Func<IAsyncEnumerator<T>> _iteratorFactory;

		public AsyncIteratorEnumerable(Func<IAsyncEnumerator<T>> iteratorFactory)
			=> _iteratorFactory = iteratorFactory;

		public IAsyncEnumerator<T> GetEnumerator()
			=> _iteratorFactory.Invoke();
	}

	public static class AsyncIteratorEnumerable
	{
		public static IAsyncEnumerable<T> Create<T>(Func<IAsyncEnumerator<T>> enumeratorFactory)
			=> new AsyncIteratorEnumerable<T>(enumeratorFactory);
	}
}
