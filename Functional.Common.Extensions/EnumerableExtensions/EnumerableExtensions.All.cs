namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<bool> All<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).All(predicate);

	public static async Task<bool> All<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
		=> (await source).All(predicate);

	public static async Task<bool> All<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		if (source == null)
			throw new ArgumentNullException(nameof(source));

		var enumerator = source.GetAsyncEnumerator();

		var value = true;

		while (value && await enumerator.MoveNextAsync())
			value = predicate.Invoke(enumerator.Current);

		return value;
	}
}
