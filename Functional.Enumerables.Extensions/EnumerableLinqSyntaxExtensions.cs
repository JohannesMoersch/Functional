using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class EnumerableLinqSyntaxExtensions
    {
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> 
			(
				await Task.WhenAll(source
					.Select(item => collectionSelector
						.Invoke(item)
						.Select(value => resultSelector.Invoke(item, value))
					)
				)
			)
			.SelectMany(o => o);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
			=> await (await source).SelectMany(collectionSelector, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=>
			(
				await Task.WhenAll(source
					.Select(item =>
						Task.WhenAll(collectionSelector
							.Invoke(item)
							.Select(value => resultSelector.Invoke(item, value))
						)
					)
				)
			)
			.SelectMany(o => o);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> await (await source).SelectMany(collectionSelector, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=>
			(
				await Task.WhenAll(source
					.Select(async item => 
						await Task.WhenAll(await collectionSelector
							.Invoke(item)
							.Select(value => resultSelector.Invoke(item, value))
						)
					)
				)
			)
			.SelectMany(o => o);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
			=> await (await source).SelectMany(collectionSelector, resultSelector);
	}
}
