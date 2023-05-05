namespace Functional;

internal static class AsyncIteratorEnumerable
{
	public static IAsyncEnumerable<TSource> Create<TValue, TSource>(TValue value, Func<TValue, CancellationToken, IAsyncEnumerator<TSource>> enumeratorFactory)
		=> new AsyncIteratorEnumerable<TValue, TSource>(value, enumeratorFactory);
}

internal class AsyncIteratorEnumerable<TValue, TSource> : IAsyncEnumerable<TSource>
{
	private readonly TValue _value;
	private readonly Func<TValue, CancellationToken, IAsyncEnumerator<TSource>> _iteratorFactory;

	public AsyncIteratorEnumerable(TValue value, Func<TValue, CancellationToken, IAsyncEnumerator<TSource>> iteratorFactory)
	{
		_value = value;
		_iteratorFactory = iteratorFactory;
	}

	public IAsyncEnumerator<TSource> GetAsyncEnumerator(CancellationToken cancellationToken = default)
		=> _iteratorFactory.Invoke(_value, cancellationToken);
}
