using FluentAssertions;
using System;
using System.Collections;
namespace Functional.Tests;

public class EnumerableExtensionsTests
{	
	[Theory]
	[EnumerableTestData<int, int>(new[] { 1, 2, 3 }, new[] { 4, 3, 2 }, SkipSynchronous = true)]
	public Task Test1(EnumerableTestInput<int, int> input)
		=> EnumerableTest
			.Execute(EnumerableExtensions.Union, input.One, input.Two)
			.ShouldBeEquivalentTo(() => Enumerable.Union(input.One.Reference, input.Two.Reference));

	[Theory]
	[EnumerableTestData<int, int>(null, new[] { 4, 3, 2 }, SkipSynchronous = true)]
	[EnumerableTestData<int, int>(new[] { 1, 2, 3 }, null, SkipSynchronous = true)]
	public Task Test2(EnumerableTestInput<int, int> input)
		=> EnumerableTest
			.Execute(EnumerableExtensions.Union, input.One, input.Two)
			.ShouldBeEquivalentTo(() => Enumerable.Union(input.One.Reference, input.Two.Reference));

	[Theory]
	[EnumerableTestData<int>(new[] { 1, 2, 3, 4, 5 }, Types = EnumerableType.AsyncTypes)]
	public Task Test3(EnumerableTestInput<int> input)
		=> EnumerableTest
			.Execute(EnumerableExtensions.Sum, input.One)
			.ShouldBeEquivalentTo(() => Enumerable.Sum(input.One.Reference));

	[Theory]
	[EnumerableTestData<int>(new[] { 1, 2, 3, 4, 5 }, Types = EnumerableType.AsyncTypes)]
	public Task Test4(EnumerableTestInput<int> input)
		=> EnumerableTest
			.Execute(EnumerableExtensions.Sum, input.One, new Func<int, float>(i => i))
			.ShouldBeEquivalentTo(() => Enumerable.Sum(input.One.Reference, i => (float)i));
}
