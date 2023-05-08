using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Functional;

public static partial class EnumerableExtensions
{
	public static IEnumerable<TSource> Do<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
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

	public static IEnumerable<TSource> Do<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		return source
			.Select((item, index) =>
			{
				action.Invoke(item, index);
				return item;
			});
	}

	public static Task<IEnumerable<TSource>> Do<TSource>(this Task<IEnumerable<TSource>> source, Action<TSource> action)
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

	public static Task<IEnumerable<TSource>> Do<TSource>(this Task<IEnumerable<TSource>> source, Action<TSource, int> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		return source
			.Select((item, index) =>
			{
				action.Invoke(item, index);
				return item;
			});
	}

	public static Task<IEnumerable<TSource>> Do<TSource>(this Task<IOrderedEnumerable<TSource>> source, Action<TSource> action)
		=> source.AsEnumerable().Do(action);


	public static Task<IEnumerable<TSource>> Do<TSource>(this Task<IOrderedEnumerable<TSource>> source, Action<TSource, int> action)
		=> source.AsEnumerable().Do(action);

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

	public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource, int> action)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));

		return source
			.Select((item, index) =>
			{
				action.Invoke(item, index);
				return item;
			});
	}
}
