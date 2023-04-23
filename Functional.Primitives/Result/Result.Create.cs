namespace Functional;

public static partial class Result
{
	public static Result<TSuccess, TFailure> Create<TSuccess, TFailure>(bool isSuccess, TSuccess success, TFailure failure)
		where TSuccess : notnull
		where TFailure : notnull
		=> isSuccess
			? Success<TSuccess, TFailure>(success)
			: Failure<TSuccess, TFailure>(failure);

	public static Result<TSuccess, TFailure> Create<TSuccess, TFailure>(bool isSuccess, TSuccess success, Func<TFailure> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (failureFactory == null)
			throw new ArgumentNullException(nameof(failureFactory));

		return isSuccess
			? Success<TSuccess, TFailure>(success)
			: Failure<TSuccess, TFailure>(failureFactory.Invoke());
	}

	public static Result<TSuccess, TFailure> Create<TSuccess, TFailure>(bool isSuccess, Func<TSuccess> successFactory, TFailure failure)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (successFactory == null)
			throw new ArgumentNullException(nameof(successFactory));

		return isSuccess
			? Success<TSuccess, TFailure>(successFactory.Invoke())
			: Failure<TSuccess, TFailure>(failure);
	}

	public static Result<TSuccess, TFailure> Create<TSuccess, TFailure>(bool isSuccess, Func<TSuccess> successFactory, Func<TFailure> failureFactory)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (successFactory == null)
			throw new ArgumentNullException(nameof(successFactory));

		if (failureFactory == null)
			throw new ArgumentNullException(nameof(failureFactory));

		return isSuccess
			? Success<TSuccess, TFailure>(successFactory.Invoke())
			: Failure<TSuccess, TFailure>(failureFactory.Invoke());
	}
}
