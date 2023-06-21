namespace Functional.Tests;

#pragma warning disable CS8600, CS8604, CS8714 // Converting null literal or possible null value to non-nullable type. Possible null reference argument. The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.

public record TestInputWithArguments<TOneReference, TOneTest>(ITestInput<TOneReference, TOneTest> Input, TOneReference One);
public record TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest>(ITestInput<TOneReference, TOneTest, TTwoReference, TTwoTest> Input, TOneReference One, TTwoReference Two);

public static class TestInputExtensions
{
	public static TestInputWithArguments<TOneReference, TOneTest> WithReferenceArguments<TOneReference, TOneTest>(this ITestInput<TOneReference, TOneTest> input, TOneReference one)
		=> new TestInputWithArguments<TOneReference, TOneTest>(input, one);

	public static TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest> WithReferenceArguments<TOneReference, TOneTest, TTwoReference, TTwoTest>(this ITestInput<TOneReference, TOneTest, TTwoReference, TTwoTest> input, TOneReference one, TTwoReference two)
		=> new TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest>(input, one, two);

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

	private static Option<MethodInfo> GetMethodFromMethodGroup(MethodInfo method, params Type[] parameterTypes)
		=> (method.DeclaringType ?? throw new Exception("Failed to get class that contained method."))
			.GetMethods(BindingFlags.Public | BindingFlags.Static)
			.Where(m => m.Name == method.Name && m.IsGenericMethod == method.IsGenericMethod)
			.Where(m => !m.IsGenericMethod || m.GetGenericArguments().Length == method.GetGenericArguments().Length)
			.Select(m => m.IsGenericMethod ? m.MakeGenericMethod(method.GetGenericArguments()) : m)
			.Where(m => m.GetParameters().Select(p => p.ParameterType).SequenceEqual(parameterTypes))
			.TryFirst();

	private static Type GetTypeFromEnumerableType<T>(EnumerableType enumerableType)
		=> enumerableType switch
		{
			EnumerableType.IEnumerable => typeof(IEnumerable<T>),
			EnumerableType.TaskOfIEnumerable => typeof(Task<IEnumerable<T>>),
			EnumerableType.TaskOfIOrderedEnumerable => typeof(Task<IOrderedEnumerable<T>>),
			EnumerableType.IAsyncEnumerable => typeof(IAsyncEnumerable<T>),
			_ => throw new Exception($"Unexpected {nameof(EnumerableType)} found.")
		};

	public record TestResult<TInput, TResult>(TInput Input, Result<Option<TResult>, Exception> Result) where TResult : notnull;

	private static async Task<TestResult<TInput, TResult>> ToTestResult<TInput, TResult>(this Task<Result<Option<TResult>, Exception>> result, TInput input)
		=> new TestResult<TInput, TResult>(input, await result);

	public static async Task ShouldBeEquivalentTo<TOneReference, TOneTest, TResult>(this Task<TestResult<TestInputWithArguments<TOneReference, TOneTest>, TResult>> result, Func<TOneReference, TResult> expected)
	{
		var testResult = await result;

		testResult.Result.ShouldBeEquivalentTo(() => expected.Invoke(testResult.Input.Input.GetArgument(0, testResult.Input.One)));
	}

	public static async Task ShouldBeEquivalentTo<TOneReference, TOneTest, TResult>(this Task<TestResult<TestInputWithArguments<TOneReference, TOneTest>, IEnumerable<TResult>>> result, Func<TOneReference, IEnumerable<TResult>> expected)
	{
		var testResult = await result;

		testResult.Result.ShouldBeEquivalentTo(() => expected.Invoke(testResult.Input.Input.GetArgument(0, testResult.Input.One)));
	}

	public static async Task ShouldBeEquivalentTo<TOneReference, TOneTest, TTwoReference, TTwoTest, TResult>(this Task<TestResult<TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest>, TResult>> result, Func<TOneReference, TTwoReference, TResult> expected)
	{
		var testResult = await result;

		testResult.Result.ShouldBeEquivalentTo(() => expected.Invoke(testResult.Input.Input.GetArgument(0, testResult.Input.One), testResult.Input.Input.GetArgument(1, testResult.Input.Two)));
	}

