using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional
{
	internal class AsyncTaskEnumerator<T> : DisposableBase, IAsyncEnumerator<T>
	{
		private static readonly Task<bool> _trueResult = Task.FromResult(true);

		private static readonly Task<bool> _falseResult = Task.FromResult(false);

		private readonly Lazy<IEnumerator<Task<T>>> _enumerator;

		public T Current { get; private set; }

		internal AsyncTaskEnumerator(Lazy<IEnumerator<Task<T>>> enumerator)
			=> _enumerator = enumerator;

		public Task<bool> MoveNext()
		{
			IEnumerator<Task<T>> enumerator = _enumerator.Value;

			if (!enumerator.MoveNext())
			{
				return _falseResult;
			}

			return enumerator.Current.ContinueWith(t => { Current = t.Result; return true; }, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);
		}

		protected override void DisposeResources()
		{
		}
	}
}
