using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Functional.Enumerables.Extensions
{
    public static class OrderedEnumerableExtensions
    {
		public static async Task<TSource> Aggregate<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TSource, TSource> func)
			=> (await source).Aggregate(func);

		public static async Task<TAccumulate> Aggregate<TSource, TAccumulate>(this Task<IOrderedEnumerable<TSource>> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
			=> (await source).Aggregate(seed, func);

		public static async Task<TResult> Aggregate<TSource, TAccumulate, TResult>(this Task<IOrderedEnumerable<TSource>> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
			=> (await source).Aggregate(seed, func, resultSelector);

		public static async Task<bool> All<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
			=> (await source).All(predicate);

		public static async Task<bool> Any<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).Any();

		public static async Task<bool> Any<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
			=> (await source).Any(predicate);

		public static async Task<double> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long> selector)
			=> (await source).Average(selector);

		public static async Task<decimal?> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal?> selector)
			=> (await source).Average(selector);

		public static async Task<double?> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double?> selector)
			=> (await source).Average(selector);

		public static async Task<float> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float> selector)
			=> (await source).Average(selector);

		public static async Task<double?> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long?> selector)
			=> (await source).Average(selector);

		public static async Task<float?> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float?> selector)
			=> (await source).Average(selector);

		public static async Task<double> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int> selector)
			=> (await source).Average(selector);

		public static async Task<double?> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int?> selector)
			=> (await source).Average(selector);

		public static async Task<double> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double> selector)
			=> (await source).Average(selector);

		public static async Task<decimal> Average<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal> selector)
			=> (await source).Average(selector);

		public static async Task<decimal> Average(this Task<IOrderedEnumerable<decimal>> source)
			=> (await source).Average();

		public static async Task<float> Average(this Task<IOrderedEnumerable<float>> source)
			=> (await source).Average();

		public static async Task<double> Average(this Task<IOrderedEnumerable<int>> source)
			=> (await source).Average();

		public static async Task<double> Average(this Task<IOrderedEnumerable<long>> source)
			=> (await source).Average();

		public static async Task<decimal?> Average(this Task<IOrderedEnumerable<decimal?>> source)
			=> (await source).Average();

		public static async Task<double> Average(this Task<IOrderedEnumerable<double>> source)
			=> (await source).Average();

		public static async Task<double?> Average(this Task<IOrderedEnumerable<int?>> source)
			=> (await source).Average();

		public static async Task<double?> Average(this Task<IOrderedEnumerable<long?>> source)
			=> (await source).Average();

		public static async Task<float?> Average(this Task<IOrderedEnumerable<float?>> source)
			=> (await source).Average();

		public static async Task<double?> Average(this Task<IOrderedEnumerable<double?>> source)
			=> (await source).Average();

		public static async Task<IEnumerable<TSource>> Concat<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
			=> first.Concat(await second);

		public static async Task<IEnumerable<TSource>> Concat<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second)
			=> (await first).Concat(second);

		public static async Task<IEnumerable<TSource>> Concat<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
			=> (await first).Concat(await second);

		public static async Task<IEnumerable<TSource>> Concat<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
			=> (await first).Concat(await second);

		public static async Task<IEnumerable<TSource>> Concat<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
			=> (await first).Concat(await second);

		public static async Task<bool> Contains<TSource>(this Task<IOrderedEnumerable<TSource>> source, TSource value)
			=> (await source).Contains(value);

		public static async Task<bool> Contains<TSource>(this Task<IOrderedEnumerable<TSource>> source, TSource value, IEqualityComparer<TSource> comparer)
			=> (await source).Contains(value, comparer);

		public static async Task<int> Count<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).Count();

		public static async Task<int> Count<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
			=> (await source).Count(predicate);

		public static async Task<IEnumerable<TSource>> DefaultIfEmpty<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).DefaultIfEmpty();

		public static async Task<IEnumerable<TSource>> DefaultIfEmpty<TSource>(this Task<IOrderedEnumerable<TSource>> source, TSource defaultValue)
			=> (await source).DefaultIfEmpty(defaultValue);

		public static async Task<IEnumerable<TSource>> Distinct<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).Distinct();

		public static async Task<IEnumerable<TSource>> Distinct<TSource>(this Task<IOrderedEnumerable<TSource>> source, IEqualityComparer<TSource> comparer)
			=> (await source).Distinct(comparer);

		public static async Task<TSource> ElementAt<TSource>(this Task<IOrderedEnumerable<TSource>> source, int index)
			=> (await source).ElementAt(index);

		public static async Task<TSource> ElementAtOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, int index)
			=> (await source).ElementAtOrDefault(index);

		public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second)
			=> (await first).Except(second);

		public static async Task<IEnumerable<TSource>> Except<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
			=> first.Except(await second);

		public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
			=> (await first).Except(await second);

		public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
			=> (await first).Except(await second);

		public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
			=> (await first).Except(await second);

		public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
			=> (await first).Except(second, comparer);

		public static async Task<IEnumerable<TSource>> Except<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> first.Except(await second, comparer);

		public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> (await first).Except(await second, comparer);

		public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> (await first).Except(await second, comparer);

		public static async Task<IEnumerable<TSource>> Except<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> (await first).Except(await second, comparer);

		public static async Task<TSource> First<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).First();

		public static async Task<TSource> First<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
			=> (await source).First(predicate);

		public static async Task<TSource> FirstOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).FirstOrDefault();

		public static async Task<TSource> FirstOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
			=> (await source).FirstOrDefault(predicate);

		public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TElement, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
			=> (await source).GroupBy(keySelector, elementSelector, resultSelector, comparer);

		public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TElement, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
			=> (await source).GroupBy(keySelector, elementSelector, resultSelector);

		public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
			=> (await source).GroupBy(keySelector, resultSelector, comparer);

		public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
			=> (await source).GroupBy(keySelector, resultSelector);

		public static async Task<IEnumerable<IGrouping<TKey, TSource>>> GroupBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
			=> (await source).GroupBy(keySelector, comparer);

		public static async Task<IEnumerable<IGrouping<TKey, TElement>>> GroupBy<TSource, TKey, TElement>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
			=> (await source).GroupBy(keySelector, elementSelector);

		public static async Task<IEnumerable<IGrouping<TKey, TSource>>> GroupBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
			=> (await source).GroupBy(keySelector);

		public static async Task<IEnumerable<IGrouping<TKey, TElement>>> GroupBy<TSource, TKey, TElement>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
			=> (await source).GroupBy(keySelector, elementSelector, comparer);

		public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
			=> (await outer).GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

		public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> (await outer).GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector);

		public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
			=> (await first).Intersect(second, comparer);

		public static async Task<IEnumerable<TSource>> Intersect<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> first.Intersect(await second, comparer);

		public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> (await first).Intersect(await second, comparer);

		public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> (await first).Intersect(await second, comparer);

		public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> (await first).Intersect(await second, comparer);

		public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second)
			=> (await first).Intersect(second);

		public static async Task<IEnumerable<TSource>> Intersect<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
			=> first.Intersect(await second);

		public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
			=> (await first).Intersect(await second);

		public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
			=> (await first).Intersect(await second);

		public static async Task<IEnumerable<TSource>> Intersect<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
			=> (await first).Intersect(await second);

		public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> (await outer).Join(inner, outerKeySelector, innerKeySelector, resultSelector);

		public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> outer.Join(await inner, outerKeySelector, innerKeySelector, resultSelector);

		public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector);

		public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector);

		public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector);

		public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
			=> (await outer).Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

		public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
			=> outer.Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

		public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
			=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

		public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
			=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

		public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(this Task<IOrderedEnumerable<TOuter>> outer, Task<IOrderedEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
			=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

		public static async Task<TSource> Last<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).Last();

		public static async Task<TSource> Last<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
			=> (await source).Last(predicate);

		public static async Task<TSource> LastOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).LastOrDefault();

		public static async Task<TSource> LastOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
			=> (await source).LastOrDefault(predicate);

		public static async Task<long> LongCount<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).LongCount();

		public static async Task<long> LongCount<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
			=> (await source).LongCount(predicate);

		public static async Task<int> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int> selector)
			=> (await source).Max(selector);

		public static async Task<long> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long> selector)
			=> (await source).Max(selector);

		public static async Task<decimal?> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal?> selector)
			=> (await source).Max(selector);

		public static async Task<double?> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double?> selector)
			=> (await source).Max(selector);

		public static async Task<float> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float> selector)
			=> (await source).Max(selector);

		public static async Task<long?> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long?> selector)
			=> (await source).Max(selector);

		public static async Task<float?> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float?> selector)
			=> (await source).Max(selector);

		public static async Task<double> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double> selector)
			=> (await source).Max(selector);

		public static async Task<int?> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int?> selector)
			=> (await source).Max(selector);

		public static async Task<decimal> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal> selector)
			=> (await source).Max(selector);

		public static async Task<TResult> Max<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TResult> selector)
			=> (await source).Max(selector);

		public static async Task<float> Max(this Task<IOrderedEnumerable<float>> source)
			=> (await source).Max();

		public static async Task<decimal> Max(this Task<IOrderedEnumerable<decimal>> source)
			=> (await source).Max();

		public static async Task<double> Max(this Task<IOrderedEnumerable<double>> source)
			=> (await source).Max();

		public static async Task<int> Max(this Task<IOrderedEnumerable<int>> source)
			=> (await source).Max();

		public static async Task<long> Max(this Task<IOrderedEnumerable<long>> source)
			=> (await source).Max();

		public static async Task<TSource> Max<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).Max();

		public static async Task<double?> Max(this Task<IOrderedEnumerable<double?>> source)
			=> (await source).Max();

		public static async Task<int?> Max(this Task<IOrderedEnumerable<int?>> source)
			=> (await source).Max();

		public static async Task<long?> Max(this Task<IOrderedEnumerable<long?>> source)
			=> (await source).Max();

		public static async Task<float?> Max(this Task<IOrderedEnumerable<float?>> source)
			=> (await source).Max();

		public static async Task<decimal?> Max(this Task<IOrderedEnumerable<decimal?>> source)
			=> (await source).Max();

		public static async Task<int> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int> selector)
			=> (await source).Min(selector);

		public static async Task<TResult> Min<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TResult> selector)
			=> (await source).Min(selector);

		public static async Task<float> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float> selector)
			=> (await source).Min(selector);

		public static async Task<float?> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float?> selector)
			=> (await source).Min(selector);

		public static async Task<long?> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long?> selector)
			=> (await source).Min(selector);

		public static async Task<int?> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int?> selector)
			=> (await source).Min(selector);

		public static async Task<double?> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double?> selector)
			=> (await source).Min(selector);

		public static async Task<decimal?> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal?> selector)
			=> (await source).Min(selector);

		public static async Task<long> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long> selector)
			=> (await source).Min(selector);

		public static async Task<decimal> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal> selector)
			=> (await source).Min(selector);

		public static async Task<double> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double> selector)
			=> (await source).Min(selector);

		public static async Task<float> Min(this Task<IOrderedEnumerable<float>> source)
			=> (await source).Min();

		public static async Task<float?> Min(this Task<IOrderedEnumerable<float?>> source)
			=> (await source).Min();

		public static async Task<long?> Min(this Task<IOrderedEnumerable<long?>> source)
			=> (await source).Min();

		public static async Task<int?> Min(this Task<IOrderedEnumerable<int?>> source)
			=> (await source).Min();

		public static async Task<double?> Min(this Task<IOrderedEnumerable<double?>> source)
			=> (await source).Min();

		public static async Task<decimal?> Min(this Task<IOrderedEnumerable<decimal?>> source)
			=> (await source).Min();

		public static async Task<long> Min(this Task<IOrderedEnumerable<long>> source)
			=> (await source).Min();

		public static async Task<int> Min(this Task<IOrderedEnumerable<int>> source)
			=> (await source).Min();

		public static async Task<double> Min(this Task<IOrderedEnumerable<double>> source)
			=> (await source).Min();

		public static async Task<decimal> Min(this Task<IOrderedEnumerable<decimal>> source)
			=> (await source).Min();

		public static async Task<TSource> Min<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).Min();

		public static async Task<IOrderedEnumerable<TSource>> OrderBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
			=> (await source).OrderBy(keySelector, comparer);

		public static async Task<IOrderedEnumerable<TSource>> OrderBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
			=> (await source).OrderBy(keySelector);

		public static async Task<IOrderedEnumerable<TSource>> OrderByDescending<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
			=> (await source).OrderByDescending(keySelector);

		public static async Task<IOrderedEnumerable<TSource>> OrderByDescending<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
			=> (await source).OrderByDescending(keySelector, comparer);

		public static async Task<IEnumerable<TSource>> Reverse<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).Reverse();

		public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TResult> selector)
			=> (await source).Select(selector);

		public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, TResult> selector)
			=> (await source).Select(selector);

		public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, IEnumerable<TResult>> selector)
			=> (await source).SelectMany(selector);

		public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, IEnumerable<TResult>> selector)
			=> (await source).SelectMany(selector);

		public static async Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> (await source).SelectMany(collectionSelector, resultSelector);

		public static async Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> (await source).SelectMany(collectionSelector, resultSelector);

		public static async Task<bool> SequenceEqual<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
			=> (await first).SequenceEqual(second, comparer);

		public static async Task<bool> SequenceEqual<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> first.SequenceEqual(await second, comparer);

		public static async Task<bool> SequenceEqual<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> (await first).SequenceEqual(await second, comparer);

		public static async Task<bool> SequenceEqual<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> (await first).SequenceEqual(await second, comparer);

		public static async Task<bool> SequenceEqual<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> (await first).SequenceEqual(await second, comparer);

		public static async Task<bool> SequenceEqual<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second)
			=> (await first).SequenceEqual(second);

		public static async Task<bool> SequenceEqual<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
			=> first.SequenceEqual(await second);

		public static async Task<bool> SequenceEqual<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
			=> (await first).SequenceEqual(await second);

		public static async Task<bool> SequenceEqual<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
			=> (await first).SequenceEqual(await second);

		public static async Task<bool> SequenceEqual<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
			=> (await first).SequenceEqual(await second);

		public static async Task<TSource> Single<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).Single();

		public static async Task<TSource> Single<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
			=> (await source).Single(predicate);

		public static async Task<TSource> SingleOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).SingleOrDefault();

		public static async Task<TSource> SingleOrDefault<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
			=> (await source).SingleOrDefault(predicate);

		public static async Task<IEnumerable<TSource>> Skip<TSource>(this Task<IOrderedEnumerable<TSource>> source, int count)
			=> (await source).Skip(count);

		public static async Task<IEnumerable<TSource>> SkipWhile<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
			=> (await source).SkipWhile(predicate);

		public static async Task<IEnumerable<TSource>> SkipWhile<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, bool> predicate)
			=> (await source).SkipWhile(predicate);

		public static async Task<int?> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int?> selector)
			=> (await source).Sum(selector);

		public static async Task<int> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int> selector)
			=> (await source).Sum(selector);

		public static async Task<long> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long> selector)
			=> (await source).Sum(selector);

		public static async Task<decimal?> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal?> selector)
			=> (await source).Sum(selector);

		public static async Task<float> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float> selector)
			=> (await source).Sum(selector);

		public static async Task<float?> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, float?> selector)
			=> (await source).Sum(selector);

		public static async Task<double> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double> selector)
			=> (await source).Sum(selector);

		public static async Task<long?> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, long?> selector)
			=> (await source).Sum(selector);

		public static async Task<decimal> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, decimal> selector)
			=> (await source).Sum(selector);

		public static async Task<double?> Sum<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, double?> selector)
			=> (await source).Sum(selector);

		public static async Task<float?> Sum(this Task<IOrderedEnumerable<float?>> source)
			=> (await source).Sum();

		public static async Task<long?> Sum(this Task<IOrderedEnumerable<long?>> source)
			=> (await source).Sum();

		public static async Task<int?> Sum(this Task<IOrderedEnumerable<int?>> source)
			=> (await source).Sum();

		public static async Task<double?> Sum(this Task<IOrderedEnumerable<double?>> source)
			=> (await source).Sum();

		public static async Task<decimal?> Sum(this Task<IOrderedEnumerable<decimal?>> source)
			=> (await source).Sum();

		public static async Task<float> Sum(this Task<IOrderedEnumerable<float>> source)
			=> (await source).Sum();

		public static async Task<long> Sum(this Task<IOrderedEnumerable<long>> source)
			=> (await source).Sum();

		public static async Task<int> Sum(this Task<IOrderedEnumerable<int>> source)
			=> (await source).Sum();

		public static async Task<double> Sum(this Task<IOrderedEnumerable<double>> source)
			=> (await source).Sum();

		public static async Task<decimal> Sum(this Task<IOrderedEnumerable<decimal>> source)
			=> (await source).Sum();

		public static async Task<IEnumerable<TSource>> Take<TSource>(this Task<IOrderedEnumerable<TSource>> source, int count)
			=> (await source).Take(count);

		public static async Task<IEnumerable<TSource>> TakeWhile<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
			=> (await source).TakeWhile(predicate);

		public static async Task<IEnumerable<TSource>> TakeWhile<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, bool> predicate)
			=> (await source).TakeWhile(predicate);

		public static async Task<IOrderedEnumerable<TSource>> ThenBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
			=> (await source).ThenBy(keySelector, comparer);

		public static async Task<IOrderedEnumerable<TSource>> ThenBy<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
			=> (await source).ThenBy(keySelector);

		public static async Task<IOrderedEnumerable<TSource>> ThenByDescending<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
			=> (await source).ThenByDescending(keySelector);

		public static async Task<IOrderedEnumerable<TSource>> ThenByDescending<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
			=> (await source).ThenByDescending(keySelector, comparer);

		public static async Task<TSource[]> ToArray<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).ToArray();

		public static async Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
			=> (await source).ToDictionary(keySelector);

		public static async Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
			=> (await source).ToDictionary(keySelector, comparer);

		public static async Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
			=> (await source).ToDictionary(keySelector, elementSelector);

		public static async Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
			=> (await source).ToDictionary(keySelector, elementSelector, comparer);

		public static async Task<List<TSource>> ToList<TSource>(this Task<IOrderedEnumerable<TSource>> source)
			=> (await source).ToList();

		public static async Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector)
			=> (await source).ToLookup(keySelector);

		public static async Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
			=> (await source).ToLookup(keySelector, comparer);

		public static async Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
			=> (await source).ToLookup(keySelector, elementSelector);

		public static async Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
			=> (await source).ToLookup(keySelector, elementSelector, comparer);

		public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second)
			=> (await first).Union(second);

		public static async Task<IEnumerable<TSource>> Union<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second)
			=> first.Union(await second);

		public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second)
			=> (await first).Union(await second);

		public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
			=> (await first).Union(await second);

		public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second)
			=> (await first).Union(await second);

		public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
			=> (await first).Union(second, comparer);

		public static async Task<IEnumerable<TSource>> Union<TSource>(this IEnumerable<TSource> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> first.Union(await second, comparer);

		public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> (await first).Union(await second, comparer);

		public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> (await first).Union(await second, comparer);

		public static async Task<IEnumerable<TSource>> Union<TSource>(this Task<IOrderedEnumerable<TSource>> first, Task<IOrderedEnumerable<TSource>> second, IEqualityComparer<TSource> comparer)
			=> (await first).Union(await second, comparer);

		public static async Task<IEnumerable<TSource>> Where<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, int, bool> predicate)
			=> (await source).Where(predicate);

		public static async Task<IEnumerable<TSource>> Where<TSource>(this Task<IOrderedEnumerable<TSource>> source, Func<TSource, bool> predicate)
			=> (await source).Where(predicate);

		public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IOrderedEnumerable<TFirst>> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> (await first).Zip(second, resultSelector);

		public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, Task<IOrderedEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> first.Zip(await second, resultSelector);

		public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IOrderedEnumerable<TFirst>> first, Task<IEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> (await first).Zip(await second, resultSelector);

		public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IEnumerable<TFirst>> first, Task<IOrderedEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> (await first).Zip(await second, resultSelector);

		public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(this Task<IOrderedEnumerable<TFirst>> first, Task<IOrderedEnumerable<TSecond>> second, Func<TFirst, TSecond, TResult> resultSelector)
			=> (await first).Zip(await second, resultSelector);
	}
}
