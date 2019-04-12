using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.Options
{
	public class OptionLinqSyntaxGroupTests
	{
		[Fact]
		public void SynchronousGroupBySuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				from value in Option.Some(num)
				group num by num % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeUntilNone()
			.AssertSome()
			.Should()
			.BeEquivalentTo(new[] { new[] { 1, 3, 5 }, new[] { 2, 4 } });


		[Fact]
		public Task SynchronousGroupByTaskSuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				from value in Option.Some(num)
				group num by num % 2 == 0 into numGroup
				select Task.FromResult(numGroup.ToArray())
			)
			.TakeUntilNone()
			.AssertSome()
			.Should()
			.BeEquivalentTo(new[] { new[] { 1, 3, 5 }, new[] { 2, 4 } });

		[Fact]
		public void SynchronousGroupByIntoFromSuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				from value in Option.Some(num)
				group num by num % 2 == 0 into numGroup
				from value in Option.Some(Array.Empty<int>())
				select numGroup.ToArray()
			)
			.TakeUntilNone()
			.AssertSome()
			.Should()
			.BeEquivalentTo(new[] { new[] { 1, 3, 5 }, new[] { 2, 4 } });

		[Fact]
		public void SynchronousWhereGroupBySuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				where Option.Where(true)
				group num by num % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeUntilNone()
			.AssertSome()
			.Should()
			.BeEquivalentTo(new[] { new[] { 1, 3, 5 }, new[] { 2, 4 } });

		[Fact]
		public void SynchronousGroupByFailure()
		=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				from value in Option.Create(num >= 3, num)
				group value by value % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeUntilNone()
			.AssertNone();

		[Fact]
		public void SynchronousGroupByIntoFromFailure()
		=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				from value in Option.Create(num >= 3, num)
				group value by value % 2 == 0 into numGroup
				from value in Option.Some(Array.Empty<int>())
				select numGroup.ToArray()
			)
			.TakeUntilNone()
			.AssertNone();

		[Fact]
		public void SynchronousWhereGroupByFailure()
		=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				where Option.Where(num >= 3)
				group num by num % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeUntilNone()
			.AssertNone();

		[Fact]
		public Task AsynchronousGroupBySuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }.AsAsyncEnumerable()
				from value in Option.Some(num)
				group num by num % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeUntilNone()
			.AssertSome()
			.Should()
			.BeEquivalentTo(new[] { new[] { 1, 3, 5 }, new[] { 2, 4 } });

		[Fact]
		public Task AsynchronousGroupByTaskSuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }.AsAsyncEnumerable()
				from value in Option.Some(num)
				group num by num % 2 == 0 into numGroup
				select Task.FromResult(numGroup.ToArray())
			)
			.TakeUntilNone()
			.AssertSome()
			.Should()
			.BeEquivalentTo(new[] { new[] { 1, 3, 5 }, new[] { 2, 4 } });

		[Fact]
		public Task AsynchronousGroupByIntoFromSuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }.AsAsyncEnumerable()
				from value in Option.Some(num)
				group num by num % 2 == 0 into numGroup
				from value in Option.Some<int[]>(Array.Empty<int>())
				select numGroup.ToArray()
			)
			.TakeUntilNone()
			.AssertSome()
			.Should()
			.BeEquivalentTo(new[] { new[] { 1, 3, 5 }, new[] { 2, 4 } });

		[Fact]
		public Task AsynchronousWhereGroupBySuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }.AsAsyncEnumerable()
				where Option.Where(true)
				group num by num % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeUntilNone()
			.AssertSome()
			.Should()
			.BeEquivalentTo(new[] { new[] { 1, 3, 5 }, new[] { 2, 4 } });

		[Fact]
		public Task AsynchronousGroupByFailure()
		=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }.AsAsyncEnumerable()
				from value in Option.Create(num >= 3, num)
				group value by value % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeUntilNone()
			.AssertNone();

		[Fact]
		public Task AsynchronousGroupByIntoFromFailure()
		=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }.AsAsyncEnumerable()
				from value in Option.Create(num >= 3, num)
				group value by value % 2 == 0 into numGroup
				from value in Option.Some<int[]>(Array.Empty<int>())
				select value
			)
			.TakeUntilNone()
			.AssertNone();

		[Fact]
		public Task AsynchronousWhereGroupByFailure()
		=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }.AsAsyncEnumerable()
				where Option.Where(num >= 3)
				group num by num % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeUntilNone()
			.AssertNone();
	}
}
