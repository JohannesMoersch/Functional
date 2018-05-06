using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static class OptionExtensions
	{
		public static bool HasValue<TValue>(this Option<TValue> option)
			=> option.Match(_ => true, () => false);

		public static async Task<bool> HasValue<TValue>(this Task<Option<TValue>> option)
			=> (await option).HasValue();

		public static Option<TResult> Select<TValue, TResult>(this Option<TValue> option, Func<TValue, TResult> select)
		{
			if (select == null)
				throw new ArgumentNullException(nameof(select));

			return option.Match(value => Option.Some(select.Invoke(value)), Option.None<TResult>);
		}

		public static async Task<Option<TResult>> Select<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, TResult> select)
			=> (await option).Select(select);

		public static Option<TResult> Bind<TValue, TResult>(this Option<TValue> option, Func<TValue, Option<TResult>> bind)
			=> option.Match(bind, Option.None<TResult>);

		public static async Task<Option<TResult>> Bind<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Option<TResult>> bind)
			=> (await option).Bind(bind);

		public static TValue ValueOrDefault<TValue>(this Option<TValue> option, TValue defaultValue = default(TValue))
			=> option.Match(value => value, () => defaultValue);

		public static async Task<TValue> ValueOrDefault<TValue>(this Task<Option<TValue>> option, TValue defaultValue = default(TValue))
			=> (await option).ValueOrDefault(defaultValue);

		public static Option<TValue> DefaultIfNone<TValue>(this Option<TValue> option, TValue defaultValue = default(TValue))
			=> option.Match(Option.Some, () => Option.Some(defaultValue));

		public static async Task<Option<TValue>> DefaultIfNone<TValue>(this Task<Option<TValue>> option, TValue defaultValue = default(TValue))
			=> (await option).DefaultIfNone(defaultValue);

		public static Option<TValue> OfType<TValue>(this Option<object> option)
			=> option.Match(value => Option.Create(value is TValue, () => (TValue)value), Option.None<TValue>);

		public static async Task<Option<TValue>> OfType<TValue>(this Task<Option<object>> option)
			=> (await option).OfType<TValue>();

		public static Option<TValue> Where<TValue>(this Option<TValue> option, Func<TValue, bool> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			return option.Match(value => Option.Create(predicate.Invoke(value), value), Option.None<TValue>);
		}

		public static async Task<Option<TValue>> Where<TValue>(this Task<Option<TValue>> option, Func<TValue, bool> predicate)
			=> (await option).Where(predicate);

		public static TValue? ToNullable<TValue>(this Option<TValue> option)
			where TValue : struct
			=> option.Match(value => (TValue?)value, () => null);

		public static async Task<TValue?> ToNullable<TValue>(this Task<Option<TValue>> option)
			where TValue : struct
			=> (await option).ToNullable();

		public static Result<TValue, TFailure> ToResult<TValue, TFailure>(this Option<TValue> option, Func<TFailure> failureFactory)
		{
			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			return option.Match(Result.Success<TValue, TFailure>, () => Result.Failure<TValue, TFailure>(failureFactory.Invoke()));
		}

		public static async Task<Result<TValue, TFailure>> ToResult<TValue, TFailure>(this Task<Option<TValue>> option, Func<TFailure> failureFactory)
			=> (await option).ToResult(failureFactory);

		public static Option<TValue> Do<TValue>(this Option<TValue> option, Action<TValue> @do)
		{
			if (@do == null)
				throw new ArgumentNullException(nameof(@do));

			return option.Match(value =>
				{
					@do.Invoke(value);
					return option;
				}, () => option);
		}

		public static async Task<Option<TValue>> Do<TValue>(this Task<Option<TValue>> option, Action<TValue> @do)
			=> (await option).Do(@do);

		public static void Apply<TValue>(this Option<TValue> option, Action<TValue> apply)
			=> option.Do(apply);

		public static Task Apply<TValue>(this Task<Option<TValue>> option, Action<TValue> apply)
			=> option.Do(apply);

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

			return option.Match(
				value => bind
					.Invoke(value)
					.Match(obj => Option.Some(resultSelector.Invoke(value, obj)), Option.None<TResult>),
				() => Task.FromResult(Option.None<TResult>())
			);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static async Task<Option<TResult>> SelectMany<TValue, TBind, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<Option<TBind>>> bind, Func<TValue, TBind, TResult> resultSelector)
			=> await (await option).SelectMany(bind, resultSelector);
	}
}
