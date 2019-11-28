using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class ConcurrentSelectIterator<TSource, TResult> : IAsyncEnumerator<TResult>
	{
		private readonly IAsyncEnumerator<TSource> _enumerator;
		private readonly Func<TSource, int, Task<TResult>> _selector;
		private int _maxConcurrency;

		private readonly Queue<Task<TResult>> _taskQueue = new Queue<Task<TResult>>();

		private int _count;

		public TResult Current { get; private set; }

		public ConcurrentSelectIterator(IAsyncEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector, int maxConcurrency)
		{
			_enumerator = (source ?? throw new ArgumentNullException(nameof(source))).GetAsyncEnumerator();
			_selector = selector ?? throw new ArgumentNullException(nameof(selector));
			_maxConcurrency = maxConcurrency;

			if (_maxConcurrency <= 0)
				throw new ArgumentOutOfRangeException(nameof(maxConcurrency), "Value must be greater than zero.");
		}

		public ValueTask DisposeAsync()
			=> _enumerator.DisposeAsync();

		public async ValueTask<bool> MoveNextAsync()
		{
			try
			{
				while (_taskQueue.Count < _maxConcurrency && await _enumerator.MoveNextAsync())
					_taskQueue.Enqueue(_selector.Invoke(_enumerator.Current, _count++));
			}
			catch (Exception ex)
			{
				throw new AggregateException(Enumerable.Repeat(ex, 1).Concat(await DrainTaskQueue(_taskQueue)));
			}

			if (_taskQueue.Count == 0)
			{
				_maxConcurrency = 0;
				Current = default;
				return false;
			}

			try
			{
				Current = await _taskQueue.Dequeue();
				return true;
			}
			catch (Exception ex)
			{
				throw new AggregateException(Enumerable.Repeat(ex, 1).Concat(await DrainTaskQueue(_taskQueue)));
			}
		}

		private async Task<IEnumerable<Exception>> DrainTaskQueue(Queue<Task<TResult>> taskQueue)
		{
			var exceptions = new List<Exception>();

			while (taskQueue.Count > 0)
			{
				try
				{
					await taskQueue.Dequeue();
				}
				catch (Exception ex)
				{
					exceptions.Add(ex);
				}
			}

			return exceptions;
		}
	}
}
