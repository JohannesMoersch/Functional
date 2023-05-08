using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableExtensions
{
	private static async Task<IEnumerable<TSource>> GetMatches<TSource>(Task<Partition<TSource>> partition)
		=> (await partition).Matches;

	private static async Task<IEnumerable<TSource>> GetNonMatches<TSource>(Task<Partition<TSource>> partition)
		=> (await partition).NonMatches;

	public static IEnumerable<TSource> PickInto<TSource>(this IEnumerable<TSource> source, out IEnumerable<TSource> matches, Func<TSource, bool> predicate)
	{
		var partition = source.Partition(predicate);

		matches = partition.Matches;

		return partition.NonMatches;
	}

	public static Task<IEnumerable<TSource>> PickInto<TSource>(this Task<IEnumerable<TSource>> source, out Task<IEnumerable<TSource>> matches, Func<TSource, bool> predicate)
	{
		var partition = source.Partition(predicate);

		matches = GetMatches(partition);

		return GetNonMatches(partition);
	}

	public static IAsyncEnumerable<TSource> PickInto<TSource>(this IAsyncEnumerable<TSource> source, out IAsyncEnumerable<TSource> matches, Func<TSource, bool> predicate)
	{
		var partition = source.Partition(predicate);

		matches = partition.Matches;

		return partition.NonMatches;
	}
}
