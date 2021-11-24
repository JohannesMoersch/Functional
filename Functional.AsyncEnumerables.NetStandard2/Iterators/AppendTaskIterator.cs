using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class AppendTaskIterator<TSource> : IAsyncEnumerator<TSource>
	{
		private readonly IAsyncEnumerator<TSource> _enumerator;
		private readonly Task<TSource> _element;

		private int _state = 0;

		public TSource Current { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public AppendTaskIterator(IAsyncEnumerable<TSource> source, Task<TSource> element)
		{
			_enumerator = (source ?? throw new ArgumentNullException(nameof(source))).GetEnumerator();
			_element = element;
		}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		public async Task<bool> MoveNext()
		{
			if (_state == 0)
			{
				if (await _enumerator.MoveNext())
				{
					Current = _enumerator.Current;
					return true;
				}
				else
					_state = 1;
			}

			if (_state == 1)
			{
				_state = 2;

				Current = await _element;
				return true;
			}

			return false;
		}
	}
}
