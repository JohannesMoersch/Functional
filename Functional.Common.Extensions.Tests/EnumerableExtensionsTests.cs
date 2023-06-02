using FluentAssertions;
using System;
using System.Collections;
namespace Functional.Tests;

public class EnumerableExtensionsTests
{	
	[Theory]
	[EnumerableTestData<int, int>(new[] { 1, 2, 3 }, new[] { 4, 3, 2 }, SkipSynchronous = true)]
	public Task Test1(TestInput.TwoEnumerables<int, int> input)
		=> EnumerableTest
			.Execute(EnumerableExtensions.Union, input.One, input.Two)
			.ShouldBeEquivalentTo(() => Enumerable.Union(input.One.Reference, input.Two.Reference));

	[Theory]
	[EnumerableTestData<int, int>(null, new[] { 4, 3, 2 }, SkipSynchronous = true)]
	[EnumerableTestData<int, int>(new[] { 1, 2, 3 }, null, SkipSynchronous = true)]
	public Task Test2(TestInput.TwoEnumerables<int, int> input)
		=> EnumerableTest
			.Execute(EnumerableExtensions.Union, input.One, input.Two)
			.ShouldBeEquivalentTo(() => Enumerable.Union(input.One.Reference, input.Two.Reference));

	[Theory]
	[EnumerableTestData<int>(new[] { 1, 2, 3, 4, 5 }, Types = EnumerableType.AsyncTypes)]
	public Task Test3(TestInput.OneEnumerable<int> input)
		=> EnumerableTest
			.ExecuteTest(EnumerableExtensions.Sum, input.One)
			.ShouldBeEquivalentTo(() => Enumerable.Sum(input.One.Reference));

	[Theory]
	[EnumerableTestData<int>(new[] { 1, 2, 3, 4, 5 }, Types = EnumerableType.AsyncTypes)]
	public Task Test4(TestInput.OneEnumerable<int> input)
		=> EnumerableTest
			.ExecuteTest(EnumerableExtensions.Sum, input.One, new Func<int, float>(i => i))
			.ShouldBeEquivalentTo(() => Enumerable.Sum(input.One.Reference, new Func<int, float>(i => i)));

	[Theory]
	[EnumerableNullTestData<int>(Types = EnumerableType.AsyncTypes)]
	public Task Test5(NullTestInput.OneEnumerable<int> input)
		=> EnumerableTest
			.ExecuteNullTest(EnumerableExtensions.Sum, input, input.One, new Func<int, float>(i => i))
			.ShouldBeEquivalentTo(Enumerable.Sum, input.One.Reference, new Func<int, float>(i => i));
}
