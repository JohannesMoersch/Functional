using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class AsyncEnumerableExtensions
	{
		public static async Task ApplyAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			foreach (var item in source)
				await action.Invoke(item);
		}

		public static async Task ApplyAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, int, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			var index = 0;
			foreach (var item in source)
				await action.Invoke(item, index++);
		}

		public static async Task ApplyAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			foreach (var item in await source)
				await action.Invoke(item);
		}

		public static async Task ApplyAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, int, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			var index = 0;
			foreach (var item in await source)
				await action.Invoke(item, index++);
		}
	}
}
