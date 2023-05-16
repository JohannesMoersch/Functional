namespace Functional;

public static partial class EnumerableExtensions
{
	public static async Task<IEnumerable<(TFirst First, TSecond Second)>> Zip<TFirst, TSecond>(this IEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second)
		=> first.Zip(await second);
	
	public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> first.Zip(await second, resultSelector);

	public static async Task<IEnumerable<(TFirst First, TSecond Second)>> Zip<TFirst, TSecond>(this IEnumerable<TFirst> first, Task<IOrderedEnumerable<TSecond>> second)
		=> first.Zip(await second);

	public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, Task<IOrderedEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> first.Zip(await second, resultSelector);

	public static async IAsyncEnumerable<(TFirst First, TSecond Second)> Zip<TFirst, TSecond>(this IEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second)
	{
		using var e1 = first.GetEnumerator();
		await using var e2 = second.GetAsyncEnumerator();

		while (e1.MoveNext() && await e2.MoveNextAsync())
			yield return (e1.Current, e2.Current);
	}

	public static async IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
	{
		if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

		using var e1 = first.GetEnumerator();
		await using var e2 = second.GetAsyncEnumerator();

		while (e1.MoveNext() && await e2.MoveNextAsync())
			yield return resultSelector.Invoke(e1.Current, e2.Current);
	}

	public static async Task<IEnumerable<(TFirst First, TSecond Second)>> Zip<TFirst, TSecond>(this Task<IEnumerable<TFirst>> first, IEnumerable<TSecond> second)
		=> (await first).Zip(second);

	public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> (await first).Zip(second, resultSelector);

	public static async Task<IEnumerable<(TFirst First, TSecond Second)>> Zip<TFirst, TSecond>(this Task<IEnumerable<TFirst>> first, Task<IEnumerable<TSecond>> second)
		=> (await first).Zip(await second);

	public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> (await first).Zip(await second, resultSelector);

	public static Task<IEnumerable<(TFirst First, TSecond Second)>> Zip<TFirst, TSecond>(this Task<IEnumerable<TFirst>> first, Task<IOrderedEnumerable<TSecond>> second)
		=> first.Zip(second.AsEnumerable());

	public static Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, Task<IOrderedEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> first.Zip(second.AsEnumerable(), resultSelector);

	public static async IAsyncEnumerable<(TFirst First, TSecond Second)> Zip<TFirst, TSecond>(this Task<IEnumerable<TFirst>> first, IAsyncEnumerable<TSecond> second)
	{
		using var e1 = (await first).GetEnumerator();
		await using var e2 = second.GetAsyncEnumerator();

		while (e1.MoveNext() && await e2.MoveNextAsync())
			yield return (e1.Current, e2.Current);
	}

	public static async IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
	{
		if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

		using var e1 = (await first).GetEnumerator();
		await using var e2 = second.GetAsyncEnumerator();

		while (e1.MoveNext() && await e2.MoveNextAsync())
			yield return resultSelector.Invoke(e1.Current, e2.Current);
	}

	public static Task<IEnumerable<(TFirst First, TSecond Second)>> Zip<TFirst, TSecond>(this Task<IOrderedEnumerable<TFirst>> first, IEnumerable<TSecond> second)
		=> first.AsEnumerable().Zip(second);

	public static Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IOrderedEnumerable<TFirst>> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> first.AsEnumerable().Zip(second, resultSelector);

	public static Task<IEnumerable<(TFirst First, TSecond Second)>> Zip<TFirst, TSecond>(this Task<IOrderedEnumerable<TFirst>> first, Task<IEnumerable<TSecond>> second)
		=> first.AsEnumerable().Zip(second);

	public static Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IOrderedEnumerable<TFirst>> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> first.AsEnumerable().Zip(second, resultSelector);

	public static Task<IEnumerable<(TFirst First, TSecond Second)>> Zip<TFirst, TSecond>(this Task<IOrderedEnumerable<TFirst>> first, Task<IOrderedEnumerable<TSecond>> second)
		=> first.AsEnumerable().Zip(second);

	public static Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IOrderedEnumerable<TFirst>> first, Task<IOrderedEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> first.AsEnumerable().Zip(second, resultSelector);

	public static IAsyncEnumerable<(TFirst First, TSecond Second)> Zip<TFirst, TSecond>(this Task<IOrderedEnumerable<TFirst>> first, IAsyncEnumerable<TSecond> second)
		=> first.AsEnumerable().Zip(second);

	public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this Task<IOrderedEnumerable<TFirst>> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> first.AsEnumerable().Zip(second, resultSelector);

	public static async IAsyncEnumerable<(TFirst First, TSecond Second)> Zip<TFirst, TSecond>(this IAsyncEnumerable<TFirst> first, IEnumerable<TSecond> second)
	{
		await using var e1 = first.GetAsyncEnumerator();
		using var e2 = second.GetEnumerator();

		while (await e1.MoveNextAsync() && e2.MoveNext())
			yield return (e1.Current, e2.Current);
	}

	public static async IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
	{
		await using var e1 = first.GetAsyncEnumerator();
		using var e2 = second.GetEnumerator();

		while (await e1.MoveNextAsync() && e2.MoveNext())
			yield return resultSelector.Invoke(e1.Current, e2.Current);
	}

	public static async IAsyncEnumerable<(TFirst First, TSecond Second)> Zip<TFirst, TSecond>(this IAsyncEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second)
	{
		await using var e1 = first.GetAsyncEnumerator();
		using var e2 = (await second).GetEnumerator();

		while (await e1.MoveNextAsync() && e2.MoveNext())
			yield return (e1.Current, e2.Current);
	}

	public static async IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
	{
		await using var e1 = first.GetAsyncEnumerator();
		using var e2 = (await second).GetEnumerator();

		while (await e1.MoveNextAsync() && e2.MoveNext())
			yield return resultSelector.Invoke(e1.Current, e2.Current);
	}

	public static IAsyncEnumerable<(TFirst First, TSecond Second)> Zip<TFirst, TSecond>(this IAsyncEnumerable<TFirst> first, Task<IOrderedEnumerable<TSecond>> second)
		=> first.Zip(second.AsEnumerable());

	public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, Task<IOrderedEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
		=> first.Zip(second.AsEnumerable(), resultSelector);

	public static async IAsyncEnumerable<(TFirst First, TSecond Second)> Zip<TFirst, TSecond>(this IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second)
	{
		await using var e1 = first.GetAsyncEnumerator();
		await using var e2 = second.GetAsyncEnumerator();

		while (await e1.MoveNextAsync() && await e2.MoveNextAsync())
			yield return (e1.Current, e2.Current);
	}

	public static async IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
	{
		await using var e1 = first.GetAsyncEnumerator();
		await using var e2 = second.GetAsyncEnumerator();

		while (await e1.MoveNextAsync() && await e2.MoveNextAsync())
			yield return resultSelector.Invoke(e1.Current, e2.Current);
	}
}
