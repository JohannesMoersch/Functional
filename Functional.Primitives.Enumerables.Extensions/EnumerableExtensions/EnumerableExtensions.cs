namespace Functional;

[EditorBrowsable(EditorBrowsableState.Never)]
public static partial class EnumerableExtensions
{
	private static readonly Task<bool> TrueResult = Task.FromResult(true);

#pragma warning disable CS8603 // Possible null reference return.
	public static IEnumerable<T> WhereSome<T>(this IEnumerable<Option<T>> source)
		where T : notnull
		=> source
			.Where(option => option.Match(_ => true, () => false))
			.Select(option => option.Match(o => o, () => default));
#pragma warning restore CS8603 // Possible null reference return.

#pragma warning disable CS8603 // Possible null reference return.
	public static Result<TSuccess[], TFailure> TakeUntilFailure<TSuccess, TFailure>(this IEnumerable<Result<TSuccess, TFailure>> source)
		where TSuccess : notnull
		where TFailure : notnull
	{	
		TSuccess[] successes;

		if (source is ICollection<Result<TSuccess, TFailure>> collection)
			successes = new TSuccess[collection.Count];
		else if (source is IReadOnlyCollection<Result<TSuccess, TFailure>> readOnlyCollection)
			successes = new TSuccess[readOnlyCollection.Count];
		else
			successes = new TSuccess[4];

		int index = 0;
		foreach (var value in source)	
		{
			if (value.Match(_ => false, _ => true))
				return Result.Failure<TSuccess[], TFailure>(value.Match(_ => default, failure => failure));

			if (index == successes.Length)
			{
				var old = successes;
				successes = new TSuccess[old.Length * 2];
				Array.Copy(old, successes, old.Length);
			}
			successes[index++] = value.Match(success => success, _ => default);	
		}

		if (index != successes.Length)
		{
			var old = successes;
			successes = new TSuccess[index];
			Array.Copy(old, successes, index);
		}

		return Result.Success<TSuccess[], TFailure>(successes);	
	}
#pragma warning restore CS8603 // Possible null reference return.

	public static Result<TSuccess[], TFailure[]> TakeAll<TSuccess, TFailure>(this IEnumerable<Result<TSuccess, TFailure>> source)
		where TSuccess : notnull
		where TFailure : notnull
	{
		TSuccess[] successes;

		if (source is ICollection<Result<TSuccess, TFailure>> collection)
			successes = new TSuccess[collection.Count];
		else if (source is IReadOnlyCollection<Result<TSuccess, TFailure>> readOnlyCollection)
			successes = new TSuccess[readOnlyCollection.Count];
		else
			successes = new TSuccess[4];

		List<TFailure>? failures = null;

		int index = 0;
		foreach (var value in source)
		{
			value
				.Match
				(
					success =>
					{
						if (failures == null)
						{
							if (index == successes.Length)
							{
								var old = successes;
								successes = new TSuccess[old.Length * 2];
								Array.Copy(old, successes, old.Length);
							}
							successes[index++] = success;
						}
						return false;
					},
					failure =>
					{
						failures ??= new List<TFailure>();
						failures.Add(failure);
						return false;
					}
				);
		}

		if (failures != null)
			return Result.Failure<TSuccess[], TFailure[]>(failures.ToArray());

		if (index != successes.Length)
		{
			var old = successes;
			successes = new TSuccess[index];
			Array.Copy(old, successes, index);
		}

		return Result.Success<TSuccess[], TFailure[]>(successes);
	}

	public static ResultPartition<TSuccess, TFailure> Partition<TSuccess, TFailure>(this IEnumerable<Result<TSuccess, TFailure>> source)
		where TSuccess : notnull
		where TFailure : notnull
	{
		var values = new ReplayableEnumerable<(bool matches, Result<TSuccess, TFailure> value)>(source.Select(value => (value.Match(_ => true, _ => false), value)));

		return new ResultPartition<TSuccess, TFailure>
		(
			values.Where(set => set.matches).Select(set => set.value.Match(success => success, failure => throw new InvalidOperationException("Expected success!"))),
			values.Where(set => !set.matches).Select(set => set.value.Match(success => throw new InvalidOperationException("Expected failure!"), failure => failure))
		);
	}

	public static Option<T> TryFirst<T>(this IEnumerable<T> source)
		where T : notnull
		=> source.TryFirst(static _ => true);

	public static Option<T> TryFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		where T : notnull
	{
		if (source is null) throw new ArgumentNullException(nameof(source));
		if (predicate is null) throw new ArgumentNullException(nameof(predicate));

		foreach (var element in source)
		{
			if (predicate.Invoke(element))
				return Option.Some(element);
		}

		return Option.None<T>();
	}

	public static async Task<Option<T>> TryFirstAsync<T>(this IEnumerable<T> source, Func<T, Task<bool>> predicate)
		where T : notnull
	{
		if (source is null) throw new ArgumentNullException(nameof(source));
		if (predicate is null) throw new ArgumentNullException(nameof(predicate));

		foreach (var element in source)
		{
			if (await predicate.Invoke(element))
				return Option.Some(element);
		}

		return Option.None<T>();
	}

	public static Option<T> TryLast<T>(this IEnumerable<T> source)
		where T : notnull
		=> source.TryLast(static _ => true);

	public static Option<T> TryLast<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		where T : notnull
	{
		if (source is null) throw new ArgumentNullException(nameof(source));
		if (predicate is null) throw new ArgumentNullException(nameof(predicate));

		var result = Option.None<T>();

		foreach (var element in source)
		{
			if (predicate.Invoke(element))
				result = Option.Some(element);
		}

		return result;
	}

	public static async Task<Option<T>> TryLastAsync<T>(this IEnumerable<T> source, Func<T, Task<bool>> predicate)
		where T : notnull
	{
		if (source is null) throw new ArgumentNullException(nameof(source));
		if (predicate is null) throw new ArgumentNullException(nameof(predicate));

		var result = Option.None<T>();

		foreach (var element in source)
		{
			if (await predicate.Invoke(element))
				result = Option.Some(element);
		}

		return result;
	}

#pragma warning disable CS8603 // Possible null reference return.
	public static Option<TValue[]> TakeUntilNone<TValue>(this IEnumerable<Option<TValue>> source)
		where TValue : notnull
	{
		TValue[] values;

		if (source is ICollection<Option<TValue>> collection)
			values = new TValue[collection.Count];
		else if (source is IReadOnlyCollection<Option<TValue>> readOnlyCollection)
			values = new TValue[readOnlyCollection.Count];
		else
			values = new TValue[4];

		var index = 0;
		foreach (var value in source)
		{
			if (value.Match(_ => false, () => true))
				return Option.None<TValue[]>();

			if (index == values.Length)
			{
				var old = values;
				values = new TValue[old.Length * 2];
				Array.Copy(old, values, old.Length);
			}
			values[index++] = value.Match(success => success, () => default);
		}

		if (index != values.Length)
		{
			var old = values;
			values = new TValue[index];
			Array.Copy(old, values, index);
		}

		return Option.Some(values);
	}
#pragma warning restore CS8603 // Possible null reference return.
}
