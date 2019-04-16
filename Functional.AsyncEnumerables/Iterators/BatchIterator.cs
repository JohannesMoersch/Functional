using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class BatchIterator<T> : IAsyncEnumerator<IReadOnlyList<T>>
	{
		public IReadOnlyList<T> Current { get; private set; }

		private readonly IAsyncEnumerator<T> _enumerator;
		private readonly int _batchSize;

		private bool _ended;

		public BatchIterator(IAsyncEnumerator<T> enumerator, int batchSize)
		{
			_enumerator = enumerator ?? throw new ArgumentNullException(nameof(enumerator));
			_batchSize = batchSize;

			if (_batchSize <= 0)
				throw new ArgumentOutOfRangeException(nameof(batchSize), "Value must be greater than zero.");
		}

		public async Task<bool> MoveNext()
		{
			if (_ended)
				return false;

			var batch = new T[_batchSize];
			int count = 0;
			while (count < _batchSize && await _enumerator.MoveNext())
				batch[count++] = _enumerator.Current;

			if (count > 0)
			{
				if (count < _batchSize)
				{
					var temp = new T[count];
					Array.Copy(batch, temp, count);
					batch = temp;
				}

				Current = batch;
				return true;
			}

			_ended = true;
			Current = default;
			return false;
		}
	}
}
