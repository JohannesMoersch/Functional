using System;
using System.Threading.Tasks;

namespace Functional
{
	internal class ConcatIterator<TSource> : DisposableBase, IAsyncEnumerator<TSource>
	{
		private readonly IAsyncEnumerator<TSource> _enumeratorOne;
		private readonly IAsyncEnumerator<TSource> _enumeratorTwo;

		private int _state = 0;

		public TSource Current { get; private set; }

		public ConcatIterator(IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
		{
			_enumeratorOne = (first ?? throw new ArgumentNullException(nameof(first))).GetEnumerator();
			_enumeratorTwo = (second ?? throw new ArgumentNullException(nameof(second))).GetEnumerator();
		}

		public async Task<bool> MoveNext()
		{
			if (_state == 0)
			{
				if (await _enumeratorOne.MoveNext())
				{
					Current = _enumeratorOne.Current;
					return true;
				}
				else
				{
					_state = 1;
				}
			}

			if (_state == 1)
			{
				if (await _enumeratorTwo.MoveNext())
				{
					Current = _enumeratorTwo.Current;
					return true;
				}
				else
				{
					_state = 2;
				}
			}

			return false;
		}

		protected override void DisposeResources()
		{
		}
	}
}
