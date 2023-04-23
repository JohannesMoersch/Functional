namespace Functional;

public static partial class Result
{
	public static Result<Unit, TFailure> Where<TFailure>(bool isSuccess, TFailure failure)
		where TFailure : notnull
		=> isSuccess ? Success<Unit, TFailure>(Functional.Unit.Value) : Result.Failure<Unit, TFailure>(failure);

	public static Result<Unit, TFailure> Where<TFailure>(bool isSuccess, Func<TFailure> failureFactory)
		where TFailure : notnull
		=> isSuccess ? Success<Unit, TFailure>(Functional.Unit.Value) : Result.Failure<Unit, TFailure>(failureFactory.Invoke());
}
