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
		public static AsyncPartition<T> Partition<T>(this IAsyncEnumerable<T> source, Func<T, bool> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			var values = new ReplayableAsyncEnumerable<(bool matches, T value)>(source.Select(value => (predicate.Invoke(value), value)));

			return new AsyncPartition<T>
			(
				values.Where(set => set.matches).Select(set => set.value),
				values.Where(set => !set.matches).Select(set => set.value)
			);
		}

		public static AsyncPartition<T> PartitionAsync<T>(this IEnumerable<T> source, Func<T, Task<bool>> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			var values = new ReplayableAsyncEnumerable<(bool matches, T value)>(source.SelectAsync(async value => (await predicate.Invoke(value), value)));

			return new AsyncPartition<T>
			(
				values.Where(set => set.matches).Select(set => set.value),
				values.Where(set => !set.matches).Select(set => set.value)
			);
		}

		public static AsyncPartition<T> PartitionAsync<T>(this Task<IEnumerable<T>> source, Func<T, Task<bool>> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			var values = new ReplayableAsyncEnumerable<(bool matches, T value)>(source.SelectAsync(async value => (await predicate.Invoke(value), value)));

			return new AsyncPartition<T>
			(
				values.Where(set => set.matches).Select(set => set.value),
				values.Where(set => !set.matches).Select(set => set.value)
			);
		}

		public static AsyncPartition<T> PartitionAsync<T>(this IAsyncEnumerable<T> source, Func<T, Task<bool>> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			var values = new ReplayableAsyncEnumerable<(bool matches, T value)>(source.SelectAsync(async value => (await predicate.Invoke(value), value)));

			return new AsyncPartition<T>
			(
				values.Where(set => set.matches).Select(set => set.value),
				values.Where(set => !set.matches).Select(set => set.value)
			);
		}

		public static AsyncPartition<T> AsAsync<T>(this Task<Partition<T>> partition)
			=> new AsyncPartition<T>
			(
				GetMatches(partition).AsAsyncEnumerable(),
				GetNonMatches(partition).AsAsyncEnumerable()
			);

		private static async Task<IEnumerable<T>> GetMatches<T>(this Task<Partition<T>> source)
			=> (await source).Matches;

		private static async Task<IEnumerable<T>> GetNonMatches<T>(this Task<Partition<T>> source)
			=> (await source).NonMatches;
	}
}