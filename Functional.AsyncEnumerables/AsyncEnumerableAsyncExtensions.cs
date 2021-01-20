using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class AsyncEnumerableAsyncExtensions
	{
		public static async Task<bool> AllAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var enumerator = source.GetAsyncEnumerator();

			var value = true;

			while (value && await enumerator.MoveNextAsync())
				value = await predicate.Invoke(enumerator.Current);

			return value;
		}

		public static async Task<bool> AnyAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var enumerator = source.GetAsyncEnumerator();

			var value = false;

			while (!value && await enumerator.MoveNextAsync())
				value = await predicate.Invoke(enumerator.Current);

			return value;
		}

		public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
			=> source.ConcurrentSelectAsync(selector, Int32.MaxValue);

		public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TResult>> selector, int maxConcurrency)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new ConcurrentSelectIterator<TSource, TResult>(source, (o, _) => selector.Invoke(o), maxConcurrency));

		public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector)
			=> source.ConcurrentSelectAsync(selector, Int32.MaxValue);

		public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector, int maxConcurrency)
			=> AsyncIteratorEnumerable.Create(() => new ConcurrentSelectIterator<TSource, TResult>(source, selector, maxConcurrency));

		public static Task<TSource> FirstAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
			=> source.WhereAsync(predicate).First();

		public static Task<TSource> FirstOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
			=> source.WhereAsync(predicate).FirstOrDefault();
			
		public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new BasicIteratorAsync<TSource, TResult>(source, async data => (BasicIteratorContinuationType.Take, await selector.Invoke(data.current))));

		public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new BasicIteratorAsync<TSource, TResult>(source, async data => (BasicIteratorContinuationType.Take, await selector.Invoke(data.current, data.index))));

		public static Task<TSource> SingleAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
			=> source.WhereAsync(predicate).Single();

		public static Task<TSource> SingleOrDefaultAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
			=> source.WhereAsync(predicate).SingleOrDefault();

		public static IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			bool skip = true;
			return AsyncIteratorEnumerable.Create(() => new BasicIteratorAsync<TSource, TSource>(source, async data => (skip ? (skip = await predicate.Invoke(data.current)) : false) ? (BasicIteratorContinuationType.Skip, default) : (BasicIteratorContinuationType.Take, data.current)));
		}

		public static IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			bool skip = true;
			return AsyncIteratorEnumerable.Create(() => new BasicIteratorAsync<TSource, TSource>(source, async data => (skip ? (skip = await predicate.Invoke(data.current, data.index)) : false) ? (BasicIteratorContinuationType.Skip, default) : (BasicIteratorContinuationType.Take, data.current)));
		}
		
		public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
			=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
				: AsyncIteratorEnumerable.Create(() => new BasicIteratorAsync<TSource, TSource>(source, async data => await predicate.Invoke(data.current) ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Stop, default)));

		public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
			=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
				: AsyncIteratorEnumerable.Create(() => new BasicIteratorAsync<TSource, TSource>(source, async data => await predicate.Invoke(data.current, data.index) ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Stop, default)));
		
		public static IAsyncEnumerable<TSource> WhereAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
			=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
				: AsyncIteratorEnumerable.Create(() => new BasicIteratorAsync<TSource, TSource>(source, async data => await predicate.Invoke(data.current, data.index) ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Skip, default)));

		public static IAsyncEnumerable<TSource> WhereAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
			=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
				: AsyncIteratorEnumerable.Create(() => new BasicIteratorAsync<TSource, TSource>(source, async data => await predicate.Invoke(data.current) ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Skip, default)));

		public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIteratorAsync<TFirst, TSecond, TResult>(first, second, resultSelector));

		public static IAsyncEnumerable<TSource> DoAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			return source
				.SelectAsync(async item =>
				{
					await action.Invoke(item);
					return item;
				});
		}

		public static IAsyncEnumerable<TSource> DoAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			return source
				.SelectAsync(async (item, index) =>
				{
					await action.Invoke(item, index);
					return item;
				});
		}

		public static IAsyncEnumerable<TSource> DoAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			return source
				.SelectAsync(async item =>
				{
					await action.Invoke(item);
					return item;
				});
		}

		public static IAsyncEnumerable<TSource> DoAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			return source
				.SelectAsync(async (item, index) =>
				{
					await action.Invoke(item, index);
					return item;
				});
		}

		public static IAsyncEnumerable<TSource> DoAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			return source
				.SelectAsync(async item =>
				{
					await action.Invoke(item);
					return item;
				});
		}

		public static IAsyncEnumerable<TSource> DoAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			return source
				.SelectAsync(async (item, index) =>
				{
					await action.Invoke(item, index);
					return item;
				});
		}

		public static async Task ApplyAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			var enumerator = source.GetAsyncEnumerator();

			while (await enumerator.MoveNextAsync())
				await action.Invoke(enumerator.Current);
		}

		public static async Task ApplyAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			var enumerator = source.GetAsyncEnumerator();

			var index = 0;
			while (await enumerator.MoveNextAsync())
			{
				await action.Invoke(enumerator.Current, index);
				++index;
			}
		}

		public static IAsyncEnumerable<TSource> PickIntoAsync<TSource>(this IEnumerable<TSource> source, out IAsyncEnumerable<TSource> matches, Func<TSource, Task<bool>> predicate)
		{
			var partition = source.PartitionAsync(predicate);

			matches = partition.Matches;

			return partition.NonMatches;
		}

		public static IAsyncEnumerable<TSource> PickIntoAsync<TSource>(this Task<IEnumerable<TSource>> source, out IAsyncEnumerable<TSource> matches, Func<TSource, Task<bool>> predicate)
		{
			var partition = source.PartitionAsync(predicate);

			matches = partition.Matches;

			return partition.NonMatches;
		}

		public static IAsyncEnumerable<TSource> PickIntoAsync<TSource>(this IAsyncEnumerable<TSource> source, out IAsyncEnumerable<TSource> matches, Func<TSource, Task<bool>> predicate)
		{
			var partition = source.PartitionAsync(predicate);

			matches = partition.Matches;

			return partition.NonMatches;
		}
	}
}
