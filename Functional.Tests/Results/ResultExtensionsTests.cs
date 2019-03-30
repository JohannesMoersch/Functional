using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Results
{
	public class ResultExtensionsTests
	{
		[Fact]
		public async Task TryWorksCorrectlyWithSuccess()
		{
			var objectObjectInput = Result.Success<object, object>(new object());
			var objectExceptionInput = Result.Success<object, Exception>(new object());

			var withFailureFactoryResult = objectObjectInput.TrySelect(o => (Object: o, Boolean: true), ex => throw new System.Exception("Should not be a failure")).AssertSuccess();
			withFailureFactoryResult.Object.Should().Be(objectObjectInput.Success().ValueOrDefault());
			withFailureFactoryResult.Boolean.Should().BeTrue();


			var withoutFailureFactoryResult = objectExceptionInput.TrySelect(o => (Object: o, Boolean: true)).AssertSuccess();
			withoutFailureFactoryResult.Object.Should().Be(objectExceptionInput.Success().ValueOrDefault());
			withoutFailureFactoryResult.Boolean.Should().BeTrue();


			var withFailureFactoryTaskResult = await Task.FromResult(objectObjectInput).TrySelect(o => (Object: o, Boolean: true), ex => throw new System.Exception("Should not be a failure")).AssertSuccess();
			withFailureFactoryTaskResult.Object.Should().Be(objectObjectInput.Success().ValueOrDefault());
			withFailureFactoryTaskResult.Boolean.Should().BeTrue();


			var result = await Task.FromResult(objectExceptionInput).TrySelect(o => (Object: o, Boolean: true)).AssertSuccess();
			result.Object.Should().Be(objectExceptionInput.Success().ValueOrDefault());
			result.Boolean.Should().BeTrue();
		}

		[Fact]
		public async Task TryWorksCorrectlyWithFailure()
		{
			var objectObjectInput = Result.Failure<object, object>(new object());
			var objectExceptionInput = Result.Failure<object, Exception>(new Exception());

			var withFailureFactoryResult = objectObjectInput.TrySelect<object, object, object>(o => throw new Exception("Should not be a success"), ex => throw new Exception("Should not be a failure")).AssertFailure();
			withFailureFactoryResult.Should().Be(objectObjectInput.Failure().ValueOrDefault());


			var withoutFailureFactoryResult = objectExceptionInput.TrySelect(o => (Object: o, Boolean: true)).AssertFailure();
			withoutFailureFactoryResult.Should().Be(objectExceptionInput.Failure().ValueOrDefault());


			var withFailureFactoryTaskResult = await Task.FromResult(objectObjectInput).TrySelect<object, object, object>(o => throw new Exception("Should not be a success"), ex => throw new Exception("Should not be a failure")).AssertFailure();
			withFailureFactoryTaskResult.Should().Be(objectObjectInput.Failure().ValueOrDefault());


			var result = await Task.FromResult(objectExceptionInput).TrySelect(o => (Object: o, Boolean: true)).AssertFailure();
			result.Should().Be(objectExceptionInput.Failure().ValueOrDefault());
		}

		[Fact]
		public async Task TryWorksCorrectlyWhenExceptionThrown()
		{
			var exception = new Exception();
			var objectObjectInput = Result.Success<object, (Exception Exception, bool Boolean)>(new object());
			var objectExceptionInput = Result.Success<object, Exception>(new object());

			var withFailureFactoryResult = objectObjectInput.TrySelect<object, object, (Exception Exception, bool Boolean)>(s => throw exception, f => (f, true)).AssertFailure();
			withFailureFactoryResult.Exception.Should().Be(exception);
			withFailureFactoryResult.Boolean.Should().BeTrue();


			var withoutFailureFactoryResult = objectExceptionInput.TrySelect<object, object>(o => throw exception).AssertFailure();
			withoutFailureFactoryResult.Should().Be(exception);


			var withFailureFactoryTaskResult = await Task.FromResult(objectObjectInput).TrySelect<object, object, (Exception Exception, bool Boolean)>(o => throw exception, ex => (ex, true)).AssertFailure();
			withFailureFactoryTaskResult.Exception.Should().Be(exception);
			withFailureFactoryTaskResult.Boolean.Should().BeTrue();


			var result = await Task.FromResult(objectExceptionInput).TrySelect<object, object>(o => throw exception).AssertFailure();
			result.Should().Be(exception);
		}
	}
}