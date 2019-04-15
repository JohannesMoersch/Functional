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
		public static IAsyncEnumerable<T> Do<T>(this IAsyncEnumerable<T> source, Action<T> action)
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

		public static IAsyncEnumerable<T> DoAsync<T>(this IAsyncEnumerable<T> source, Func<T, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			return source
				.SelectAsync(async item =>
				{
					await action.Invoke(item);
					return item;
				});
		}

		public static async Task Apply<T>(this IAsyncEnumerable<T> source, Action<T> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			var enumerator = source.GetEnumerator();

			while (await enumerator.MoveNext())
				action.Invoke(enumerator.Current);
		}

		public static async Task ApplyAsync<T>(this IAsyncEnumerable<T> source, Func<T, Task> action)
		{
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			var enumerator = source.GetEnumerator();

			while (await enumerator.MoveNext())
				await action.Invoke(enumerator.Current);
		}
	}
}
