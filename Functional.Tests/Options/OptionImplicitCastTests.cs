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
		public void ImplicitSuccessCastFromValue()
			=> OptionTestExtensions
				.AssertSome<int>(1)
				.Should()
				.Be(1);

		[Fact]
		public void ImplicitFailureCastFromOptionFailure()
			=> OptionTestExtensions
				.AssertNone<int>(Option.None());
	}
}
