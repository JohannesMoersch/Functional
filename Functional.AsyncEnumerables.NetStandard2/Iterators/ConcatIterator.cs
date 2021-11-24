using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class ConcatIterator<TSource> : IAsyncEnumerator<TSource>
	{
		private readonly IAsyncEnumerator<TSource> _enumeratorOne;
		private readonly IAsyncEnumerator<TSource> _enumeratorTwo;

		private int _state = 0;

		public TSource Current { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public ConcatIterator(IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
		{
			_enumeratorOne = (first ?? throw new ArgumentNullException(nameof(first))).GetEnumerator();
			_enumeratorTwo = (second ?? throw new ArgumentNullException(nameof(second))).GetEnumerator();
		}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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
					_state = 1;
			}

			if (_state == 1)
			{
				if (await _enumeratorTwo.MoveNext())
				{
					Current = _enumeratorTwo.Current;
					return true;
				}
				else
					_state = 2;
			}

			return false;
		}
	}
}
