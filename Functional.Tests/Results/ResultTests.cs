using System;
using System.Threading.Tasks;
using FluentAssertions;
using Functional.Tests.Utilities;
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
			var objectObjectInput = Result.Success<object, object>(new object());
			var objectExceptionInput = Result.Success<object, Exception>(new object());

			objectObjectInput.TrySelect(o => (Object: o, Boolean: true), ex => throw new System.Exception("Should not be a failure")).Should().BeSuccessful(withFailureFactoryResult =>
			{
				withFailureFactoryResult.Object.Should().Be(objectObjectInput.Success().ValueOrDefault());
				withFailureFactoryResult.Boolean.Should().BeTrue();
			});

			objectExceptionInput.TrySelect(o => (Object: o, Boolean: true)).Should().BeSuccessful(withoutFailureFactoryResult =>
			{
				withoutFailureFactoryResult.Object.Should().Be(objectExceptionInput.Success().ValueOrDefault());
				withoutFailureFactoryResult.Boolean.Should().BeTrue();
			});

			(await Task.FromResult(objectObjectInput).TrySelect(o => (Object: o, Boolean: true), ex => throw new System.Exception("Should not be a failure"))).Should().BeSuccessful(withFailureFactoryTaskResult =>
			{
				withFailureFactoryTaskResult.Object.Should().Be(objectObjectInput.Success().ValueOrDefault());
				withFailureFactoryTaskResult.Boolean.Should().BeTrue();
			});

			(await Task.FromResult(objectExceptionInput).TrySelect(o => (Object: o, Boolean: true))).Should().BeSuccessful(result =>
			{
				result.Object.Should().Be(objectExceptionInput.Success().ValueOrDefault());
				result.Boolean.Should().BeTrue();
			});
		}

		[Fact]
		public async Task TryWorksCorrectlyWithFailure()
		{
			var objectObjectInput = Result.Failure<object, object>(new object());
			var objectExceptionInput = Result.Failure<object, Exception>(new Exception());

			objectObjectInput.TrySelect<object, object, object>(o => throw new Exception("Should not be a success"), ex => throw new Exception("Should not be a failure")).Should().BeFaulted(withFailureFactoryResult =>
			{
				withFailureFactoryResult.Should().Be(objectObjectInput.Failure().ValueOrDefault());
			});

			objectExceptionInput.TrySelect(o => (Object: o, Boolean: true)).Should().BeFaulted(withoutFailureFactoryResult =>
			{
				withoutFailureFactoryResult.Should().Be(objectExceptionInput.Failure().ValueOrDefault());
			});

			(await Task.FromResult(objectObjectInput).TrySelect<object, object, object>(o => throw new Exception("Should not be a success"), ex => throw new Exception("Should not be a failure"))).Should().BeFaulted(withFailureFactoryTaskResult =>
			{
				withFailureFactoryTaskResult.Should().Be(objectObjectInput.Failure().ValueOrDefault());
			});

			(await Task.FromResult(objectExceptionInput).TrySelect(o => (Object: o, Boolean: true))).Should().BeFaulted(result =>
			{
				result.Should().Be(objectExceptionInput.Failure().ValueOrDefault());
			});
		}

		[Fact]
		public async Task TryWorksCorrectlyWhenExceptionThrown()
		{
			var exception = new Exception();
			var objectObjectInput = Result.Success<object, (Exception Exception, bool Boolean)>(new object());
			var objectExceptionInput = Result.Success<object, Exception>(new object());

			objectObjectInput.TrySelect<object, object, (Exception Exception, bool Boolean)>(s => throw exception, f => (f, true)).Should().BeFaulted(withFailureFactoryResult =>
			{
				withFailureFactoryResult.Exception.Should().Be(exception);
				withFailureFactoryResult.Boolean.Should().BeTrue();
			});

			objectExceptionInput.TrySelect<object, object>(o => throw exception).Should().BeFaulted(withoutFailureFactoryResult =>
			{
				withoutFailureFactoryResult.Should().Be(exception);
			});

			(await Task.FromResult(objectObjectInput).TrySelect<object, object, (Exception Exception, bool Boolean)>(o => throw exception, ex => (ex, true))).Should().BeFaulted(withFailureFactoryTaskResult =>
			{
				withFailureFactoryTaskResult.Exception.Should().Be(exception);
				withFailureFactoryTaskResult.Boolean.Should().BeTrue();
			});

			(await Task.FromResult(objectExceptionInput).TrySelect<object, object>(o => throw exception)).Should().BeFaulted(result =>
			{
				result.Should().Be(exception);
			});
		}
	}
}
