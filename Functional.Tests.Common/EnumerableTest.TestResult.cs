namespace Functional.Tests;

public static partial class EnumerableTest
{
	public record TestResult<TResult>(Result<Option<TResult>, Exception> Result) where TResult : notnull;

	public record NullTestResult<TResult>(Result<Option<TResult>, Exception> Result, bool[] IsNull) where TResult : notnull;
}
