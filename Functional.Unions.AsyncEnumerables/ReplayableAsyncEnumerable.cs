using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Functional
{
	internal class ReplayableAsyncEnumerableData<T> : IAsyncDisposable
	{
		private readonly IAsyncEnumerator<T> _enumerator;

		private readonly List<T> _values = new List<T>();

		private bool _complete;

		public ReplayableAsyncEnumerableData(IAsyncEnumerator<T> enumerator)
			=> _enumerator = enumerator;

		public ValueTask DisposeAsync()
			=> _enumerator.DisposeAsync();

		public async Task<(bool hasValue, T value)> TryGetValue(int index)
		{
			if (index < _values.Count)
				return (true, _values[index]);

			if (!_complete)
			{
				if (await _enumerator.MoveNextAsync())
				{
					_values.Add(_enumerator.Current);
					return (true, _enumerator.Current);
				}
				else
					_complete = true;
			}

#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
			return (false, default);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
		}
	}

	internal class ReplayableAsyncEnumerator<T> : IAsyncEnumerator<T>
	{
		public T Current { get; private set; }

		private readonly ReplayableAsyncEnumerableData<T> _data;

		private int _index = 0;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public ReplayableAsyncEnumerator(ReplayableAsyncEnumerableData<T> data)
			=> _data = data;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		public ValueTask DisposeAsync()
			=> _data.DisposeAsync();

#pragma warning disable CS8601 // Possible null reference assignment.
		public async ValueTask<bool> MoveNextAsync()
		{
			var value = await _data.TryGetValue(_index++);
			if (_index >= 0 && value.hasValue)
			{
				Current = value.value;
				return true;
			}

			Current = default;
			return false;
		}
#pragma warning restore CS8601 // Possible null reference assignment.

		public void Reset()
			=> _index = 0;
	}

	internal class ReplayableAsyncEnumerable<T> : IAsyncEnumerable<T>
	{
		private readonly ReplayableAsyncEnumerableData<T> _data;

		public ReplayableAsyncEnumerable(IAsyncEnumerable<T> data)
			=> _data = new ReplayableAsyncEnumerableData<T>(data.GetAsyncEnumerator());

		public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
			=> new ReplayableAsyncEnumerator<T>(_data);
	}
}
