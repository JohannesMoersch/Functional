namespace Functional;

public static class AsyncEnumerable
{
	public static IAsyncEnumerable<T> Create<T>(IEnumerable<T> source)
		=> new EnumerableToAsyncEnumerable<T>(source);

	public static IAsyncEnumerable<T> Create<T>(Task<IEnumerable<T>> source)
		=> new TaskEnumerableToAsyncEnumerable<T>(source);

	public static IAsyncEnumerable<T> Create<T>(Task<IAsyncEnumerable<T>> source)
		=> new TaskAsyncEnumerableToAsyncEnumerable<T>(source);

	public static IAsyncEnumerable<T> Create<T>(Func<IEnumerable<T>> source)
		=> new FuncAsyncEnumerableToAsyncEnumerable<Func<IEnumerable<T>>, T>(source, o => new EnumerableToAsyncEnumerable<T>(o.Invoke()));

	public static IAsyncEnumerable<T> Create<T>(Func<Task<IEnumerable<T>>> source)
		=> new FuncAsyncEnumerableToAsyncEnumerable<Func<Task<IEnumerable<T>>>, T>(source, o => new TaskEnumerableToAsyncEnumerable<T>(o.Invoke()));

	public static IAsyncEnumerable<T> Create<T>(Func<Task<IAsyncEnumerable<T>>> source)
		=> new FuncAsyncEnumerableToAsyncEnumerable<Func<Task<IAsyncEnumerable<T>>>, T>(source, o => new TaskAsyncEnumerableToAsyncEnumerable<T>(o.Invoke()));

	public static IAsyncEnumerable<T> Repeat<T>(T element, int count)
		=> Create(Enumerable.Repeat(element, count));

	public static IAsyncEnumerable<T> Repeat<T>(Task<T> element, int count)
		=> Create(Enumerable.Repeat(element, count)).SelectAsync(_ => _);
}
