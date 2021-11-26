using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Options
{
	public class OptionImplicitCastTests
	{
		[Fact]
		public void ImplicitFailureCastFromOptionFailure()
			=> OptionTestExtensions
				.AssertNone<int>(Option.None());
	}
}
