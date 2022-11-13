using System.Collections;
using System.Collections.Generic;

namespace Functional
{
	internal class ReplayableEnumerableData<T>
	{
		private readonly IEnumerator<T> _enumerator;

		private readonly List<T> _values = new List<T>();

		private bool _complete;

		public ReplayableEnumerableData(IEnumerator<T> enumerator)
			=> _enumerator = enumerator;

		public bool TryGetValue(int index, out T value)
		{
			if (index < _values.Count)
			{
				value = _values[index];
				return true;
			}

			if (!_complete)
			{
				if (_enumerator.MoveNext())
				{
					value = _enumerator.Current;
					_values.Add(value);
					return true;
				}
				else
					_complete = true;
			}

#pragma warning disable CS8601 // Possible null reference assignment.
			value = default;
#pragma warning restore CS8601 // Possible null reference assignment.
			return false;
		}
	}

	internal class ReplayableEnumerator<T> : IEnumerator<T>
	{
		public T Current { get; private set; }

#pragma warning disable CS8603 // Possible null reference return.
		object IEnumerator.Current => Current;
#pragma warning restore CS8603 // Possible null reference return.

		private readonly ReplayableEnumerableData<T> _data;

		private int _index = 0;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public ReplayableEnumerator(ReplayableEnumerableData<T> data)
			=> _data = data;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		public void Dispose() { }

		public bool MoveNext()
		{
			if (_index >= 0 && _data.TryGetValue(_index++, out var value))
			{
				Current = value;
				return true;
			}

#pragma warning disable CS8601 // Possible null reference assignment.
			Current = default;
#pragma warning restore CS8601 // Possible null reference assignment.
			return false;
		}

		public void Reset()
			=> _index = 0;
	}

	internal class ReplayableEnumerable<T> : IEnumerable<T>
	{
		private readonly ReplayableEnumerableData<T> _data;

		public ReplayableEnumerable(IEnumerable<T> data)
			=> _data = new ReplayableEnumerableData<T>(data.GetEnumerator());

		public IEnumerator<T> GetEnumerator()
			=> new ReplayableEnumerator<T>(_data);

		IEnumerator IEnumerable.GetEnumerator()
			=> new ReplayableEnumerator<T>(_data);
	}
}
