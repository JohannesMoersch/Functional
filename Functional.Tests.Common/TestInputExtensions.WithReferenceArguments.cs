namespace Functional.Tests;

public static partial class TestInputExtensions
{
	public record TestInputWithArguments<TOneReference, TOneTest>(ITestInput<TOneReference, TOneTest> Input, TOneReference One);

	public record TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest>(ITestInput<TOneReference, TOneTest, TTwoReference, TTwoTest> Input, TOneReference One, TTwoReference Two);

	public static TestInputWithArguments<TOneReference, TOneTest> WithReferenceArguments<TOneReference, TOneTest>(this ITestInput<TOneReference, TOneTest> input, TOneReference one)
		=> new TestInputWithArguments<TOneReference, TOneTest>(input, one);

	public static TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest> WithReferenceArguments<TOneReference, TOneTest, TTwoReference, TTwoTest>(this ITestInput<TOneReference, TOneTest, TTwoReference, TTwoTest> input, TOneReference one, TTwoReference two)
		=> new TestInputWithArguments<TOneReference, TOneTest, TTwoReference, TTwoTest>(input, one, two);
}
