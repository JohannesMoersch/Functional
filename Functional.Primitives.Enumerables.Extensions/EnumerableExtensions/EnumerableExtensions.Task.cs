using System;

namespace Functional;

public static partial class EnumerableExtensions
{
#pragma warning disable CS8603 // Possible null reference return.
	public static async Task<IEnumerable<T>> WhereSome<T>(this Task<IEnumerable<Option<T>>> source)
		where T : notnull
		=> (await source)
			.Where(option => option.Match(_ => true, () => false))
			.Select(option => option.Match(o => o, () => default));
#pragma warning restore CS8603 // Possible null reference return.

	public static async Task<Result<TSuccess[], TFailure>> TakeUntilFailure<TSuccess, TFailure>(this Task<IEnumerable<Result<TSuccess, TFailure>>> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await source).TakeUntilFailure();

	public static async Task<Result<TSuccess[], TFailure[]>> TakeAll<TSuccess, TFailure>(this Task<IEnumerable<Result<TSuccess, TFailure>>> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await source).TakeAll();

	public static async Task<ResultPartition<TSuccess, TFailure>> Partition<TSuccess, TFailure>(this Task<IEnumerable<Result<TSuccess, TFailure>>> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await source).Partition();

	public static async Task<Option<T>> TryFirst<T>(this Task<IEnumerable<T>> source)
		where T : notnull
		=> (await source).TryFirst();

	public static async Task<Option<T>> TryFirst<T>(this Task<IEnumerable<T>> source, Func<T, bool> predicate)
		where T : notnull
		=> (await source).TryFirst(predicate);

	public static async Task<Option<T>> TryFirstAsync<T>(this Task<IEnumerable<T>> source, Func<T, Task<bool>> predicate)
		where T : notnull
		=> await (await source).TryFirstAsync(predicate);

	public static async Task<Option<T>> TryLast<T>(this Task<IEnumerable<T>> source)
		where T : notnull
		=> (await source).TryLast();

	public static async Task<Option<T>> TryLast<T>(this Task<IEnumerable<T>> source, Func<T, bool> predicate)
		where T : notnull
		=> (await source).TryLast(predicate);

	public static async Task<Option<T>> TryLastAsync<T>(this Task<IEnumerable<T>> source, Func<T, Task<bool>> predicate)
		where T : notnull
		=> await (await source).TryLastAsync(predicate);

	public static async Task<Option<TValue[]>> TakeUntilNone<TValue>(this Task<IEnumerable<Option<TValue>>> source)
		where TValue : notnull
		=> (await source).TakeUntilNone();
}
