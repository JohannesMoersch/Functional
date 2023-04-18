using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
	public class MiscellaneousTests
    {
		[Fact]
		public async Task SelectExecutedOnlyElementsEvaluatedByTake()
		{
			int selectCallCount = 0;

			await AsyncEnumerable
				.Create(Task.FromResult(new int[] { 1, 2, 3 }).AsEnumerable())
				.Select(i => ++selectCallCount)
				.TakeWhile(i => i != 2)
				.AsEnumerable();

			selectCallCount.Should().Be(2);
		}

		[Fact]
		public async Task MultipleEnumerationShouldBeEquivalent()
		{
			int invokeCount = 0;

			var sut =  AsyncEnumerable.Create(() => Task.FromResult(new[] { ++invokeCount }).AsEnumerable());

			(await sut.AsEnumerable()).Should().BeEquivalentTo(await sut.AsEnumerable());
		}

		[Fact]
		public async Task EnumerationOfArrayOfTasksIsSuccessful()
			=> (
					await
					AsyncEnumerable
					.Create(new[] { Task.FromResult(1), Task.FromResult(2), Task.FromResult(3) })
					.AsEnumerable()
				)
				.Should()
				.BeEquivalentTo(new[] { 1, 2, 3 });
	}
}
