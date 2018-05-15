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

			var enumerator = source.GetEnumerator();

			var value = true;

			while (value && await enumerator.MoveNext())
				value = await predicate.Invoke(enumerator.Current);

			return value;
		}

		public static async Task<bool> AnyAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var enumerator = source.GetEnumerator();

			var value = false;

			while (!value && await enumerator.MoveNext())
				value = await predicate.Invoke(enumerator.Current);

			return value;
		}

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

		public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TResult>>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TResult, TResult>(source, (o, _) => selector(o).AsAsyncEnumerable(), (_, o) => o));

		public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<IEnumerable<TResult>>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TResult, TResult>(source, (o, i) => selector(o, i).AsAsyncEnumerable(), (_, o) => o));

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

		public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIteratorAsync<TFirst, TSecond, TResult>(first.AsAsyncEnumerable(), second, resultSelector));

		public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIteratorAsync<TFirst, TSecond, TResult>(first.AsAsyncEnumerable(), second, resultSelector));

		public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIteratorAsync<TFirst, TSecond, TResult>(first, second.AsAsyncEnumerable(), resultSelector));

		public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIteratorAsync<TFirst, TSecond, TResult>(first, second.AsAsyncEnumerable(), resultSelector));

		public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIteratorAsync<TFirst, TSecond, TResult>(first, second, resultSelector));
	}
}
