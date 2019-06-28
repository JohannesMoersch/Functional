using System;
using System.ComponentModel;
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
					.Where(_ => true, i => "123")
					.AssertSuccess()
					.Should()
					.Be(10);

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
				Value.Apply(_ => success = true);
				success
					.Should()
					.BeTrue();
			}

			[Fact]
			public void ApplyWithTwoParameters()
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
					.Where(_ => true, i => "123")
					.AssertSuccess()
					.Should()
					.Be(10);

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
				await Value.Apply(_ => success = true);
				success
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task ApplyWithTwoParameters()
			{
				bool success = false, failure = false;
				await Value.Apply(_ => success = true, _ => failure = true);
				success

			public class AndSelectIfNone
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class OntoValueProducingFunction
				{
					[Fact]
					public void ShouldDoNothingOnSuccessWithSomeValue()
						=> Result
							.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
							.SelectIfNone(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public void ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.SelectIfNone(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(EXPECTED_VALUE);

					[Fact]
					public void ShouldDoNothingOnFailure()
						=> Result
							.Failure<Option<int>, string>("some error")
							.SelectIfNone(OtherValue)
							.AssertFailure();

					private static int OtherValue() => EXPECTED_VALUE;
				}

				public class OntoOptionProducingFunction
				{
					public class OfSome
					{
						[Fact]
						public void ShouldDoNothingOnSuccessWithSomeValue()
							=> Result
								.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
								.SelectIfNone(OtherValue)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public void ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.SelectIfNone(OtherValue)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(EXPECTED_VALUE);

						[Fact]
						public void ShouldDoNothingOnFailure()
							=> Result
								.Failure<Option<int>, string>("some error")
								.SelectIfNone(OtherValue)
								.AssertFailure();

						private static Option<int> OtherValue() => Option.Some(EXPECTED_VALUE);
					}

					public class OfNone
					{
						[Fact]
						public void ShouldDoNothingOnSuccessWithSomeValue()
							=> Result
								.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
								.SelectIfNone(Nothing)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public void ShouldMapOptionNoneToOptionNone()
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.SelectIfNone(Nothing)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldDoNothingOnFailure()
							=> Result
								.Failure<Option<int>, string>("some error")
								.SelectIfNone(Nothing)
								.AssertFailure();

						private static Option<int> Nothing() => Option.None<int>();
					}
				}
			}

			public class AndSelectIfNoneAsync
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class OntoValueProducingFunction
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Result
							.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
							.SelectIfNoneAsync(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.SelectIfNoneAsync(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(EXPECTED_VALUE);

					[Fact]
					public Task ShouldDoNothingOnFailure()
						=> Result
							.Failure<Option<int>, string>("some error")
							.SelectIfNoneAsync(OtherValue)
							.AssertFailure();

					private static Task<int> OtherValue() => Task.FromResult(EXPECTED_VALUE);
				}

				public class OntoOptionProducingFunction
				{
					public class OfSome
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome()
							=> Result
								.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
								.SelectIfNoneAsync(OtherValue)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone()
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.SelectIfNoneAsync(OtherValue)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(EXPECTED_VALUE);

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Result
								.Failure<Option<int>, string>("some error")
								.SelectIfNoneAsync(OtherValue)
								.AssertFailure();

						private static Task<Option<int>> OtherValue() => Task.FromResult(Option.Some(EXPECTED_VALUE));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldDoNothingOnSuccessWithSomeValue()
							=> Result
								.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
								.SelectIfNoneAsync(Nothing)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone()
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.SelectIfNoneAsync(Nothing)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Result
								.Failure<Option<int>, string>("some error")
								.SelectIfNoneAsync(Nothing)
								.AssertFailure();

						private static Task<Option<int>> Nothing() => Task.FromResult(Option.None<int>());
					}
				}
			}

			public class AndBindIfNone
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public void ShouldMapOptionSomeToOptionSome()
						=> Result
							.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
							.BindIfNone(OtherResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public void ShouldMapOptionNoneToOptionNone()
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindIfNone(OtherResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(EXPECTED_VALUE);

					[Fact]
					public void ShouldDoNothingOnFailure()
						=> Result
							.Failure<Option<int>, string>("some error")
							.BindIfNone(OtherResult)
							.AssertFailure();

					private static Result<int, string> OtherResult() => Result.Success<int, string>(EXPECTED_VALUE);
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public void ShouldMapOptionSomeToOptionSome()
						=> Result
							.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
							.BindIfNone(ErrorResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public void ShouldMapOptionNoneToFaultedResult()
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindIfNone(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public void ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						Result.Failure<Option<int>, string>(EXISTING_ERROR)
							.BindIfNone(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Result<int, string> ErrorResult() => Result.Failure<int, string>(ERROR);
				}
			}

			public class AndBindIfNoneAsync
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Result
							.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
							.BindIfNoneAsync(OtherResultAsync)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindIfNoneAsync(OtherResultAsync)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(EXPECTED_VALUE);

					[Fact]
					public Task ShouldDoNothingOnFailure()
						=> Result
							.Failure<Option<int>, string>("some error")
							.BindIfNoneAsync(OtherResultAsync)
							.AssertFailure();

					private static Task<Result<int, string>> OtherResultAsync() => Task.FromResult(Result.Success<int, string>(EXPECTED_VALUE));
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToSuccessfulResult()
						=> Result
							.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
							.BindIfNoneAsync(ErrorResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToFaultedResult()
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindIfNoneAsync(ErrorResult)
							.AssertFailure();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Result.Failure<Option<int>, string>(EXISTING_ERROR)
							.BindIfNoneAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<int, string>> ErrorResult() => Task.FromResult(Result.Failure<int, string>(ERROR));
				}
			}

			public class AndBindIfNoneToResultOfOptionProducingFunction
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class AndFunctionProducesSuccessfulResult
				{
					public class OfSome
					{
						[Fact]
						public void ShouldDoNothingOnSuccessWithSomeValue()
							=> Result
								.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
								.BindIfNone(OtherSuccessfulResultWithSome)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public void ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.BindIfNone(OtherSuccessfulResultWithSome)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(EXPECTED_VALUE);

						[Fact]
						public void ShouldDoNothingOnFailure()
							=> Result
								.Failure<Option<int>, string>("some error")
								.BindIfNone(OtherSuccessfulResultWithSome)
								.AssertFailure();

						private static Result<Option<int>, string> OtherSuccessfulResultWithSome() => Result.Success<Option<int>, string>(Option.Some(EXPECTED_VALUE));
					}

					public class OfNone
					{
						[Fact]
						public void ShouldMapOptionSomeToOptionSome()
							=> Result
								.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
								.BindIfNone(IsNoneResult)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public void ShouldMapOptionNoneToOptionNone()
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.BindIfNone(IsNoneResult)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldDoNothingOnFailure()
							=> Result
								.Failure<Option<int>, string>("some error")
								.BindIfNone(IsNoneResult)
								.AssertFailure();

						private static Result<Option<int>, string> IsNoneResult() => Result.Success<Option<int>, string>(Option.None<int>());
					}
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public void ShouldMapOptionSomeToOptionSome()
						=> Result
							.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
							.BindIfNone(ErrorResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public void ShouldMapOptionNoneToFaultedResult()
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindIfNone(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public void ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						Result.Failure<Option<int>, string>(EXISTING_ERROR)
							.BindIfNone(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Result<Option<int>, string> ErrorResult() => Result.Failure<Option<int>, string>(ERROR);
				}
			}

			public class AndBindIfNoneAsyncToResultOfOptionProducingFunction
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class AndFunctionProducesSuccessfulResult
				{
					public class OfSome
					{
						[Fact]
						public Task ShouldDoNothingOnSuccessWithSomeValue()
							=> Result
								.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
								.BindIfNoneAsync(OtherResultAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.BindIfNoneAsync(OtherResultAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(EXPECTED_VALUE);

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Result
								.Failure<Option<int>, string>("some error")
								.BindIfNoneAsync(OtherResultAsync)
								.AssertFailure();

						private static Task<Result<Option<int>, string>> OtherResultAsync() => Task.FromResult(Result.Success<Option<int>, string>(Option.Some(EXPECTED_VALUE)));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldDoNothingOnSuccessWithSomeValue()
							=> Result
								.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
								.BindIfNoneAsync(OtherResultAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone()
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.BindIfNoneAsync(OtherResultAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Result
								.Failure<Option<int>, string>("some error")
								.BindIfNoneAsync(OtherResultAsync)
								.AssertFailure();

						private static Task<Result<Option<int>, string>> OtherResultAsync() => Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>()));
					}
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Result
							.Success<Option<int>, string>(Option.Some(INITIAL_VALUE))
							.BindIfNoneAsync(ErrorResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToFaultedResult()
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindIfNoneAsync(ErrorResult)
							.AssertFailure();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Result.Failure<Option<int>, string>(EXISTING_ERROR)
							.BindIfNoneAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<Option<int>, string>> ErrorResult() => Task.FromResult(Result.Failure<Option<int>, string>(ERROR));
				}
			}
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
				Value.Apply(_ => success = true);
				success
					.Should()
					.BeFalse();
			}

			[Fact]
			public void ApplyWithTwoParameters()
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
				await Value.Apply(_ => success = true);
				success
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task ApplyWithTwoParameters()
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

			public class AndSelectIfNone
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class OntoValueProducingFunction
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
							.SelectIfNone(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.SelectIfNone(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(EXPECTED_VALUE);

					[Fact]
					public Task ShouldDoNothingOnFailure()
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.SelectIfNone(OtherValue)
							.AssertFailure();

					private static int OtherValue() => EXPECTED_VALUE;
				}

				public class OntoOptionProducingFunction
				{
					public class OfSome
					{
						[Fact]
						public Task ShouldDoNothingOnSuccessWithSomeValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
								.SelectIfNone(OtherOption)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.SelectIfNone(OtherOption)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(EXPECTED_VALUE);

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.SelectIfNone(OtherOption)
								.AssertFailure();

						private static Option<int> OtherOption() => Option.Some(EXPECTED_VALUE);
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionNone()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
								.SelectIfNone(Nothing)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.SelectIfNone(Nothing)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.SelectIfNone(Nothing)
								.AssertFailure();

						private static Option<int> Nothing() => Option.None<int>();
					}
				}
			}

			public class AndSelectIfNoneAsync
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class OntoValueProducingFunction
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
							.SelectIfNoneAsync(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.SelectIfNoneAsync(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(EXPECTED_VALUE);

					[Fact]
					public Task ShouldDoNothingOnFailure()
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.SelectIfNoneAsync(OtherValue)
							.AssertFailure();

					private static Task<int> OtherValue() => Task.FromResult(EXPECTED_VALUE);
				}

				public class OntoOptionProducingFunction
				{
					public class OfSome
					{
						[Fact]
						public Task ShouldDoNothingOnSuccessWithSomeValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
								.SelectIfNoneAsync(OtherValue)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.SelectIfNoneAsync(OtherValue)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(EXPECTED_VALUE);

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.SelectIfNoneAsync(OtherValue)
								.AssertFailure();

						private static Task<Option<int>> OtherValue() => Task.FromResult(Option.Some(EXPECTED_VALUE));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldDoNothingOnSuccessWithSomeValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
								.SelectIfNoneAsync(Nothing)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.SelectIfNoneAsync(Nothing)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.SelectIfNoneAsync(Nothing)
								.AssertFailure();

						private static Task<Option<int>> Nothing() => Task.FromResult(Option.None<int>());
					}
				}
	}

			public class AndBindIfNone
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
							.BindIfNone(OtherResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindIfNone(OtherResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(EXPECTED_VALUE);

					[Fact]
					public Task ShouldDoNothingOnFailure()
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.BindIfNone(OtherResult)
							.AssertFailure();

					private static Result<int, string> OtherResult() => Result.Success<int, string>(EXPECTED_VALUE);
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
							.BindIfNone(ErrorResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToFaultedResult()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindIfNone(ErrorResult)
							.AssertFailure();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindIfNone(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Result<int, string> ErrorResult() => Result.Failure<int, string>(ERROR);
				}
			}

			public class AndBindIfNoneAsync
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
							.BindIfNoneAsync(OtherResultAsync)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindIfNoneAsync(OtherResultAsync)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(EXPECTED_VALUE);

					[Fact]
					public Task ShouldDoNothingOnFailure()
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.BindIfNoneAsync(OtherResultAsync)
							.AssertFailure();

					private static Task<Result<int, string>> OtherResultAsync() => Task.FromResult(Result.Success<int, string>(EXPECTED_VALUE));
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
							.BindIfNoneAsync(OtherResultAsync)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToFaultedResult()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindIfNoneAsync(OtherResultAsync)
							.AssertFailure();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindIfNoneAsync(OtherResultAsync)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<int, string>> OtherResultAsync() => Task.FromResult(Result.Failure<int, string>(ERROR));
				}
			}

			public class AndBindIfNoneToResultOfOptionProducingFunction
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class AndFunctionProducesSuccessfulResult
				{
					public class OfSome
					{
						[Fact]
						public Task ShouldDoNothingOnSuccessWithSomeValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
								.BindIfNone(OtherSuccessfulResultWithSome)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindIfNone(OtherSuccessfulResultWithSome)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(EXPECTED_VALUE);

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindIfNone(OtherSuccessfulResultWithSome)
								.AssertFailure();

						private static Result<Option<int>, string> OtherSuccessfulResultWithSome() => Result.Success<Option<int>, string>(Option.Some(EXPECTED_VALUE));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
								.BindIfNone(IsNoneResult)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindIfNone(IsNoneResult)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindIfNone(IsNoneResult)
								.AssertFailure();

						private static Result<Option<int>, string> IsNoneResult() => Result.Success<Option<int>, string>(Option.None<int>());
					}
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToOptionSome()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
							.BindIfNone(ErrorResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToFaultedResult()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindIfNone(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public async Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						await Task
							.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindIfNone(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Result<Option<int>, string> ErrorResult() => Result.Failure<Option<int>, string>(ERROR);
				}
			}

			public class AndBindIfNoneAsyncToResultOfOptionProducingFunction
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class AndFunctionProducesSuccessfulResult
				{
					public class OfSome
					{
						[Fact]
						public Task ShouldDoNothingOnSuccessWithSomeValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
								.BindIfNoneAsync(OtherResultAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindIfNoneAsync(OtherResultAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(EXPECTED_VALUE);

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindIfNoneAsync(OtherResultAsync)
								.AssertFailure();

						private static Task<Result<Option<int>, string>> OtherResultAsync() => Task.FromResult(Result.Success<Option<int>, string>(Option.Some(EXPECTED_VALUE)));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldDoNothingOnSuccessWithSomeValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
								.BindIfNoneAsync(OtherResultAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindIfNoneAsync(OtherResultAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindIfNoneAsync(OtherResultAsync)
								.AssertFailure();

						private static Task<Result<Option<int>, string>> OtherResultAsync() => Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>()));
					}
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
							.BindIfNoneAsync(ErrorResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToFaultedResult()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindIfNoneAsync(ErrorResult)
							.AssertFailure();

					[Fact]
					public async Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						await Task
							.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindIfNoneAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<Option<int>, string>> ErrorResult() => Task.FromResult(Result.Failure<Option<int>, string>(ERROR));
				}
			}
}
