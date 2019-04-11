using System;
using System.Threading;
using System.Threading.Tasks;

namespace Functional
{
	internal class AsyncLazy<TValue> : DisposableBase
	{
		private readonly TaskCompletionSource<TValue> _tcs = new TaskCompletionSource<TValue>();

		private readonly Func<Task<TValue>> _taskFactory;

		private int _taskInitiated;

		public AsyncLazy(Func<Task<TValue>> taskFactory) => _taskFactory = taskFactory ?? throw new ArgumentNullException(nameof(taskFactory));

		public bool IsValueCreated => _tcs.Task.Status == TaskStatus.RanToCompletion;

		// For callers that want a task
		public async Task<TValue> GetValueAsync()
		{
			// Did someone else already kick off the task?
			if (Interlocked.CompareExchange(ref _taskInitiated, 1, 0) == 1)
			{
				return await _tcs.Task.ConfigureAwait(false);
			}

			// We're first, so we need to kick off the task
			try
			{
				Task<TValue> task = _taskFactory();
				TValue result = await task.ConfigureAwait(false);
				_tcs.SetResult(result);
				return result;
			}
			catch (OperationCanceledException)
			{
				_tcs.SetCanceled();
				throw;
			}
			catch (Exception exception)
			{
				_tcs.SetException(exception);
				throw;
			}
		}

		protected override void DisposeResources()
		{
			if (IsValueCreated)
			{
				if (GetValueAsync().ConfigureAwait(false).GetAwaiter().GetResult() is IDisposable disposable)
				{
					disposable?.Dispose();
				}
			}
		}
	}
}
