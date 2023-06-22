namespace Functional.Tests;

public static partial class TestInputExtensions
{
	public record TestResult<TInput, TResult>(TInput Input, Result<Option<TResult>, Exception> Result) where TResult : notnull;

	private static async Task<TestResult<TInput, TResult>> ToTestResult<TInput, TResult>(this Task<Result<Option<TResult>, Exception>> result, TInput input)
		where TResult : notnull
		=> new TestResult<TInput, TResult>(input, await result);
}
