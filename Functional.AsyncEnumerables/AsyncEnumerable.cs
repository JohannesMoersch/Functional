using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Functional
{
	internal class AsyncEnumerable<T> : IAsyncEnumerable<T>
	{
		private readonly Lazy<Task<IEnumerator<T>>> _source;

		public AsyncEnumerable(Func<Task<IEnumerable<T>>> source)
			=> _source = new Lazy<Task<IEnumerator<T>>>(() => source.Invoke().ContinueWith(t => t.Result.GetEnumerator(), TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously), LazyThreadSafetyMode.ExecutionAndPublication);

		public IAsyncEnumerator<T> GetEnumerator()
			=> new AsyncEnumerator<T>(_source);
	}

	public static class AsyncEnumerable
	{
		public static IAsyncEnumerable<T> Create<T>(IEnumerable<T> source)
			=> new AsyncEnumerable<T>(() => Task.FromResult(source));

		public static IAsyncEnumerable<T> Create<T>(Task<IEnumerable<T>> source)
			=> new AsyncEnumerable<T>(() => source);

		public static IAsyncEnumerable<T> Create<T>(Func<Task<IEnumerable<T>>> source)
			=> new AsyncEnumerable<T>(source);
	}
}
