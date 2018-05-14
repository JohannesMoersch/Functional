using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Functional.Tests
{
    public class Test
    {
		[Fact]
		public void Blah()
		{
			var a =
				from one in Result.Success<int, string>(1)
				from item in new[] { 1, 2, 3 }
				select (one, item);

			var b =
				from item in new[] { 1, 2, 3 }
				from one in Result.Success<int, string>(1)
				select (item, one);

			var c =
				from item1 in new[] { 1, 2, 3 }
				from one in Result.Success<int, string>(1)
				from item2 in new[] { 4, 5, 6 }
				from two in Result.Success<int, string>(1)
				select (item1, one, item2, two);

			var d =
				(
					from item1 in new[] { 1, 2, 3 }
					from one in Result.Create(item1 % 2 == 1, item1, "Failed!")
					from item2 in new[] { 4, 5, 6 }
					from two in Result.Success<int, string>(1)
					select (item1, one, item2, two)
				)
				.TakeUntilFailure();
		}
    }
}
