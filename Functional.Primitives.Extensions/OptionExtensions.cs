using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static partial class OptionExtensions
	{
		public static bool HasValue<TValue>(this Option<TValue> option)
			=> option.Match(DelegateCache<TValue>.True, DelegateCache.False);

		public static async Task<bool> HasValue<TValue>(this Task<Option<TValue>> option)
			=> (await option).HasValue();

		public static Option<TResult> Map<TValue, TResult>(this Option<TValue> option, Func<TValue, TResult> map)
		{
			if (map == null)
				throw new ArgumentNullException(nameof(map));

			if (option.TryGetValue(out var some))
				return Option.Some(map.Invoke(some));

			return Option.None<TResult>();
		}

		public static async Task<Option<TResult>> Map<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, TResult> map)
			=> (await option).Map(map);

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

		public static IEnumerable<TValue> ValueOrEmpty<TValue>(this Option<IEnumerable<TValue>> option)
			=> option.ValueOrDefault(Enumerable.Empty<TValue>());

		public static async Task<IEnumerable<TValue>> ValueOrEmpty<TValue>(this Task<Option<IEnumerable<TValue>>> option)
			=> (await option).ValueOrEmpty();

		public static Option<TValue> BindOnNone<TValue>(this Option<TValue> option, Func<Option<TValue>> bind)
			=> option.TryGetValue(out _) ? option : bind();

		public static async Task<Option<TValue>> BindOnNone<TValue>(this Task<Option<TValue>> option, Func<Option<TValue>> bind)
			=> (await option).BindOnNone(bind);

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

		public static Option<TValue> Do<TValue>(this Option<TValue> option, Action<TValue> @do)
			=> option.Do(@do, DelegateCache.Void);

		public static async Task<Option<TValue>> Do<TValue>(this Task<Option<TValue>> option, Action<TValue> @do)
			=> (await option).Do(@do, DelegateCache.Void);

		public static void Apply<TValue>(this Option<TValue> option, Action<TValue> applyWhenSome, Action applyWhenNone)
			=> option.Do(applyWhenSome, applyWhenNone);

		public static Task Apply<TValue>(this Task<Option<TValue>> option, Action<TValue> applyWhenSome, Action applyWhenNone)
			=> option.Do(applyWhenSome, applyWhenNone);

		public static void Apply<TValue>(this Option<TValue> option, Action<TValue> apply)
			=> option.Do(apply);

		public static Task Apply<TValue>(this Task<Option<TValue>> option, Action<TValue> apply)
			=> option.Do(apply);
	}
}
