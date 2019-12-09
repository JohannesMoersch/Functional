using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class OptionAsyncExtensions
	{
		public static async Task<Option<TResult>> MapAsync<TValue, TResult>(this Option<TValue> option, Func<TValue, Task<TResult>> map)
		{
			if (map == null)
				throw new ArgumentNullException(nameof(map));

			if (option.TryGetValue(out var some))
				return Option.Some(await map.Invoke(some));

			return Option.None<TResult>();
		}

		public static async Task<Option<TResult>> MapAsync<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<TResult>> map)
			=> await (await option).MapAsync(map);

		public static async Task<Option<TResult>> BindAsync<TValue, TResult>(this Option<TValue> option, Func<TValue, Task<Option<TResult>>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			if (option.TryGetValue(out var some))
				return await bind.Invoke(some);

			return Option.None<TResult>();
		}

		public static async Task<Option<TResult>> BindAsync<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<Option<TResult>>> bind)
			=> await (await option).BindAsync(bind);

		public static async Task<Option<TValue>> BindIfNoneAsync<TValue>(this Option<TValue> option, Func<Task<Option<TValue>>> bind)
			=> option.TryGetValue(out _) ? option : await bind();

		public static async Task<Option<TValue>> BindIfNoneAsync<TValue>(this Task<Option<TValue>> option, Func<Task<Option<TValue>>> bind)
			=> await (await option).BindIfNoneAsync(bind);

		public static async Task<Option<TValue>> WhereAsync<TValue>(this Option<TValue> option, Func<TValue, Task<bool>> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			if (option.TryGetValue(out var some))
				return Option.Create(await predicate.Invoke(some), some);

			return Option.None<TValue>();
		}

		public static async Task<Option<TValue>> WhereAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task<bool>> predicate)
			=> await (await option).WhereAsync(predicate);

		public static async Task<Result<TValue, TFailure>> ToResultAsync<TValue, TFailure>(this Option<TValue> option, Func<Task<TFailure>> failureFactory)
		{
			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			if (option.TryGetValue(out var some))
				return Result.Success<TValue, TFailure>(some);
			
			return Result.Failure<TValue, TFailure>(await failureFactory.Invoke());
		}

		public static async Task<Result<TValue, TFailure>> ToResultAsync<TValue, TFailure>(this Task<Option<TValue>> option, Func<Task<TFailure>> failureFactory)
			=> await (await option).ToResultAsync(failureFactory);

		public static async Task<Option<TValue>> DoAsync<TValue>(this Option<TValue> option, Func<TValue, Task> doWhenSome, Func<Task> doWhenNone)
		{
			if (doWhenSome == null)
				throw new ArgumentNullException(nameof(doWhenSome));

			if (doWhenNone == null)
				throw new ArgumentNullException(nameof(doWhenNone));

			if (option.TryGetValue(out var some))
				await doWhenSome.Invoke(some);
			else
				await doWhenNone.Invoke();

			return option;
		}

		public static async Task<Option<TValue>> DoAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task> doWhenSome, Func<Task> doWhenNone)
			=> await (await option).DoAsync(doWhenSome, doWhenNone);

		public static Task<Option<TValue>> DoAsync<TValue>(this Option<TValue> option, Func<TValue, Task> @do)
			=> option.DoAsync(@do, DelegateCache.Task);

		public static async Task<Option<TValue>> DoAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task> @do)
			=> await (await option).DoAsync(@do, DelegateCache.Task);

		public static Task ApplyAsync<TValue>(this Option<TValue> option, Func<TValue, Task> applyWhenSome, Func<Task> applyWhenNone)
			=> option.DoAsync(applyWhenSome, applyWhenNone);

		public static Task ApplyAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task> applyWhenSome, Func<Task> applyWhenNone)
			=> option.DoAsync(applyWhenSome, applyWhenNone);

		public static Task ApplyAsync<TValue>(this Option<TValue> option, Func<TValue, Task> apply)
			=> option.DoAsync(apply);

		public static Task ApplyAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task> apply)
			=> option.DoAsync(apply);
	}
}
