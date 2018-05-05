using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Functional
{
	public interface IUnionTaskAwaiter<out T> : INotifyCompletion
	{
		bool IsCompleted { get; }

		T GetResult();
	}

	internal class UnionTaskAwaiter<T> : IUnionTaskAwaiter<T>
	{
		private readonly TaskAwaiter<T> _task;

		public bool IsCompleted => _task.IsCompleted;

		public UnionTaskAwaiter(TaskAwaiter<T> task)
			=> _task = task;

		public T GetResult()
			=> _task.GetResult();

		public void OnCompleted(Action continuation)
			=> _task.OnCompleted(continuation);
	}
}
