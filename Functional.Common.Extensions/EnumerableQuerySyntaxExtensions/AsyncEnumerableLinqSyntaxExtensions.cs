﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
		public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<TResult>> selector)
			=> source.SelectAsync(selector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
			=> source.SelectAsync(selector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> (await source).SelectMany(collectionSelector, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyTaskAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyTaskAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyTaskAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyTaskAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyTaskAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyTaskAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyTaskAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyTaskAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create((source, collectionSelector, resultSelector), static (o, t) => SelectManyTaskAsyncIterator.Create(o.source.AsAsyncEnumerable(), o, static (s, _, context) => context.collectionSelector.Invoke(s).AsAsyncEnumerable(), static (s, c, context) => context.resultSelector.Invoke(s, c), t));
	}
}
