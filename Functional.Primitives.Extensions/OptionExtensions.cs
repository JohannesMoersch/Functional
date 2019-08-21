using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class OptionExtensions
	{
		public static bool HasValue<TValue>(this Option<TValue> option)
			=> option.Match(Helpers.ValueToTrue<TValue>.Value, Helpers.False.Value);

		public static async Task<bool> HasValue<TValue>(this Task<Option<TValue>> option)
			=> (await option).HasValue();

		public static Option<TResult> Select<TValue, TResult>(this Option<TValue> option, Func<TValue, TResult> select)
		{
			if (select == null)
				throw new ArgumentNullException(nameof(select));

			if (option.TryGetValue(out var some))
				return Option.Some(select.Invoke(some));

			return Option.None<TResult>();
		}

		public static async Task<Option<TResult>> Select<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, TResult> select)
			=> (await option).Select(select);

		public static Option<TResult> Bind<TValue, TResult>(this Option<TValue> option, Func<TValue, Option<TResult>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (option.TryGetValue(out var some))
				return bind.Invoke(some);
			
			return Option.None<TResult>();
		}

		public static async Task<Option<TResult>> Bind<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Option<TResult>> bind)
			=> (await option).Bind(bind);

		public static TValue ValueOrDefault<TValue>(this Option<TValue> option, TValue defaultValue = default)
			=> option.TryGetValue(out var some) ? some : defaultValue;

		public static async Task<TValue> ValueOrDefault<TValue>(this Task<Option<TValue>> option, TValue defaultValue = default)
			=> (await option).ValueOrDefault(defaultValue);

		public static TValue? ValueOrNull<TValue>(this Option<TValue> option)
			where TValue : struct
			=> option.TryGetValue(out var some) ? (TValue?)some : null;

		public static async Task<TValue?> ValueOrNull<TValue>(this Task<Option<TValue>> option)
			where TValue : struct
			=> (await option).ValueOrNull();

		public static Option<TValue> DefaultIfNone<TValue>(this Option<TValue> option, TValue defaultValue = default)
			=> option.TryGetValue(out var some) ? Option.Some(some) : Option.Some(defaultValue);

		public static async Task<Option<TValue>> DefaultIfNone<TValue>(this Task<Option<TValue>> option, TValue defaultValue = default)
			=> (await option).DefaultIfNone(defaultValue);

		public static Option<TValue> OfType<TValue>(this Option<object> option)
			=> option.TryGetValue(out var some) ? (some is TValue value ? Option.Some(value) : Option.None<TValue>()) : Option.None<TValue>();

		public static async Task<Option<TValue>> OfType<TValue>(this Task<Option<object>> option)
			=> (await option).OfType<TValue>();

		public static Option<TValue> Where<TValue>(this Option<TValue> option, Func<TValue, bool> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			if (option.TryGetValue(out var some))
				return Option.Create(predicate.Invoke(some), some);

			return Option.None<TValue>();
		}

		public static async Task<Option<TValue>> Where<TValue>(this Task<Option<TValue>> option, Func<TValue, bool> predicate)
			=> (await option).Where(predicate);

		public static TValue? ToNullable<TValue>(this Option<TValue> option)
			where TValue : struct
			=> option.TryGetValue(out var some) ? (TValue?)some : null;

		public static async Task<TValue?> ToNullable<TValue>(this Task<Option<TValue>> option)
			where TValue : struct
			=> (await option).ToNullable();

		public static Result<TValue, TFailure> ToResult<TValue, TFailure>(this Option<TValue> option, Func<TFailure> failureFactory)
		{
			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			if (option.TryGetValue(out var some))
				return Result.Success<TValue, TFailure>(some);

			return Result.Failure<TValue, TFailure>(failureFactory.Invoke());
		}

		public static async Task<Result<TValue, TFailure>> ToResult<TValue, TFailure>(this Task<Option<TValue>> option, Func<TFailure> failureFactory)
			=> (await option).ToResult(failureFactory);

		public static Option<TValue> Do<TValue>(this Option<TValue> option, Action<TValue> @do)
		{
			if (@do == null)
				throw new ArgumentNullException(nameof(@do));

			if (option.TryGetValue(out var some))
				@do.Invoke(some);

			return option;
		}

		public static async Task<Option<TValue>> Do<TValue>(this Task<Option<TValue>> option, Action<TValue> @do)
			=> (await option).Do(@do);

		public static void Apply<TValue>(this Option<TValue> option, Action<TValue> apply)
			=> option.Do(apply);

		public static Task Apply<TValue>(this Task<Option<TValue>> option, Action<TValue> apply)
			=> option.Do(apply);

		public static Option<TValue> Do<TValue>(this Option<TValue> option, Action<TValue> doWhenSome, Action doWhenNone)
		{
			if (doWhenSome == null)
				throw new ArgumentNullException(nameof(doWhenSome));

			if (doWhenNone == null)
				throw new ArgumentNullException(nameof(doWhenNone));

			if (option.TryGetValue(out var some))
				doWhenSome.Invoke(some);
			else
				doWhenNone.Invoke();

			return option;
		}

		public static async Task<Option<TValue>> Do<TValue>(this Task<Option<TValue>> option, Action<TValue> doWhenSome, Action doWhenNone)
			=> (await option).Do(doWhenSome, doWhenNone);

		public static void Apply<TValue>(this Option<TValue> option, Action<TValue> applyWhenSome, Action applyWhenNone)
			=> option.Do(applyWhenSome, applyWhenNone);

		public static Task Apply<TValue>(this Task<Option<TValue>> option, Action<TValue> applyWhenSome, Action applyWhenNone)
			=> option.Do(applyWhenSome, applyWhenNone);
	}
}
