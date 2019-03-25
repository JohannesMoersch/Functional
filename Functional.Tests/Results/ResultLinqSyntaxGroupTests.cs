using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.Results
{
	public class ResultLinqSyntaxGroupTests
	{
		[Fact]
		public void SynchronousGroupBySuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				from value in Result.Success<int, string>(num)
				group num by num % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeUntilFailure()
			.AssertSuccess()
			.Should()
			.BeEquivalentTo(new[] { new[] { 1, 3, 5 }, new[] { 2, 4 } });

		[Fact]
		public void SynchronousWhereGroupBySuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				where Result.Where(true, String.Empty)
				group num by num % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeUntilFailure()
			.AssertSuccess()
			.Should()
			.BeEquivalentTo(new[] { new[] { 1, 3, 5 }, new[] { 2, 4 } });

		[Fact]
		public void SynchronousGroupByFailure()
		=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				from value in Result.Create(num >= 3, num, num.ToString())
				group value by value % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeAll()
			.AssertFailure()
			.Should()
			.BeEquivalentTo(new[] { "1", "2" });

		[Fact]
		public void SynchronousWhereGroupByFailure()
		=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				where Result.Where(num >= 3, num.ToString())
				group num by num % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeAll()
			.AssertFailure()
			.Should()
			.BeEquivalentTo(new[] { "1", "2" });

		[Fact]
		public Task AsynchronousGroupBySuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }.AsAsyncEnumerable()
				from value in Result.Success<int, string>(num)
				group num by num % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeUntilFailure()
			.AssertSuccess()
			.Should()
			.BeEquivalentTo(new[] { new[] { 1, 3, 5 }, new[] { 2, 4 } });

		[Fact]
		public Task AsynchronousWhereGroupBySuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }.AsAsyncEnumerable()
				where Result.Where(true, String.Empty)
				group num by num % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeUntilFailure()
			.AssertSuccess()
			.Should()
			.BeEquivalentTo(new[] { new[] { 1, 3, 5 }, new[] { 2, 4 } });

		[Fact]
		public Task AsynchronousGroupByFailure()
		=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }.AsAsyncEnumerable()
				from value in Result.Create(num >= 3, num, num.ToString())
				group value by value % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeAll()
			.AssertFailure()
			.Should()
			.BeEquivalentTo(new[] { "1", "2" });

		[Fact]
		public Task AsynchronousWhereGroupByFailure()
		=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }.AsAsyncEnumerable()
				where Result.Where(num >= 3, num.ToString())
				group num by num % 2 == 0 into numGroup
				select numGroup.ToArray()
			)
			.TakeAll()
			.AssertFailure()
			.Should()
			.BeEquivalentTo(new[] { "1", "2" });
	}
}
