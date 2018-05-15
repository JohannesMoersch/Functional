using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.AsyncEnumerables
{
    public class ChainTests
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
    }
}
