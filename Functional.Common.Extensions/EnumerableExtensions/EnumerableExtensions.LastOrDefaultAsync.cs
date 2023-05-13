namespace Functional;

public static partial class EnumerableExtensions
{
	public static Task<TSource?> LastOrDefaultAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).LastOrDefault(default(TSource));

	public static Task<TSource> LastOrDefaultAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate, TSource defaultValue)
		=> source.WhereAsync(predicate).LastOrDefault(defaultValue);

	public static Task<TSource?> LastOrDefaultAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).LastOrDefault(default(TSource));

	public static Task<TSource> LastOrDefaultAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate, TSource defaultValue)
		=> source.WhereAsync(predicate).LastOrDefault(defaultValue);

	public static Task<TSource?> LastOrDefaultAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).LastOrDefault(default(TSource));

	public static Task<TSource> LastOrDefaultAsync<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate, TSource defaultValue)
		=> source.WhereAsync(predicate).LastOrDefault(defaultValue);

	public static Task<TSource?> LastOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		=> source.WhereAsync(predicate).LastOrDefault(default(TSource));

	public static Task<TSource> LastOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate, TSource defaultValue)
		=> source.WhereAsync(predicate).LastOrDefault(defaultValue);
}
