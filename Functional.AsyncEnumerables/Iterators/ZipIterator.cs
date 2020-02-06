using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class ZipIterator<TFirst, TSecond, TResult> : IAsyncEnumerator<TResult>
	{
		private readonly IAsyncEnumerator<TFirst> _enumeratorOne;
		private readonly IAsyncEnumerator<TSecond> _enumeratorTwo;
		private readonly Func<TFirst, TSecond, TResult> _resultSelector;

		private bool _complete;

		public TResult Current { get; private set; }

		public ZipIterator(IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		{
			_enumeratorOne = (first ?? throw new ArgumentNullException(nameof(first))).GetAsyncEnumerator();
			_enumeratorTwo = (second ?? throw new ArgumentNullException(nameof(second))).GetAsyncEnumerator();
			_resultSelector = resultSelector ?? throw new ArgumentNullException(nameof(resultSelector));
		}

		public async ValueTask DisposeAsync()
		{
			await _enumeratorOne.DisposeAsync();
			await _enumeratorTwo.DisposeAsync();
		}

		public async ValueTask<bool> MoveNextAsync()
		{
			if (_complete)
				return false;

			if (await _enumeratorOne.MoveNextAsync() && await _enumeratorTwo.MoveNextAsync())
			{
				Current = _resultSelector.Invoke(_enumeratorOne.Current, _enumeratorTwo.Current);
				return true;
			}
			else
				_complete = true;

			return false;
		}
	}
}
