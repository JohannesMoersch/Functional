using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class DefaultIfEmptyAsyncIterator<TSource> : IAsyncEnumerator<TSource>
	{
		private readonly IAsyncEnumerator<TSource> _enumerator;
		private readonly TSource _defaultValue;

		private int _state;

		public TSource Current { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public DefaultIfEmptyAsyncIterator(IAsyncEnumerable<TSource> source, TSource defaultValue)
		{
			_enumerator = (source ?? throw new ArgumentNullException(nameof(source))).GetAsyncEnumerator();
			_defaultValue = defaultValue;
		}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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
