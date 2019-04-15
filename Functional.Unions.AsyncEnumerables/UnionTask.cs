using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class UnionPartitionTask<T> : IUnionTask<T>
	{
		private readonly Task<T> _task;

		public UnionPartitionTask(Task<T> task)
			=> _task = task ?? throw new ArgumentNullException(nameof(task));

		public IUnionTaskAwaiter<T> GetAwaiter()
			=> new UnionPartitionTaskAwaiter<T>(_task.GetAwaiter());
	}
}
