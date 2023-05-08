using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static Partition<T> Partition<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		if (predicate == null)
			throw new ArgumentNullException(nameof(predicate));

		var values = source.Select(value => (matches: predicate.Invoke(value), value)).Cached();

		return new Partition<T>
		(
			values.Where(set => set.matches).Select(set => set.value),
			values.Where(set => !set.matches).Select(set => set.value)
		);
	}

	public static async Task<Partition<T>> Partition<T>(this Task<IEnumerable<T>> source, Func<T, bool> predicate)
		=> (await source).Partition(predicate);

	public static async Task<Partition<T>> Partition<T>(this Task<IOrderedEnumerable<T>> source, Func<T, bool> predicate)
		=> (await source).Partition(predicate);

	public static AsyncPartition<T> Partition<T>(this IAsyncEnumerable<T> source, Func<T, bool> predicate)
	{
		if (predicate == null)
			throw new ArgumentNullException(nameof(predicate));

		var values = source.Select(value => (matches: predicate.Invoke(value), value)).Cached();

		return new AsyncPartition<T>
		(
			values.Where(set => set.matches).Select(set => set.value),
			values.Where(set => !set.matches).Select(set => set.value)
		);
	}
}
