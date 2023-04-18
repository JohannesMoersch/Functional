namespace Functional;

public static partial class OptionExtensions
{
	public static Task<TResult> MatchAsync<TValue, TResult>(this Option<TValue> option, Func<TValue, Task<TResult>> some, Func<Task<TResult>> none)
		where TValue : notnull
		=> option.Match(some, none);

	public static async Task<TResult> MatchAsync<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<TResult>> some, Func<Task<TResult>> none)
		where TValue : notnull
		=> await (await option).Match(some, none);

	public static async Task<Option<TResult>> MapAsync<TValue, TResult>(this Option<TValue> option, Func<TValue, Task<TResult>> map)
		where TValue : notnull
		where TResult : notnull
	{
		if (map == null)
			throw new ArgumentNullException(nameof(map));

		if (option.TryGetValue(out var some))
			return Option.Some(await map.Invoke(some));

		return Option.None<TResult>();
	}

	public static async Task<Option<TResult>> MapAsync<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<TResult>> map)
		where TValue : notnull
		where TResult : notnull
		=> await (await option).MapAsync(map);

	public static async Task<Option<TResult>> BindAsync<TValue, TResult>(this Option<TValue> option, Func<TValue, Task<Option<TResult>>> bind)
		where TValue : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (option.TryGetValue(out var some))
			return await bind.Invoke(some);

		return Option.None<TResult>();
	}

	public static async Task<Option<TResult>> BindAsync<TValue, TResult>(this Task<Option<TValue>> option, Func<TValue, Task<Option<TResult>>> bind)
		where TValue : notnull
		where TResult : notnull
		=> await (await option).BindAsync(bind);

	public static async Task<Option<TValue>> BindOnNoneAsync<TValue>(this Option<TValue> option, Func<Task<Option<TValue>>> bind)
		where TValue : notnull
		=> option.TryGetValue(out _) ? option : await bind();

	public static async Task<Option<TValue>> BindOnNoneAsync<TValue>(this Task<Option<TValue>> option, Func<Task<Option<TValue>>> bind)
		where TValue : notnull
		=> await (await option).BindOnNoneAsync(bind);

	public static async Task<TValue> ValueOrDefaultAsync<TValue>(this Option<TValue> option, Func<Task<TValue>> valueFactory)
		where TValue : notnull
		=> option.TryGetValue(out var some) ? some : await valueFactory.Invoke();

	public static async Task<TValue> ValueOrDefaultAsync<TValue>(this Task<Option<TValue>> option, Func<Task<TValue>> valueFactory)
		where TValue : notnull
		=> await (await option).ValueOrDefaultAsync(valueFactory);

	public static async Task<Option<TValue>> WhereAsync<TValue>(this Option<TValue> option, Func<TValue, Task<bool>> predicate)
		where TValue : notnull
	{
		if (predicate == null)
			throw new ArgumentNullException(nameof(predicate));

		if (option.TryGetValue(out var some))
			return Option.Create(await predicate.Invoke(some), some);

		return Option.None<TValue>();
	}

	public static async Task<Option<TValue>> WhereAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task<bool>> predicate)
		where TValue : notnull
		=> await (await option).WhereAsync(predicate);

	public static async Task<Result<TValue, TFailure>> ToResultAsync<TValue, TFailure>(this Option<TValue> option, Func<Task<TFailure>> failureFactory)
		where TValue : notnull
		where TFailure : notnull
	{
		if (failureFactory == null)
			throw new ArgumentNullException(nameof(failureFactory));

		if (option.TryGetValue(out var some))
			return Result.Success<TValue, TFailure>(some);
		
		return Result.Failure<TValue, TFailure>(await failureFactory.Invoke());
	}

	public static async Task<Result<TValue, TFailure>> ToResultAsync<TValue, TFailure>(this Task<Option<TValue>> option, Func<Task<TFailure>> failureFactory)
		where TValue : notnull
		where TFailure : notnull
		=> await (await option).ToResultAsync(failureFactory);

	public static async Task<Option<TValue>> DoAsync<TValue>(this Option<TValue> option, Func<TValue, Task> doWhenSome, Func<Task> doWhenNone)
		where TValue : notnull
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
		where TValue : notnull
		=> await (await option).DoAsync(doWhenSome, doWhenNone);

	public static Task<Option<TValue>> DoAsync<TValue>(this Option<TValue> option, Func<TValue, Task> @do)
		where TValue : notnull
		=> option.DoAsync(@do, static () => Task.CompletedTask);

	public static async Task<Option<TValue>> DoAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task> @do)
		where TValue : notnull
		=> await (await option).DoAsync(@do, static () => Task.CompletedTask);

	public static async Task<Option<TValue>> DoOnNoneAsync<TValue>(this Option<TValue> option, Func<Task> @do)
		where TValue : notnull
		=> await option.DoAsync(static _ => Task.CompletedTask, @do);

	public static async Task<Option<TValue>> DoOnNoneAsync<TValue>(this Task<Option<TValue>> option, Func<Task> @do)
		where TValue : notnull
		=> await (await option).DoOnNoneAsync(@do);

	public static Task ApplyAsync<TValue>(this Option<TValue> option, Func<TValue, Task> applyWhenSome, Func<Task> applyWhenNone)
		where TValue : notnull
		=> option.DoAsync(applyWhenSome, applyWhenNone);

	public static Task ApplyAsync<TValue>(this Task<Option<TValue>> option, Func<TValue, Task> applyWhenSome, Func<Task> applyWhenNone)
		where TValue : notnull
		=> option.DoAsync(applyWhenSome, applyWhenNone);
}
