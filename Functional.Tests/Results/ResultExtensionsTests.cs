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
		private const int VALUE = 10;

		public class WhenResultIsSuccess
		{
			private static Result<int, string> Value => Result.Success<int, string>(VALUE);

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
					.Be(VALUE);

			[Fact]
			public void Failure()
				=> Value
					.Failure()
					.AssertNone();

			[Fact]
			public void Select()
				=> Value
					.Map(i => i * 2)
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public void WhereTrue()
				=> Value
					.Where(_ => true, i => "123")
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public void WhereFalse()
				=> Value
					.Where(_ => false, i => "123")
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public void MapFailure()
				=> Value
					.MapOnFailure(i => 1.0f)
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public void BindSuccess()
				=> Value
					.Bind(i => Result.Success<float, string>(i))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public void BindFailure()
				=> Value
					.Bind(i => Result.Failure<float, string>("123"))
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public void BindOnFailureSuccess()
				=> Value
					.BindOnFailure(i => Result.Success<int, string>(3))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public void BindOnFailureFailure()
				=> Value
					.BindOnFailure(i => Result.Failure<int, string>("123"))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

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
			public void Apply()
			{
				bool success = false, failure = false;
				Value.Apply(_ => success = true, _ => failure = true);
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
					.TryMap(i => i * 2, e => e.Message)
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public void TrySelectThrowsException()
				=> Value
					.TryMap<int, int, string>(i => throw new TestException("123"), e => e.Message)
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public void TrySelectException()
				=> Result
					.Success<int, Exception>(VALUE)
					.TryMap(i => i * 2)
					.AssertSuccess()
					.Should()
					.Be(VALUE * 2);

			[Fact]
			public void TrySelectExceptionThrowsException()
				=> Result
					.Success<int, Exception>(VALUE)
					.TryMap<int, int>(i => throw new TestException())
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();

			[Fact]
			public void DoesNotThrowException()
				=> Result.Success<int, string>(1337)
					.ThrowOnFailure(_ => new InvalidOperationException("Expected success!"));
		}

		public class WhenTaskResultIsSuccess
		{
			private static Task<Result<int, string>> Value => Task.FromResult(Result.Success<int, string>(VALUE));

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
					.Be(VALUE);

			[Fact]
			public Task Failure()
				=> Value
					.Failure()
					.AssertNone();

			[Fact]
			public Task Select()
				=> Value
					.Map(i => i * 2)
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public Task WhereTrue()
				=> Value
					.Where(_ => true, i => "123")
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public Task WhereFalse()
				=> Value
					.Where(_ => false, i => "123")
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public Task MapFailure()
				=> Value
					.MapOnFailure(i => 1.0f)
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public Task BindSuccess()
				=> Value
					.Bind(i => Result.Success<float, string>(i))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public Task BindFailure()
				=> Value
					.Bind(i => Result.Failure<float, string>("123"))
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public Task BindOnFailureSuccess()
				=> Value
					.BindOnFailure(i => Result.Success<int, string>(3))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public Task BindOnFailureFailure()
				=> Value
					.BindOnFailure(i => Result.Failure<int, string>("123"))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

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
			public async Task Apply()
			{
				bool success = false, failure = false;
				await Value.Apply(_ => success = true, _ => failure = true);
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
					.TryMap(i => i * 2, e => e.Message)
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public Task TrySelectThrowsException()
				=> Value
					.TryMap<int, int, string>(i => throw new TestException("123"), e => e.Message)
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public Task TrySelectException()
				=> Task
					.FromResult(Result
						.Success<int, Exception>(VALUE)
					)
					.TryMap(i => i * 2)
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public Task TrySelectExceptionThrowsException()
				=> Task
					.FromResult(Result
						.Success<int, Exception>(VALUE)
					)
					.TryMap<int, int>(i => throw new TestException())
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();

			[Fact]
			public async Task DoesNotThrowException()
				=> await Task.FromResult(Result.Success<int, string>(1337))
					.ThrowOnFailure(_ => new InvalidOperationException("Expected success!"));
		}

		public class WhenResultIsFailure
		{
			private static Result<int, string> Value => Result.Failure<int, string>("abc");

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
					.Map(i => i * 2)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public void WhereTrue()
				=> Value
					.Where(_ => true, i => "123")
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public void WhereFalse()
				=> Value
					.Where(_ => false, i => "123")
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public void MapFailure()
				=> Value
					.MapOnFailure(i => 1.0f)
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
			public void BindOnFailureSuccess()
				=> Value
					.BindOnFailure(i => Result.Success<int, bool>(3))
					.AssertSuccess()
					.Should()
					.Be(3);

			[Fact]
			public void BindOnFailureFailure()
				=> Value
					.BindOnFailure(i => Result.Failure<int, bool>(false))
					.AssertFailure()
					.Should()
					.Be(false);

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
			public void Apply()
			{
				bool success = false, failure = false;
				Value.Apply(_ => success = true, _ => failure = true);
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
					.TryMap(i => i * 2, e => e.Message)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public void TrySelectThrowsException()
				=> Value
					.TryMap<int, int, string>(i => throw new TestException("123"), e => e.Message)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public void TrySelectException()
				=> Result
					.Failure<int, Exception>(new TestException())
					.TryMap(i => i * 2)
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();

			[Fact]
			public void TrySelectExceptionThrowsException()
				=> Result
					.Failure<int, Exception>(new TestException())
					.TryMap<int, int>(i => throw new ArgumentException())
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();

			[Fact]
			public void ThrowsException()
			{
				const string EXPECTED = "error";
				try
				{
					Result.Failure<int, string>(EXPECTED).ThrowOnFailure(e => new InvalidOperationException(e));
					throw new Exception("Expected to throw 'InvalidOperationException'");
				}
				catch (InvalidOperationException e)
				{
					e.Message.Should().Be(EXPECTED);
				}
			}
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
					.Map(i => i * 2)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task WhereTrue()
				=> Value
					.Where(_ => true, i => "123")
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task WhereFalse()
				=> Value
					.Where(_ => false, i => "123")
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task MapFailure()
				=> Value
					.MapOnFailure(i => 1.0f)
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
			public Task BindOnFailureSuccess()
				=> Value
					.BindOnFailure(i => Result.Success<int, string>(3))
					.AssertSuccess()
					.Should()
					.Be(3);

			[Fact]
			public Task BindOnFailureFailure()
				=> Value
					.BindOnFailure(i => Result.Failure<int, string>("123"))
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
			public async Task Apply()
			{
				bool success = false, failure = false;
				await Value.Apply(_ => success = true, _ => failure = true);
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
					.TryMap(i => i * 2, e => e.Message)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task TrySelectThrowsException()
				=> Value
					.TryMap<int, int, string>(i => throw new TestException("123"), e => e.Message)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task TrySelectException()
				=> Task
					.FromResult(Result
						.Failure<int, Exception>(new TestException())
					)
					.TryMap(i => i * 2)
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();

			[Fact]
			public Task TrySelectExceptionThrowsException()
				=> Task
					.FromResult(Result
						.Failure<int, Exception>(new TestException())
					)
					.TryMap<int, int>(i => throw new ArgumentException())
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();

			[Fact]
			public async Task ThrowsException()
			{
				const string EXPECTED = "error";
				try
				{
					await Task.FromResult(Result.Failure<int, string>(EXPECTED)).ThrowOnFailure(e => new InvalidOperationException(e));
					throw new Exception("Expected to throw 'InvalidOperationException'");
				}
				catch (InvalidOperationException e)
				{
					e.Message.Should().Be(EXPECTED);
				}
			}
		}
	}
}
