using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.Options
{
	public class OptionLinqSyntaxWhereTests
	{
		[Fact]
		public void WhereSuccessful()
			=>
			(
				from unit in Option.Unit()
				where Option.Where(true)
				select unit
			)
			.AssertSome();

		[Fact]
		public void WhereFailure()
			=>
			(
				from unit in Option.Unit()
				where Option.Where(false)
				select unit
			)
			.AssertNone();

		[Fact]
		public Task WhereTaskSuccessful()
			=>
			(
				from unit in Option.Unit()
				where Task.FromResult(Option.Where(true))
				select unit
			)
			.AssertSome();

		[Fact]
		public Task WhereTaskFailure()
			=>
			(
				from unit in Option.Unit()
				where Task.FromResult(Option.Where(false))
				select unit
			)
			.AssertNone();

		[Fact]
		public void EnumerableWhereSuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				where Option.Where(true)
				select num
			)
			.WhereSome()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });

		[Fact]
		public void EnumerableWhereFailure()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				where Option.Where(num % 2 == 0)
				select num
			)
			.Count(o => !o.HasValue())
			.Should()
			.Be(3);

		[Fact]
		public Task EnumerableWhereAsyncSuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				where Task.FromResult(Option.Where(true))
				select num
			)
			.WhereSome()
			.AsEnumerable()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });

		[Fact]
		public Task EnumerableWhereAsyncFailure()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				where Task.FromResult(Option.Where(num % 2 == 0))
				select num
			)
			.AsEnumerable()
			.Count(o => !o.HasValue())
			.Should()
			.Be(3);
	}
}
