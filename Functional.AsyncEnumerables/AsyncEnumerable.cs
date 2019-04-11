using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Functional
{
	internal class AsyncEnumerable<T> : DisposableBase, IAsyncEnumerable<T>
	{
		private readonly AsyncLazy<IEnumerable<T>> _source;

		public AsyncEnumerable(Func<Task<IEnumerable<T>>> source)
			=> _source = new AsyncLazy<IEnumerable<T>>(source);

		public IAsyncEnumerator<T> GetEnumerator()
			=> new AsyncEnumerator<T>(new AsyncLazy<IEnumerator<T>>(async () =>
			{
				IEnumerable<T> enumerable = await _source.GetValueAsync().ConfigureAwait(false);
				return enumerable.GetEnumerator();
			}));

		protected override void DisposeResources()
		{
			_source?.Dispose();
		}
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
