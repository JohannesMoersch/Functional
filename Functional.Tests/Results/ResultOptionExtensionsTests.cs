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
							.MapIfSome(IsEven)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.BeFalse();

					[Fact]
					public void ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.MapIfSome(IsEven)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public void ShouldDoNothingOnFailure() 
						=> Result
							.Failure<Option<int>, string>("some error")
							.MapIfSome(IsEven)
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
								.MapIfSome(IsEven)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.BeFalse();

						[Fact]
						public void ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.MapIfSome(IsEven)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.MapIfSome(IsEven)
								.AssertFailure();

						private static Option<bool> IsEven(int i) => Option.Some(i % 2 == 0);
					}

					public class OfNone
					{
						[Fact]
						public void ShouldMapOptionSomeToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.MapIfSome(IsEven)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.MapIfSome(IsEven)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public void ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.MapIfSome(IsEven)
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
							.MapIfSomeAsync(IsEvenAsync)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.BeFalse();

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Result
							.Success<Option<int>, string>(Option.None<int>())
							.MapIfSomeAsync(IsEvenAsync)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure() 
						=> Result
							.Failure<Option<int>, string>("some error")
							.MapIfSomeAsync(IsEvenAsync)
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
								.MapIfSomeAsync(IsEvenAsync)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.BeFalse();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.MapIfSomeAsync(IsEvenAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.MapIfSomeAsync(IsEvenAsync)
								.AssertFailure();

						private static Task<Option<bool>> IsEvenAsync(int i) => Task.FromResult(Option.Some(i % 2 == 0));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.Some(1337))
								.MapIfSomeAsync(IsEvenAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Result
								.Success<Option<int>, string>(Option.None<int>())
								.MapIfSomeAsync(IsEvenAsync)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Result
								.Failure<Option<int>, string>("some error")
								.MapIfSomeAsync(IsEvenAsync)
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

			public class AndBindOnSomeAsync
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
							.MapIfNone(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.MapIfNone(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(EXPECTED_VALUE);

					[Fact]
					public Task ShouldDoNothingOnFailure()
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.MapIfNone(OtherValue)
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
								.MapIfNone(OtherOption)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapIfNone(OtherOption)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(EXPECTED_VALUE);

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapIfNone(OtherOption)
								.AssertFailure();

						private static Option<int> OtherOption() => Option.Some(EXPECTED_VALUE);
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionNone()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
								.MapIfNone(Nothing)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapIfNone(Nothing)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapIfNone(Nothing)
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
							.MapIfNoneAsync(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(INITIAL_VALUE);

					[Fact]
					public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.MapIfNoneAsync(OtherValue)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be(EXPECTED_VALUE);

					[Fact]
					public Task ShouldDoNothingOnFailure()
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.MapIfNoneAsync(OtherValue)
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
								.MapIfNoneAsync(OtherValue)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionSomeContainingExpectedValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapIfNoneAsync(OtherValue)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(EXPECTED_VALUE);

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapIfNoneAsync(OtherValue)
								.AssertFailure();

						private static Task<Option<int>> OtherValue() => Task.FromResult(Option.Some(EXPECTED_VALUE));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldDoNothingOnSuccessWithSomeValue()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(INITIAL_VALUE)))
								.MapIfNoneAsync(Nothing)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be(INITIAL_VALUE);

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone()
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapIfNoneAsync(Nothing)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapIfNoneAsync(Nothing)
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

			public class WhenApplyOnSome
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

			public class WhenApplyOnSomeAsync
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

			public class AndMapOnSome
			{
				public class OntoValueProducingFunction
				{
					[Fact]
					public Task ShouldMapOptionSomeToOptionSome()
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
							.MapIfSome(ToString)
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be("1337");

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.MapIfSome(ToString)
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure() 
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.MapIfSome(ToString)
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
								.MapIfSome(ToString)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be("1337");

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapIfSome(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapIfSome(ToString)
								.AssertFailure();

						private static Option<string> ToString(int i) => Option.Some(i.ToString());
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.MapIfSome(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapIfSome(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure()
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapIfSome(ToString)
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
							.MapIfSomeAsync(i => Task.FromResult(i.ToString()))
							.AssertSuccess()
							.AssertSome()
							.Should()
							.Be("1337");

					[Fact]
					public Task ShouldMapOptionNoneToOptionNone() 
						=> Task
							.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
							.MapIfSomeAsync(i => Task.FromResult(i.ToString()))
							.AssertSuccess()
							.AssertNone();

					[Fact]
					public Task ShouldDoNothingOnFailure() 
						=> Task
							.FromResult(Result.Failure<Option<int>, string>("some error"))
							.MapIfSomeAsync(i => Task.FromResult(i.ToString()))
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
								.MapIfSomeAsync(ToString)
								.AssertSuccess()
								.AssertSome()
								.Should()
								.Be("1337");

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapIfSomeAsync(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapIfSomeAsync(ToString)
								.AssertFailure();

						private static Task<Option<string>> ToString(int i) => Task.FromResult(Option.Some(i.ToString()));
					}

					public class OfNone
					{
						[Fact]
						public Task ShouldMapOptionSomeToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))
								.MapIfSomeAsync(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldMapOptionNoneToOptionNone() 
							=> Task
								.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))
								.MapIfSomeAsync(ToString)
								.AssertSuccess()
								.AssertNone();

						[Fact]
						public Task ShouldDoNothingOnFailure() 
							=> Task
								.FromResult(Result.Failure<Option<int>, string>("some error"))
								.MapIfSomeAsync(ToString)
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

			public class AndBindOnSomeAsync
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

			public class WhenApplyOnSome
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

			public class WhenApplyOnSomeAsync
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

			public class WhenDoOnSome
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

			public class WhenDoOnSomeAsync
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
