using System;
namespace Functional;

internal static class IteratorEnumerable
{
	public static IEnumerable<TSource> Create<TValue, TSource>(TValue value, Func<TValue, IEnumerator<TSource>> enumeratorFactory)
		=> new IteratorEnumerable<TValue, TSource>(value, enumeratorFactory);
}

internal class IteratorEnumerable<TValue, TSource> : IEnumerable<TSource>
{
	private readonly TValue _value;
	private readonly Func<TValue, IEnumerator<TSource>> _iteratorFactory;

	public IteratorEnumerable(TValue value, Func<TValue, IEnumerator<TSource>> iteratorFactory)
	{
		_value = value;
		_iteratorFactory = iteratorFactory;
	}

	public IEnumerator<TSource> GetEnumerator()
		=> _iteratorFactory.Invoke(_value);

	IEnumerator IEnumerable.GetEnumerator()
		=> GetEnumerator();
}
