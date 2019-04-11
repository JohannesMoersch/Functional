using System;
using System.Threading.Tasks;

namespace Functional
{
	internal class DefaultIfEmptyIterator<TSource> : DisposableBase, IAsyncEnumerator<TSource>
	{
		private readonly IAsyncEnumerator<TSource> _enumerator;
		private readonly TSource _defaultValue;

		private int _state;

		public TSource Current { get; private set; }

		public DefaultIfEmptyIterator(IAsyncEnumerable<TSource> source, TSource defaultValue)
		{
			_enumerator = (source ?? throw new ArgumentNullException(nameof(source))).GetEnumerator();
			_defaultValue = defaultValue;
		}

		public async Task<bool> MoveNext()
		{
			switch (_state)
			{
				case 0:
					if (await _enumerator.MoveNext())
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
					if (await _enumerator.MoveNext())
					{
						Current = _enumerator.Current;
						return true;
					}
					_state = 2;
					break;
			}
			return false;
		}

		protected override void DisposeResources()
		{
		}
	}
}
