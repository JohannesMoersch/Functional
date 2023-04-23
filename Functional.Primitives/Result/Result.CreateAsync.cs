namespace Functional;

public static partial class Result
{
	public static async Task<Result<TSuccess, TFailure>> CreateAsync<TSuccess, TFailure>(bool isSuccess, TSuccess success, Func<Task<TFailure>> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (failureFactory == null)
			throw new ArgumentNullException(nameof(failureFactory));

		return isSuccess
			? Success<TSuccess, TFailure>(success)
			: Failure<TSuccess, TFailure>(await failureFactory.Invoke());
	}

	public static async Task<Result<TSuccess, TFailure>> CreateAsync<TSuccess, TFailure>(bool isSuccess, Func<TSuccess> successFactory, Func<Task<TFailure>> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (successFactory == null)
			throw new ArgumentNullException(nameof(successFactory));

		if (failureFactory == null)
			throw new ArgumentNullException(nameof(failureFactory));

		return isSuccess
			? Success<TSuccess, TFailure>(successFactory.Invoke())
			: Failure<TSuccess, TFailure>(await failureFactory.Invoke());
	}

	public static async Task<Result<TSuccess, TFailure>> CreateAsync<TSuccess, TFailure>(bool isSuccess, Func<Task<TSuccess>> successFactory, TFailure failure)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (successFactory == null)
			throw new ArgumentNullException(nameof(successFactory));

		return isSuccess
			? Success<TSuccess, TFailure>(await successFactory.Invoke())
			: Failure<TSuccess, TFailure>(failure);
	}

	public static async Task<Result<TSuccess, TFailure>> CreateAsync<TSuccess, TFailure>(bool isSuccess, Func<Task<TSuccess>> successFactory, Func<TFailure> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (successFactory == null)
			throw new ArgumentNullException(nameof(successFactory));

		if (failureFactory == null)
			throw new ArgumentNullException(nameof(failureFactory));

		return isSuccess
			? Success<TSuccess, TFailure>(await successFactory.Invoke())
			: Failure<TSuccess, TFailure>(failureFactory.Invoke());
	}

	public static async Task<Result<TSuccess, TFailure>> CreateAsync<TSuccess, TFailure>(bool isSuccess, Func<Task<TSuccess>> successFactory, Func<Task<TFailure>> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (successFactory == null)
			throw new ArgumentNullException(nameof(successFactory));

		if (failureFactory == null)
			throw new ArgumentNullException(nameof(failureFactory));

		return isSuccess
			? Success<TSuccess, TFailure>(await successFactory.Invoke())
			: Failure<TSuccess, TFailure>(await failureFactory.Invoke());
	}
}
