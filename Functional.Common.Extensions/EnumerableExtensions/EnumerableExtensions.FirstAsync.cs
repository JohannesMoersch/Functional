namespace Functional;

public static partial class EnumerableExtensions
{
	public static Task<TSource> FirstAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).First();

	public static Task<TSource> FirstAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).First();

	public static Task<TSource> FirstAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).First();

	public static Task<TSource> FirstAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).First();
}
