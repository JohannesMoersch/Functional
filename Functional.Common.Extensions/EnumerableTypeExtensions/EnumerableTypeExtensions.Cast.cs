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

	public static IAsyncEnumerable<TResult> Cast<TResult>(this IAsyncEnumerable<object> source)
			=> AsyncIteratorEnumerable.Create(() => new BasicAsyncIterator<object, TResult>(source, data => (BasicIteratorContinuationType.Take, (TResult)data.current)));
}
