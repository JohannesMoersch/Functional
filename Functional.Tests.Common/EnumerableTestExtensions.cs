namespace Functional.Tests;

public static class EnumerableTestExtensions
{
#pragma warning disable CS8600, CS8604 // Converting null literal or possible null value to non-nullable type. Possible null reference argument.
	public static IEnumerable<TestEnumerable<T>> ToTestEnumerableVariants<T>(this IEnumerable<T>? source, EnumerableType enumerableTypes)
	{
		IReadOnlyList<T> readOnlyList = source?.ToArray();
		IOrderedEnumerable<T> orderedEnumerable = source != null ? new OrderedEnumerable<T>(source) : null;

		return new TestEnumerable<T>[]
		{
			new TestEnumerable<T>(EnumerableType.IEnumerable, source, readOnlyList),
			new TestEnumerable<T>(EnumerableType.TaskOfIEnumerable, Task.FromResult(source), readOnlyList),
			new TestEnumerable<T>(EnumerableType.TaskOfIOrderedEnumerable, Task.FromResult(orderedEnumerable), readOnlyList),
			new TestEnumerable<T>(EnumerableType.IAsyncEnumerable, source != null ? AsyncEnumerable.Create(source) : null, readOnlyList)
		}
		.Where(enumerable => enumerableTypes.HasFlag(enumerable.Type));
	}
#pragma warning restore CS8600, CS8604 // Converting null literal or possible null value to non-nullable type. Possible null reference argument.

	private class OrderedEnumerable<T> : IOrderedEnumerable<T>
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
}
