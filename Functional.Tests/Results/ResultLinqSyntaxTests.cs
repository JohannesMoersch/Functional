using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Functional.Tests.Results
{
	public class ResultLinqSyntaxTests
	{
		public void SynchronousGroupBy()
			=>
			(
				from num in new int[] { 1, 2, 3, 4, 5 }
				from value in Result.Success<int, string>(num)
				group value by value % 2 == 0 into numGroup
				from x in numGroup
				select x
			)
			.TakeUntilFailure();
	}
}
