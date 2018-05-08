using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class OptionLinqSyntaxExtensions
    {
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Option<TResult> SelectMany<TValue, TResult>(this Option<TValue> option, Func<TValue, Option<TResult>> bind)
			=> option.Match(bind, Option.None<TResult>);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<TResult>> SelectMany<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Option<TResult>> bind)
			=> (await option).SelectMany(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Option<TResult> SelectMany<TValue, TBind, TResult>(this Option<TValue> option, Func<TValue, Option<TBind>> bind, Func<TValue, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return option.Match(
				value => bind
					.Invoke(value)
					.Match(obj => Option.Some(resultSelector.Invoke(value, obj)), Option.None<TResult>),
				Option.None<TResult>
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<TResult>> SelectMany<TValue, TBind, TResult>(this Task<Option<TValue>> option, Func<TValue, Option<TBind>> bind, Func<TValue, TBind, TResult> resultSelector)
			=> (await option).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Option<TResult>> SelectMany<TValue, TBind, TResult>(this Option<TValue> option, Func<TValue, Task<Option<TBind>>> bind, Func<TValue, TBind, TResult> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return option.MatchAsync(
				value => bind
					.Invoke(value)
					.Match(obj => Option.Some(resultSelector.Invoke(value, obj)), Option.None<TResult>),
				() => Task.FromResult(Option.None<TResult>())
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<TResult>> SelectMany<TValue, TBind, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<Option<TBind>>> bind, Func<TValue, TBind, TResult> resultSelector)
			=> await (await option).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Option<TResult>> SelectMany<TValue, TResult>(this Option<TValue> option, Func<TValue, Task<Option<TResult>>> bind)
			=> option.MatchAsync(bind, () => Task.FromResult(Option.None<TResult>()));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<TResult>> SelectMany<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<Option<TResult>>> bind)
			=> await (await option).SelectMany(bind);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Option<TResult>> SelectMany<TValue, TBind, TResult>(this Option<TValue> option, Func<TValue, Option<TBind>> bind, Func<TValue, TBind, Task<TResult>> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return option.MatchAsync(
				value => bind
					.Invoke(value)
					.MatchAsync(obj => Option.Some(resultSelector.Invoke(value, obj)), () => Task.FromResult(Option.None<TResult>())),
				() => Task.FromResult(Option.None<TResult>())
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<TResult>> SelectMany<TValue, TBind, TResult>(this Task<Option<TValue>> option, Func<TValue, Option<TBind>> bind, Func<TValue, TBind, Task<TResult>> resultSelector)
			=> await (await option).SelectMany(bind, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Option<TResult>> SelectMany<TValue, TBind, TResult>(this Option<TValue> option, Func<TValue, Task<Option<TBind>>> bind, Func<TValue, TBind, Task<TResult>> resultSelector)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return option.MatchAsync(
				value => bind
					.Invoke(value)
					.MatchAsync(obj => Option.Some(resultSelector.Invoke(value, obj)), () => Task.FromResult(Option.None<TResult>())),
				() => Task.FromResult(Option.None<TResult>())
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<TResult>> SelectMany<TValue, TBind, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<Option<TBind>>> bind, Func<TValue, TBind, Task<TResult>> resultSelector)
			=> await (await option).SelectMany(bind, resultSelector);
	}
}
