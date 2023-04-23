namespace Functional;

public static partial class OptionExtensions
{
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
}
