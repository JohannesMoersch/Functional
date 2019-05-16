using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Functional
{
	internal class AsyncEnumerable<T> : IAsyncEnumerable<T>
	{
		private readonly Lazy<Task<IEnumerable<T>>> _source;

		public AsyncEnumerable(Func<Task<IEnumerable<T>>> source)
			=> _source = new Lazy<Task<IEnumerable<T>>>(source, LazyThreadSafetyMode.ExecutionAndPublication);

		public IAsyncEnumerator<T> GetEnumerator()
			=> new AsyncEnumerator<T>(new Lazy<Task<IEnumerator<T>>>(() => _source.Value.ContinueWith(t => t.Result.GetEnumerator(), TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously), LazyThreadSafetyMode.PublicationOnly));
	}

	public static class AsyncEnumerable
	{
		public static IAsyncEnumerable<T> Create<T>(IEnumerable<T> source)
			=> new AsyncEnumerable<T>(() => Task.FromResult(source));

		public static IAsyncEnumerable<T> Create<T>(Task<IEnumerable<T>> source)
			=> new AsyncEnumerable<T>(() => source);

		public static IAsyncEnumerable<T> Create<T>(Task<T[]> source)
			=> new AsyncEnumerable<T>(async () => (await source).AsEnumerable());

		public static IAsyncEnumerable<T> Create<T>(IEnumerable<Task<T>> source)
			=> new AsyncTaskEnumerable<T>(() => source);

		public static IAsyncEnumerable<T> Create<T>(Task<IAsyncEnumerable<T>> source)
			=> new AsyncTaskAsyncEnumerable<T>(source);

		public static IAsyncEnumerable<T> Create<T>(Func<IEnumerable<Task<T>>> source)
			=> new AsyncTaskEnumerable<T>(source);

		public static IAsyncEnumerable<T> Create<T>(Func<Task<IEnumerable<T>>> source)
			=> new AsyncEnumerable<T>(source);

		public static IAsyncEnumerable<T> Repeat<T>(T element, int count)
			=> Create(Enumerable.Repeat(element, count));

		public static IAsyncEnumerable<T> Repeat<T>(Task<T> element, int count)
			=> Create(Enumerable.Repeat(element, count));
	}
}
