namespace Functional;

public static partial class OptionExtensions
{
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
}
