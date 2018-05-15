using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class AsyncEnumerableExtensions
	{
		public static async Task<IEnumerable<TSource>> AsEnumerable<TSource>(this IAsyncEnumerable<TSource> source)
		{
			var enumerator = source.GetEnumerator();

			var list = new List<TSource>();

			while (await enumerator.MoveNext())
				list.Add(enumerator.Current);

			return list.AsEnumerable();
		}

		/*
		public static Task<TSource> Aggregate<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
			=> (await source).Aggregate(func);

		public static Task<TAccumulate> Aggregate<TSource, TAccumulate>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
			=> (await source).Aggregate(seed, func);

		public static Task<TResult> Aggregate<TSource, TAccumulate, TResult>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
			=> (await source).Aggregate(seed, func, resultSelector);

		public static Task<bool> All<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> (await source).All(predicate);

		public static Task<bool> Any<TSource>(this IAsyncEnumerable<TSource> source)
			=> (await source).Any();

		public static Task<bool> Any<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> (await source).Any(predicate);

		public static IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second)
			=> (await first).Concat(second);

		public static IAsyncEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
			=> first.Concat(await second);

		public static IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
			=> (await first).Concat(await second);

		public static IAsyncEnumerable<TSource> DefaultIfEmpty<TSource>(this IAsyncEnumerable<TSource> source)
			=> (await source).DefaultIfEmpty();

		public static IAsyncEnumerable<TSource> DefaultIfEmpty<TSource>(this IAsyncEnumerable<TSource> source, TSource defaultValue)
			=> (await source).DefaultIfEmpty(defaultValue);

		public static Task<TSource> First<TSource>(this IAsyncEnumerable<TSource> source)
			=> (await source).First();

		public static Task<TSource> First<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> (await source).First(predicate);

		public static Task<TSource> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source)
			=> (await source).FirstOrDefault();

		public static Task<TSource> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> (await source).FirstOrDefault(predicate);
			*/
		public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, TResult> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new BasicIterator<TSource, TResult>(source, data => (BasicIteratorContinuationType.Take, selector.Invoke(data.current))));

		public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, TResult> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new BasicIterator<TSource, TResult>(source, data => (BasicIteratorContinuationType.Take, selector.Invoke(data.current, data.index))));
		/*
		public static Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
			=> (await source).SelectMany(selector);

		public static Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
			=> (await source).SelectMany(selector);

		public static Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> (await source).SelectMany(collectionSelector, resultSelector);

		public static Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> (await source).SelectMany(collectionSelector, resultSelector);

		public static Task<TSource> Single<TSource>(this IAsyncEnumerable<TSource> source)
			=> (await source).Single();

		public static Task<TSource> Single<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> (await source).Single(predicate);

		public static Task<TSource> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source)
			=> (await source).SingleOrDefault();

		public static Task<TSource> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> (await source).SingleOrDefault(predicate);
			*/
		public static IAsyncEnumerable<TSource> Skip<TSource>(this IAsyncEnumerable<TSource> source, int count)
			=> AsyncIteratorEnumerable.Create(() => new BasicIterator<TSource, TSource>(source, data => data.index >= count ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Skip, default)));

		public static IAsyncEnumerable<TSource> SkipWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			bool skip = true;
			return AsyncIteratorEnumerable.Create(() => new BasicIterator<TSource, TSource>(source, data => (skip ? (skip = predicate.Invoke(data.current)) : false) ? (BasicIteratorContinuationType.Skip, default) : (BasicIteratorContinuationType.Take, data.current)));
		}

		public static IAsyncEnumerable<TSource> SkipWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			bool matchFound = false;
			return AsyncIteratorEnumerable.Create(() => new BasicIterator<TSource, TSource>(source, data => (matchFound ? true : (matchFound = predicate.Invoke(data.current, data.index))) ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Skip, default)));
		}

		public static IAsyncEnumerable<TSource> Take<TSource>(this IAsyncEnumerable<TSource> source, int count)
			=> AsyncIteratorEnumerable.Create(() => new BasicIterator<TSource, TSource>(source, data => data.index < count ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Stop, default)));
		
		public static IAsyncEnumerable<TSource> TakeWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
				: AsyncIteratorEnumerable.Create(() => new BasicIterator<TSource, TSource>(source, data => predicate.Invoke(data.current) ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Stop, default)));

		public static IAsyncEnumerable<TSource> TakeWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate)
			=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
				: AsyncIteratorEnumerable.Create(() => new BasicIterator<TSource, TSource>(source, data => predicate.Invoke(data.current, data.index) ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Stop, default)));
		
		public static IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate)
			=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
				: AsyncIteratorEnumerable.Create(() => new BasicIterator<TSource, TSource>(source, data => predicate.Invoke(data.current, data.index) ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Skip, default)));

		public static IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> predicate == null ? throw new ArgumentNullException(nameof(predicate))
				: AsyncIteratorEnumerable.Create(() => new BasicIterator<TSource, TSource>(source, data => predicate.Invoke(data.current) ? (BasicIteratorContinuationType.Take, data.current) : (BasicIteratorContinuationType.Skip, default)));
		/*
		public static Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> (await first).Zip(second, resultSelector);

		public static Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> first.Zip(await second, resultSelector);

		public static Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> (await first).Zip(await second, resultSelector);
			*/
	}
}
