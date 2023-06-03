namespace Functional.Tests;

public static partial class EnumerableTest
{
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
	public static Task<TestResult<IEnumerable<TResult>>> Execute<TOne, TTwo, TResult>(Func<Task<IEnumerable<TOne>>, Task<IEnumerable<TTwo>>, Task<IEnumerable<TResult>>> function, TestEnumerable<TOne> one, TestEnumerable<TTwo> two)
		=> GetMethodFromMethodGroup(function.GetMethodInfo(), GetTypeFromEnumerableType<TOne>(one.Type), GetTypeFromEnumerableType<TTwo>(two.Type))
			.MapAsync(method => Result.TryAsync(() => (Task<Option<IEnumerable<TResult>>>)ConvertToEnumerable<TResult>((dynamic)method.Invoke(null, new object?[] { one.Enumerable, two.Enumerable }))))
			.ThrowOnNone(() => new Exception("Couldn't find matching method in method group."))
			.ToTestResult();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

	public static Task ShouldBeEquivalentTo<TResult>(this Task<TestResult<IEnumerable<TResult>>> result, Func<IEnumerable<TResult>> expected)
		=> Result
			.Try(() => Option.FromNullable(expected.Invoke()))
			.ApplyAsync
			(
				async expectedValue => (await result)
					.Result
					.Apply
					(
						s => s.Should().BeEquivalentTo(expectedValue),
						() => throw new Exception($"Expected {expectedValue.ToFormattedString()} but found null."),
						e => throw new Exception($"Expected {expectedValue.ToFormattedString()} but found {e.ToFormattedString()}.")
					),
				async () => (await result)
					.Result
					.Apply
					(
						s => throw new Exception($"Expected null but found {s.ToFormattedString()}."),
						() => { },
						e => throw new Exception($"Expected null but found {e.ToFormattedString()}.")
					),
				async expectedException => (await result)
					.Result
					.Apply
					(
						s => throw new Exception($"Expected {expectedException.ToFormattedString()} but found {s.ToFormattedString()}."),
						() => throw new Exception($"Expected {expectedException.ToFormattedString()} but found null."),
						e => e.ShouldMatchTypeAndMessage(expectedException)

					)
			);

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