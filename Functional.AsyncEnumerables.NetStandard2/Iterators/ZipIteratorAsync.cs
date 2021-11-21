using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class ZipIteratorAsync<TFirst, TSecond, TResult> : IAsyncEnumerator<TResult>
	{
		private readonly IAsyncEnumerator<TFirst> _enumeratorOne;
		private readonly IAsyncEnumerator<TSecond> _enumeratorTwo;
		private readonly Func<TFirst, TSecond, Task<TResult>> _resultSelector;

		private bool _complete;

		public TResult Current { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public ZipIteratorAsync(IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
		{
			_enumeratorOne = (first ?? throw new ArgumentNullException(nameof(first))).GetEnumerator();
			_enumeratorTwo = (second ?? throw new ArgumentNullException(nameof(second))).GetEnumerator();
			_resultSelector = resultSelector ?? throw new ArgumentNullException(nameof(resultSelector));
		}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		public async Task<bool> MoveNext()
		{
			if (_complete)
				return false;

			if (await _enumeratorOne.MoveNext() && await _enumeratorTwo.MoveNext())
			{
				Current = await _resultSelector.Invoke(_enumeratorOne.Current, _enumeratorTwo.Current);
				return true;
			}
			else
				_complete = true;

			return false;
		}
	}
}
