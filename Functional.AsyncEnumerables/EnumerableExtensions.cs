using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class EnumerableExtensions
    {
		public static IAsyncEnumerable<TSource> AsAsyncEnumerable<TSource>(this IEnumerable<TSource> source)
			=> AsyncEnumerable.Create(source);

		public static IAsyncEnumerable<TSource> AsAsyncEnumerable<TSource>(this Task<IEnumerable<TSource>> source)
			=> AsyncEnumerable.Create(source);

		public static IAsyncEnumerable<TSource> AsAsyncEnumerable<TSource>(this Task<TSource[]> source)
			=> AsyncEnumerable.Create(source);

		public static IAsyncEnumerable<TSource> AsAsyncEnumerable<TSource>(this IEnumerable<Task<TSource>> source)
			=> AsyncEnumerable.Create(source);

		public static IAsyncEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
			=> AsyncIteratorEnumerable.Create(() => new ConcatIterator<TSource>(first.AsAsyncEnumerable(), second));

		public static IAsyncEnumerable<TSource> Concat<TSource>(this Task<IEnumerable<TSource>> first, IAsyncEnumerable<TSource> second)
			=> AsyncIteratorEnumerable.Create(() => new ConcatIterator<TSource>(first.AsAsyncEnumerable(), second));

		public static IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second)
			=> AsyncIteratorEnumerable.Create(() => new ConcatIterator<TSource>(first, second.AsAsyncEnumerable()));

		public static IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, Task<IEnumerable<TSource>> second)
			=> AsyncIteratorEnumerable.Create(() => new ConcatIterator<TSource>(first, second.AsAsyncEnumerable()));

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TResult>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TResult, TResult>(source.AsAsyncEnumerable(), (o, _) => selector(o), (_, o) => o));

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IAsyncEnumerable<TResult>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TResult, TResult>(source.AsAsyncEnumerable(), selector, (_, o) => o));

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IAsyncEnumerable<TResult>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TResult, TResult>(source.AsAsyncEnumerable(), (o, _) => selector(o), (_, o) => o));

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, IAsyncEnumerable<TResult>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TResult, TResult>(source.AsAsyncEnumerable(), selector, (_, o) => o));

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TResult, TResult>(source, (o, _) => selector(o).AsAsyncEnumerable(), (_, o) => o));

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TResult, TResult>(source, (o, i) => selector(o, i).AsAsyncEnumerable(), (_, o) => o));

		public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIterator<TFirst, TSecond, TResult>(first.AsAsyncEnumerable(), second, resultSelector));

		public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIterator<TFirst, TSecond, TResult>(first.AsAsyncEnumerable(), second, resultSelector));

		public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIterator<TFirst, TSecond, TResult>(first, second.AsAsyncEnumerable(), resultSelector));

		public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIterator<TFirst, TSecond, TResult>(first, second.AsAsyncEnumerable(), resultSelector));
	}
}
