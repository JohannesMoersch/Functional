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

		private int _count;

		private Queue<TResult> _resultsQueue;

		public TResult Current { get; private set; }

		public ConcurrentSelectIterator(IAsyncEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector)
		{
			_enumerator = (source ?? throw new ArgumentNullException(nameof(source))).GetEnumerator();
			_selector = selector ?? throw new ArgumentNullException(nameof(selector));
		}

		public async Task<bool> MoveNext()
		{
			if (_resultsQueue == null)
			{
				var taskQueue = new Queue<Task<TResult>>();

				try
				{
					while (await _enumerator.MoveNext())
						taskQueue.Enqueue(_selector.Invoke(_enumerator.Current, _count++));
				}
				catch (Exception ex)
				{
					throw new AggregateException(Enumerable.Repeat(ex, 1).Concat(await DrainTaskQueue(taskQueue)));
				}

				_resultsQueue = new Queue<TResult>(taskQueue.Count);

				try
				{
					while (taskQueue.Count > 0)
						_resultsQueue.Enqueue(await taskQueue.Dequeue());
				}
				catch (Exception ex)
				{
					throw new AggregateException(Enumerable.Repeat(ex, 1).Concat(await DrainTaskQueue(taskQueue)));
				}
			}

			if (_resultsQueue.Count == 0)
				return false;

			Current = _resultsQueue.Dequeue();

			return true;
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
