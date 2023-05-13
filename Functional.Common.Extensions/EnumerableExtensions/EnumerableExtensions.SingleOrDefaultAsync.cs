namespace Functional;

public static partial class EnumerableExtensions
{
	public static Task<TSource?> SingleOrDefaultAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).SingleOrDefault();

	public static Task<TSource?> SingleOrDefaultAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).SingleOrDefault();

	public static Task<TSource?> SingleOrDefaultAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).SingleOrDefault();

	public static Task<TSource?> SingleOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).SingleOrDefault();
}
