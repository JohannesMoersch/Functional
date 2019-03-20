using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xunit;

namespace Functional.Tests.Results
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ResultLinqSyntaxGroupExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<System.Linq.IGrouping<TKey, TElement>, TFailure> GroupBy<TKey, TSuccess, TElement, TFailure>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, TKey> keySelector, Func<TSuccess, TElement> elementSelector)
			=> null;

		public static IResultEnumerable<TSuccess, TFailure> Select<TSuccess, TResult, TFailure>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, TResult> selector)
			=> null;
	}

	public class ResultLinqSyntaxTests
	{
		[Fact]
		public void EnumerableWhereSuccessful()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				where Result.Success<Unit, string>(Unit.Value)
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
				where Result.Create(num % 2 == 0, Unit.Value, num.ToString())
				select num
			)
			.TakeAll()
			.AssertFailure()
			.Should()
			.BeEquivalentTo(new[] { "1", "3", "5" });

		[Fact]
		public void SynchronousGroupBy()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				from value in Result.Success<int, string>(num)
				group value by value % 2 == 0 into numGroup
				select (numGroup.Key, numGroup)
			)
			.Should()
			.BeEquivalentTo(null);

		[Fact]
		public void SynchronousGroupBy2()
		{
			/*
			var stuff =
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				from value in Result.Success<int, string>(num)
				group value by value % 2 == 0 into numGroup
				from x in Result.Success<int, string>(numGroup.Count())
				select x
			).ToArray();
			*/
		}
	}
}
