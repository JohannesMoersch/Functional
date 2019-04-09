using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class PartitionExtensions
	{
		private class ReplayableEnumerableData<T>
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

				value = default;
				return false;
			}
		}

		private class ReplayableEnumerator<T> : IEnumerator<T>
		{
			public T Current { get; private set; }

			object IEnumerator.Current => Current;

			private readonly ReplayableEnumerableData<T> _data;

			private int _index = 0;

			public ReplayableEnumerator(ReplayableEnumerableData<T> data)
				=> _data = data;

			public void Dispose() { }

			public bool MoveNext()
			{
				if (_index >= 0 && _data.TryGetValue(_index++, out var value))
				{
					Current = value;
					return true;
				}

				Current = default;
				return false;
			}

			public void Reset()
				=> _index = 0;
		}

		private class ReplayableEnumerable<T> : IEnumerable<T>
		{
			private readonly ReplayableEnumerableData<T> _data;

			public ReplayableEnumerable(IEnumerable<T> data)
				=> _data = new ReplayableEnumerableData<T>(data.GetEnumerator());

			public IEnumerator<T> GetEnumerator()
				=> new ReplayableEnumerator<T>(_data);

			IEnumerator IEnumerable.GetEnumerator()
				=> new ReplayableEnumerator<T>(_data);
		}

		public static Partition<T> Partition<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			var values = new ReplayableEnumerable<(bool matches, T value)>(source.Select(value => (predicate.Invoke(value), value)));

			return new Partition<T>
			(
				values.Where(set => set.matches).Select(set => set.value), 
				values.Where(set => !set.matches).Select(set => set.value)
			);
		}
	}
}
