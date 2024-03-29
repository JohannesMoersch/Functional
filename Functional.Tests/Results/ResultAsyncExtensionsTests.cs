﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Results
{
	public class ResultAsyncExtensionsTests
	{
		private const int VALUE = 10;

		public class WhenResultIsSuccess
		{
			private Result<int, string> Value => Result.Success<int, string>(VALUE);

			[Fact]
			public Task Select()
				=> Value
					.MapAsync(i => Task.FromResult(i * 2))
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public Task WhereTrue()
				=> Value
					.WhereAsync(_ => Task.FromResult(true), i => Task.FromResult("123"))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public Task WhereFalse()
				=> Value
					.WhereAsync(_ => Task.FromResult(false), i => Task.FromResult("123"))
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public Task MapFailure()
				=> Value
					.MapOnFailureAsync(i => Task.FromResult(1.0f))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public Task BindSuccess()
				=> Value
					.BindAsync(i => Task.FromResult(Result.Success<float, string>(i)))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public Task BindFailure()
				=> Value
					.BindAsync(i => Task.FromResult(Result.Failure<float, string>("123")))
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public Task BindOnFailureSuccess()
				=> Value
					.BindOnFailureAsync(i => Task.FromResult(Result.Success<int, string>(3)))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public Task BindOnFailureFailure()
				=> Value
					.BindOnFailureAsync(i => Task.FromResult(Result.Failure<int, string>("123")))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public async Task DoWithOneParameter()
			{
				bool success = false;
				await Value.DoAsync(_ => Task.FromResult(success = true));
				success
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task DoWithTwoParameters()
			{
				bool success = false, failure = false;
				await Value.DoAsync(_ => Task.FromResult(success = true), _ => Task.FromResult(failure = true));
				success
					.Should()
					.BeTrue();
				failure
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task DoOnFailure()
			{
				bool failure = false;
				await Value.DoOnFailureAsync(_ => Task.FromResult(failure = true));
				failure
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task Apply()
			{
				bool success = false, failure = false;
				await Value.ApplyAsync(_ => Task.FromResult(success = true), _ => Task.FromResult(failure = true));
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
					.TryMapAsync(i => Task.FromResult(i * 2), e => e.Message)
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public Task TrySelectThrowsException()
				=> Value
					.TryMapAsync<int, int, string>(i => throw new TestException("123"), e => e.Message)
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public Task TrySelectException()
				=> Result
					.Success<int, Exception>(VALUE)
					.TryMapAsync(i => Task.FromResult(i * 2))
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public Task TrySelectExceptionThrowsException()
				=> Result
					.Success<int, Exception>(VALUE)
					.TryMapAsync<int, int>(i => throw new TestException())
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();
		}

		public class WhenTaskResultIsSuccess
		{
			private Task<Result<int, string>> Value => Task.FromResult(Result.Success<int, string>(VALUE));

			[Fact]
			public Task Select()
				=> Value
					.MapAsync(i => Task.FromResult(i * 2))
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public Task WhereTrue()
				=> Value
					.WhereAsync(_ => Task.FromResult(true), i => Task.FromResult("123"))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public Task WhereFalse()
				=> Value
					.WhereAsync(_ => Task.FromResult(false), i => Task.FromResult("123"))
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public Task MapFailure()
				=> Value
					.MapOnFailureAsync(i => Task.FromResult(1.0f))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public Task BindSuccess()
				=> Value
					.BindAsync(i => Task.FromResult(Result.Success<float, string>(i)))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public Task BindFailure()
				=> Value
					.BindAsync(i => Task.FromResult(Result.Failure<float, string>("123")))
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public Task BindOnFailureSuccess()
				=> Value
					.BindOnFailureAsync(i => Task.FromResult(Result.Success<int, string>(3)))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public Task BindOnFailureFailure()
				=> Value
					.BindOnFailureAsync(i => Task.FromResult(Result.Failure<int, string>("123")))
					.AssertSuccess()
					.Should()
					.Be(VALUE);

			[Fact]
			public async Task DoWithOneParameter()
			{
				bool success = false;
				await Value.DoAsync(_ => Task.FromResult(success = true));
				success
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task DoWithTwoParameters()
			{
				bool success = false, failure = false;
				await Value.DoAsync(_ => Task.FromResult(success = true), _ => Task.FromResult(failure = true));
				success
					.Should()
					.BeTrue();
				failure
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task DoOnFailure()
			{
				bool failure = false;
				await Value.DoOnFailureAsync(_ => Task.FromResult(failure = true));
				failure
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task Apply()
			{
				bool success = false, failure = false;
				await Value.ApplyAsync(_ => Task.FromResult(success = true), _ => Task.FromResult(failure = true));
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
					.TryMapAsync(i => Task.FromResult(i * 2), e => e.Message)
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public Task TrySelectThrowsException()
				=> Value
					.TryMapAsync<int, int, string>(i => throw new TestException("123"), e => e.Message)
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public Task TrySelectException()
				=> Task
					.FromResult(Result
						.Success<int, Exception>(VALUE)
					)
					.TryMapAsync(i => Task.FromResult(i * 2))
					.AssertSuccess()
					.Should()
					.Be(20);

			[Fact]
			public Task TrySelectExceptionThrowsException()
				=> Task
					.FromResult(Result
						.Success<int, Exception>(VALUE)
					)
					.TryMapAsync<int, int>(i => throw new TestException())
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();
		}

		public class WhenResultIsFailure
		{
			private Result<int, string> Value => Result.Failure<int, string>("abc");

			[Fact]
			public Task Select()
				=> Value
					.MapAsync(i => Task.FromResult(i * 2))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task WhereTrue()
				=> Value
					.WhereAsync(_ => Task.FromResult(true), i => Task.FromResult("123"))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task WhereFalse()
				=> Value
					.WhereAsync(_ => Task.FromResult(false), i => Task.FromResult("123"))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task MapFailure()
				=> Value
					.MapOnFailureAsync(i => Task.FromResult(1.0f))
					.AssertFailure()
					.Should()
					.Be(1.0f);

			[Fact]
			public Task BindSuccess()
				=> Value
					.BindAsync(i => Task.FromResult(Result.Success<float, string>(i)))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task BindFailure()
				=> Value
					.BindAsync(i => Task.FromResult(Result.Failure<float, string>("123")))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task BindOnFailureSuccess()
				=> Value
					.BindOnFailureAsync(i => Task.FromResult(Result.Success<int, bool>(3)))
					.AssertSuccess()
					.Should()
					.Be(3);

			[Fact]
			public Task BindOnFailureFailure()
				=> Value
					.BindOnFailureAsync(i => Task.FromResult(Result.Failure<int, bool>(false)))
					.AssertFailure()
					.Should()
					.BeFalse();

			[Fact]
			public async Task DoWithOneParameter()
			{
				bool success = false;
				await Value.DoAsync(_ => Task.FromResult(success = true));
				success
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task DoWithTwoParameters()
			{
				bool success = false, failure = false;
				await Value.DoAsync(_ => Task.FromResult(success = true), _ => Task.FromResult(failure = true));
				success
					.Should()
					.BeFalse();
				failure
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task DoOnFailure()
			{
				bool failure = false;
				await Value.DoOnFailureAsync(_ => Task.FromResult(failure = true));
				failure
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task Apply()
			{
				bool success = false, failure = false;
				await Value.ApplyAsync(_ => Task.FromResult(success = true), _ => Task.FromResult(failure = true));
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
					.TryMapAsync(i => Task.FromResult(i * 2), e => e.Message)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task TrySelectThrowsException()
				=> Value
					.TryMapAsync<int, int, string>(i => throw new TestException("123"), e => e.Message)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task TrySelectException()
				=> Result
					.Failure<int, Exception>(new TestException())
					.TryMapAsync(i => Task.FromResult(i * 2))
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();

			[Fact]
			public Task TrySelectExceptionThrowsException()
				=> Result
					.Failure<int, Exception>(new TestException())
					.TryMapAsync<int, int>(i => throw new ArgumentException())
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();
		}

		public class WhenTaskResultIsFailure
		{
			private Task<Result<int, string>> Value => Task.FromResult(Result.Failure<int, string>("abc"));

			[Fact]
			public Task Select()
				=> Value
					.MapAsync(i => Task.FromResult(i * 2))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task WhereTrue()
				=> Value
					.WhereAsync(_ => Task.FromResult(true), i => Task.FromResult("123"))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task WhereFalse()
				=> Value
					.WhereAsync(_ => Task.FromResult(false), i => Task.FromResult("123"))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task MapFailure()
				=> Value
					.MapOnFailureAsync(i => Task.FromResult(1.0f))
					.AssertFailure()
					.Should()
					.Be(1.0f);

			[Fact]
			public Task BindSuccess()
				=> Value
					.BindAsync(i => Task.FromResult(Result.Success<float, string>(i)))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task BindFailure()
				=> Value
					.BindAsync(i => Task.FromResult(Result.Failure<float, string>("123")))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task BindOnFailureSuccess()
				=> Value
					.BindOnFailureAsync(i => Task.FromResult(Result.Success<int, string>(3)))
					.AssertSuccess()
					.Should()
					.Be(3);

			[Fact]
			public Task BindOnFailureFailure()
				=> Value
					.BindOnFailureAsync(i => Task.FromResult(Result.Failure<int, string>("123")))
					.AssertFailure()
					.Should()
					.Be("123");

			[Fact]
			public async Task DoWithOneParameter()
			{
				bool success = false;
				await Value.DoAsync(_ => Task.FromResult(success = true));
				success
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task DoWithTwoParameters()
			{
				bool success = false, failure = false;
				await Value.DoAsync(_ => Task.FromResult(success = true), _ => Task.FromResult(failure = true));
				success
					.Should()
					.BeFalse();
				failure
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task DoOnFailure()
			{
				bool failure = false;
				await Value.DoOnFailureAsync(_ => Task.FromResult(failure = true));
				failure
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task Apply()
			{
				bool success = false, failure = false;
				await Value.ApplyAsync(_ => Task.FromResult(success = true), _ => Task.FromResult(failure = true));
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
					.TryMapAsync(i => Task.FromResult(i * 2), e => e.Message)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task TrySelectThrowsException()
				=> Value
					.TryMapAsync<int, int, string>(i => throw new TestException("123"), e => e.Message)
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public Task TrySelectException()
				=> Task
					.FromResult(Result
						.Failure<int, Exception>(new TestException())
					)
					.TryMapAsync(i => Task.FromResult(i * 2))
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();

			[Fact]
			public Task TrySelectExceptionThrowsException()
				=> Task
					.FromResult(Result
						.Failure<int, Exception>(new TestException())
					)
					.TryMapAsync<int, int>(i => throw new ArgumentException())
					.AssertFailure()
					.Should()
					.BeOfType<TestException>();
		}
	}
}
