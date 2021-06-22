using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Results
{
	public class ResultOptionExtensionsTests
	{
		public class WhenResultOfOption
		{
			public class AndMatch
			{
				[Fact]
				public void ShouldMapOptionSomeToFirstValue() 
					=> Result
						.Success<Option<int>, string>(Option.Some(1337))
						.Match(First, Second, Third)
						.Should()
						.Be("1337");

				[Fact]
				public void ShouldMapOptionNoneToSecondValue() 
					=> Result
						.Success<Option<int>, string>(Option.None<int>())
						.Match(First, Second, Third)
						.Should()
						.Be("none");

				[Fact]
				public void ShouldMapOptionNoneToThirdValue() 
					=> Result
						.Failure<Option<int>, string>("error")
						.Match(First, Second, Third)
						.Should()
						.Be("error");

				private static string First(int i) => i.ToString();
				private static string Second() => "none";
				private static string Third(string s) => s;
			}

			public class AndMatchAsync
			{
				[Fact]
				public Task ShouldMapOptionSomeToFirstValue() 
					=> Result
						.Success<Option<int>, string>(Option.Some(1337))
						.MatchAsync(First, Second, Third)
						.Should()
						.Be("1337");

				[Fact]
				public Task ShouldMapOptionNoneToSecondValue() 
					=> Result
						.Success<Option<int>, string>(Option.None<int>())
						.MatchAsync(First, Second, Third)
						.Should()
						.Be("none");

				[Fact]
				public Task ShouldMapOptionNoneToThirdValue() 
					=> Result
						.Failure<Option<int>, string>("error")
						.MatchAsync(First, Second, Third)
						.Should()
						.Be("error");

				private static Task<string> First(int i) => Task.FromResult(i.ToString());
				private static Task<string> Second() => Task.FromResult("none");
				private static Task<string> Third(string s) => Task.FromResult(s);
			}

			public class AndMapOnSome
			{
				public class OntoValueProducingFunction
				{
					[Fact]
					public void ShouldMapOptionSomeToOptionSome() 
						=> Result
							.Success<Option<int>, string>(Option.Some(1337))
							.MapOnSome(IsEven)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.BeFalse();

					[Fact]
					public void ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.MapOnSome(IsEven)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public void ShouldDoNothingOnFailure() 
						=> Result
							.Failure<Option<int>, string>("some error")
							.MapOnSome(IsEven)
							.AssertFailure();

					private static bool IsEven(int i) => i % 2 == 0;
				}

				public class OntoOptionProducingFunction
				{
					public class OfSome
					{
						[Fact]
						public void ShouldMapOptionSomeToOptionSome() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.MapOnSome(IsEven)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.BeFalse();

						[Fact]
						public void ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.MapOnSome(IsEven)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.MapOnSome(IsEven)
								.AssertFailure();

						private static Option<bool> IsEven(int i) => Option.Some(i % 2 == 0);
					}

					public class OfNone
					{
						[Fact]
						public void ShouldMapOptionSomeToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.MapOnSome(IsEven)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.MapOnSome(IsEven)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.MapOnSome(IsEven)
								.AssertFailure();

						private static Option<bool> IsEven(int i) => Option.None<bool>();
					}
				}
			}

			public class AndMapOnSomeAsync
			{
				public class OntoValueProducingFunction
				{
					[Fact]
					public Task ShouldMapOptionSomeToOptionSome() 
						=> Result
							.Success<Option<int>, string>(Option.Some(1337))
							.MapOnSomeAsync(IsEvenAsync)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.BeFalse();

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.MapOnSomeAsync(IsEvenAsync)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure() 
						=> Result
							.Failure<Option<int>, string>("some error")
							.MapOnSomeAsync(IsEvenAsync)
							.AssertFailure();

					private static Task<bool> IsEvenAsync(int i) => Task.FromResult(i % 2 == 0);
				}

				public class OntoOptionProducingFunction
				{
					public class OfSome
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.MapOnSomeAsync(IsEvenAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.BeFalse();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.MapOnSomeAsync(IsEvenAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.MapOnSomeAsync(IsEvenAsync)
								.AssertFailure();

						private static Task<Option<bool>> IsEvenAsync(int i) => Task.FromResult(Option.Some(i % 2 == 0));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.MapOnSomeAsync(IsEvenAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.MapOnSomeAsync(IsEvenAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.MapOnSomeAsync(IsEvenAsync)
								.AssertFailure();

						private static Task<Option<bool>> IsEvenAsync(int i) => Task.FromResult(Option.None<bool>());
					}
				}
			}

			public class AndBindOnSome
			{
				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public void ShouldMapOptionSomeToOptionSome() 
						=> Result
							.Success<Option<int>, string>(Option.Some(1337))
							.BindOnSome(IsEvenResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.BeFalse();

					[Fact]
					public void ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindOnSome(IsEvenResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public void ShouldDoNothingOnFailure() 
						=> Result
							.Failure<Option<int>, string>("some error")
							.BindOnSome(IsEvenResult)
							.AssertFailure();

					private static Result<bool, string> IsEvenResult(int i) => Result.Success<bool, string>(i % 2 == 0);
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public void ShouldMapOptionSomeToFaultedResult() 
						=> Result
							.Success<Option<int>, string>(Option.Some(1337))
							.BindOnSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public void ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindOnSome(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public void ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						Result.Failure<Option<int>, string>(EXISTING_ERROR)
							.BindOnSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Result<bool, string> ErrorResult(int i) => Result.Failure<bool, string>(ERROR);
				}
			}

			public class AndBindOnSomeAsync
			{
				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToOptionSome() 
						=> Result
							.Success<Option<int>, string>(Option.Some(1337))
							.BindOnSomeAsync(IsEvenResultAsync)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.BeFalse();

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindOnSomeAsync(IsEvenResultAsync)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure() 
						=> Result
							.Failure<Option<int>, string>("some error")
							.BindOnSomeAsync(IsEvenResultAsync)
							.AssertFailure();

					private static Task<Result<bool, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<bool, string>(i % 2 == 0));
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToFaultedResult() 
						=> Result
							.Success<Option<int>, string>(Option.Some(1337))
							.BindOnSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindOnSomeAsync(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Result.Failure<Option<int>, string>(EXISTING_ERROR)
							.BindOnSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<bool, string>> ErrorResult(int i) => Task.FromResult(Result.Failure<bool, string>(ERROR));
				}
			}

			public class AndBindOnSomeToResultOfOptionProducingFunction
			{
				public class AndFunctionProducesSuccessfulResult
				{
					public class OfSome
					{
						[Fact]
						public void ShouldMapOptionSomeToOptionSome() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.BindOnSome(IsEvenResult)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.BeFalse();

						[Fact]
						public void ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.BindOnSome(IsEvenResult)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.BindOnSome(IsEvenResult)
								.AssertFailure();

						private static Result<Option<bool>, string> IsEvenResult(int i) => Result.Success<Option<bool>, string>(Option.Some(i % 2 == 0));
					}

					public class OfNone
					{
						[Fact]
						public void ShouldMapOptionSomeToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.BindOnSome(IsNoneResult)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.BindOnSome(IsNoneResult)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.BindOnSome(IsNoneResult)
								.AssertFailure();

						private static Result<Option<bool>, string> IsNoneResult(int i) => Result.Success<Option<bool>, string>(Option.None<bool>());
					}
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public void ShouldMapOptionSomeToFaultedResult() 
						=> Result
							.Success<Option<int>, string>(Option.Some(1337))
							.BindOnSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public void ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindOnSome(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public void ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						Result.Failure<Option<int>, string>(EXISTING_ERROR)
							.BindOnSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Result<Option<bool>, string> ErrorResult(int i) => Result.Failure<Option<bool>, string>(ERROR);
				}
			}

			public class AndBindOnSomeAsyncToResultOfOptionProducingFunction
			{
				public class AndFunctionProducesSuccessfulResult
				{
					public class OfSome
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.BindOnSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.BeFalse();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.BindOnSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.BindOnSomeAsync(IsEvenResultAsync)
								.AssertFailure();

						private static Task<Result<Option<bool>, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<Option<bool>, string>(Option.Some(i % 2 == 0)));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.BindOnSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.BindOnSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.BindOnSomeAsync(IsEvenResultAsync)
								.AssertFailure();

						private static Task<Result<Option<bool>, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<Option<bool>, string>(Option.None<bool>()));
					}
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToFaultedResult() 
						=> Result
							.Success<Option<int>, string>(Option.Some(1337))
							.BindOnSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindOnSomeAsync(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Result.Failure<Option<int>, string>(EXISTING_ERROR)
							.BindOnSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<Option<bool>, string>> ErrorResult(int i) => Task.FromResult(Result.Failure<Option<bool>, string>(ERROR));
				}
			}

			public class AndMapOnNone
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class OntoValueProducingFunction
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
							.MapOnNone(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.MapOnNone(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(EXPECTED_VALUE);

					[Fact]
					public Task ShouldDoNothingOnFailure()
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.MapOnNone(OtherValue)
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
								.MapOnNone(OtherOption)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapOnNone(OtherOption)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(EXPECTED_VALUE);

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapOnNone(OtherOption)
								.AssertFailure();

						private static Option<int> OtherOption() => Option.Some(EXPECTED_VALUE);
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionNone()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
								.MapOnNone(Nothing)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapOnNone(Nothing)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapOnNone(Nothing)
								.AssertFailure();

						private static Option<int> Nothing() => Option.None<int>();
					}
				}
			}

			public class AndMapOnNoneAsync
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class OntoValueProducingFunction
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
							.MapOnNoneAsync(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.MapOnNoneAsync(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(EXPECTED_VALUE);

					[Fact]
					public Task ShouldDoNothingOnFailure()
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.MapOnNoneAsync(OtherValue)
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
								.MapOnNoneAsync(OtherValue)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapOnNoneAsync(OtherValue)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(EXPECTED_VALUE);

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapOnNoneAsync(OtherValue)
								.AssertFailure();

						private static Task<Option<int>> OtherValue() => Task.FromResult(Option.Some(EXPECTED_VALUE));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldDoNothingOnSuccessWithSomeValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
								.MapOnNoneAsync(Nothing)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapOnNoneAsync(Nothing)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapOnNoneAsync(Nothing)
								.AssertFailure();

						private static Task<Option<int>> Nothing() => Task.FromResult(Option.None<int>());
					}
				}
			}

			public class AndBindOnNone
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
							.BindOnNone(OtherResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindOnNone(OtherResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(EXPECTED_VALUE);

					[Fact]
					public Task ShouldDoNothingOnFailure()
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.BindOnNone(OtherResult)
							.AssertFailure();

					private static Result<int, string> OtherResult() => Result.Success<int, string>(EXPECTED_VALUE);
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
							.BindOnNone(ErrorResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToFaultedResult()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindOnNone(ErrorResult)
							.AssertFailure();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindOnNone(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Result<int, string> ErrorResult() => Result.Failure<int, string>(ERROR);
				}
			}

			public class AndBindOnNoneAsync
			{
				private const int INITIAL_VALUE = 1337;
				private const int EXPECTED_VALUE = 420;

				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
							.BindOnNoneAsync(OtherResultAsync)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindOnNoneAsync(OtherResultAsync)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(EXPECTED_VALUE);

					[Fact]
					public Task ShouldDoNothingOnFailure()
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.BindOnNoneAsync(OtherResultAsync)
							.AssertFailure();

					private static Task<Result<int, string>> OtherResultAsync() => Task.FromResult(Result.Success<int, string>(EXPECTED_VALUE));
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldDoNothingOnSuccessWithSomeValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
							.BindOnNoneAsync(OtherResultAsync)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToFaultedResult()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindOnNoneAsync(OtherResultAsync)
							.AssertFailure();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindOnNoneAsync(OtherResultAsync)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<int, string>> OtherResultAsync() => Task.FromResult(Result.Failure<int, string>(ERROR));
				}
			}

			public class AndBindOnNoneToResultOfOptionProducingFunction
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
								.BindOnNone(OtherSuccessfulResultWithSome)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindOnNone(OtherSuccessfulResultWithSome)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(EXPECTED_VALUE);

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindOnNone(OtherSuccessfulResultWithSome)
								.AssertFailure();

						private static Result<Option<int>, string> OtherSuccessfulResultWithSome() => Result.Success<Option<int>, string>(Option.Some(EXPECTED_VALUE));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
								.BindOnNone(IsNoneResult)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindOnNone(IsNoneResult)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindOnNone(IsNoneResult)
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
							.BindOnNone(ErrorResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToFaultedResult()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindOnNone(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public async Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						await Task
							.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindOnNone(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Result<Option<int>, string> ErrorResult() => Result.Failure<Option<int>, string>(ERROR);
				}
			}

			public class AndBindOnNoneAsyncToResultOfOptionProducingFunction
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
								.BindOnNoneAsync(OtherResultAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindOnNoneAsync(OtherResultAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(EXPECTED_VALUE);

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindOnNoneAsync(OtherResultAsync)
								.AssertFailure();

						private static Task<Result<Option<int>, string>> OtherResultAsync() => Task.FromResult(Result.Success<Option<int>, string>(Option.Some(EXPECTED_VALUE)));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldDoNothingOnSuccessWithSomeValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
								.BindOnNoneAsync(OtherResultAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindOnNoneAsync(OtherResultAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindOnNoneAsync(OtherResultAsync)
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
							.BindOnNoneAsync(ErrorResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToFaultedResult()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindOnNoneAsync(ErrorResult)
							.AssertFailure();

					[Fact]
					public async Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						await Task
							.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindOnNoneAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<Option<int>, string>> ErrorResult() => Task.FromResult(Result.Failure<Option<int>, string>(ERROR));
				}
			}

			public class AndWhereOnSome
			{
				private const int SUCCESS = 1337;
				private const string FAILURE = "error";

				[Fact]
				public void ShouldMapOptionSomeSatisfyingPredicateToOptionSome()
					=> Result.Success<Option<int>, string>(Option.Some(SUCCESS))
						.WhereOnSome(i => i == SUCCESS, i => FAILURE)
						.AssertSuccess()
						.AssertSome()
						.Should()
						.Be(SUCCESS);

				[Fact]
				public void ShouldMapOptionNoneToOptionNone()
					=> Result.Success<Option<int>, string>(Option.None<int>())
						.WhereOnSome(i => i == SUCCESS, i => FAILURE)
						.AssertSuccess()
						.AssertNone();

				[Fact]
				public void ShouldMapOptionSomeNotSatisfyingPredicateToFailure()
					=> Result.Success<Option<int>, string>(Option.Some(SUCCESS))
						.WhereOnSome(i => i != SUCCESS, i => FAILURE)
						.AssertFailure()
						.Should()
						.Be(FAILURE);

				[Fact]
				public void ShouldMapFailureToFailure()
				{
					const string EXPECTED = "TEST";

					Result.Failure<Option<int>, string>(EXPECTED)
						.WhereOnSome(i => i != SUCCESS, i => FAILURE)
						.AssertFailure()
						.Should()
						.Be(EXPECTED);
				}
			}

			public class AndEvert
			{
				private const int SUCCESS = 1337;
				private const string FAILURE = "error";

				[Fact]
				public void EvertSome()
					=> Option.Some(Result.Success<int, string>(SUCCESS))
						.Evert()
						.AssertSuccess()
						.AssertSome()
						.Should()
						.Be(SUCCESS);

				[Fact]
				public void EvertNone()
					=> Option.None<Result<int, string>>()
						.Evert()
						.AssertSuccess()
						.AssertNone();

				[Fact]
				public void EvertError()
					=> Option.Some(Result.Failure<int, string>(FAILURE))
						.Evert()
						.AssertFailure()
						.Should()
						.Be(FAILURE);
			}

			public class AndApply
			{
				[Fact]
				public void ApplySome()
					=> Result.Success<Option<int>, string>(Option.Some(1337)).Apply(
						some => { },
						() => throw new InvalidOperationException("Expected onSome branch to be executed but onNone branch was executed instead!"),
						error => throw new InvalidOperationException("Expected onSome branch to be executed but onFailure branch was executed instead!"));

				[Fact]
				public void ApplyNone()
					=> Result.Success<Option<int>, string>(Option.None<int>()).Apply(
						some => throw new InvalidOperationException("Expected onNone branch to be executed but onSome branch was executed instead!"),
						() => { },
						error => throw new InvalidOperationException("Expected onNone branch to be executed but onFailure branch was executed instead!"));

				[Fact]
				public void ApplyFailure()
					=> Result.Failure<Option<int>, string>("ERROR").Apply(
						some => throw new InvalidOperationException("Expected onFailure branch to be executed but onSome branch was executed instead!"),
						() => throw new InvalidOperationException("Expected onFailure branch to be executed but onNone branch was executed instead!"),
						failure => { });
			}

			public class AndApplyAsync
			{
				[Fact]
				public async Task ApplySome()
					=> await Result.Success<Option<int>, string>(Option.Some(1337)).ApplyAsync(
						some => Task.CompletedTask,
						() => throw new InvalidOperationException("Expected onSome branch to be executed but onNone branch was executed instead!"),
						error => throw new InvalidOperationException("Expected onSome branch to be executed but onFailure branch was executed instead!"));

				[Fact]
				public async Task ApplyNone()
					=> await Result.Success<Option<int>, string>(Option.None<int>()).ApplyAsync(
						some => throw new InvalidOperationException("Expected onNone branch to be executed but onSome branch was executed instead!"),
						() => Task.CompletedTask,
						error => throw new InvalidOperationException("Expected onNone branch to be executed but onFailure branch was executed instead!"));

				[Fact]
				public async Task ApplyFailure()
					=> await Result.Failure<Option<int>, string>("ERROR").ApplyAsync(
						some => throw new InvalidOperationException("Expected onFailure branch to be executed but onSome branch was executed instead!"),
						() => throw new InvalidOperationException("Expected onFailure branch to be executed but onNone branch was executed instead!"),
						failure => Task.CompletedTask);
			}
		}

		public class WhenTaskOfResultOfOption
		{
			public class AndMatch
			{
				[Fact]
				public Task ShouldMapOptionSomeToFirstValue() 
					=> Task
						.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
						.Match(First, Second, Third)
						.Should()
						.Be("1337");

				[Fact]
				public Task ShouldMapOptionNoneToSecondValue() 
					=> Task
						.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
						.Match(First, Second, Third)
						.Should()
						.Be("none");

				[Fact]
				public Task ShouldMapOptionNoneToThirdValue() 
					=> Task
						.FromResult(Result.Failure<Option<int>, string>("error"))
						.Match(First, Second, Third)
						.Should()
						.Be("error");

				private static string First(int i) => i.ToString();
				private static string Second() => "none";
				private static string Third(string s) => s;
			}

			public class AndMatchAsync
			{
				[Fact]
				public Task ShouldMapOptionSomeToFirstValue() 
					=> Task
						.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
						.MatchAsync(First, Second, Third)
						.Should()
						.Be("1337");

				[Fact]
				public Task ShouldMapOptionNoneToSecondValue() 
					=> Task
						.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
						.MatchAsync(First, Second, Third)
						.Should()
						.Be("none");

				[Fact]
				public Task ShouldMapOptionNoneToThirdValue() 
					=> Task
						.FromResult(Result.Failure<Option<int>, string>("error"))
						.MatchAsync(First, Second, Third)
						.Should()
						.Be("error");

				private static Task<string> First(int i) => Task.FromResult(i.ToString());
				private static Task<string> Second() => Task.FromResult("none");
				private static Task<string> Third(string s) => Task.FromResult(s);
			}

			public class AndMapOnSome
			{
				public class OntoValueProducingFunction
				{
					[Fact]
					public Task ShouldMapOptionSomeToOptionSome()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
							.MapOnSome(ToString)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be("1337");

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.MapOnSome(ToString)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure() 
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.MapOnSome(ToString)
							.AssertFailure();

					private static string ToString(int i) => i.ToString();
				}

				public class OntoOptionProducingFunction
				{
					public class OfSome
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.MapOnSome(ToString)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be("1337");

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapOnSome(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapOnSome(ToString)
								.AssertFailure();

						private static Option<string> ToString(int i) => Option.Some(i.ToString());
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.MapOnSome(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapOnSome(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapOnSome(ToString)
								.AssertFailure();

						private static Option<string> ToString(int i) => Option.None<string>();
					}
				}
			}

			public class AndMapOnSomeAsync
			{
				public class OntoValueProducingFunction
				{
					[Fact]
					public Task ShouldMapOptionSomeToOptionSome() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
							.MapOnSomeAsync(i => Task.FromResult(i.ToString()))
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be("1337");

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.MapOnSomeAsync(i => Task.FromResult(i.ToString()))
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure() 
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.MapOnSomeAsync(i => Task.FromResult(i.ToString()))
							.AssertFailure();
				}

				public class OntoOptionProducingFunction
				{
					public class OfSome
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.MapOnSomeAsync(ToString)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be("1337");

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapOnSomeAsync(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapOnSomeAsync(ToString)
								.AssertFailure();

						private static Task<Option<string>> ToString(int i) => Task.FromResult(Option.Some(i.ToString()));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.MapOnSomeAsync(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapOnSomeAsync(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapOnSomeAsync(ToString)
								.AssertFailure();

						private static Task<Option<string>> ToString(int i) => Task.FromResult(Option.None<string>());
					}
				}
			}

			public class AndBindOnSome
			{
				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToOptionSome() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
							.BindOnSome(IsEvenResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.BeFalse();

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindOnSome(IsEvenResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure() 
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.BindOnSome(IsEvenResult)
							.AssertFailure();

					private static Result<bool, string> IsEvenResult(int i) => Result.Success<bool, string>(i % 2 == 0);
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToFaultedResult() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
							.BindOnSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindOnSome(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindOnSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Result<bool, string> ErrorResult(int i) => Result.Failure<bool, string>(ERROR);
				}
			}

			public class AndBindOnSomeAsync
			{
				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToOptionSome() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
							.BindOnSomeAsync(IsEvenResultAsync)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.BeFalse();

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindOnSomeAsync(IsEvenResultAsync)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure() 
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.BindOnSomeAsync(IsEvenResultAsync)
							.AssertFailure();

					private static Task<Result<bool, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<bool, string>(i % 2 == 0));
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToFaultedResult() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
							.BindOnSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindOnSomeAsync(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindOnSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<bool, string>> ErrorResult(int i) => Task.FromResult(Result.Failure<bool, string>(ERROR));
				}
			}

			public class AndBindOnSomeToResultOfOptionProducingFunction
			{
				public class AndFunctionProducesSuccessfulResult
				{
					public class OfSome
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.BindOnSome(IsEvenResult)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.BeFalse();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindOnSome(IsEvenResult)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindOnSome(IsEvenResult)
								.AssertFailure();

						private static Result<Option<bool>, string> IsEvenResult(int i) => Result.Success<Option<bool>, string>(Option.Some(i % 2 == 0));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.BindOnSome(IsNoneResult)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindOnSome(IsNoneResult)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindOnSome(IsNoneResult)
								.AssertFailure();

						private static Result<Option<bool>, string> IsNoneResult(int i) => Result.Success<Option<bool>, string>(Option.None<bool>());
					}
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToFaultedResult() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
							.BindOnSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindOnSome(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindOnSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Result<Option<bool>, string> ErrorResult(int i) => Result.Failure<Option<bool>, string>(ERROR);
				}
			}

			public class AndBindOnSomeAsyncToResultOfOptionProducingFunction
			{
				public class AndFunctionProducesSuccessfulResult
				{
					public class OfSome
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.BindOnSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.BeFalse();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindOnSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindOnSomeAsync(IsEvenResultAsync)
								.AssertFailure();

						private static Task<Result<Option<bool>, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<Option<bool>, string>(Option.Some(i % 2 == 0)));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.BindOnSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindOnSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindOnSomeAsync(IsEvenResultAsync)
								.AssertFailure();

						private static Task<Result<Option<bool>, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<Option<bool>, string>(Option.None<bool>()));
					}
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToFaultedResult() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
							.BindOnSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindOnSomeAsync(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindOnSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<Option<bool>, string>> ErrorResult(int i) => Task.FromResult(Result.Failure<Option<bool>, string>(ERROR));
				}
			}

			public class WhenDoOnSome
			{
				[Fact]
				public async Task ShouldInvokeActionWhenSome()
				{
					bool methodCalled = false;
					await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).DoOnSome(_ => methodCalled = true);
					methodCalled.Should().BeTrue();
				}

				[Fact]
				public async Task ShouldNotInvokeActionWhenNone()
				{
					bool methodCalled = false;
					await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).DoOnSome(_ => methodCalled = true);
					methodCalled.Should().BeFalse();
				}

				[Fact]
				public async Task ShouldNotInvokeActionWhenFailure()
				{
					bool methodCalled = false;
					await Task.FromResult(Result.Failure<Option<int>, string>("error")).DoOnSome(_ => methodCalled = true);
					methodCalled.Should().BeFalse();
				}
			}

			public class WhenDoOnSomeAsync
			{
				[Fact]
				public async Task ShouldInvokeActionWhenSome()
				{
					bool methodCalled = false;
					await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).DoOnSomeAsync(_ =>
					{
						methodCalled = true;
						return Task.CompletedTask;
					});
					methodCalled.Should().BeTrue();
				}

				[Fact]
				public async Task ShouldNotInvokeActionWhenNone()
				{
					bool methodCalled = false;
					await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).DoOnSomeAsync(_ =>
					{
						methodCalled = true;
						return Task.CompletedTask;
					});
					methodCalled.Should().BeFalse();
				}

				[Fact]
				public async Task ShouldNotInvokeActionWhenFailure()
				{
					bool methodCalled = false;
					await Task.FromResult(Result.Failure<Option<int>, string>("error")).DoOnSomeAsync(_ =>
					{
						methodCalled = true;
						return Task.CompletedTask;
					});
					methodCalled.Should().BeFalse();
				}
			}

			public class WhenWhereOnSome
			{
				private const int SUCCESS = 1337;
				private const string FAILURE = "error";

				[Fact]
				public async Task ShouldMapOptionSomeSatisfyingPredicateToOptionSome()
					=> await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(SUCCESS)))
						.WhereOnSome(i => i == SUCCESS, i => FAILURE)
						.AssertSuccess()
						.AssertSome()
						.Should()
						.Be(SUCCESS);

				[Fact]
				public async Task ShouldMapOptionNoneToOptionNone()
					=> await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
						.WhereOnSome(i => i == SUCCESS, i => FAILURE)
						.AssertSuccess()
						.AssertNone();

				[Fact]
				public async Task ShouldMapOptionSomeNotSatisfyingPredicateToFailure()
					=> await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(SUCCESS)))
						.WhereOnSome(i => i != SUCCESS, i => FAILURE)
						.AssertFailure()
						.Should()
						.Be(FAILURE);

				[Fact]
				public async Task ShouldMapFailureToFailure()
				{
					const string EXPECTED = "TEST";

					await Task.FromResult(Result.Failure<Option<int>, string>(EXPECTED))
						.WhereOnSome(i => i != SUCCESS, i => FAILURE)
						.AssertFailure()
						.Should()
						.Be(EXPECTED);
				}
			}

			public class WhenWhereOnSomeAsync
			{
				private const int SUCCESS = 1337;
				private const string FAILURE = "error";

				[Fact]
				public async Task ShouldMapOptionSomeSatisfyingPredicateToOptionSome()
					=> await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(SUCCESS)))
						.WhereOnSomeAsync(i => Task.FromResult(i == SUCCESS), i => FAILURE)
						.AssertSuccess()
						.AssertSome()
						.Should()
						.Be(SUCCESS);

				[Fact]
				public async Task ShouldMapOptionNoneToOptionNone()
					=> await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
						.WhereOnSomeAsync(i => Task.FromResult(i == SUCCESS), i => FAILURE)
						.AssertSuccess()
						.AssertNone();

				[Fact]
				public async Task ShouldMapOptionSomeNotSatisfyingPredicateToFailure()
					=> await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(SUCCESS)))
						.WhereOnSomeAsync(i => Task.FromResult(i != SUCCESS), i => FAILURE)
						.AssertFailure()
						.Should()
						.Be(FAILURE);

				[Fact]
				public async Task ShouldMapFailureToFailure()
				{
					const string EXPECTED = "TEST";

					await Task.FromResult(Result.Failure<Option<int>, string>(EXPECTED))
						.WhereOnSomeAsync(i => Task.FromResult(i != SUCCESS), i => FAILURE)
						.AssertFailure()
						.Should()
						.Be(EXPECTED);
				}
			}

			public class AndEvert
			{
				private const int SUCCESS = 1337;
				private const string FAILURE = "error";

				[Fact]
				public async Task EvertSome()
					=> await Task.FromResult(Option.Some(Result.Success<int, string>(SUCCESS)))
						.Evert()
						.AssertSuccess()
						.AssertSome()
						.Should()
						.Be(SUCCESS);

				[Fact]
				public async Task EvertNone()
					=> await Task.FromResult(Option.None<Result<int, string>>())
						.Evert()
						.AssertSuccess()
						.AssertNone();

				[Fact]
				public async Task EvertError()
					=> await Task.FromResult(Option.Some(Result.Failure<int, string>(FAILURE)))
						.Evert()
						.AssertFailure()
						.Should()
						.Be(FAILURE);
			}

			public class AndApply
			{
				[Fact]
				public async Task ApplySome()
					=> await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).Apply(
						some => { },
						() => throw new InvalidOperationException("Expected onSome branch to be executed but onNone branch was executed instead!"),
						error => throw new InvalidOperationException("Expected onSome branch to be executed but onFailure branch was executed instead!"));

				[Fact]
				public async Task ApplyNone()
					=> await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).Apply(
						some => throw new InvalidOperationException("Expected onNone branch to be executed but onSome branch was executed instead!"),
						() => { },
						error => throw new InvalidOperationException("Expected onNone branch to be executed but onFailure branch was executed instead!"));

				[Fact]
				public async Task ApplyFailure()
					=> await Task.FromResult(Result.Failure<Option<int>, string>("ERROR")).Apply(
						some => throw new InvalidOperationException("Expected onFailure branch to be executed but onSome branch was executed instead!"),
						() => throw new InvalidOperationException("Expected onFailure branch to be executed but onNone branch was executed instead!"),
						failure => { });
			}

			public class AndApplyAsync
			{
				[Fact]
				public async Task ApplySome()
					=> await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).ApplyAsync(
						some => Task.CompletedTask,
						() => throw new InvalidOperationException("Expected onSome branch to be executed but onNone branch was executed instead!"),
						error => throw new InvalidOperationException("Expected onSome branch to be executed but onFailure branch was executed instead!"));

				[Fact]
				public async Task ApplyNone()
					=> await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).ApplyAsync(
						some => throw new InvalidOperationException("Expected onNone branch to be executed but onSome branch was executed instead!"),
						() => Task.CompletedTask,
						error => throw new InvalidOperationException("Expected onNone branch to be executed but onFailure branch was executed instead!"));

				[Fact]
				public async Task ApplyFailure()
					=> await Task.FromResult(Result.Failure<Option<int>, string>("ERROR")).ApplyAsync(
						some => throw new InvalidOperationException("Expected onFailure branch to be executed but onSome branch was executed instead!"),
						() => throw new InvalidOperationException("Expected onFailure branch to be executed but onNone branch was executed instead!"),
						failure => Task.CompletedTask);
			}
		}
	}
}
