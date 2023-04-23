namespace Functional;

public static partial class EnumerableExtensions
{
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

	public static async Task<Option<TValue[]>> TakeUntilNone<TValue>(this Task<IEnumerable<Option<TValue>>> source)
		where TValue : notnull
		=> (await source).TakeUntilNone();

#pragma warning disable CS8603 // Possible null reference return.
	public static async Task<Option<TValue[]>> TakeUntilNone<TValue>(this IAsyncEnumerable<Option<TValue>> source)
		where TValue : notnull
	{
		var values = new TValue[4];

		var enumerator = source.GetAsyncEnumerator(CancellationToken.None);

		var index = 0;
		while (await enumerator.MoveNextAsync())
		{
			var value = enumerator.Current;

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
