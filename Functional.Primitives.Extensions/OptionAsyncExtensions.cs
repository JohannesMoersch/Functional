using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static class OptionAsyncExtensions
	{
		public static Task<Option<TResult>> SelectAsync<TValue, TResult>(this Option<TValue> option, Func<TValue, Task<TResult>> select)
		{
			if (select == null)
				throw new ArgumentNullException(nameof(select));

			return option.Match(async value => Option.Some(await select.Invoke(value)), () => Task.FromResult(Option.None<TResult>()));
		}

		public static async Task<Option<TResult>> SelectAsync<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<TResult>> select)
			=> await (await option).SelectAsync(select);

		public static Task<Option<TResult>> BindAsync<TValue, TResult>(this Option<TValue> option, Func<TValue, Task<Option<TResult>>> bind)
			=> option.Match(bind, () => Task.FromResult(Option.None<TResult>()));

		public static async Task<Option<TResult>> BindAsync<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<Option<TResult>>> bind)
			=> await (await option).BindAsync(bind);

		public static Task<Option<TValue>> WhereAsync<TValue>(this Option<TValue> option, Func<TValue, Task<bool>> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			return option.Match(async value => Option.Create(await predicate.Invoke(value), value), () => Task.FromResult(Option.None<TValue>()));
		}

		public static async Task<Option<TValue>> WhereAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task<bool>> predicate)
			=> await (await option).WhereAsync(predicate);

		public static Task<Result<TValue, TFailure>> ToResultAsync<TValue, TFailure>(this Option<TValue> option, Func<Task<TFailure>> failureFactory)
		{
			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			return option.Match(value => Task.FromResult(Result.Success<TValue, TFailure>(value)), async () => Result.Failure<TValue, TFailure>(await failureFactory.Invoke()));
		}

		public static async Task<Result<TValue, TFailure>> ToResultAsync<TValue, TFailure>(this Task<Option<TValue>> option, Func<Task<TFailure>> failureFactory)
			=> await (await option).ToResultAsync(failureFactory);

		public static Task<Option<TValue>> DoAsync<TValue>(this Option<TValue> option, Func<TValue, Task> @do)
		{
			if (@do == null)
				throw new ArgumentNullException(nameof(@do));

			return option.Match(async value =>
				{
					await @do.Invoke(value);
					return option;
				}, () => Task.FromResult(option));
		}

		public static async Task<Option<TValue>> DoAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task> @do)
			=> await (await option).DoAsync(@do);

		public static Task ApplyAsync<TValue>(this Option<TValue> option, Func<TValue, Task> apply)
			=> option.DoAsync(apply);

		public static Task ApplyAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task> apply)
			=> option.DoAsync(apply);

		public static Task<Option<TResult>> UnwrapAndBindAsync<TValue, TResult>(this Option<Task<TValue>> option, Func<TValue, Task<Option<TResult>>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			return option.Match(async t => await bind.Invoke(await t), () => Task.FromResult(Option.None<TResult>()));
		}

		public static Task<Option<TResult>> UnwrapAndBindAsync<TValue, TResult>(this Task<Option<Task<TValue>>> option, Func<TValue, Task<Option<TResult>>> bind)
		{
			if (bind == null)
				throw new ArgumentNullException(nameof(bind));

			return option.Match(async t => await bind.Invoke(await t), () => Task.FromResult(Option.None<TResult>())).Unwrap();
		}
	}
}
