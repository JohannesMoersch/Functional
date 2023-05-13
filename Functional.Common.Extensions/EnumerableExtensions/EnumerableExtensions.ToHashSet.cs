namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<HashSet<TSource>> ToHashSet<TSource>(this Task<IEnumerable<TSource>> source)
		=> (await source).ToHashSet();

	public static async Task<HashSet<TSource>> ToHashSet<TSource>(this Task<IEnumerable<TSource>> source, IEqualityComparer<TSource>? comparer)
		=> (await source).ToHashSet(comparer);

	public static Task<HashSet<TSource>> ToHashSet<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> source.AsEnumerable().ToHashSet();

	public static Task<HashSet<TSource>> ToHashSet<TSource>(this Task<IOrderedEnumerable<TSource>> source, IEqualityComparer<TSource>? comparer)
		=> source.AsEnumerable().ToHashSet(comparer);

	public static Task<HashSet<TSource>> ToHashSet<TSource>(this IAsyncEnumerable<TSource> source)
		=> source.AsEnumerable().ToHashSet();

	public static Task<HashSet<TSource>> ToHashSet<TSource>(this IAsyncEnumerable<TSource> source, IEqualityComparer<TSource>? comparer)
		=> source.AsEnumerable().ToHashSet(comparer);

}
