namespace Functional.Tests.EnumerableExtensionsTests;

public class UnionTests
{
	[Theory]
	[EnumerableTestData<int, int>]
	public Task Union(TestInput.TwoEnumerables<int, int> input)
		=> input
			.WithReferenceArguments(new[] { 1, 2, 2, 3 }, new[] { 4, 3, 2 })
			.Execute(EnumerableExtensions.Union)
			.ShouldBeEquivalentTo(Enumerable.Union);
}
