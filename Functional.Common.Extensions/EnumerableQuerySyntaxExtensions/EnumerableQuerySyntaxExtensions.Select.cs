namespace Functional;

public static partial class EnumerableQuerySyntaxExtensions
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
		=> source.SelectAsync(selector);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<TResult>> selector)
		=> source.SelectAsync(selector);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
		=> source.SelectAsync(selector);
}
