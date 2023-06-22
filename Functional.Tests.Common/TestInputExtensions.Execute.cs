namespace Functional.Tests;

#pragma warning disable CS8600, CS8604, CS8714 // Converting null literal or possible null value to non-nullable type. Possible null reference argument. The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.

public static partial class TestInputExtensions
{
	public static Task<TestResult<TestInputWithArguments<TOneReference, TOneTest>, TResult>> Execute<TOneReference, TOneTest, TResult>(this TestInputWithArguments<TOneReference, TOneTest> input, Func<TOneTest, Task<TResult>> method)
		=> method
			.GetMethodInfo()
			.ExecuteSingle<TestInputWithArguments<TOneReference, TOneTest>, TResult>
			(
				input,
				(input.Input.OneType, input.Input.GetOne(input.One))
			);

	public static Task<TestResult<TestInputWithArguments<TOneReference, TOneTest>, IEnumerable<TResult>>> Execute<TOneReference, TOneTest, TResult>(this TestInputWithArguments<TOneReference, TOneTest> input, Func<TOneTest, Task<IEnumerable<TResult>>> method)
		=> method
			.GetMethodInfo()
			.ExecuteEnumerable<TestInputWithArguments<TOneReference, TOneTest>, TResult>
			(
				input,
				(input.Input.OneType, input.Input.GetOne(input.One))
			);

	public static Task<TestResult<TestInputWithArguments<TOneReference, TOneTest>, TResult>> Execute<TOneReference, TOneTest, TTwo, TResult>(this TestInputWithArguments<TOneReference, TOneTest> input, Func<TOneTest, TTwo, Task<TResult>> method, TTwo two)
		=> method
			.GetMethodInfo()
			.ExecuteSingle<TestInputWithArguments<TOneReference, TOneTest>, TResult>
			(
				input,
				(input.Input.OneType, input.Input.GetOne(input.One)),
				(typeof(TTwo), two)
			);

	public static Task<TestResult<TestInputWithArguments<TOneReference, TOneTest>, IEnumerable<TResult>>> Execute<TOneReference, TOneTest, TTwo, TResult>(this TestInputWithArguments<TOneReference, TOneTest> input, Func<TOneTest, TTwo, Task<IEnumerable<TResult>>> method, TTwo two)
		=> method
			.GetMethodInfo()
			.ExecuteEnumerable<TestInputWithArguments<TOneReference, TOneTest>, TResult>
			(
				input,
				(input.Input.OneType, input.Input.GetOne(input.One)),
				(typeof(TTwo), two)
			);

	public static Task<TestResult<TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest>, TResult>> Execute<TOneReference, TOneTest, TTwoReference, TTwoTest, TResult>(this TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest> input, Func<TOneTest, TTwoTest, Task<TResult>> method)
		=> method
			.GetMethodInfo()
			.ExecuteSingle<TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest>, TResult>
			(
				input,
				(input.Input.OneType, input.Input.GetOne(input.One)),
				(input.Input.TwoType, input.Input.GetTwo(input.Two))
			);

	public static Task<TestResult<TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest>, IEnumerable<TResult>>> Execute<TOneReference, TOneTest, TTwoReference, TTwoTest, TResult>(this TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest> input, Func<TOneTest, TTwoTest, Task<IEnumerable<TResult>>> method)
		=> method
			.GetMethodInfo()
			.ExecuteEnumerable<TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest>, TResult>
			(
				input,
				(input.Input.OneType, input.Input.GetOne(input.One)),
				(input.Input.TwoType, input.Input.GetTwo(input.Two))
			);

	private static Task<TestResult<TInput, TResult>> ExecuteSingle<TInput, TResult>(this MethodInfo methodInfo, TInput input, params (Type Type, object? Value)[] arguments)
		=> methodInfo
			.Execute(input, result => (Task<Option<TResult>>)ConvertToTask<TResult>((dynamic)result), arguments);


	private static Task<TestResult<TInput, IEnumerable<TResult>>> ExecuteEnumerable<TInput, TResult>(this MethodInfo methodInfo, TInput input, params (Type Type, object? Value)[] arguments)
		=> methodInfo
			.Execute(input, result => (Task<Option<IEnumerable<TResult>>>)ConvertToEnumerable<TResult>((dynamic)result), arguments);
	
	private static Task<TestResult<TInput, TResult>> Execute<TInput, TResult>(this MethodInfo methodInfo, TInput input, Func<object?, Task<Option<TResult>>> resultHandler, params (Type Type, object? Value)[] arguments)
		=> GetMethodFromMethodGroup(methodInfo, arguments.Select(a => a.Type).ToArray())
			.MapAsync(method => Result.TryAsync(() => resultHandler.Invoke(method.Invoke(null, arguments.Select(a => a.Value).ToArray()))))
			.ThrowOnNone(() => new Exception("Couldn't find matching method in method group."))
			.ToTestResult(input);
}

#pragma warning restore CS8600, CS8604, CS8714 // Converting null literal or possible null value to non-nullable type. Possible null reference argument. The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.