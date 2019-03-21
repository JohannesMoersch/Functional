using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.Results
{
	public class ResultLinqSyntaxWhereTests
	{
		[Fact]
		public void WhereSuccessful()
			=>
			(
				from unit in Result.Unit<string>()
				where Result.Where(true, () => String.Empty)
				select unit
			)
			.AssertSuccess();

		[Fact]
		public void WhereFailure()
			=>
			(
				from unit in Result.Unit<string>()
				where Result.Where(false, () => String.Empty)
				select unit
			)
			.AssertFailure();

		[Fact]
		public Task WhereTaskSuccessful()
			=>
			(
				from unit in Result.Unit<string>()
				where Task.FromResult(Result.Where(true, () => String.Empty))
				select unit
			)
			.AssertSuccess();

		[Fact]
		public Task WhereTaskFailure()
			=>
			(
				from unit in Result.Unit<string>()
				where Task.FromResult(Result.Where(false, () => String.Empty))
				select unit
			)
			.AssertFailure();

		[Fact]
		public void EnumerableWhereSuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				where Result.Where(true, () => String.Empty)
				select num
			)
			.TakeAll()
			.AssertSuccess()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });

		[Fact]
		public void EnumerableWhereFailure()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				where Result.Where(num % 2 == 0, () => num.ToString())
				select num
			)
			.TakeAll()
			.AssertFailure()
			.Should()
			.BeEquivalentTo(new[] { "1", "3", "5" });

		[Fact]
		public Task EnumerableWhereAsyncSuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				where Task.FromResult(Result.Where(true, () => String.Empty))
				select num
			)
			.TakeAll()
			.AssertSuccess()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });

		[Fact]
		public Task EnumerableWhereAsyncFailure()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				where Task.FromResult(Result.Where(num % 2 == 0, num.ToString()))
				select num
			)
			.TakeAll()
			.AssertFailure()
			.Should()
			.BeEquivalentTo(new[] { "1", "3", "5" });
	}
}
