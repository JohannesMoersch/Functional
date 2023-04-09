using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class EnumerableAsyncExtensions
	{
		public static Task<bool> AllAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().AllAsync(predicate);

		public static Task<bool> AllAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().AllAsync(predicate);

		public static Task<bool> AnyAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().AnyAsync(predicate);

		public static Task<bool> AnyAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().AnyAsync(predicate);

		public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
			=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

		public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector, int maxConcurrency)
			=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

		public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<TResult>> selector)
			=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

		public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<TResult>> selector, int maxConcurrency)
			=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

		public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector)
			=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

		public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector, int maxConcurrency)
			=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

		public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<TResult>> selector)
			=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector);

		public static IAsyncEnumerable<TResult> ConcurrentSelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<TResult>> selector, int maxConcurrency)
			=> source.AsAsyncEnumerable().ConcurrentSelectAsync(selector, maxConcurrency);

		public static Task<TSource> FirstAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().FirstAsync(predicate);

		public static Task<TSource> FirstAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().FirstAsync(predicate);

		public static Task<TSource?> FirstOrDefaultAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().FirstOrDefaultAsync(predicate);

		public static Task<TSource?> FirstOrDefaultAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().FirstOrDefaultAsync(predicate);

		public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
			=> source.AsAsyncEnumerable().SelectAsync(selector);

		public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, Task<TResult>> selector)
			=> source.AsAsyncEnumerable().SelectAsync(selector);

		public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<TResult>> selector)
			=> source.AsAsyncEnumerable().SelectAsync(selector);

		public static IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<TResult>> selector)
			=> source.AsAsyncEnumerable().SelectAsync(selector);

		public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TResult>>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyAsyncIterator<TSource, TResult, TResult>(source, (o, _) => selector(o).AsAsyncEnumerable(), (_, o) => o));

		public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TResult>>> selector)
			=> source.AsAsyncEnumerable().SelectManyAsync(selector);

		public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<IEnumerable<TResult>>> selector)
			=> source.AsAsyncEnumerable().SelectManyAsync(selector);

		public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<IEnumerable<TResult>>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyAsyncIterator<TSource, TResult, TResult>(source, (o, i) => selector(o, i).AsAsyncEnumerable(), (_, o) => o));

		public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, Task<IEnumerable<TResult>>> selector)
			=> source.AsAsyncEnumerable().SelectManyAsync(selector);

		public static IAsyncEnumerable<TResult> SelectManyAsync<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<IEnumerable<TResult>>> selector)
			=> source.AsAsyncEnumerable().SelectManyAsync(selector);

		public static Task<TSource> SingleAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().SingleAsync(predicate);

		public static Task<TSource> SingleAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().SingleAsync(predicate);

		public static Task<TSource?> SingleOrDefaultAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().SingleOrDefaultAsync(predicate);

		public static IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().SkipWhileAsync(predicate);

		public static IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().SkipWhileAsync(predicate);

		public static IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().SkipWhileAsync(predicate);

		public static IAsyncEnumerable<TSource> SkipWhileAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().SkipWhileAsync(predicate);

		public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().TakeWhileAsync(predicate);

		public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().TakeWhileAsync(predicate);

		public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().TakeWhileAsync(predicate);

		public static IAsyncEnumerable<TSource> TakeWhileAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().TakeWhileAsync(predicate);

		public static IAsyncEnumerable<TSource> WhereAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().WhereAsync(predicate);

		public static IAsyncEnumerable<TSource> WhereAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().WhereAsync(predicate);

		public static IAsyncEnumerable<TSource> WhereAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().WhereAsync(predicate);

		public static IAsyncEnumerable<TSource> WhereAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<bool>> predicate)
			=> source.AsAsyncEnumerable().WhereAsync(predicate);

		public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipTaskAsyncIterator<TFirst, TSecond, TResult>(first.AsAsyncEnumerable(), second, resultSelector));

		public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipTaskAsyncIterator<TFirst, TSecond, TResult>(first.AsAsyncEnumerable(), second, resultSelector));

		public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipTaskAsyncIterator<TFirst, TSecond, TResult>(first, second.AsAsyncEnumerable(), resultSelector));

		public static IAsyncEnumerable<TResult> ZipAsync<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, Task<TResult>> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipTaskAsyncIterator<TFirst, TSecond, TResult>(first, second.AsAsyncEnumerable(), resultSelector));

		public static async Task ApplyAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			foreach (var item in source)
				await action.Invoke(item);
		}

		public static async Task ApplyAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			var index = 0;
			foreach (var item in source)
				await action.Invoke(item, index++);
		}

		public static async Task ApplyAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			foreach (var item in await source)
				await action.Invoke(item);
		}

		public static async Task ApplyAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			var index = 0;
			foreach (var item in await source)
				await action.Invoke(item, index++);
		}
	}
}
