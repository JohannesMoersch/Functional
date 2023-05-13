namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<bool> Contains<TSource>(this Task<IEnumerable<TSource>> source, TSource value)
		=> (await source).Contains(value);

	public static async Task<bool> Contains<TSource>(this Task<IEnumerable<TSource>> source, TSource value, IEqualityComparer<TSource>? comparer)
		=> (await source).Contains(value, comparer);

	public static async Task<bool> Contains<TSource>(this Task<IOrderedEnumerable<TSource>> source, TSource value)
		=> (await source).Contains(value);

	public static async Task<bool> Contains<TSource>(this Task<IOrderedEnumerable<TSource>> source, TSource value, IEqualityComparer<TSource>? comparer)
		=> (await source).Contains(value, comparer);

	public static Task<bool> Contains<TSource>(this IAsyncEnumerable<TSource> source, TSource value)
		=> source.Contains(value, EqualityComparer<TSource>.Default);

	public static async Task<bool> Contains<TSource>(this IAsyncEnumerable<TSource> source, TSource value, IEqualityComparer<TSource>? comparer)
	{
		if (comparer != null)
		{
			await foreach (var item in source)
			{
				if (comparer.Equals(item, value))
					return true;
			}
		}
		else
		{
			await foreach (var item in source)
			{
				if (EqualityComparer<TSource>.Default.Equals(item, value))
					return true;
			}
		}

		return false;
	}
}
