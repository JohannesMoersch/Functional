namespace Functional.Tests;


public static partial class TestInputExtensions
{
#pragma warning disable CS8604 // Possible null reference argument.
	public static async Task ShouldBeEquivalentTo<TOneReference, TOneTest, TResult>(this Task<TestResult<TestInputWithArguments<TOneReference, TOneTest>, TResult>> result, Func<TOneReference, TResult> expected)
		where TResult : notnull
	{
		var testResult = await result;

		testResult.Result.ShouldBeEquivalentTo(() => expected.Invoke(testResult.Input.Input.GetArgument(0, testResult.Input.One)));
	}

	public static async Task ShouldBeEquivalentTo<TOneReference, TOneTest, TResult>(this Task<TestResult<TestInputWithArguments<TOneReference, TOneTest>, IEnumerable<TResult>>> result, Func<TOneReference, IEnumerable<TResult>> expected)
		where TResult : notnull
	{
		var testResult = await result;

		testResult.Result.ShouldBeEquivalentTo(() => expected.Invoke(testResult.Input.Input.GetArgument(0, testResult.Input.One)));
	}

	public static async Task ShouldBeEquivalentTo<TOneReference, TOneTest, TTwoReference, TTwoTest, TResult>(this Task<TestResult<TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest>, TResult>> result, Func<TOneReference, TTwoReference, TResult> expected)
		where TResult : notnull
	{
		var testResult = await result;

		testResult.Result.ShouldBeEquivalentTo(() => expected.Invoke(testResult.Input.Input.GetArgument(0, testResult.Input.One), testResult.Input.Input.GetArgument(1, testResult.Input.Two)));
	}

	public static async Task ShouldBeEquivalentTo<TOneReference, TOneTest, TTwoReference, TTwoTest, TResult>(this Task<TestResult<TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest>, IEnumerable<TResult>>> result, Func<TOneReference, TTwoReference, IEnumerable<TResult>> expected)
		where TResult : notnull
	{
		var testResult = await result;

		testResult.Result.ShouldBeEquivalentTo(() => expected.Invoke(testResult.Input.Input.GetArgument(0, testResult.Input.One), testResult.Input.Input.GetArgument(1, testResult.Input.Two)));
	}
#pragma warning restore CS8604 // Possible null reference argument.

	public static void ShouldBeEquivalentTo<TResult>(this Result<Option<TResult>, Exception> result, Func<TResult> expected)
		where TResult : notnull
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
		where TResult : notnull
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
}

