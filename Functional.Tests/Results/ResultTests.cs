using System;
using System.Threading.Tasks;
using FluentAssertions;
using Functional.Tests.Utilities.Assertions;
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

		[Fact]
		public async Task TryWorksCorrectlyWithSuccess()
		{
			const int VALUE = 1337;
			var valueInput = Result.Success<int, string>(VALUE);
			var valueExceptionInput = Result.Success<int, Exception>(VALUE);

			valueInput.TrySelect(i => i.ToString(), ex => throw new InvalidOperationException()).Should().BeSuccessful(x => x.Should().Be(VALUE.ToString()));
			valueExceptionInput.TrySelect(i => i.ToString()).Should().BeSuccessful(withoutFailureFactoryResult => withoutFailureFactoryResult.Should().Be(VALUE.ToString()));

			(await Task.FromResult(valueInput).TrySelect(i => i.ToString(), ex => throw new InvalidOperationException())).Should().BeSuccessful(withFailureFactoryTaskResult => withFailureFactoryTaskResult.Should().Be(VALUE.ToString()));
			(await Task.FromResult(valueExceptionInput).TrySelect(i => i.ToString())).Should().BeSuccessful(result => result.Should().Be(VALUE.ToString()));
		}

		[Fact]
		public async Task TryWorksCorrectlyWithFailure()
		{
			const string ERROR = "some error";
			var exception = new Exception();
			var faultedInputHoldingMessage = Result.Failure<int, string>(ERROR);
			var faultedInputHoldingException = Result.Failure<int, Exception>(exception);

			faultedInputHoldingMessage.TrySelect<int, object, string>(o => throw new InvalidOperationException(), ex => throw new InvalidOperationException()).Should().BeFaulted(value => value.Should().Be(ERROR));
			faultedInputHoldingException.TrySelect(i => (Value: i, Boolean: true)).Should().BeFaulted(value => value.Should().Be(exception));

			(await Task.FromResult(faultedInputHoldingMessage).TrySelect<int, object, string>(o => throw new InvalidOperationException(), ex => throw new InvalidOperationException())).Should().BeFaulted(value => value.Should().Be(ERROR));
			(await Task.FromResult(faultedInputHoldingException).TrySelect(i => (Value: i, Boolean: true))).Should().BeFaulted(value => value.Should().Be(exception));
		}

		[Fact]
		public async Task TryWorksCorrectlyWhenExceptionThrown()
		{
			var exception = new Exception("the error message");
			var objectObjectInput = Result.Success<object, string>(new object());
			var objectExceptionInput = Result.Success<object, Exception>(new object());

			objectObjectInput.TrySelect<object, object, string>(s => throw exception, f => f.Message).Should().BeFaulted(value => value.Should().Be(exception.Message));
			objectExceptionInput.TrySelect<object, object>(o => throw exception).Should().BeFaulted(value => value.Should().Be(exception));

			(await Task.FromResult(objectObjectInput).TrySelect<object, object, string>(o => throw exception, ex => ex.Message)).Should().BeFaulted(value => value.Should().Be(exception.Message));
			(await Task.FromResult(objectExceptionInput).TrySelect<object, object>(o => throw exception)).Should().BeFaulted(value => value.Should().Be(exception));
		}
	}
}
