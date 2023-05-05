using System;

namespace Functional;

internal static class ConcurrentSelectAsyncIterator
{
	public static IAsyncEnumerator<TResult> Create<TSource, TResult, TContext>(IAsyncEnumerable<TSource> source, TContext context, Func<TSource, int, TContext, Task<TResult>> selector, int maxConcurrency, CancellationToken cancellationToken)
		=> new ConcurrentSelectAsyncIterator<TSource, TResult, TContext>(source, context, selector, maxConcurrency, cancellationToken);
}

internal class ConcurrentSelectAsyncIterator<TSource, TResult, TContext> : IAsyncEnumerator<TResult>
{
	private readonly IAsyncEnumerator<TSource> _enumerator;
	private readonly TContext _context;
	private readonly Func<TSource, int, TContext, Task<TResult>> _selector;
	private readonly CancellationToken _cancellationToken;

	private readonly Queue<Task<TResult>> _taskQueue = new Queue<Task<TResult>>();

	private int _maxConcurrency;
	private int _count;

	public TResult Current { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public ConcurrentSelectAsyncIterator(IAsyncEnumerable<TSource> source, TContext context, Func<TSource, int, TContext, Task<TResult>> selector, int maxConcurrency, CancellationToken cancellationToken)
	{
		_enumerator = (source ?? throw new ArgumentNullException(nameof(source))).GetAsyncEnumerator();
		_context = context;
		_selector = selector ?? throw new ArgumentNullException(nameof(selector));
		_maxConcurrency = maxConcurrency;
		_cancellationToken = cancellationToken;
		if (_maxConcurrency <= 0)
			throw new ArgumentOutOfRangeException(nameof(maxConcurrency), "Value must be greater than zero.");
	}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	public async ValueTask DisposeAsync()
	{
		var exceptions = await DrainTaskQueue(_taskQueue);

		try
		{
			await _enumerator.DisposeAsync();
		}
		catch (Exception ex)
		{
			throw new AggregateException(new[] { ex }.Concat(exceptions));
		}

		if (exceptions.Any())
			throw new AggregateException(exceptions);
	}

	public async ValueTask<bool> MoveNextAsync()
	{
		_cancellationToken.ThrowIfCancellationRequested();

		try
		{
			while (_taskQueue.Count < _maxConcurrency && await _enumerator.MoveNextAsync())
			{
				_cancellationToken.ThrowIfCancellationRequested();

				_taskQueue.Enqueue(_selector.Invoke(_enumerator.Current, _count++, _context));
			}
		}
		catch (Exception ex)
		{
			throw new AggregateException(new[] { ex }.Concat(await DrainTaskQueue(_taskQueue)));
		}

		if (_taskQueue.Count == 0)
		{
			_maxConcurrency = 0;
#pragma warning disable CS8601 // Possible null reference assignment.
			Current = default;
#pragma warning restore CS8601 // Possible null reference assignment.
			return false;
		}

		try
		{
			Current = await _taskQueue.Dequeue();

			_cancellationToken.ThrowIfCancellationRequested();

			return true;
		}
		catch (Exception ex)
		{
			throw new AggregateException(Enumerable.Repeat(ex, 1).Concat(await DrainTaskQueue(_taskQueue)));
		}
	}

	private async ValueTask<IEnumerable<Exception>> DrainTaskQueue(Queue<Task<TResult>> taskQueue)
	{
		List<Exception>? exceptions = null;

		while (taskQueue.Count > 0)
		{
			try
			{
				await taskQueue.Dequeue();
			}
			catch (Exception ex)
			{
				(exceptions ??= new List<Exception>()).Add(ex);
			}
		}

		return exceptions?.AsEnumerable() ?? Array.Empty<Exception>();
	}
}
