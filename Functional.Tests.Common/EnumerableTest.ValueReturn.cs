namespace Functional.Tests;

#pragma warning disable CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
public static partial class EnumerableTest
{
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
	public static Task<Result<Option<TResult>, Exception>> Execute<TOne, TResult>(Func<Task<IEnumerable<TOne>>, Task<TResult>> function, TestEnumerable<TOne> one)
		=> GetMethodFromMethodGroup(function.GetMethodInfo(), GetTypeFromEnumerableType<TOne>(one.Type))
			.MapAsync(method => Result.TryAsync(() => (Task<Option<TResult>>)ConvertToTask<TResult>((dynamic)method.Invoke(null, new object?[] { one.Enumerable }))))
			.ThrowOnNone(() => new Exception("Couldn't find matching method in method group."));

	public static Task<Result<Option<TResult>, Exception>> Execute<TOne, TTwo, TResult>(Func<Task<IEnumerable<TOne>>, TTwo, Task<TResult>> function, TestEnumerable<TOne> one, TTwo two)
		=> GetMethodFromMethodGroup(function.GetMethodInfo(), GetTypeFromEnumerableType<TOne>(one.Type), typeof(TTwo))
			.MapAsync(method => Result.TryAsync(() => (Task<Option<TResult>>)ConvertToTask<TResult>((dynamic)method.Invoke(null, new object?[] { one.Enumerable, two }))))
			.ThrowOnNone(() => new Exception("Couldn't find matching method in method group."));
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

	public static Task ShouldBeEquivalentTo<T>(this Task<Result<Option<T>, Exception>> source, Func<T> expected)
		=> Result
			.Try(() => expected.Invoke() is T value ? Option.Some(value) : Option.None())
			.ApplyAsync
			(
				expectedValue => source
					.Apply
					(
						s => s.Should().BeEquivalentTo(expectedValue),
						() => throw new Exception($"Expected {expectedValue} but found null."),
						e => throw new Exception($"Expected {expectedValue} but found {e.ToFormattedString()}.")
					),
				() => source
					.Apply
					(
						s => throw new Exception($"Expected null but found {s}."),
						() => { },
						e => throw new Exception($"Expected null but found {e.ToFormattedString()}.")
					),
				expectedException => source
					.Apply
					(
						s => throw new Exception($"Expected {expectedException.ToFormattedString()} but found {s}."),
						() => throw new Exception($"Expected {expectedException.ToFormattedString()} but found null."),
						e => e.ShouldMatchTypeAndMessage(expectedException)

					)
			);

	private static Task<Option<T>> ConvertToTask<T>(T source)
		=> Task.FromResult(source != null ? Option.Some(source) : Option.None());

	private static async Task<Option<T>> ConvertToTask<T>(Task<T> source)
		=> await source is T value ? value : Option.None();
}
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.