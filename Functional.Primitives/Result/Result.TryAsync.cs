namespace Functional;

public static partial class Result
{
	public static async Task<Result<TSuccess, Exception>> TryAsync<TSuccess>(Func<Task<TSuccess>> successFactory)
		where TSuccess : notnull
	{
		if (successFactory == null)
			throw new ArgumentNullException(nameof(successFactory));

		try
		{
			return Success<TSuccess, Exception>(await successFactory.Invoke());
		}
		catch (Exception ex)
		{
			return Failure<TSuccess, Exception>(ex);
		}
	}

	public static async Task<Result<Unit, Exception>> TryAsync(Func<Task> successFactory)
	{
		if (successFactory == null)
			throw new ArgumentNullException(nameof(successFactory));

		try
		{
			await successFactory.Invoke();

			return Success<Unit, Exception>(Functional.Unit.Value);
		}
		catch (Exception ex)
		{
			return Failure<Unit, Exception>(ex);
		}
	}

	public static async Task<Result<TSuccess, TFailure>> TryAsync<TSuccess, TFailure>(Func<Task<TSuccess>> successFactory, Func<Exception, TFailure> @catch)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (successFactory == null)
			throw new ArgumentNullException(nameof(successFactory));

		if (@catch == null)
			throw new ArgumentNullException(nameof(@catch));

		try
		{
			return Success<TSuccess, TFailure>(await successFactory.Invoke());
		}
		catch (Exception ex)
		{
			return Failure<TSuccess, TFailure>(@catch.Invoke(ex));
		}
	}

	public static async Task<Result<Unit, TFailure>> TryAsync<TFailure>(Func<Task> successFactory, Func<Exception, TFailure> @catch)
		where TFailure : notnull
	{
		if (successFactory == null)
			throw new ArgumentNullException(nameof(successFactory));

		if (@catch == null)
			throw new ArgumentNullException(nameof(@catch));

		try
		{
			await successFactory.Invoke();

			return Success<Unit, TFailure>(Functional.Unit.Value);
		}
		catch (Exception ex)
		{
			return Failure<Unit, TFailure>(@catch.Invoke(ex));
		}
	}
}
