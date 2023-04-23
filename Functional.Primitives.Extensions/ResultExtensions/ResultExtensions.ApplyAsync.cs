namespace Functional;

public static partial class ResultExtensions
{
	public static Task ApplyAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, Func<TSuccess, Task> success, Func<TFailure, Task> failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.DoAsync(success, failure);

	public static Task ApplyAsync<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result, Func<TSuccess, Task> success, Func<TFailure, Task> failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> result.DoAsync(success, failure);

	public static async Task ApplyAsync<T, TFailure>(this Result<Option<T>, TFailure> result, Func<T, Task> onSome, Func<Task> onNone, Func<TFailure, Task> onFailure)
		where TFailure : notnull
		where T : notnull
	{
		if (onSome == null) throw new ArgumentNullException(nameof(onSome));
		if (onNone == null) throw new ArgumentNullException(nameof(onNone));
		if (onFailure == null) throw new ArgumentNullException(nameof(onFailure));

		if (result.TryGetValue(out var success, out var failure))
		{
			if (success.TryGetValue(out var some))
			{
				await onSome.Invoke(some);
			}
			else
			{
				await onNone.Invoke();
			}
		}
		else
		{
			await onFailure.Invoke(failure);
		}
	}

	public static async Task ApplyAsync<T, TFailure>(this Task<Result<Option<T>, TFailure>> result, Func<T, Task> onSome, Func<Task> onNone, Func<TFailure, Task> onFailure)
		where T : notnull
		where TFailure : notnull
		=> await (await result).ApplyAsync(onSome, onNone, onFailure);
}
