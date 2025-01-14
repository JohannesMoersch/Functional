namespace Functional.Tests.EnumerableExtensionsTests;

public class SumTests
{
	[Theory]
	[EnumerableTestData<int>]
	public Task Sum(TestInput.OneEnumerable<int> input)
		=> input
			.WithReferenceArguments([1, 2, 3])
			.Execute(EnumerableExtensions.Sum)
			.ShouldBeEquivalentTo(Enumerable.Sum);

	[Theory]
	[EnumerableTestData<int>]
	public Task SumWithSelector(TestInput.OneEnumerable<int> input)
		=> input
			.WithReferenceArguments([1, 2, 3])
			.Execute(EnumerableExtensions.Sum, new Func<int, float>(i => i))
			.ShouldBeEquivalentTo(Enumerable.Sum, new Func<int, float>(i => i));

	[Theory]
	[EnumerableTestData<int>]
	public Task SumWithSelectorAndStuff(TestInput.OneEnumerable<int> input)
	=> input
		.WithReferenceArguments([1, 2, 3])
		.Execute(EnumerableExtensions.Sum, new Func<int, float>(i => i))
		.ShouldBeEquivalentTo(Enumerable.Sum, new Func<int, float>(i => i));
}
