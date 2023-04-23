namespace Functional;

public static partial class Result
{
	public static Result<TSuccess, TFailure> Success<TSuccess, TFailure>(TSuccess success)
		where TSuccess : notnull
		where TFailure : notnull
	{
		if (success == null)
			throw new ArgumentNullException(nameof(success));

#pragma warning disable CS8604 // Possible null reference argument.
		return new Result<TSuccess, TFailure>(true, success, default);
#pragma warning restore CS8604 // Possible null reference argument.
	}

	public static PartialResult.Success<TSuccess> Success<TSuccess>(TSuccess success)
		where TSuccess : notnull
		=> new(success);
}
