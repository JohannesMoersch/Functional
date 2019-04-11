using System;
using System.Threading.Tasks;

namespace Functional
{
	internal class ZipIteratorAsync<TFirst, TSecond, TResult> : DisposableBase, IAsyncEnumerator<TResult>
	{
		private readonly IAsyncEnumerator<TFirst> _enumeratorOne;
		private readonly IAsyncEnumerator<TSecond> _enumeratorTwo;
		private readonly Func<TFirst, TSecond, Task<TResult>> _resultSelector;

		private bool _complete;

		public TResult Current { get; private set; }

		public ZipIteratorAsync(IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
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
				Current = await _resultSelector.Invoke(_enumeratorOne.Current, _enumeratorTwo.Current);
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
