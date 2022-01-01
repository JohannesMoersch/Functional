using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Results
{
	public class ResultImplicitCastTests
	{
		[Fact]
		public void ImplicitSuccessCastFromValue()
			=> ResultTestExtensions
				.AssertSuccess<int, string>(1)
				.Should()
				.Be(1);

		[Fact]
		public void ImplicitSuccessCastFromResultSuccess()
			=> ResultTestExtensions
				.AssertSuccess<int, string>(Result.Success(1))
				.Should()
				.Be(1);

		[Fact]
		public void ImplicitFailureCastFromValue()
			=> ResultTestExtensions
				.AssertFailure<int, string>("One")
				.Should()
				.Be("One");

		[Fact]
		public void ImplicitFailureCastFromResultFailure()
			=> ResultTestExtensions
				.AssertFailure<int, string>(Result.Failure("One"))
				.Should()
				.Be("One");
	}
}
