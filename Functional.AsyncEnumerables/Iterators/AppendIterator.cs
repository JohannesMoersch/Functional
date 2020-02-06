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
			_enumerator = (source ?? throw new ArgumentNullException(nameof(source))).GetAsyncEnumerator();
			_element = element;
		}

		public ValueTask DisposeAsync()
			=> _enumerator.DisposeAsync();

		public async ValueTask<bool> MoveNextAsync()
		{
			if (_state == 0)
			{
				if (await _enumerator.MoveNextAsync())
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
