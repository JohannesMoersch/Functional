using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    internal class AsyncSelectIterator<TSource, TResult> : IAsyncEnumerator<TResult>
    {
		private readonly Func<TSource, int, TResult> _selector;

		private readonly IAsyncEnumerator<TSource> _enumerator;

		private int _count;

		public TResult Current { get; private set; }

		public AsyncSelectIterator(IAsyncEnumerable<TSource> source, Func<TSource, int, TResult> selector)
			=> (_enumerator, _selector) = (source.GetEnumerator(), selector);

		public Task<bool> MoveNext()
			=> _enumerator
				.MoveNext()
				.ContinueWith(t =>
				{
					if (t.Result)
						Current = _selector.Invoke(_enumerator.Current, _count++);
					return t.Result;
				}, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);
	}
}
