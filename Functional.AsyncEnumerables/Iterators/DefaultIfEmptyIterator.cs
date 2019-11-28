using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class DefaultIfEmptyIterator<TSource> : IAsyncEnumerator<TSource>
	{
		private readonly IAsyncEnumerator<TSource> _enumerator;
		private readonly TSource _defaultValue;

		private int _state;

		public TSource Current { get; private set; }

		public DefaultIfEmptyIterator(IAsyncEnumerable<TSource> source, TSource defaultValue)
		{
			_enumerator = (source ?? throw new ArgumentNullException(nameof(source))).GetAsyncEnumerator();
			_defaultValue = defaultValue;
		}

		public ValueTask DisposeAsync()
			=> _enumerator.DisposeAsync();

		public async ValueTask<bool> MoveNextAsync()
		{
			switch (_state)
			{
				case 0:
					if (await _enumerator.MoveNextAsync())
					{
						_state = 1;
						Current = _enumerator.Current;
					}
					else
					{
						_state = 2;
						Current = _defaultValue;
					}
					return true;
				case 1:
					if (await _enumerator.MoveNextAsync())
					{
						Current = _enumerator.Current;
						return true;
					}
					_state = 2;
					break;
			}
			return false;
		}
	}
}
