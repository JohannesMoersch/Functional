using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static async Task<IEnumerable<TResult>> OfType<TResult>(this Task<IEnumerable> source)
		=> (await source).OfType<TResult>();

	public static async Task<IEnumerable<TResult>> OfType<TSource, TResult>(this Task<IEnumerable<TSource>> source)
		=> (await source).OfType<TResult>();

	public static IAsyncEnumerable<TResult> OfType<TResult>(this IAsyncEnumerable<object> source)
		=> AsyncIteratorEnumerable.Create(source, static (o, t) => BasicAsyncIterator.Create(o, false, static (s, _, _) => s is TResult result ? (BasicIteratorContinuationType.Take, result) : (BasicIteratorContinuationType.Skip, default), t));
}
