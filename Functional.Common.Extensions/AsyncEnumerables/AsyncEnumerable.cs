namespace Functional;

public static class AsyncEnumerable
{
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
	public static async IAsyncEnumerable<T> Create<T>(IEnumerable<T> source)
	{
		foreach (var item in source)
			yield return item;
	}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

	public static async IAsyncEnumerable<T> Create<T>(Task<IEnumerable<T>> source)
	{
		foreach (var item in await source)
			yield return item;
	}

	public static async IAsyncEnumerable<T> Create<T>(Task<IOrderedEnumerable<T>> source)
	{
		foreach (var item in await source)
			yield return item;
	}

	public static async IAsyncEnumerable<T> Create<T>(Task<IAsyncEnumerable<T>> source)
	{
		await foreach (var item in await source)
			yield return item;
	}

	public static IAsyncEnumerable<T> Create<T>(Func<IEnumerable<T>> source)
		=> FuncAsyncEnumerableToAsyncEnumerable.Create(source, o => Create(o.Invoke()));

	public static IAsyncEnumerable<T> Create<T>(Func<Task<IEnumerable<T>>> source)
		=> FuncAsyncEnumerableToAsyncEnumerable.Create(source, o => Create(o.Invoke()));

	public static IAsyncEnumerable<T> Create<T>(Func<Task<IOrderedEnumerable<T>>> source)
		=> FuncAsyncEnumerableToAsyncEnumerable.Create(source, o => Create(o.Invoke()));

	public static IAsyncEnumerable<T> Create<T>(Func<IAsyncEnumerable<T>> source)
	=> FuncAsyncEnumerableToAsyncEnumerable.Create(source, o => o.Invoke());

	public static IAsyncEnumerable<T> Create<T>(Func<Task<IAsyncEnumerable<T>>> source)
		=> FuncAsyncEnumerableToAsyncEnumerable.Create(source, o => Create(o.Invoke()));

	public static IAsyncEnumerable<T> Repeat<T>(T element, int count)
		=> Create(Enumerable.Repeat(element, count));

	public static IAsyncEnumerable<T> Repeat<T>(Task<T> element, int count)
		=> Create(Enumerable.Repeat(element, count)).SelectAsync(_ => _);
}
