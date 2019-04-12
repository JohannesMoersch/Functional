using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Functional
{
	internal class UnionPartitionTaskAwaiter<T> : IUnionTaskAwaiter<T>
	{
		private readonly TaskAwaiter<T> _task;

		public bool IsCompleted => _task.IsCompleted;

		public UnionPartitionTaskAwaiter(TaskAwaiter<T> task)
			=> _task = task;

		public T GetResult()
			=> _task.GetResult();

		public void OnCompleted(Action continuation)
			=> _task.OnCompleted(continuation);
	}
}
