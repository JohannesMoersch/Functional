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