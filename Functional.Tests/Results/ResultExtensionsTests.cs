using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Results
{
	public class ResultExtensionsTests
	{
		public class WhenResultIsSuccess
		{
			private Result<int, string> Value => Result.Success<int, string>(10);

			[Fact]
			public void IsSuccess()
				=> Value
					.IsSuccess()
					.Should()
					.BeTrue();

			[Fact]
			public void Success()
				=> Value
					.Success()
					.AssertSome()
					.Should()
					.Be(10);

			[Fact]
			public void Failure()
				=> Value
					.Failure()
					.AssertNone();

			[Fact]
			public void Select()
				=> Value
					.Select(i => i * 2)
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public void WhereTrue()
				=> Value
					.Where(_ => Result.Unit<string>())
					.AssertSuccess()
					.Should()
					.Be(10);

			[Fact]
			public void WhereFalse()
				=> Value
					.Where(_ => Result.Failure<Unit, string>("123"))
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public void MapFailure()
				=> Value
					.MapFailure(i => 1.0f)
					.AssertSuccess()
					.Should()
					.Be(10);

			[Fact]
			public void BindSuccess()
				=> Value
					.Bind(i => Result.Success<float, string>(i))
					.AssertSuccess()
					.Should()
					.Be(10.0f);

			[Fact]
			public void BindFailure()
				=> Value
					.Bind(i => Result.Failure<float, string>("123"))
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public void DoWithOneParameter()
			{
				bool success = false;
				Value.Do(_ => success = true);
				success
					.Should()
					.BeTrue();
			}

			[Fact]
			public void DoWithTwoParameters()
			{
				bool success = false, failure = false;
				Value.Do(_ => success = true, _ => failure = true);
				success
					.Should()
					.BeTrue();
				failure
					.Should()
					.BeFalse();
			}

			[Fact]
			public void ApplyWithOneParameter()
			{
				bool success = false;
				Value.Do(_ => success = true);
				success
					.Should()
					.BeTrue();
			}

			[Fact]
			public void ApplyWithTwoParameters()
			{
				bool success = false, failure = false;
				Value.Do(_ => success = true, _ => failure = true);
				success
					.Should()
					.BeTrue();
				failure
					.Should()
					.BeFalse();
			}

			[Fact]
			public void TrySelect()
				=> Value
					.TrySelect(i => i * 2, e => e.Message)
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public void TrySelectThrowsException()
				=> Value
					.TrySelect<int, int, string>(i => throw new TestException("123"), e => e.Message)
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public void TrySelectException()
				=> Result
					.Success<int, Exception>(10)
					.TrySelect(i => i * 2)
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public void TrySelectExceptionThrowsException()
				=> Result
					.Success<int, Exception>(10)
					.TrySelect<int, int>(i => throw new TestException())
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();
		}

		public class WhenTaskResultIsSuccess
		{
			private Task<Result<int, string>> Value => Task.FromResult(Result.Success<int, string>(10));

			[Fact]
			public Task IsSuccess()
				=> Value
					.IsSuccess()
					.Should()
					.BeTrue();

			[Fact]
			public Task Success()
				=> Value
					.Success()
					.AssertSome()
					.Should()
					.Be(10);

			[Fact]
			public Task Failure()
				=> Value
					.Failure()
					.AssertNone();

			[Fact]
			public Task Select()
				=> Value
					.Select(i => i * 2)
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public Task WhereTrue()
				=> Value
					.Where(_ => Result.Unit<string>())
					.AssertSuccess()
					.Should()
					.Be(10);

			[Fact]
			public Task WhereFalse()
				=> Value
					.Where(_ => Result.Failure<Unit, string>("123"))
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public Task MapFailure()
				=> Value
					.MapFailure(i => 1.0f)
					.AssertSuccess()
					.Should()
					.Be(10);

			[Fact]
			public Task BindSuccess()
				=> Value
					.Bind(i => Result.Success<float, string>(i))
					.AssertSuccess()
					.Should()
					.Be(10.0f);

			[Fact]
			public Task BindFailure()
				=> Value
					.Bind(i => Result.Failure<float, string>("123"))
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public async Task DoWithOneParameter()
			{
				bool success = false;
				await Value.Do(_ => success = true);
				success
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task DoWithTwoParameters()
			{
				bool success = false, failure = false;
				await Value.Do(_ => success = true, _ => failure = true);
				success
					.Should()
					.BeTrue();
				failure
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task ApplyWithOneParameter()
			{
				bool success = false;
				await Value.Do(_ => success = true);
				success
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task ApplyWithTwoParameters()
			{
				bool success = false, failure = false;
				await Value.Do(_ => success = true, _ => failure = true);
				success
					.Should()
					.BeTrue();
				failure
					.Should()
					.BeFalse();
			}

			[Fact]
			public Task TrySelect()
				=> Value
					.TrySelect(i => i * 2, e => e.Message)
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public Task TrySelectThrowsException()
				=> Value
					.TrySelect<int, int, string>(i => throw new TestException("123"), e => e.Message)
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public Task TrySelectException()
				=> Task
					.FromResult(Result
						.Success<int, Exception>(10)
					)
					.TrySelect(i => i * 2)
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public Task TrySelectExceptionThrowsException()
				=> Task
					.FromResult(Result
						.Success<int, Exception>(10)
					)
					.TrySelect<int, int>(i => throw new TestException())
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();
		}

		public class WhenResultIsFailure
		{
			private Result<int, string> Value => Result.Failure<int, string>("abc");

			[Fact]
			public void IsSuccess()
				=> Value
					.IsSuccess()
					.Should()
					.BeFalse();

			[Fact]
			public void Success()
				=> Value
					.Success()
					.AssertNone();

			[Fact]
			public void Failure()
				=> Value
					.Failure()
					.AssertSome()
					.Should()
					.Be("abc");

			[Fact]
			public void Select()
				=> Value
					.Select(i => i * 2)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public void WhereTrue()
				=> Value
					.Where(_ => Result.Unit<string>())
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public void WhereFalse()
				=> Value
					.Where(_ => Result.Failure<Unit, string>("123"))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public void MapFailure()
				=> Value
					.MapFailure(i => 1.0f)
					.AssertFailure()
					.Should()
					.Be(1.0f);

			[Fact]
			public void BindSuccess()
				=> Value
					.Bind(i => Result.Success<float, string>(i))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public void BindFailure()
				=> Value
					.Bind(i => Result.Failure<float, string>("123"))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public void DoWithOneParameter()
			{
				bool success = false;
				Value.Do(_ => success = true);
				success
					.Should()
					.BeFalse();
			}

			[Fact]
			public void DoWithTwoParameters()
			{
				bool success = false, failure = false;
				Value.Do(_ => success = true, _ => failure = true);
				success
					.Should()
					.BeFalse();
				failure
					.Should()
					.BeTrue();
			}

			[Fact]
			public void ApplyWithOneParameter()
			{
				bool success = false;
				Value.Do(_ => success = true);
				success
					.Should()
					.BeFalse();
			}

			[Fact]
			public void ApplyWithTwoParameters()
			{
				bool success = false, failure = false;
				Value.Do(_ => success = true, _ => failure = true);
				success
					.Should()
					.BeFalse();
				failure
					.Should()
					.BeTrue();
			}

			[Fact]
			public void TrySelect()
				=> Value
					.TrySelect(i => i * 2, e => e.Message)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public void TrySelectThrowsException()
				=> Value
					.TrySelect<int, int, string>(i => throw new TestException("123"), e => e.Message)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public void TrySelectException()
				=> Result
					.Failure<int, Exception>(new TestException())
					.TrySelect(i => i * 2)
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();

			[Fact]
			public void TrySelectExceptionThrowsException()
				=> Result
					.Failure<int, Exception>(new TestException())
					.TrySelect<int, int>(i => throw new ArgumentException())
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();
		}

		public class WhenTaskResultIsFailure
		{
			private Task<Result<int, string>> Value => Task.FromResult(Result.Failure<int, string>("abc"));

			[Fact]
			public Task IsSuccess()
				=> Value
					.IsSuccess()
					.Should()
					.BeFalse();

			[Fact]
			public Task Success()
				=> Value
					.Success()
					.AssertNone();

			[Fact]
			public Task Failure()
				=> Value
					.Failure()
					.AssertSome()
					.Should()
					.Be("abc");

			[Fact]
			public Task Select()
				=> Value
					.Select(i => i * 2)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task WhereTrue()
				=> Value
					.Where(_ => Result.Unit<string>())
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task WhereFalse()
				=> Value
					.Where(_ => Result.Failure<Unit, string>("123"))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task MapFailure()
				=> Value
					.MapFailure(i => 1.0f)
					.AssertFailure()
					.Should()
					.Be(1.0f);

			[Fact]
			public Task BindSuccess()
				=> Value
					.Bind(i => Result.Success<float, string>(i))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task BindFailure()
				=> Value
					.Bind(i => Result.Failure<float, string>("123"))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public async Task DoWithOneParameter()
			{
				bool success = false;
				await Value.Do(_ => success = true);
				success
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task DoWithTwoParameters()
			{
				bool success = false, failure = false;
				await Value.Do(_ => success = true, _ => failure = true);
				success
					.Should()
					.BeFalse();
				failure
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task ApplyWithOneParameter()
			{
				bool success = false;
				await Value.Do(_ => success = true);
				success
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task ApplyWithTwoParameters()
			{
				bool success = false, failure = false;
				await Value.Do(_ => success = true, _ => failure = true);
				success
					.Should()
					.BeFalse();
				failure
					.Should()
					.BeTrue();
			}

			[Fact]
			public Task TrySelect()
				=> Value
					.TrySelect(i => i * 2, e => e.Message)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task TrySelectThrowsException()
				=> Value
					.TrySelect<int, int, string>(i => throw new TestException("123"), e => e.Message)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task TrySelectException()
				=> Task
					.FromResult(Result
						.Failure<int, Exception>(new TestException())
					)
					.TrySelect(i => i * 2)
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();

			[Fact]
			public Task TrySelectExceptionThrowsException()
				=> Task
					.FromResult(Result
						.Failure<int, Exception>(new TestException())
					)
					.TrySelect<int, int>(i => throw new ArgumentException())
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();
		}
	}
}
