using FluentAssertions;
using Xunit;

namespace Functional.Tests.Results
{
	public class ResultTests
	{
		[Fact]
		public void SuccessDoesNotEqualFailure()
		{
			var success = Result.Success<Unit, Unit>(Unit.Value);
			var failure = Result.Failure<Unit, Unit>(Unit.Value);

			success.Equals(failure).Should().BeFalse();
		}

		[Fact]
		public void FailureDoesNotEqualSuccess()
		{
			var success = Result.Success<Unit, Unit>(Unit.Value);
			var failure = Result.Failure<Unit, Unit>(Unit.Value);

			failure.Equals(success).Should().BeFalse();
		}

		[Fact]
		public void SuccessEqualsSuccess()
		{
			var successOne = Result.Success<Unit, Unit>(Unit.Value);
			var successTwo = Result.Success<Unit, Unit>(Unit.Value);

			successOne.Equals(successTwo).Should().BeTrue();
		}
		
		[Fact]
		public void FailureEqualsFailure()
		{
			var failureOne = Result.Failure<Unit, Unit>(Unit.Value);
			var failureTwo = Result.Failure<Unit, Unit>(Unit.Value);

			failureOne.Equals(failureTwo).Should().BeTrue();
		}

		[Fact]
		public void SuccessDoesNotEqualSuccessOfDifferentValue()
		{
			var successOne = Result.Success<int, Unit>(1);
			var successTwo = Result.Success<int, Unit>(2);

			successOne.Equals(successTwo).Should().BeFalse();
		}

		[Fact]
		public void FailureDoesNotEqualFailureOfDifferentValue()
		{
			var failureOne = Result.Failure<Unit, int>(1);
			var failureTwo = Result.Failure<Unit, int>(2);

			failureOne.Equals(failureTwo).Should().BeFalse();
		}
	}
}
