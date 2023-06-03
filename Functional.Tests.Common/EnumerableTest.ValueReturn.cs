using System.ComponentModel;

namespace Functional.Tests;

#pragma warning disable CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
public static partial class EnumerableTest
{
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
	public static Task<TestResult<TResult>> ExecuteTest<TOne, TResult>(Func<Task<IEnumerable<TOne>>, Task<TResult>> function, TestEnumerable<TOne> one)
		=> GetMethodFromMethodGroup(function.GetMethodInfo(), GetTypeFromEnumerableType<TOne>(one.Type))
			.Execute<TResult>(new object?[] { one.Enumerable })
			.ToTestResult();

	public static Task<TestResult<TResult>> ExecuteTest<TOne, TTwo, TResult>(Func<Task<IEnumerable<TOne>>, TTwo, Task<TResult>> function, TestEnumerable<TOne> one, TTwo two)
		=> GetMethodFromMethodGroup(function.GetMethodInfo(), GetTypeFromEnumerableType<TOne>(one.Type), typeof(TTwo))
			.Execute<TResult>(new object?[] { one.Enumerable, two })
			.ToTestResult();

	public static Task<NullTestResult<TResult>> ExecuteNullTest<TOne, TResult>(Func<Task<IEnumerable<TOne>>, Task<TResult>> function, NullTestInput.OneEnumerable<TOne> input, TestEnumerable<TOne> one)
		=> GetMethodFromMethodGroup(function.GetMethodInfo(), GetTypeFromEnumerableType<TOne>(one.Type))
			.Execute<TResult>(new object?[] { one.Enumerable }.Select((o, i) => !input.IsNull[i] ? o : null))
			.ToNullTestResult(input.IsNull);

	public static Task<NullTestResult<TResult>> ExecuteNullTest<TOne, TTwo, TResult>(Func<Task<IEnumerable<TOne>>, TTwo, Task<TResult>> function, NullTestInput.OneEnumerable<TOne> input, TestEnumerable<TOne> one, TTwo two)
		=> GetMethodFromMethodGroup(function.GetMethodInfo(), GetTypeFromEnumerableType<TOne>(one.Type), typeof(TTwo))
			.Execute<TResult>(new object?[] { one.Enumerable }.Select((o, i) => !input.IsNull[i] ? o : null).Append(two))
			.ToNullTestResult(input.IsNull);

	private static Task<Result<Option<TResult>, Exception>> Execute<TResult>(this Option<MethodInfo> method, IEnumerable<object?> arguments)
		=> method
			.MapAsync(method => Result.TryAsync(() => (Task<Option<TResult>>)ConvertToTask<TResult>((dynamic)method.Invoke(null, arguments.ToArray()))))
			.ThrowOnNone(() => new Exception("Couldn't find matching method in method group."));
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

	public static void ShouldBeEquivalentTo<TResult>(this Result<Option<TResult>, Exception> result, Func<TResult> expected)
		=> Result
			.Try(() => expected.Invoke() is TResult value ? Option.Some(value) : Option.None())
			.Apply
			(
				expectedValue => result
					.Apply
					(
						s => s.Should().BeEquivalentTo(expectedValue),
						() => throw new Exception($"Expected {expectedValue} but found null."),
						e => throw new Exception($"Expected {expectedValue} but found {e.ToFormattedString()}.")
					),
				() => result
					.Apply
					(
						s => throw new Exception($"Expected null but found {s}."),
						() => { },
						e => throw new Exception($"Expected null but found {e.ToFormattedString()}.")
					),
				expectedException => result
					.Apply
					(
						s => throw new Exception($"Expected {expectedException.ToFormattedString()} but found {s}."),
						() => throw new Exception($"Expected {expectedException.ToFormattedString()} but found null."),
						e => e.ShouldMatchTypeAndMessage(expectedException)

					)
			);

	public static async Task ShouldBeEquivalentTo<TResult>(this Task<TestResult<TResult>> result, Func<TResult> expected)
		=> (await result).Result.ShouldBeEquivalentTo(expected);

	public static async Task ShouldBeEquivalentTo<TResult, TOne, TTwo>(this Task<NullTestResult<TResult>> source, Func<TOne, TTwo, TResult> method, TOne one, TTwo two)
		=> (await source).ShouldBeEquivalentTo(method, one, two);

#pragma warning disable CS8604 // Possible null reference argument.
	private static void ShouldBeEquivalentTo<TResult, TOne, TTwo>(this NullTestResult<TResult> source, Func<TOne, TTwo, TResult> method, TOne one, TTwo two)
		=> source.Result.ShouldBeEquivalentTo(() => method.Invoke(!source.IsNull[0] ? one : default, !source.IsNull[1] ? two : default));
#pragma warning restore CS8604 // Possible null reference argument.

	private static Task<Option<T>> ConvertToTask<T>(T source)
		=> Task.FromResult(source != null ? Option.Some(source) : Option.None());

	private static async Task<Option<T>> ConvertToTask<T>(Task<T> source)
		=> await source is T value ? value : Option.None();
}
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.