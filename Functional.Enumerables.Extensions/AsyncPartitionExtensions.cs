using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class AsyncPartitionExtensions
	{
		private class ReplayableAsyncEnumerableData<T>
		{
			private readonly IAsyncEnumerator<T> _enumerator;

			private readonly List<T> _values = new List<T>();

			private bool _complete;

			public ReplayableAsyncEnumerableData(IAsyncEnumerator<T> enumerator)
				=> _enumerator = enumerator;

			public async Task<(bool hasValue, T value)> TryGetValue(int index)
			{
				if (index < _values.Count)
					return (true, _values[index]);

				if (!_complete)
				{
					if (await _enumerator.MoveNext())
					{
						_values.Add(_enumerator.Current);
						return (true, _enumerator.Current);
					}
					else
						_complete = true;
				}

				return (false, default);
			}
		}

		private class ReplayableAsyncEnumerator<T> : IAsyncEnumerator<T>
		{
			public T Current { get; private set; }
			
			private readonly ReplayableAsyncEnumerableData<T> _data;

			private int _index = 0;

			public ReplayableAsyncEnumerator(ReplayableAsyncEnumerableData<T> data)
				=> _data = data;

			public void Dispose() { }

			public async Task<bool> MoveNext()
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

			public void Reset()
				=> _index = 0;
		}

		private class ReplayableAsyncEnumerable<T> : IAsyncEnumerable<T>
		{
			private readonly ReplayableAsyncEnumerableData<T> _data;

			public ReplayableAsyncEnumerable(IAsyncEnumerable<T> data)
				=> _data = new ReplayableAsyncEnumerableData<T>(data.GetEnumerator());

			public IAsyncEnumerator<T> GetEnumerator()
				=> new ReplayableAsyncEnumerator<T>(_data);
		}
		
		public static AsyncPartition<T> Partition<T>(this Task<IEnumerable<T>> source, Func<T, bool> predicate)
		{
			var values = new ReplayableAsyncEnumerable<(bool matches, T value)>(source.AsAsyncEnumerable().Select(value => (predicate.Invoke(value), value)));

			return new AsyncPartition<T>
			(
				values.Where(set => set.matches).Select(set => set.value),
				values.Where(set => !set.matches).Select(set => set.value)
			);
		}

		public static AsyncPartition<T> Partition<T>(this IAsyncEnumerable<T> source, Func<T, bool> predicate)
		{
			var values = new ReplayableAsyncEnumerable<(bool matches, T value)>(source.Select(value => (predicate.Invoke(value), value)));

			return new AsyncPartition<T>
			(
				values.Where(set => set.matches).Select(set => set.value),
				values.Where(set => !set.matches).Select(set => set.value)
			);
		}

		public static AsyncPartition<T> PartitionAsync<T>(this IEnumerable<T> source, Func<T, Task<bool>> predicate)
		{
			var values = new ReplayableAsyncEnumerable<(bool matches, T value)>(source.SelectAsync(async value => (await predicate.Invoke(value), value)));

			return new AsyncPartition<T>
			(
				values.Where(set => set.matches).Select(set => set.value),
				values.Where(set => !set.matches).Select(set => set.value)
			);
		}

		public static AsyncPartition<T> PartitionAsync<T>(this Task<IEnumerable<T>> source, Func<T, Task<bool>> predicate)
		{
			var values = new ReplayableAsyncEnumerable<(bool matches, T value)>(source.SelectAsync(async value => (await predicate.Invoke(value), value)));

			return new AsyncPartition<T>
			(
				values.Where(set => set.matches).Select(set => set.value),
				values.Where(set => !set.matches).Select(set => set.value)
			);
		}

		public static AsyncPartition<T> PartitionAsync<T>(this IAsyncEnumerable<T> source, Func<T, Task<bool>> predicate)
		{
			var values = new ReplayableAsyncEnumerable<(bool matches, T value)>(source.SelectAsync(async value => (await predicate.Invoke(value), value)));

			return new AsyncPartition<T>
			(
				values.Where(set => set.matches).Select(set => set.value),
				values.Where(set => !set.matches).Select(set => set.value)
			);
		}
	}
}
