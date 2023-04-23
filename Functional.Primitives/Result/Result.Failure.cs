namespace Functional;

public static partial class Result
{
	public static Result<TSuccess, TFailure> Failure<TSuccess, TFailure>(TFailure failure)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (failure == null)
			throw new ArgumentNullException(nameof(failure));

#pragma warning disable CS8604 // Possible null reference argument.
		return new Result<TSuccess, TFailure>(false, default, failure);
#pragma warning restore CS8604 // Possible null reference argument.
	}

	public static PartialResult.Failure<TFailure> Failure<TFailure>(TFailure failure)
		where TFailure : notnull
		=> new(failure);
}
