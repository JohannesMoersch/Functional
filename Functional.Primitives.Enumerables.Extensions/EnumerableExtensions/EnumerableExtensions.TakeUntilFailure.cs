namespace Functional;

public static partial class EnumerableExtensions
{
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

	public static async Task<Result<TSuccess[], TFailure>> TakeUntilFailure<TSuccess, TFailure>(this Task<IEnumerable<Result<TSuccess, TFailure>>> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> (await source).TakeUntilFailure();

#pragma warning disable CS8603 // Possible null reference return.
	public static async Task<Result<TSuccess[], TFailure>> TakeUntilFailure<TSuccess, TFailure>(this IAsyncEnumerable<Result<TSuccess, TFailure>> source)
		where TSuccess : notnull
		where TFailure : notnull
	{
		var successes = new TSuccess[4];

		var enumerator = source.GetAsyncEnumerator(CancellationToken.None);

		var index = 0;
		while (await enumerator.MoveNextAsync())
		{
			var value = enumerator.Current;

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
}
