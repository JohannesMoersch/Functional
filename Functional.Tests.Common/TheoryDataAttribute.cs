using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Functional.Tests
{
	public abstract class TheoryDataAttribute : DataAttribute
	{
		public override ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(MethodInfo testMethod, DisposalTracker disposalTracker)
			=> ValueTask
				.FromResult<IReadOnlyCollection<ITheoryDataRow>>
				(
					GetData()
						.Select(value => ConvertDataRow(value))
						.ToArray()
				);

		public override bool SupportsDiscoveryEnumeration()
			=> true;

		public abstract IEnumerable<object[]> GetData();
	}
}
