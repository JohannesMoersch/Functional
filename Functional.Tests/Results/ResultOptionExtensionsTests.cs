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

			public class AndSelectIfSome
			{
				public class OntoValueProducingFunction
				{
					[Fact]
					public void ShouldMapOptionSomeToOptionSome() 
						=> Result
							.Success<Option<int>, string>(Option.Some(1337))
							.SelectIfSome(IsEven)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.BeFalse();

					[Fact]
					public void ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.SelectIfSome(IsEven)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public void ShouldDoNothingOnFailure() 
						=> Result
							.Failure<Option<int>, string>("some error")
							.SelectIfSome(IsEven)
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
								.SelectIfSome(IsEven)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.BeFalse();

						[Fact]
						public void ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.SelectIfSome(IsEven)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.SelectIfSome(IsEven)
								.AssertFailure();

						private static Option<bool> IsEven(int i) => Option.Some(i % 2 == 0);
					}

					public class OfNone
					{
						[Fact]
						public void ShouldMapOptionSomeToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.SelectIfSome(IsEven)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.SelectIfSome(IsEven)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.SelectIfSome(IsEven)
								.AssertFailure();

						private static Option<bool> IsEven(int i) => Option.None<bool>();
					}
				}
			}

			public class AndSelectIfSomeAsync
			{
				public class OntoValueProducingFunction
				{
					[Fact]
					public Task ShouldMapOptionSomeToOptionSome() 
						=> Result
							.Success<Option<int>, string>(Option.Some(1337))
							.SelectIfSomeAsync(IsEvenAsync)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.BeFalse();

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.SelectIfSomeAsync(IsEvenAsync)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure() 
						=> Result
							.Failure<Option<int>, string>("some error")
							.SelectIfSomeAsync(IsEvenAsync)
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
								.SelectIfSomeAsync(IsEvenAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.BeFalse();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.SelectIfSomeAsync(IsEvenAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.SelectIfSomeAsync(IsEvenAsync)
								.AssertFailure();

						private static Task<Option<bool>> IsEvenAsync(int i) => Task.FromResult(Option.Some(i % 2 == 0));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.SelectIfSomeAsync(IsEvenAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.SelectIfSomeAsync(IsEvenAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.SelectIfSomeAsync(IsEvenAsync)
								.AssertFailure();

						private static Task<Option<bool>> IsEvenAsync(int i) => Task.FromResult(Option.None<bool>());
					}
				}
			}

			public class AndBindIfSome
			{
				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public void ShouldMapOptionSomeToOptionSome() 
						=> Result
							.Success<Option<int>, string>(Option.Some(1337))
							.BindIfSome(IsEvenResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.BeFalse();

					[Fact]
					public void ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindIfSome(IsEvenResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public void ShouldDoNothingOnFailure() 
						=> Result
							.Failure<Option<int>, string>("some error")
							.BindIfSome(IsEvenResult)
							.AssertFailure();

					private static Result<bool, string> IsEvenResult(int i) => Result.Success<bool, string>(i % 2 == 0);
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public void ShouldMapOptionSomeToFaultedResult() 
						=> Result
							.Success<Option<int>, string>(Option.Some(1337))
							.BindIfSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public void ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindIfSome(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public void ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						Result.Failure<Option<int>, string>(EXISTING_ERROR)
							.BindIfSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Result<bool, string> ErrorResult(int i) => Result.Failure<bool, string>(ERROR);
				}
			}

			public class AndBindIfSomeAsync
			{
				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToOptionSome() 
						=> Result
							.Success<Option<int>, string>(Option.Some(1337))
							.BindIfSomeAsync(IsEvenResultAsync)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.BeFalse();

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindIfSomeAsync(IsEvenResultAsync)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure() 
						=> Result
							.Failure<Option<int>, string>("some error")
							.BindIfSomeAsync(IsEvenResultAsync)
							.AssertFailure();

					private static Task<Result<bool, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<bool, string>(i % 2 == 0));
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToFaultedResult() 
						=> Result
							.Success<Option<int>, string>(Option.Some(1337))
							.BindIfSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindIfSomeAsync(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Result.Failure<Option<int>, string>(EXISTING_ERROR)
							.BindIfSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<bool, string>> ErrorResult(int i) => Task.FromResult(Result.Failure<bool, string>(ERROR));
				}
			}

			public class AndBindIfSomeToResultOfOptionProducingFunction
			{
				public class AndFunctionProducesSuccessfulResult
				{
					public class OfSome
					{
						[Fact]
						public void ShouldMapOptionSomeToOptionSome() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.BindIfSome(IsEvenResult)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.BeFalse();

						[Fact]
						public void ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.BindIfSome(IsEvenResult)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.BindIfSome(IsEvenResult)
								.AssertFailure();

						private static Result<Option<bool>, string> IsEvenResult(int i) => Result.Success<Option<bool>, string>(Option.Some(i % 2 == 0));
					}

					public class OfNone
					{
						[Fact]
						public void ShouldMapOptionSomeToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.BindIfSome(IsNoneResult)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.BindIfSome(IsNoneResult)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.BindIfSome(IsNoneResult)
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
							.BindIfSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public void ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindIfSome(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public void ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						Result.Failure<Option<int>, string>(EXISTING_ERROR)
							.BindIfSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Result<Option<bool>, string> ErrorResult(int i) => Result.Failure<Option<bool>, string>(ERROR);
				}
			}

			public class AndBindIfSomeAsyncToResultOfOptionProducingFunction
			{
				public class AndFunctionProducesSuccessfulResult
				{
					public class OfSome
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.BindIfSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.BeFalse();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.BindIfSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.BindIfSomeAsync(IsEvenResultAsync)
								.AssertFailure();

						private static Task<Result<Option<bool>, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<Option<bool>, string>(Option.Some(i % 2 == 0)));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.BindIfSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.BindIfSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.BindIfSomeAsync(IsEvenResultAsync)
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
							.BindIfSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.BindIfSomeAsync(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Result.Failure<Option<int>, string>(EXISTING_ERROR)
							.BindIfSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<Option<bool>, string>> ErrorResult(int i) => Task.FromResult(Result.Failure<Option<bool>, string>(ERROR));
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

			public class WhenApplyIfSome
			{
				[Fact]
				public void ShouldInvokeActionWhenSome()
				{
					bool methodCalled = false;
					Result.Success<Option<int>, string>(Option.Some(1337)).ApplyIfSome(_ => methodCalled = true);
					methodCalled.Should().BeTrue();
				}

				[Fact]
				public void ShouldNotInvokeActionWhenNone()
				{
					bool methodCalled = false;
					Result.Success<Option<int>, string>(Option.None<int>()).ApplyIfSome(_ => methodCalled = true);
					methodCalled.Should().BeFalse();
				}

				[Fact]
				public void ShouldNotInvokeActionWhenFailure()
				{
					bool methodCalled = false;
					Result.Failure<Option<int>, string>("error").ApplyIfSome(_ => methodCalled = true);
					methodCalled.Should().BeFalse();
				}
			}

			public class WhenApplyIfSomeAsync
			{
				[Fact]
				public async Task ShouldInvokeActionWhenSome()
				{
					bool methodCalled = false;
					await Result.Success<Option<int>, string>(Option.Some(1337)).ApplyIfSomeAsync(_ =>
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
					await Result.Success<Option<int>, string>(Option.None<int>()).ApplyIfSomeAsync(_ =>
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
					await Result.Failure<Option<int>, string>("error").ApplyIfSomeAsync(_ =>
					{
						methodCalled = true;
						return Task.CompletedTask;
					});
					methodCalled.Should().BeFalse();
				}
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

			public class AndSelectIfSome
			{
				public class OntoValueProducingFunction
				{
					[Fact]
					public Task ShouldMapOptionSomeToOptionSome()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
							.SelectIfSome(ToString)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be("1337");

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.SelectIfSome(ToString)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure() 
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.SelectIfSome(ToString)
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
								.SelectIfSome(ToString)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be("1337");

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.SelectIfSome(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.SelectIfSome(ToString)
								.AssertFailure();

						private static Option<string> ToString(int i) => Option.Some(i.ToString());
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.SelectIfSome(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.SelectIfSome(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.SelectIfSome(ToString)
								.AssertFailure();

						private static Option<string> ToString(int i) => Option.None<string>();
					}
				}
			}

			public class AndSelectIfSomeAsync
			{
				public class OntoValueProducingFunction
				{
					[Fact]
					public Task ShouldMapOptionSomeToOptionSome() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
							.SelectIfSomeAsync(i => Task.FromResult(i.ToString()))
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be("1337");

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.SelectIfSomeAsync(i => Task.FromResult(i.ToString()))
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure() 
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.SelectIfSomeAsync(i => Task.FromResult(i.ToString()))
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
								.SelectIfSomeAsync(ToString)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be("1337");

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.SelectIfSomeAsync(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.SelectIfSomeAsync(ToString)
								.AssertFailure();

						private static Task<Option<string>> ToString(int i) => Task.FromResult(Option.Some(i.ToString()));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.SelectIfSomeAsync(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.SelectIfSomeAsync(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.SelectIfSomeAsync(ToString)
								.AssertFailure();

						private static Task<Option<string>> ToString(int i) => Task.FromResult(Option.None<string>());
					}
				}
			}

			public class AndBindIfSome
			{
				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToOptionSome() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
							.BindIfSome(IsEvenResult)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.BeFalse();

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindIfSome(IsEvenResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure() 
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.BindIfSome(IsEvenResult)
							.AssertFailure();

					private static Result<bool, string> IsEvenResult(int i) => Result.Success<bool, string>(i % 2 == 0);
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToFaultedResult() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
							.BindIfSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindIfSome(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindIfSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Result<bool, string> ErrorResult(int i) => Result.Failure<bool, string>(ERROR);
				}
			}

			public class AndBindIfSomeAsync
			{
				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToOptionSome() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
							.BindIfSomeAsync(IsEvenResultAsync)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.BeFalse();

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindIfSomeAsync(IsEvenResultAsync)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure() 
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.BindIfSomeAsync(IsEvenResultAsync)
							.AssertFailure();

					private static Task<Result<bool, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<bool, string>(i % 2 == 0));
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public Task ShouldMapOptionSomeToFaultedResult() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
							.BindIfSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindIfSomeAsync(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindIfSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<bool, string>> ErrorResult(int i) => Task.FromResult(Result.Failure<bool, string>(ERROR));
				}
			}

			public class AndBindIfSomeToResultOfOptionProducingFunction
			{
				public class AndFunctionProducesSuccessfulResult
				{
					public class OfSome
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.BindIfSome(IsEvenResult)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.BeFalse();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindIfSome(IsEvenResult)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindIfSome(IsEvenResult)
								.AssertFailure();

						private static Result<Option<bool>, string> IsEvenResult(int i) => Result.Success<Option<bool>, string>(Option.Some(i % 2 == 0));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.BindIfSome(IsNoneResult)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindIfSome(IsNoneResult)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindIfSome(IsNoneResult)
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
							.BindIfSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindIfSome(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindIfSome(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Result<Option<bool>, string> ErrorResult(int i) => Result.Failure<Option<bool>, string>(ERROR);
				}
			}

			public class AndBindIfSomeAsyncToResultOfOptionProducingFunction
			{
				public class AndFunctionProducesSuccessfulResult
				{
					public class OfSome
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.BindIfSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.BeFalse();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindIfSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindIfSomeAsync(IsEvenResultAsync)
								.AssertFailure();

						private static Task<Result<Option<bool>, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<Option<bool>, string>(Option.Some(i % 2 == 0)));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionSome() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.BindIfSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.BindIfSomeAsync(IsEvenResultAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.BindIfSomeAsync(IsEvenResultAsync)
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
							.BindIfSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(ERROR);

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.BindIfSomeAsync(ErrorResult)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						return Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))
							.BindIfSomeAsync(ErrorResult)
							.AssertFailure()
							.Should()
							.Be(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<Option<bool>, string>> ErrorResult(int i) => Task.FromResult(Result.Failure<Option<bool>, string>(ERROR));
				}
			}

			public class WhenApplyIfSome
			{
				[Fact]
				public async Task ShouldInvokeActionWhenSome()
				{
					bool methodCalled = false;
					await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).ApplyIfSome(_ => methodCalled = true);
					methodCalled.Should().BeTrue();
				}

				[Fact]
				public async Task ShouldNotInvokeActionWhenNone()
				{
					bool methodCalled = false;
					await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).ApplyIfSome(_ => methodCalled = true);
					methodCalled.Should().BeFalse();
				}

				[Fact]
				public async Task ShouldNotInvokeActionWhenFailure()
				{
					bool methodCalled = false;
					await Task.FromResult(Result.Failure<Option<int>, string>("error")).ApplyIfSome(_ => methodCalled = true);
					methodCalled.Should().BeFalse();
				}
			}

			public class WhenApplyIfSomeAsync
			{
				[Fact]
				public async Task ShouldInvokeActionWhenSome()
				{
					bool methodCalled = false;
					await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).ApplyIfSomeAsync(_ =>
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
					await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).ApplyIfSomeAsync(_ =>
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
					await Task.FromResult(Result.Failure<Option<int>, string>("error")).ApplyIfSomeAsync(_ =>
					{
						methodCalled = true;
						return Task.CompletedTask;
					});
					methodCalled.Should().BeFalse();
				}
			}

			public class WhenDoIfSome
			{
				[Fact]
				public async Task ShouldInvokeActionWhenSome()
				{
					bool methodCalled = false;
					await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).DoIfSome(_ => methodCalled = true);
					methodCalled.Should().BeTrue();
				}

				[Fact]
				public async Task ShouldNotInvokeActionWhenNone()
				{
					bool methodCalled = false;
					await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).DoIfSome(_ => methodCalled = true);
					methodCalled.Should().BeFalse();
				}

				[Fact]
				public async Task ShouldNotInvokeActionWhenFailure()
				{
					bool methodCalled = false;
					await Task.FromResult(Result.Failure<Option<int>, string>("error")).DoIfSome(_ => methodCalled = true);
					methodCalled.Should().BeFalse();
				}
			}

			public class WhenDoIfSomeAsync
			{
				[Fact]
				public async Task ShouldInvokeActionWhenSome()
				{
					bool methodCalled = false;
					await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).DoIfSomeAsync(_ =>
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
					await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).DoIfSomeAsync(_ =>
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
					await Task.FromResult(Result.Failure<Option<int>, string>("error")).DoIfSomeAsync(_ =>
					{
						methodCalled = true;
						return Task.CompletedTask;
					});
					methodCalled.Should().BeFalse();
				}
			}
		}
	}
}
