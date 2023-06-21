namespace Functional;

public static partial class ResultExtensions
{
	public static void Apply<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Action<TSuccess> onSuccess, Action<TFailure> onFailure)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.Do(onSuccess, onFailure);

	public static Task Apply<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Action<TSuccess> onSuccess, Action<TFailure> onFailure)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.Do(onSuccess, onFailure);

	public static void Apply<TValue, TFailure>(this Result<Option<TValue>, TFailure> result, Action<TValue> onSome, Action onNone, Action<TFailure> onFailure)
		where TValue : notnull
		where TFailure : notnull
	{
		if (onSome == null) throw new ArgumentNullException(nameof(onSome));
		if (onNone == null) throw new ArgumentNullException(nameof(onNone));
		if (onFailure == null) throw new ArgumentNullException(nameof(onFailure));

		if (result.TryGetValue(out var success, out var failure))
		{
			if (success.TryGetValue(out var some))
			{
				onSome.Invoke(some);
			}
			else
			{
				onNone.Invoke();
			}
		}
		else
		{
			onFailure.Invoke(failure);
		}
	}

	public static async Task Apply<TValue, TFailure>(this Task<Result<Option<TValue>, TFailure>> result, Action<TValue> onSome, Action onNone, Action<TFailure> onFailure)
		where TValue : notnull
		where TFailure : notnull
		=> (await result).Apply(onSome, onNone, onFailure);
}
