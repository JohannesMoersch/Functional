namespace Functional;

public static partial class EnumerableExtensions
{
	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector, int maxConcurrency)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector, int maxConcurrency)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<TResult>> selector, int maxConcurrency)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<TResult>> selector, int maxConcurrency)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, Task<TResult>> selector, int maxConcurrency)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, Task<TResult>> selector)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, Task<TResult>> selector, int maxConcurrency)
		=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
		=> source.ConcurrentSelectAsync(selector, Int32.MaxValue);

	public static async IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TResult>> selector, int maxConcurrency)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		await using var enumerator = source.GetAsyncEnumerator();
		await using var taskQueue = new TaskQueue<TResult>(maxConcurrency <= 16 ? maxConcurrency : 16);

		var ongoing = true;

		do
		{
			try
			{
				while (ongoing && taskQueue.Count < maxConcurrency && (ongoing = await enumerator.MoveNextAsync()))
					taskQueue.Enqueue(selector.Invoke(enumerator.Current));
			}
			catch (Exception ex)
			{
				throw new AggregateException(new[] { ex }.Concat(await taskQueue.DrainQueue().AsEnumerable()));
			}

			TResult result;
			try
			{
				result = await taskQueue.Dequeue();
			}
			catch (Exception ex)
			{
				throw new AggregateException(new[] { ex }.Concat(await taskQueue.DrainQueue().AsEnumerable()));
			}
			yield return result;
		}
		while (taskQueue.Count > 0);
	}

	public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector)
		=> source.ConcurrentSelectAsync(selector, Int32.MaxValue);

	public static async IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector, int maxConcurrency)
	{
		if (selector is null) throw new ArgumentNullException(nameof(selector));

		await using var enumerator = source.GetAsyncEnumerator();
		await using var taskQueue = new TaskQueue<TResult>(maxConcurrency);

		var count = 0;
		var ongoing = true;

		do
		{
			try
			{
				while (ongoing && taskQueue.Count < maxConcurrency && (ongoing = await enumerator.MoveNextAsync()))
					taskQueue.Enqueue(selector.Invoke(enumerator.Current, count++));
			}
			catch (Exception ex)
			{
				throw new AggregateException(new[] { ex }.Concat(await taskQueue.DrainQueue().AsEnumerable()));
			}

			TResult result;
			try
			{
				result = await taskQueue.Dequeue();
			}
			catch (Exception ex)
			{
				throw new AggregateException(new[] { ex }.Concat(await taskQueue.DrainQueue().AsEnumerable()));
			}
			yield return result;
		}
		while (taskQueue.Count > 0);
	}
}
