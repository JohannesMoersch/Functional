using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional;

public static partial class EnumerableTypeExtensions
{
	public static IAsyncEnumerable<TSource> AsAsyncEnumerable<TSource>(this IEnumerable<TSource> source)
		=> AsyncEnumerable.Create(source);

	public static IAsyncEnumerable<TSource> AsAsyncEnumerable<TSource>(this Task<IEnumerable<TSource>> source)
		=> AsyncEnumerable.Create(source);

	public static IAsyncEnumerable<TSource> AsAsyncEnumerable<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> AsyncEnumerable.Create(source);

	public static IAsyncEnumerable<TSource> AsAsyncEnumerable<TSource>(this Task<TSource[]> source)
		=> AsyncEnumerable.Create(source);

	public static IAsyncEnumerable<TSource> AsAsyncEnumerable<TSource>(this IEnumerable<Task<TSource>> source)
		=> AsyncEnumerable.Create(source);

	public static IAsyncEnumerable<TSource> AsAsyncEnumerable<TSource>(this Task<IAsyncEnumerable<TSource>> source)
		=> AsyncEnumerable.Create(source);
}
