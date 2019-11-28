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

		public BasicIterator(IAsyncEnumerable<TSource> source, Func<(TSource current, int index), (BasicIteratorContinuationType type, TResult current)> onNext)
		{
			_enumerator = (source ?? throw new ArgumentNullException(nameof(source))).GetAsyncEnumerator();
			_moveNext = onNext ?? throw new ArgumentNullException(nameof(onNext));
		}

		public ValueTask DisposeAsync()
			=> _enumerator.DisposeAsync();

		public async ValueTask<bool> MoveNextAsync()
		{
			while (await _enumerator.MoveNextAsync())
			{
				var (type, current) = _moveNext.Invoke((_enumerator.Current, _count++));

				switch (type)
				{
					case BasicIteratorContinuationType.Take:
						Current = current;
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
