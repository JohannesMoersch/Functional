using System;
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
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			foreach (var item in source)
			{
				foreach (var innerItem in collectionSelector.Invoke(item))
					yield return await resultSelector.Invoke(item, innerItem);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			foreach (var item in source)
			{
				foreach (var innerItem in await collectionSelector.Invoke(item))
					yield return resultSelector.Invoke(item, innerItem);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			foreach (var item in source)
			{
				foreach (var innerItem in await collectionSelector.Invoke(item))
					yield return await resultSelector.Invoke(item, innerItem);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			foreach (var item in source)
			{
				await foreach (var innerItem in collectionSelector.Invoke(item))
					yield return resultSelector.Invoke(item, innerItem);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			foreach (var item in source)
			{
				await foreach (var innerItem in collectionSelector.Invoke(item))
					yield return await resultSelector.Invoke(item, innerItem);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			foreach (var item in await source)
			{
				foreach (var innerItem in collectionSelector.Invoke(item))
					yield return await resultSelector.Invoke(item, innerItem);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			foreach (var item in await source)
			{
				foreach (var innerItem in await collectionSelector.Invoke(item))
					yield return resultSelector.Invoke(item, innerItem);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			foreach (var item in await source)
			{
				foreach (var innerItem in await collectionSelector.Invoke(item))
					yield return await resultSelector.Invoke(item, innerItem);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			foreach (var item in await source)
			{
				await foreach (var innerItem in collectionSelector.Invoke(item))
					yield return resultSelector.Invoke(item, innerItem);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this Task<IEnumerable<TSource>> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			foreach (var item in await source)
			{
				await foreach (var innerItem in collectionSelector.Invoke(item))
					yield return await resultSelector.Invoke(item, innerItem);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			await foreach (var item in source)
			{
				foreach (var innerItem in collectionSelector.Invoke(item))
					yield return resultSelector.Invoke(item, innerItem);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			await foreach (var item in source)
			{
				foreach (var innerItem in collectionSelector.Invoke(item))
					yield return await resultSelector.Invoke(item, innerItem);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			await foreach (var item in source)
			{
				foreach (var innerItem in await collectionSelector.Invoke(item))
					yield return resultSelector.Invoke(item, innerItem);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<IEnumerable<TCollection>>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			await foreach (var item in source)
			{
				foreach (var innerItem in await collectionSelector.Invoke(item))
					yield return await resultSelector.Invoke(item, innerItem);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			await foreach (var item in source)
			{
				await foreach (var innerItem in collectionSelector.Invoke(item))
					yield return resultSelector.Invoke(item, innerItem);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async IAsyncEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, Task<TResult>> resultSelector)
		{
			if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
			if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));

			await foreach (var item in source)
			{
				await foreach (var innerItem in collectionSelector.Invoke(item))
					yield return await resultSelector.Invoke(item, innerItem);
			}
		}
	}
}
