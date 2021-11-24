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
			where TValue : notnull
			=> option.Match(DelegateCache<TValue>.True, DelegateCache.False);

		public static async Task<bool> HasValue<TValue>(this Task<Option<TValue>> option)
			where TValue : notnull
			=> (await option).HasValue();

		public static Option<TResult> Map<TValue, TResult>(this Option<TValue> option, Func<TValue, TResult> map)
			where TValue : notnull
			where TResult : notnull
		{
			if (map == null)
				throw new ArgumentNullException(nameof(map));

			if (option.TryGetValue(out var some))
				return Option.Some(map.Invoke(some));

			return Option.None<TResult>();
		}

		public static async Task<Option<TResult>> Map<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, TResult> map)
			where TValue : notnull
			where TResult : notnull
			=> (await option).Map(map);

		public static Option<TResult> Bind<TValue, TResult>(this Option<TValue> option, Func<TValue, Option<TResult>> bind)
			where TValue : notnull
			where TResult : notnull
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (option.TryGetValue(out var some))
				return bind.Invoke(some);
			
			return Option.None<TResult>();
		}

		public static async Task<Option<TResult>> Bind<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Option<TResult>> bind)
			where TValue : notnull
			where TResult : notnull
			=> (await option).Bind(bind);

		public static TValue? ValueOrDefault<TValue>(this Option<TValue> option)
			where TValue : notnull
			=> option.TryGetValue(out var some) ? some : default;

		public static TValue ValueOrDefault<TValue>(this Option<TValue> option, TValue defaultValue)
			where TValue : notnull
			=> option.TryGetValue(out var some) ? some : defaultValue;

		public static async Task<TValue?> ValueOrDefault<TValue>(this Task<Option<TValue>> option)
			where TValue : notnull
			=> (await option).ValueOrDefault();

		public static async Task<TValue> ValueOrDefault<TValue>(this Task<Option<TValue>> option, TValue defaultValue)
			where TValue : notnull
			=> (await option).ValueOrDefault(defaultValue);

		public static TValue ValueOrDefault<TValue>(this Option<TValue> option, Func<TValue> valueFactory)
			where TValue : notnull
			=> option.TryGetValue(out var some) ? some : valueFactory.Invoke();

		public static async Task<TValue> ValueOrDefault<TValue>(this Task<Option<TValue>> option, Func<TValue> valueFactory)
			where TValue : notnull
			=> (await option).ValueOrDefault(valueFactory);
    
		public static IEnumerable<TValue> ValueOrEmpty<TValue>(this Option<IEnumerable<TValue>> option)
			=> option.ValueOrDefault(Enumerable.Empty<TValue>());

		public static async Task<IEnumerable<TValue>> ValueOrEmpty<TValue>(this Task<Option<IEnumerable<TValue>>> option)
			=> (await option).ValueOrEmpty();

		public static Option<TValue> BindOnNone<TValue>(this Option<TValue> option, Func<Option<TValue>> bind)
			where TValue : notnull
			=> option.TryGetValue(out _) ? option : bind();

		public static async Task<Option<TValue>> BindOnNone<TValue>(this Task<Option<TValue>> option, Func<Option<TValue>> bind)
			where TValue : notnull
			=> (await option).BindOnNone(bind);

		public static Option<TValue> OfType<TValue>(this Option<object> option)
			where TValue : notnull
			=> option.TryGetValue(out var some) ? (some is TValue value ? Option.Some(value) : Option.None<TValue>()) : Option.None<TValue>();

		public static async Task<Option<TValue>> OfType<TValue>(this Task<Option<object>> option)
			where TValue : notnull
			=> (await option).OfType<TValue>();

		public static Option<TValue> Where<TValue>(this Option<TValue> option, Func<TValue, bool> predicate)
			where TValue : notnull
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			if (option.TryGetValue(out var some))
				return Option.Create(predicate.Invoke(some), some);

			return Option.None<TValue>();
		}

		public static async Task<Option<TValue>> Where<TValue>(this Task<Option<TValue>> option, Func<TValue, bool> predicate)
			where TValue : notnull
			=> (await option).Where(predicate);

		public static TValue? ToNullable<TValue>(this Option<TValue> option)
			where TValue : struct
			=> option.TryGetValue(out var some) ? (TValue?)some : null;

		public static async Task<TValue?> ToNullable<TValue>(this Task<Option<TValue>> option)
			where TValue : struct
			=> (await option).ToNullable();

		public static Result<TValue, TFailure> ToResult<TValue, TFailure>(this Option<TValue> option, Func<TFailure> failureFactory)
			where TValue : notnull
			where TFailure : notnull
		{
			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			if (option.TryGetValue(out var some))
				return Result.Success<TValue, TFailure>(some);

			return Result.Failure<TValue, TFailure>(failureFactory.Invoke());
		}

		public static async Task<Result<TValue, TFailure>> ToResult<TValue, TFailure>(this Task<Option<TValue>> option, Func<TFailure> failureFactory)
			where TValue : notnull
			where TFailure : notnull
			=> (await option).ToResult(failureFactory);

		public static Option<TValue> Do<TValue>(this Option<TValue> option, Action<TValue> doWhenSome, Action doWhenNone)
			where TValue : notnull
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
			where TValue : notnull
			=> (await option).Do(doWhenSome, doWhenNone);

		public static Option<TValue> Do<TValue>(this Option<TValue> option, Action<TValue> @do)
			where TValue : notnull
			=> option.Do(@do, DelegateCache.Void);

		public static async Task<Option<TValue>> Do<TValue>(this Task<Option<TValue>> option, Action<TValue> @do)
			where TValue : notnull
			=> (await option).Do(@do, DelegateCache.Void);

		public static Option<TValue> DoOnNone<TValue>(this Option<TValue> option, Action @do)
			where TValue : notnull
			=> option.Do(DelegateCache<TValue>.Void, @do);

		public static async Task<Option<TValue>> DoOnNone<TValue>(this Task<Option<TValue>> option, Action @do)
			where TValue : notnull
			=> (await option).DoOnNone(@do);

		public static void Apply<TValue>(this Option<TValue> option, Action<TValue> applyWhenSome, Action applyWhenNone)
			where TValue : notnull
			=> option.Do(applyWhenSome, applyWhenNone);

		public static Task Apply<TValue>(this Task<Option<TValue>> option, Action<TValue> applyWhenSome, Action applyWhenNone)
			where TValue : notnull
			=> option.Do(applyWhenSome, applyWhenNone);

		[AllowAllocations]
		public static IEnumerable<T> ToEnumerable<T>(this Option<T> option)
			where T : notnull
			=> option.TryGetValue(out var value) ? new[] { value } : Enumerable.Empty<T>();

		public static async Task<IEnumerable<T>> ToEnumerable<T>(this Task<Option<T>> option)
			where T : notnull
			=> (await option).ToEnumerable();

		[AllowAllocations]
		public static T[] ToArray<T>(this Option<T> option)
			where T : notnull
			=> option.TryGetValue(out var value) ? new [] { value } : Array.Empty<T>();

		public static async Task<T[]> ToArray<T>(this Task<Option<T>> option)
			where T : notnull
			=> (await option).ToArray();

		public static TValue ThrowOnNone<TValue>(this Option<TValue> option, Func<Exception> exceptionFactory)
			where TValue : notnull
			=> option.TryGetValue(out var some) ? some : throw exceptionFactory.Invoke();

		public static async Task<TValue> ThrowOnNone<TValue>(this Task<Option<TValue>> option, Func<Exception> exceptionFactory)
			where TValue : notnull
			=> (await option).ThrowOnNone(exceptionFactory);
	}
}
