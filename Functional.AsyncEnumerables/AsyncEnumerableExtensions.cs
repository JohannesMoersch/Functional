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
		public static Task<IEnumerable<TSource>> AsEnumerable<TSource>(this IAsyncEnumerable<TSource> source)
			=> source.ToList().AsEnumerable();

		public static async Task<TSource[]> ToArray<TSource>(this IAsyncEnumerable<TSource> source)
		{
			var list = await source.ToList();

			var arr = new TSource[list.Count];

			list.CopyTo(arr);

			return arr;
		}

		public static async Task<List<TSource>> ToList<TSource>(this IAsyncEnumerable<TSource> source)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var enumerator = source.GetEnumerator();

			var list = new List<TSource>();

			while (await enumerator.MoveNext())
				list.Add(enumerator.Current);

			return list;
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

		public static IAsyncEnumerable<TSource> Append<TSource>(this IAsyncEnumerable<TSource> source, TSource element)
			=> AsyncIteratorEnumerable.Create(() => new AppendIterator<TSource>(source, element));

		public static IAsyncEnumerable<TResult> Cast<TResult>(this IAsyncEnumerable<object> source)
			=> AsyncIteratorEnumerable.Create(() => new BasicIterator<object, TResult>(source, data => (BasicIteratorContinuationType.Take, (TResult)data.current)));

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

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TResult>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TResult, TResult>(source, (o, _) => selector(o), (_, o) => o));

		public static IAsyncEnumerable<TResult> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IAsyncEnumerable<TResult>> selector)
			=> selector == null ? throw new ArgumentNullException(nameof(selector))
				: AsyncIteratorEnumerable.Create(() => new SelectManyIterator<TSource, TResult, TResult>(source, selector, (_, o) => o));

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

		public static IAsyncEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> AsyncIteratorEnumerable.Create(() => new ZipIterator<TFirst, TSecond, TResult>(first, second, resultSelector));

		public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			return source
				.Select(item =>
				{
					action.Invoke(item);
					return item;
				});
		}

		public static async Task Apply<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			var enumerator = source.GetEnumerator();

			while (await enumerator.MoveNext())
				action.Invoke(enumerator.Current);
		}

		public static IAsyncEnumerable<IReadOnlyList<TSource>> Batch<TSource>(this IAsyncEnumerable<TSource> source, int batchSize)
			=> AsyncIteratorEnumerable.Create(() => new BatchIterator<TSource>(source.GetEnumerator(), batchSize));

		public static IAsyncEnumerable<TSource> PickInto<TSource>(this IAsyncEnumerable<TSource> source, out IAsyncEnumerable<TSource> matches, Func<TSource, bool> predicate)
		{
			var partition = source.Partition(predicate);

			matches = partition.Matches;

			return partition.NonMatches;
		}
	}
}
