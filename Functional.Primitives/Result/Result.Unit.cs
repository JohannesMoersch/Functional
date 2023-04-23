namespace Functional;

public static partial class Result
{
	public static Result<Unit, TFailure> Unit<TFailure>()
		where TFailure : notnull
		=> Success<Unit, TFailure>(Functional.Unit.Value);
}
