namespace Functional;

public static partial class EnumerableExtensions
{
	public static Task<TSource?> FirstOrDefaultAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).FirstOrDefault();

	public static Task<TSource?> FirstOrDefaultAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).FirstOrDefault();

	public static Task<TSource?> FirstOrDefaultAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).FirstOrDefault();

	public static Task<TSource?> FirstOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).FirstOrDefault();
}
