using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class BasicIterator<TSource, TResult> : IAsyncEnumerator<TResult>
	{
		private readonly IAsyncEnumerator<TSource> _enumerator;
		private readonly Func<(TSource current, int index), (BasicIteratorContinuationType type, TResult current)> _moveNext;

		private int _count;

		public TResult Current { get; private set; }

		public BasicIterator(IAsyncEnumerable<TSource> source, Func<(TSource current, int index), (BasicIteratorContinuationType type, TResult current)> moveNext)
			=> (_enumerator, _moveNext) = ((source ?? throw new ArgumentNullException(nameof(source))).GetEnumerator(), moveNext);

		public async Task<bool> MoveNext()
		{
			while (await _enumerator.MoveNext())
			{
				var value = _moveNext.Invoke((_enumerator.Current, _count++));

				switch (value.type)
				{
					case BasicIteratorContinuationType.Take:
						Current = value.current;
						return true;
					case BasicIteratorContinuationType.Skip:
						continue;
				}
				break;
			}

			return false;
		}
	}
}
