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
		public static async Task<TSource> Aggregate<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
			=> (await source).Aggregate(func);

		public static async Task<TAccumulate> Aggregate<TSource, TAccumulate>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
			=> (await source).Aggregate(seed, func);

		public static async Task<TResult> Aggregate<TSource, TAccumulate, TResult>(this IAsyncEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
			=> (await source).Aggregate(seed, func, resultSelector);

		public static async Task<bool> All<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> (await source).All(predicate);

		public static async Task<bool> Any<TSource>(this IAsyncEnumerable<TSource> source)
			=> (await source).Any();

		public static async Task<bool> Any<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> (await source).Any(predicate);

		public static async IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, IEnumerable<TSource> second)
			=> (await first).Concat(second);

		public static async IAsyncEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
			=> first.Concat(await second);

		public static async IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second)
			=> (await first).Concat(await second);

		public static async IAsyncEnumerable<TSource> DefaultIfEmpty<TSource>(this IAsyncEnumerable<TSource> source)
			=> (await source).DefaultIfEmpty();

		public static async IAsyncEnumerable<TSource> DefaultIfEmpty<TSource>(this IAsyncEnumerable<TSource> source, TSource defaultValue)
			=> (await source).DefaultIfEmpty(defaultValue);

		public static async Task<TSource> First<TSource>(this IAsyncEnumerable<TSource> source)
			=> (await source).First();

		public static async Task<TSource> First<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> (await source).First(predicate);

		public static async Task<TSource> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source)
			=> (await source).FirstOrDefault();

		public static async Task<TSource> FirstOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> (await source).FirstOrDefault(predicate);
			*/
		public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, TResult> selector)
			=> AsyncIteratorEnumerable.Create(() => new AsyncSelectIterator<TSource, TResult>(source, (o, i) => selector.Invoke(o)));

		public static IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, TResult> selector)
			=> AsyncIteratorEnumerable.Create(() => new AsyncSelectIterator<TSource, TResult>(source, selector));
		/*
		public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, TResult> selector)
			=> (await source).Select(selector);

		public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
			=> (await source).SelectMany(selector);

		public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
			=> (await source).SelectMany(selector);

		public static async Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> (await source).SelectMany(collectionSelector, resultSelector);

		public static async Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> (await source).SelectMany(collectionSelector, resultSelector);

		public static async Task<TSource> Single<TSource>(this IAsyncEnumerable<TSource> source)
			=> (await source).Single();

		public static async Task<TSource> Single<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> (await source).Single(predicate);

		public static async Task<TSource> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source)
			=> (await source).SingleOrDefault();

		public static async Task<TSource> SingleOrDefault<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> (await source).SingleOrDefault(predicate);

		public static async IAsyncEnumerable<TSource> Skip<TSource>(this IAsyncEnumerable<TSource> source, int count)
			=> (await source).Skip(count);

		public static async IAsyncEnumerable<TSource> SkipWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> (await source).SkipWhile(predicate);

		public static async IAsyncEnumerable<TSource> SkipWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate)
			=> (await source).SkipWhile(predicate);

		public static async IAsyncEnumerable<TSource> Take<TSource>(this IAsyncEnumerable<TSource> source, int count)
			=> (await source).Take(count);

		public static async IAsyncEnumerable<TSource> TakeWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> (await source).TakeWhile(predicate);

		public static async IAsyncEnumerable<TSource> TakeWhile<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate)
			=> (await source).TakeWhile(predicate);

		public static async IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int, bool> predicate)
			=> (await source).Where(predicate);

		public static async IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
			=> (await source).Where(predicate);

		public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> (await first).Zip(second, resultSelector);

		public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> first.Zip(await second, resultSelector);

		public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> (await first).Zip(await second, resultSelector);
			*/
	}
}
