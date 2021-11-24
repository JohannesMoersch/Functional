using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class AsyncTaskEnumerator<T> : IAsyncEnumerator<T>
	{
		private static readonly Task<bool> _trueResult = Task.FromResult(true);

		private static readonly Task<bool> _falseResult = Task.FromResult(false);

		private readonly Lazy<IEnumerator<Task<T>>> _enumerator;

		public T Current { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		internal AsyncTaskEnumerator(Lazy<IEnumerator<Task<T>>> enumerator)
			=> _enumerator = enumerator;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		public Task<bool> MoveNext()
		{
			var enumerator = _enumerator.Value;

			if (!enumerator.MoveNext())
				return _falseResult;

			return enumerator.Current.ContinueWith(t => { Current = t.Result; return true; }, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);
		}
	}
}
