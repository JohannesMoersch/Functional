namespace Functional.Tests;

public static class OrderedEnumerable
{
	public static IOrderedEnumerable<T> Create<T>(this IEnumerable<T> enumerable)
		=> new OrderedEnumerable<T>(enumerable);
}

public class OrderedEnumerable<T> : IOrderedEnumerable<T>
{
	private readonly IEnumerable<T> _source;

	public OrderedEnumerable(IEnumerable<T> source)
		=> _source = source;

	public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey>(Func<T, TKey> keySelector, IComparer<TKey>? comparer, bool descending)
		=> descending
			? _source.OrderByDescending(keySelector, comparer)
			: _source.OrderBy(keySelector, comparer);

	public IEnumerator<T> GetEnumerator()
		=> _source.GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
		=> _source.GetEnumerator();
}