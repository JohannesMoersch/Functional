using System;
using System.Threading.Tasks;

namespace Functional
{
	internal class ZipIterator<TFirst, TSecond, TResult> : DisposableBase, IAsyncEnumerator<TResult>
	{
		private readonly IAsyncEnumerator<TFirst> _enumeratorOne;
		private readonly IAsyncEnumerator<TSecond> _enumeratorTwo;
		private readonly Func<TFirst, TSecond, TResult> _resultSelector;

		private bool _complete;

		public TResult Current { get; private set; }

		public ZipIterator(IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		{
			_enumeratorOne = (first ?? throw new ArgumentNullException(nameof(first))).GetEnumerator();
			_enumeratorTwo = (second ?? throw new ArgumentNullException(nameof(second))).GetEnumerator();
			_resultSelector = resultSelector ?? throw new ArgumentNullException(nameof(resultSelector));
		}

		public async Task<bool> MoveNext()
		{
			if (_complete)
			{
				return false;
			}

			if (await _enumeratorOne.MoveNext() && await _enumeratorTwo.MoveNext())
			{
				Current = _resultSelector.Invoke(_enumeratorOne.Current, _enumeratorTwo.Current);
				return true;
			}
			else
			{
				_complete = true;
			}

			return false;
		}

		protected override void DisposeResources()
		{
		}
	}
}
