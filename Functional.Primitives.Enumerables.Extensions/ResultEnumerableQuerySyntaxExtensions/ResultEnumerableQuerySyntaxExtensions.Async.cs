namespace Functional;

public static partial class ResultEnumerableQuerySyntaxExtensions
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IEnumerable<TSuccess> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TFailure : notnull
		where TBind : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.AsAsyncEnumerable()
			.SelectAsync(value => bind
				.Invoke(value)
				.MapAsync(success => resultSelector.Invoke(value, success))
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IEnumerable<TSuccess> source, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TFailure : notnull
		where TBind : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.AsAsyncEnumerable()
			.SelectAsync(value => bind
				.Invoke(value)
				.MapAsync(success => resultSelector.Invoke(value, success))
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<IEnumerable<TSuccess>> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TFailure : notnull
		where TBind : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.AsAsyncEnumerable()
			.SelectAsync(value => bind
				.Invoke(value)
				.MapAsync(success => resultSelector.Invoke(value, success))
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<IEnumerable<TSuccess>> source, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TFailure : notnull
		where TBind : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.AsAsyncEnumerable()
			.SelectAsync(value => bind
				.Invoke(value)
				.MapAsync(success => resultSelector.Invoke(value, success))
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IAsyncEnumerable<TSuccess> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TFailure : notnull
		where TBind : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.SelectAsync(value => bind
				.Invoke(value)
				.MapAsync(success => resultSelector.Invoke(value, success))
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IAsyncEnumerable<TSuccess> source, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TFailure : notnull
		where TBind : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.SelectAsync(value => bind
				.Invoke(value)
				.MapAsync(success => resultSelector.Invoke(value, success))
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, IEnumerable<TBind>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.SelectMany(result => result
				.Match(success =>
					bind
					.Invoke(success)
					.AsAsyncEnumerable()
					.SelectAsync(obj => resultSelector.Invoke(success, obj))
					.Select(Result.Success<TResult, TFailure>),
					failure => AsyncEnumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
				)
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Task<IEnumerable<TBind>>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.AsAsyncEnumerable()
			.SelectMany(result => result
				.Match(success =>
					bind
					.Invoke(success)
					.AsAsyncEnumerable()
					.SelectAsync(obj => resultSelector.Invoke(success, obj))
					.Select(Result.Success<TResult, TFailure>),
					failure => AsyncEnumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
				)
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, IAsyncEnumerable<TBind>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.AsAsyncEnumerable()
			.SelectMany(result => result
				.Match(success =>
					bind
					.Invoke(success)
					.SelectAsync(obj => resultSelector.Invoke(success, obj))
					.Select(Result.Success<TResult, TFailure>),
					failure => AsyncEnumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
				)
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TBind : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.AsAsyncEnumerable()
			.SelectAsync(result => result
				.MatchAsync(success =>
					bind
					.Invoke(success)
					.MapAsync(value => resultSelector.Invoke(success, value)),
					failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure))
				)
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TBind : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.AsAsyncEnumerable()
			.SelectAsync(result => result
				.MatchAsync(success =>
					bind
					.Invoke(success)
					.MapAsync(value => resultSelector.Invoke(success, value)),
					failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure))
				)
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, IEnumerable<TBind>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.SelectMany(result => result
				.Match(success =>
					bind
					.Invoke(success)
					.AsAsyncEnumerable()
					.SelectAsync(obj => resultSelector.Invoke(success, obj))
					.Select(Result.Success<TResult, TFailure>),
					failure => AsyncEnumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
				)
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Task<IEnumerable<TBind>>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.SelectMany(result => result
				.Match(success =>
					bind
					.Invoke(success)
					.AsAsyncEnumerable()
					.SelectAsync(obj => resultSelector.Invoke(success, obj))
					.Select(Result.Success<TResult, TFailure>),
					failure => AsyncEnumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
				)
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, IAsyncEnumerable<TBind>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.SelectMany(result => result
				.Match(success =>
					bind
					.Invoke(success)
					.SelectAsync(obj => resultSelector.Invoke(success, obj))
					.Select(Result.Success<TResult, TFailure>),
					failure => AsyncEnumerable.Repeat(Result.Failure<TResult, TFailure>(failure), 1)
				)
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Result<TBind, TFailure>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TBind : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.SelectAsync(result => result
				.MatchAsync(success =>
					bind
					.Invoke(success)
					.MapAsync(value => resultSelector.Invoke(success, value)),
					failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure))
				)
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Task<Result<TBind, TFailure>>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TBind : notnull
		where TResult : notnull
	{
		if (bind == null)
			throw new ArgumentNullException(nameof(bind));

		if (resultSelector == null)
			throw new ArgumentNullException(nameof(resultSelector));

		return source
			.SelectAsync(result => result
				.MatchAsync(success =>
					bind
					.Invoke(success)
					.MapAsync(value => resultSelector.Invoke(success, value)),
					failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure))
				)
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> source, Func<TSuccess, IEnumerable<TBind>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> Enumerable.Repeat(source, 1).AsResultEnumerable().SelectMany(bind, resultSelector);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> source, Func<TSuccess, Task<IEnumerable<TBind>>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> Enumerable.Repeat(source, 1).AsResultEnumerable().SelectMany(bind, resultSelector);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Result<TSuccess, TFailure> source, Func<TSuccess, IAsyncEnumerable<TBind>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> Enumerable.Repeat(source, 1).AsResultEnumerable().SelectMany(bind, resultSelector);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> source, Func<TSuccess, IEnumerable<TBind>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> AsyncEnumerable.Repeat(source, 1).AsAsyncResultEnumerable().SelectMany(bind, resultSelector);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> source, Func<TSuccess, Task<IEnumerable<TBind>>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> AsyncEnumerable.Repeat(source, 1).AsAsyncResultEnumerable().SelectMany(bind, resultSelector);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> SelectMany<TSuccess, TFailure, TBind, TResult>(this Task<Result<TSuccess, TFailure>> source, Func<TSuccess, IAsyncEnumerable<TBind>> bind, Func<TSuccess, TBind, Task<TResult>> resultSelector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
		=> AsyncEnumerable.Repeat(source, 1).AsAsyncResultEnumerable().SelectMany(bind, resultSelector);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> Select<TSuccess, TResult, TFailure>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Task<TResult>> selector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (selector == null)
			throw new ArgumentNullException(nameof(selector));

		return source
			.SelectAsync(result => result
				.MatchAsync(
					success => Result.SuccessAsync<TResult, TFailure>(selector.Invoke(success)),
					failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure))
				)
			)
			.AsAsyncResultEnumerable();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncResultEnumerable<TResult, TFailure> Select<TSuccess, TResult, TFailure>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, Task<TResult>> selector)
		where TSuccess : notnull
		where TFailure : notnull
		where TResult : notnull
	{
		if (selector == null)
			throw new ArgumentNullException(nameof(selector));

		return source
			.SelectAsync(result => result
				.MatchAsync(
					success => Result.SuccessAsync<TResult, TFailure>(selector.Invoke(success)),
					failure => Task.FromResult(Result.Failure<TResult, TFailure>(failure))
				)
			)
			.AsAsyncResultEnumerable();
	}
}