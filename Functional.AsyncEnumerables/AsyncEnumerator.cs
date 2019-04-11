using System.Collections.Generic;
using System.Threading.Tasks;

namespace Functional
{
	internal class AsyncEnumerator<T> : DisposableBase, IAsyncEnumerator<T>
	{
		private static readonly Task<bool> _trueResult = Task.FromResult(true);

		private static readonly Task<bool> _falseResult = Task.FromResult(false);

		private readonly AsyncLazy<IEnumerator<T>> _enumerator;

		public T Current => GetCurrentAsync().ConfigureAwait(false).GetAwaiter().GetResult();

		internal AsyncEnumerator(AsyncLazy<IEnumerator<T>> enumerator)
			=> _enumerator = enumerator;

		public async Task<bool> MoveNext()
		{
			var enumerator = await _enumerator.GetValueAsync().ConfigureAwait(false);
			return enumerator.MoveNext();
		}

		public async Task<T> GetCurrentAsync()
		{
			var enumerator = await _enumerator.GetValueAsync().ConfigureAwait(false);
			return enumerator.Current;
		}

		protected override void DisposeResources()
		{
		}
	}
}
