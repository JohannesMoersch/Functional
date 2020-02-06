using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class AsyncEnumerableLinqSyntaxExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
			=> source.SelectAsync(selector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
			=> source.SelectAsync(selector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TCollection, TResult>(source.AsAsyncEnumerable(), (o, _) => collectionSelector(o), resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TCollection, TResult>(source.AsAsyncEnumerable(), collectionSelector, resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TCollection, TResult>(source.AsAsyncEnumerable(), (o, _) => collectionSelector(o), resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TCollection, TResult>(source.AsAsyncEnumerable(), collectionSelector, resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TCollection, TResult>(source, (o, _) => collectionSelector(o).AsAsyncEnumerable(), resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TCollection, TResult>(source, (o, i) => collectionSelector(o, i).AsAsyncEnumerable(), resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TCollection, TResult>(source, (o, _) => collectionSelector(o).AsAsyncEnumerable(), resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TCollection, TResult>(source, (o, i) => collectionSelector(o, i).AsAsyncEnumerable(), resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TCollection, TResult>(source, (o, _) => collectionSelector(o), resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TCollection, TResult>(source, collectionSelector, resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIteratorAsync<TSource, TCollection, TResult>(source.AsAsyncEnumerable(), (o, _) => collectionSelector(o), resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIteratorAsync<TSource, TCollection, TResult>(source.AsAsyncEnumerable(), collectionSelector, resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIteratorAsync<TSource, TCollection, TResult>(source.AsAsyncEnumerable(), (o, _) => collectionSelector(o), resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, int, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIteratorAsync<TSource, TCollection, TResult>(source.AsAsyncEnumerable(), collectionSelector, resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIteratorAsync<TSource, TCollection, TResult>(source, (o, _) => collectionSelector(o).AsAsyncEnumerable(), resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIteratorAsync<TSource, TCollection, TResult>(source, (o, i) => collectionSelector(o, i).AsAsyncEnumerable(), resultSelector));
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIteratorAsync<TSource, TCollection, TResult>(source, (o, _) => collectionSelector(o).AsAsyncEnumerable(), resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIteratorAsync<TSource, TCollection, TResult>(source, (o, i) => collectionSelector(o, i).AsAsyncEnumerable(), resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIteratorAsync<TSource, TCollection, TResult>(source, (o, _) => collectionSelector(o), resultSelector));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIteratorAsync<TSource, TCollection, TResult>(source, collectionSelector, resultSelector));
	}
}
