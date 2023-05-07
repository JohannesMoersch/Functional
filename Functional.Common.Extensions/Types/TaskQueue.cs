using System.Threading.Tasks;

namespace Functional.Types;

internal class TaskQueue<T> : IAsyncDisposable
{
	private Queue<Task<T>>? _tasks;

	public int Count => _tasks?.Count ?? 0;

	public TaskQueue(int capacity) 
		=> _tasks = new Queue<Task<T>>(capacity);

	public async ValueTask DisposeAsync()
	{
		var exceptions = await DrainQueue().ToArray();

		if (exceptions.Any())
			throw new AggregateException($"One or more tasks threw an exception.", exceptions);
	}

	public void Enqueue(Task<T> task)
	{
		if (task is null) throw new ArgumentNullException(nameof(task));
		
		if (_tasks is Queue<Task<T>> queue)
			queue.Enqueue(task);
		else
			throw new ObjectDisposedException("TaskQueue");
	}

	public Task<T> Dequeue()
	{
		if (_tasks is Queue<Task<T>> queue)
			return queue.Dequeue();
		else
			throw new ObjectDisposedException("TaskQueue");
	}

	public async IAsyncEnumerable<Exception> DrainQueue()
	{
		if (Interlocked.Exchange(ref _tasks, null) is not Queue<Task<T>> tasks)
			yield break;

		while (tasks.Count > 0)
		{
			Exception? exception = null;

			try
			{
				await tasks.Dequeue();
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			if (exception is not null)
				yield return exception;
		}
	}
}
