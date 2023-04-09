using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static partial class OptionExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Option<TResult> Select<TValue, TResult>(this Option<TValue> option, Func<TValue, TResult> selector)
			where TValue : notnull
			where TResult : notnull
			=> option.Map(selector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Option<TResult>> Select<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, TResult> selector)
			where TValue : notnull
			where TResult : notnull
			=> option.Map(selector);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class OptionLinqSyntaxExtensions
    {
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Option<TResult> SelectMany<TValue, TBind, TResult>(this Option<TValue> option, Func<TValue, Option<TBind>> bind, Func<TValue, TBind, TResult> resultSelector)
			where TValue : notnull
			where TBind : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			if (option.TryGetValue(out var some) && bind.Invoke(some).TryGetValue(out var result))
				return Option.Some(resultSelector.Invoke(some, result));

			return Option.None<TResult>();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<TResult>> SelectMany<TValue, TBind, TResult>(this Task<Option<TValue>> option, Func<TValue, Option<TBind>> bind, Func<TValue, TBind, TResult> resultSelector)
			where TValue : notnull
			where TBind : notnull
			where TResult : notnull
			=> (await option).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<TResult>> SelectMany<TValue, TBind, TResult>(this Option<TValue> option, Func<TValue, Task<Option<TBind>>> bind, Func<TValue, TBind, TResult> resultSelector)
			where TValue : notnull
			where TBind : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			if (option.TryGetValue(out var some) && (await bind.Invoke(some)).TryGetValue(out var result))
				return Option.Some(resultSelector.Invoke(some, result));

			return Option.None<TResult>();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<TResult>> SelectMany<TValue, TBind, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<Option<TBind>>> bind, Func<TValue, TBind, TResult> resultSelector)
			where TValue : notnull
			where TBind : notnull
			where TResult : notnull
			=> await (await option).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<TResult>> SelectMany<TValue, TBind, TResult>(this Option<TValue> option, Func<TValue, Option<TBind>> bind, Func<TValue, TBind, Task<TResult>> resultSelector)
			where TValue : notnull
			where TBind : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			if (option.TryGetValue(out var some) && bind.Invoke(some).TryGetValue(out var result))
				return Option.Some(await resultSelector.Invoke(some, result));

			return Option.None<TResult>();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<TResult>> SelectMany<TValue, TBind, TResult>(this Task<Option<TValue>> option, Func<TValue, Option<TBind>> bind, Func<TValue, TBind, Task<TResult>> resultSelector)
			where TValue : notnull
			where TBind : notnull
			where TResult : notnull
			=> await (await option).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<TResult>> SelectMany<TValue, TBind, TResult>(this Option<TValue> option, Func<TValue, Task<Option<TBind>>> bind, Func<TValue, TBind, Task<TResult>> resultSelector)
			where TValue : notnull
			where TBind : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			if (option.TryGetValue(out var some) && (await bind.Invoke(some)).TryGetValue(out var result))
				return Option.Some(await resultSelector.Invoke(some, result));

			return Option.None<TResult>();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<TResult>> SelectMany<TValue, TBind, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<Option<TBind>>> bind, Func<TValue, TBind, Task<TResult>> resultSelector)
			where TValue : notnull
			where TBind : notnull
			where TResult : notnull
			=> await (await option).SelectMany(bind, resultSelector);
	}
}
