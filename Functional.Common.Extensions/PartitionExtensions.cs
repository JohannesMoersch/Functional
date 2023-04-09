using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class PartitionExtensions
	{
		public static Partition<T> Partition<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			var values = new ReplayableEnumerable<(bool matches, T value)>(source.Select(value => (predicate.Invoke(value), value)));

			return new Partition<T>
			(
				values.Where(set => set.matches).Select(set => set.value), 
				values.Where(set => !set.matches).Select(set => set.value)
			);
		}

		public static async Task<Partition<T>> Partition<T>(this Task<IEnumerable<T>> source, Func<T, bool> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			var values = new ReplayableEnumerable<(bool matches, T value)>((await source).Select(value => (predicate.Invoke(value), value)));

			return new Partition<T>
			(
				values.Where(set => set.matches).Select(set => set.value),
				values.Where(set => !set.matches).Select(set => set.value)
			);
		}
	}
}
