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
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var enumerator = source.GetEnumerator();

			var list = new List<TSource>();

			while (await enumerator.MoveNext())
				list.Add(enumerator.Current);

			return list.AsEnumerable();
		}


		public static async Task<TSource> Aggregate<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var enumerator = source.GetEnumerator();

			if (!await enumerator.MoveNext())
				throw new InvalidOperationException("Sequence contains no elements");

			var value = enumerator.Current;
			
			while (await enumerator.MoveNext())
				value = func.Invoke(value, enumerator.Current);

			return value;
		}

		public static Task<TAccumulate> Aggregate<TSource, TAccumulate>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
			=> Aggregate(source, seed, func, o => o);

		public static async Task<TResult> Aggregate<TSource, TAccumulate, TResult>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			if (func == null)
				throw new ArgumentNullException(nameof(func));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			var enumerator = source.GetEnumerator();

			var value = seed;

			while (await enumerator.MoveNext())
				value = func.Invoke(value, enumerator.Current);

			return resultSelector.Invoke(value);
		}
		
		public static async Task<bool> All<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var enumerator = source.GetEnumerator();

			var value = true;

			while (value && await enumerator.MoveNext())
				value = predicate.Invoke(enumerator.Current);

			return value;
		}

		public static Task<bool> Any<TSource>(this IAsyncEnumerable<TSource> source)
			=> (source ?? throw new ArgumentNullException(nameof(source))).GetEnumerator().MoveNext();

		public static async Task<bool> Any<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var enumerator = source.GetEnumerator();

			var value = false;

			while (!value && await enumerator.MoveNext())
				value = predicate.Invoke(enumerator.Current);

			return value;
		}
		
		public static IAsyncEnumerable<TResult> Cast<TResult>(this IAsyncEnumerable<object> source)
			=> AsyncIteratorEnumerable.Create(() => new BasicIterator<object, TResult>(source, data => (BasicIteratorContinuationType.Take, (TResult)data.current)));

		public static IAsyncEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
			=> AsyncIteratorEnumerable.Create(() => new ConcatIterator<TSource>(first.AsAsyncEnumerable(), second));

		public static IAsyncEnumerable<TSource> Concat<TSource>(this Task<IEnumerable<TSource>> first, IAsyncEnumerable<TSource> second)
			=> AsyncIteratorEnumerable.Create(() => new ConcatIterator<TSource>(first.AsAsyncEnumerable(), second));

		public static IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second)
			=> AsyncIteratorEnumerable.Create(() => new ConcatIterator<TSource>(first, second.AsAsyncEnumerable()));

		public static IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, Task<IEnumerable<TSource>> second)
			=> AsyncIteratorEnumerable.Create(() => new ConcatIterator<TSource>(first, second.AsAsyncEnumerable()));

		public static IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
			=> AsyncIteratorEnumerable.Create(() => new ConcatIterator<TSource>(first, second));
		
		public static IAsyncEnumerable<TSource> DefaultIfEmpty<TSource>(this IAsyncEnumerable<TSource> source)
			=> AsyncIteratorEnumerable.Create(() => new DefaultIfEmptyIterator<TSource>(source, default));

		public static IAsyncEnumerable<TSource> DefaultIfEmpty<TSource>(this IAsyncEnumerable<TSource> source, TSource defaultValue)
			=> AsyncIteratorEnumerable.Create(() => new DefaultIfEmptyIterator<TSource>(source, defaultValue));

		public static async Task<TSource> ElementAt<TSource>(this IAsyncEnumerable<TSource> source, int index)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var enumerator = source.GetEnumerator();

			for (int i = 0; i <= index; ++i)
			{
				if (!await enumerator.MoveNext())
					throw new ArgumentOutOfRangeException(nameof(index), "Index was out of range. Must be non-negative and less than the size of the collection.");
			}

			return enumerator.Current;
		}

		public static async Task<TSource> ElementAtOrDefault<TSource>(this IAsyncEnumerable<TSource> source, int index)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var enumerator = source.GetEnumerator();

			for (int i = 0; i <= index; ++i)
			{
				if (!await enumerator.MoveNext())
					return default;
			}

			return enumerator.Current;
		}

		public static async Task<TSource> First<TSource>(this IAsyncEnumerable<TSource> source)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var enumerator = source.GetEnumerator();

			return (await enumerator.MoveNext()) ? enumerator.Current : throw new InvalidOperationException("Sequence contains no elements");
		}

		public static Task<TSource> First<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> source.Where(predicate).First();

		public static async Task<TSource> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var enumerator = source.GetEnumerator();

			return (await enumerator.MoveNext()) ? enumerator.Current : default;
		}

		public static Task<TSource> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> source.Where(predicate).FirstOrDefault();

		public static IAsyncEnumerable<TResult> OfType<TResult>(this IAsyncEnumerable<object> source)
			=> AsyncIteratorEnumerable.Create(() => new BasicIterator<object, TResult>(source, data => data.current is TResult result ? (BasicIteratorContinuationType.Take, result) : (BasicIteratorContinuationType.Skip, default)));
			
		public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, TResult> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new BasicIterator<TSource, TResult>(source, data => (BasicIteratorContinuationType.Take, selector.Invoke(data.current))));

		public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, TResult> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new BasicIterator<TSource, TResult>(source, data => (BasicIteratorContinuationType.Take, selector.Invoke(data.current, data.index))));

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TResult, TResult>(source, (o, _) => selector(o).AsAsyncEnumerable(), (_, o) => o));

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TResult, TResult>(source, (o, i) => selector(o, i).AsAsyncEnumerable(), (_, o) => o));

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TCollection, TResult>(source, (o, _) => collectionSelector(o).AsAsyncEnumerable(), resultSelector));

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TCollection, TResult>(source, (o, i) => collectionSelector(o, i).AsAsyncEnumerable(), resultSelector));

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TResult>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TResult, TResult>(source, (o, _) => selector(o), (_, o) => o));

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IAsyncEnumerable<TResult>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TResult, TResult>(source, selector, (_, o) => o));

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TCollection, TResult>(source, (o, _) => collectionSelector(o), resultSelector));

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> collectionSelector == null ? throw new ArgumentNullException(nameof(collectionSelector))
				: resultSelector == null ? throw new ArgumentNullException(nameof(resultSelector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TCollection, TResult>(source, collectionSelector, resultSelector));

		public static async Task<TSource> Single<TSource>(this IAsyncEnumerable<TSource> source)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var enumerator = source.GetEnumerator();

			if (!await enumerator.MoveNext())
				throw new InvalidOperationException("Sequence contains no elements");

			var result = enumerator.Current;

			if (await enumerator.MoveNext())
				throw new InvalidOperationException("Sequence contains more than one element");

			return result;
		}

		public static Task<TSource> Single<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> source.Where(predicate).Single();

		public static async Task<TSource> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var enumerator = source.GetEnumerator();

			if (!await enumerator.MoveNext())
				return default;

			var result = enumerator.Current;

			if (await enumerator.MoveNext())
				throw new InvalidOperationException("Sequence contains more than one element");

			return result;
		}

		public static Task<TSource> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> source.Where(predicate).SingleOrDefault();
			
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

			bool skip = true;
			return AsyncIteratorEnumerable.Create(() => new BasicIterator<TSource, TSource>(source, data => (skip ? (skip = predicate.Invoke(data.current, data.index)) : false) ? (BasicIteratorContinuationType.Skip, default) : (BasicIteratorContinuationType.Take, data.current)));
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

		public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIterator<TFirst, TSecond, TResult>(first.AsAsyncEnumerable(), second, resultSelector));

		public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIterator<TFirst, TSecond, TResult>(first.AsAsyncEnumerable(), second, resultSelector));

		public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIterator<TFirst, TSecond, TResult>(first, second.AsAsyncEnumerable(), resultSelector));

		public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIterator<TFirst, TSecond, TResult>(first, second.AsAsyncEnumerable(), resultSelector));

		public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIterator<TFirst, TSecond, TResult>(first, second, resultSelector));
	}
}