	public static async Task ShouldBeEquivalentTo<TOneReference, TOneTest, TTwoReference, TTwoTest, TResult>(this Task<TestResult<TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest>, IEnumerable<TResult>>> result, Func<TOneReference, TTwoReference, IEnumerable<TResult>> expected)
	{
		var testResult = await result;

		testResult.Result.ShouldBeEquivalentTo(() => expected.Invoke(testResult.Input.Input.GetArgument(0, testResult.Input.One), testResult.Input.Input.GetArgument(1, testResult.Input.Two)));
	}

	public static void ShouldBeEquivalentTo<TResult>(this Result<Option<TResult>, Exception> result, Func<TResult> expected)
		=> Result
			.Try(() => expected.Invoke() is TResult value ? Option.Some(value) : Option.None())
			.Apply
			(
				expectedValue => result
					.Apply
					(
						s => s.Should().BeEquivalentTo(expectedValue),
						() => AssertionException.Throw(expectedValue.ToString(), null),
						e => AssertionException.Throw(expectedValue.ToString(), e.ToFormattedString())
					),
				() => result
					.Apply
					(
						s => AssertionException.Throw(null, s.ToString()),
						() => { },
						e => AssertionException.Throw(null, e.ToFormattedString())
					),
				expectedException => result
					.Apply
					(
						s => AssertionException.Throw(expectedException.ToFormattedString(), s.ToString()),
						() => AssertionException.Throw(expectedException.ToFormattedString(), null),
						e => e.ShouldMatchTypeAndMessage(expectedException)

					)
			);

	public static void ShouldBeEquivalentTo<TResult>(this Result<Option<IEnumerable<TResult>>, Exception> result, Func<IEnumerable<TResult>> expected)
		=> Result
			.Try(() => Option.FromNullable(expected.Invoke()))
			.Apply
			(
				expectedValue => result
					.Apply
					(
						s => s.Should().BeEquivalentTo(expectedValue),
						() => AssertionException.Throw(expectedValue.ToFormattedString(), null),
						e => AssertionException.Throw(expectedValue.ToFormattedString(), e.ToFormattedString())
					),
				() => result
					.Apply
					(
						s => AssertionException.Throw(null, s.ToFormattedString()),
						() => { },
						e => AssertionException.Throw(null, e.ToFormattedString())
					),
				expectedException => result
					.Apply
					(
						s => AssertionException.Throw(expectedException.ToFormattedString(), s.ToFormattedString()),
						() => AssertionException.Throw(expectedException.ToFormattedString(), null),
						e => e.ShouldMatchTypeAndMessage(expectedException)

					)
			);

	private static void ShouldMatchTypeAndMessage(this Exception exception, Exception expected)
	{
		if (exception.GetType() != expected.GetType() || exception.Message != expected.Message)
			AssertionException.Throw(expected.ToFormattedString(), exception.ToFormattedString());
	}

	private static string ToFormattedString<T>(this IEnumerable<T> value)
		=> $"({String.Join(", ", value.Select(i => i?.ToString() ?? "null"))})";

	private static string ToFormattedString(this Exception value)
		=> $"{value.GetType().Name} with message \"{value.Message}\"";

	private static Task<Option<T>> ConvertToTask<T>(T source)
		=> Task.FromResult(source != null ? Option.Some(source) : Option.None());

	private static async Task<Option<T>> ConvertToTask<T>(Task<T> source)
		=> await source is T value ? value : Option.None();

	private static Task<Option<IEnumerable<T>>> ConvertToEnumerable<T>(IEnumerable<T> source)
		=> Task.FromResult(Option.FromNullable(source));

	private static async Task<Option<IEnumerable<T>>> ConvertToEnumerable<T>(Task<IEnumerable<T>> source)
		=> Option.FromNullable(await source);

	private static async Task<Option<IEnumerable<T>>> ConvertToEnumerable<T>(Task<IOrderedEnumerable<T>> source)
		=> Option.FromNullable<IEnumerable<T>>(await source);

	private static async Task<Option<IEnumerable<T>>> ConvertToEnumerable<T>(IAsyncEnumerable<T> source)
	{
		await using var enumerator = source.GetAsyncEnumerator();

		var results = new List<T>();
		while (await enumerator.MoveNextAsync())
			results.Add(enumerator.Current);

		return Option.FromNullable<IEnumerable<T>>(results);
	}
}

#pragma warning restore CS8600, CS8604, CS8714 // Converting null literal or possible null value to non-nullable type. Possible null reference argument. The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.