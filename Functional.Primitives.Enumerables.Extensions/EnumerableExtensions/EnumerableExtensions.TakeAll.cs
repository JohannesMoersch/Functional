namespace Functional;

public static partial class EnumerableExtensions
{
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

	public static async Task<Result<TSuccess[], TFailure[]>> TakeAll<TSuccess, TFailure>(this Task<IEnumerable<Result<TSuccess, TFailure>>> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await source).TakeAll();

	public static async Task<Result<TSuccess[], TFailure[]>> TakeAll<TSuccess, TFailure>(this IAsyncEnumerable<Result<TSuccess, TFailure>> source)
		where TSuccess : notnull
		where TFailure : notnull
	{
		var successes = new TSuccess[4];

		List<TFailure>? failures = null;

		var enumerator = source.GetAsyncEnumerator(CancellationToken.None);

		int index = 0;
		while (await enumerator.MoveNextAsync())
		{
			enumerator
				.Current
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
}
