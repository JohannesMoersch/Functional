using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TResult>> Cast<TResult>(this Task<IEnumerable> source)
		=> (await source).Cast<TResult>();

	public static async Task<IEnumerable<TResult>> Cast<TSource, TResult>(this Task<IEnumerable<TSource>> source)
		=> (await source).Cast<TResult>();

	public static async Task<IEnumerable<TResult>> Cast<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source)
		=> (await source).Cast<TResult>();

	public static IAsyncEnumerable<TResult> Cast<TResult>(this IAsyncEnumerable<object> source)
			=> AsyncIteratorEnumerable.Create(() => new BasicAsyncIterator<object, TResult>(source, data => (BasicIteratorContinuationType.Take, (TResult)data.current)));

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
	public static IAsyncEnumerable<TResult> Cast<TSource, TResult>(this IAsyncEnumerable<TSource> source)
		=> AsyncIteratorEnumerable.Create(() => new BasicAsyncIterator<TSource, TResult>(source, data => (BasicIteratorContinuationType.Take, (TResult)(object)data.current)));
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
}
