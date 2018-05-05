using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public interface IUnionTask<out T>
	{
		IUnionTaskAwaiter<T> GetAwaiter();
	}

	internal class UnionTask<T> : IUnionTask<T>
	{
		private readonly Task<T> _task;

		public UnionTask(Task<T> task)
			=> _task = task ?? throw new ArgumentNullException(nameof(task));

		public IUnionTaskAwaiter<T> GetAwaiter()
			=> new UnionTaskAwaiter<T>(_task.GetAwaiter());
	}
}
