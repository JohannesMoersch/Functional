using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class AppendIterator<TSource> : IAsyncEnumerator<TSource>
	{
		private readonly IAsyncEnumerator<TSource> _enumerator;
		private readonly TSource _element;

		private int _state = 0;

		public TSource Current { get; private set; }

		public AppendIterator(IAsyncEnumerable<TSource> source, TSource element)
		{
			_enumerator = (source ?? throw new ArgumentNullException(nameof(source))).GetEnumerator();
			_element = element;
		}

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

				Current = _element;
				return true;
			}

			return false;
		}
	}
}
