using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests
{
    public class Test
    {
		[Fact]
		public async Task Blah()
		{
			var x = await
				from item1 in new[] { 1, 2, 3 }
				from item2 in new[] { 4, 5, 6 }
				select Task.FromResult((item1, item2));
			
			var y = await
				from item1 in Task.FromResult(new[] { 1, 2, 3 }).AsEnumerable()
				from item2 in new[] { 4, 5, 6 }
				from item3 in Task.FromResult(new[] { 7, 8, 9 }).AsEnumerable()
				from item4 in new[] { 10, 11, 11 }
				select (item1, item2, item3, item4);

			var z = await
				from item1 in new[] { 1, 2, 3 }
				from item2 in Task.FromResult(new[] { 4, 5, 6 }).AsEnumerable()
				from item3 in new[] { 7, 8, 9 }
				from item4 in Task.FromResult(new[] { 10, 11, 11 }).AsEnumerable()
				select Task.FromResult((item1, item2, item3, item4));

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
