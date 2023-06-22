using FluentAssertions;
using System;
using System.Collections;
namespace Functional.Tests;

public class EnumerableExtensionsTests
{	
	[Theory]
	[EnumerableTestData<int, int>]
	public Task Test1(TestInput.TwoEnumerables<int, int> input)
		=> input
			.WithReferenceArguments(new[] { 1, 2, 2, 3 }, new[] { 4, 3, 2 })
			.Execute(EnumerableExtensions.Union)
			.ShouldBeEquivalentTo(Enumerable.Union);

	[Theory]
	[EnumerableNullTestData<int, int>]
	public Task Test2(NullTestInput.TwoEnumerables<int, int> input)
		=> input
			.WithReferenceArguments(Array.Empty<int>(), Array.Empty<int>())
			.Execute(EnumerableExtensions.Union)
			.ShouldBeEquivalentTo(Enumerable.Union);

	[Theory]
	[EnumerableTestData<int>]
	public Task Test3(TestInput.OneEnumerable<int> input)
		=> input
			.WithReferenceArguments(new[] { 1, 2, 3 })
			.Execute(EnumerableExtensions.Sum)
			.ShouldBeEquivalentTo(Enumerable.Sum);

	[Theory]
	[EnumerableTestData<int>]
	public Task Test4(TestInput.OneEnumerable<int> input)
		=> input
			.WithReferenceArguments(new[] { 1, 2, 3 })
			.Execute(EnumerableExtensions.Sum, new Func<int, float>(i => i))
			.ShouldBeEquivalentTo(Enumerable.Sum, new Func<int, float>(i => i));

	[Theory]
	[EnumerableNullTestData<int>(AdditionalArgumentCount = 1)]
	public Task Test5(NullTestInput.OneEnumerable<int> input)
		=> input
			.WithReferenceArguments(Array.Empty<int>())
			.Execute(EnumerableExtensions.Sum, new Func<int, float>(i => i))
			.ShouldBeEquivalentTo(Enumerable.Sum, new Func<int, float>(i => i));
}
