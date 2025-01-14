namespace Functional.Tests.EnumerableExtensionsTests;

public class UnionTests
{
	[Theory]
	[EnumerableTestData<int, int>]
	public Task Union(TestInput.TwoEnumerables<int, int> input)
		=> input
			.WithReferenceArguments([1, 2, 2, 3], [4, 3, 2])
			.Execute(EnumerableExtensions.Union)
			.ShouldBeEquivalentTo(Enumerable.Union);
}
