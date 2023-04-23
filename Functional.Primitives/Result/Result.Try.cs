namespace Functional;

public static partial class Result
{
	public static Result<TSuccess, Exception> Try<TSuccess>(Func<TSuccess> successFactory)
		where TSuccess : notnull
		=> Try<TSuccess, Exception>(successFactory);

	public static Result<Unit, Exception> Try(Action successFactory)
		=> Try<Exception>(successFactory);

	public static Result<TSuccess, TException> Try<TSuccess, TException>(Func<TSuccess> successFactory) where TException : Exception
		where TSuccess : notnull
	{
		if (successFactory == null)
			throw new ArgumentNullException(nameof(successFactory));

		try
		{
			return Success<TSuccess, TException>(successFactory.Invoke());
		}
		catch (TException ex)
		{
			return Failure<TSuccess, TException>(ex);
		}
	}

	public static Result<Unit, TException> Try<TException>(Action successFactory) where TException : Exception
	{
		if (successFactory == null)
			throw new ArgumentNullException(nameof(successFactory));

		try
		{
			successFactory.Invoke();

			return Success<Unit, TException>(Functional.Unit.Value);
		}
		catch (TException ex)
		{
			return Failure<Unit, TException>(ex);
		}
	}

	public static Result<TSuccess, TFailure> Try<TSuccess, TFailure>(Func<TSuccess> successFactory, Func<Exception, TFailure> @catch)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (successFactory == null)
			throw new ArgumentNullException(nameof(successFactory));

		if (@catch == null)
			throw new ArgumentNullException(nameof(@catch));

		try
		{
			return Success<TSuccess, TFailure>(successFactory.Invoke());
		}
		catch (Exception ex)
		{
			return Failure<TSuccess, TFailure>(@catch.Invoke(ex));
		}
	}

	public static Result<Unit, TFailure> Try<TFailure>(Action successFactory, Func<Exception, TFailure> @catch)
		where TFailure : notnull
	{
		if (successFactory == null)
			throw new ArgumentNullException(nameof(successFactory));

		if (@catch == null)
			throw new ArgumentNullException(nameof(@catch));

		try
		{
			successFactory.Invoke();

			return Success<Unit, TFailure>(Functional.Unit.Value);
		}
		catch (Exception ex)
		{
			return Failure<Unit, TFailure>(@catch.Invoke(ex));
		}
	}
}
