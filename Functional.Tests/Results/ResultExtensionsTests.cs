using System.Threading.Tasks;
using FluentAssertions;
using Functional.Tests.Utilities.Assertions;
using Xunit;

namespace Functional.Tests.Results
{
	public class ResultExtensionsTests
	{
		public class WhenResultOfOption
		{
			public class AndMatch
			{
				[Fact]
				public void ShouldMapOptionSomeToFirstValue() => Result.Success<Option<int>, string>(Option.Some(1337)).Match(First, Second, Third).Should().Be("1337");

				[Fact]
				public void ShouldMapOptionNoneToSecondValue() => Result.Success<Option<int>, string>(Option.None<int>()).Match(First, Second, Third).Should().Be("none");

				[Fact]
				public void ShouldMapOptionNoneToThirdValue() => Result.Failure<Option<int>, string>("error").Match(First, Second, Third).Should().Be("error");

				private static string First(int i) => i.ToString();
				private static string Second() => "none";
				private static string Third(string s) => s;
			}

			public class AndMatchAsync
			{
				[Fact]
				public async Task ShouldMapOptionSomeToFirstValue() => (await Result.Success<Option<int>, string>(Option.Some(1337)).MatchAsync(First, Second, Third)).Should().Be("1337");

				[Fact]
				public async Task ShouldMapOptionNoneToSecondValue() => (await Result.Success<Option<int>, string>(Option.None<int>()).MatchAsync(First, Second, Third)).Should().Be("none");

				[Fact]
				public async Task ShouldMapOptionNoneToThirdValue() => (await Result.Failure<Option<int>, string>("error").MatchAsync(First, Second, Third)).Should().Be("error");

				private static Task<string> First(int i) => Task.FromResult(i.ToString());
				private static Task<string> Second() => Task.FromResult("none");
				private static Task<string> Third(string s) => Task.FromResult(s);
			}

			public class AndSelectIfSome
			{
				public class OntoValueProducingFunction
				{
					[Fact]
					public void ShouldMapOptionSomeToOptionSome() => Result.Success<Option<int>, string>(Option.Some(1337)).SelectIfSome(IsEven).Should().BeSuccessful(option => option.Should().HaveExpectedValue(false));

					[Fact]
					public void ShouldMapOptionNoneToOptionNone() => Result.Success<Option<int>, string>(Option.None<int>()).SelectIfSome(IsEven).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public void ShouldDoNothingOnFailure() => Result.Failure<Option<int>, string>("some error").SelectIfSome(IsEven).Should().BeFaulted();

					private static bool IsEven(int i) => i % 2 == 0;
				}

				public class OntoOptionProducingFunction
				{
					public class OfSome
					{
						[Fact]
						public void ShouldMapOptionSomeToOptionSome() => Result.Success<Option<int>, string>(Option.Some(1337)).SelectIfSome(IsEven).Should().BeSuccessful(option => option.Should().HaveExpectedValue(false));

						[Fact]
						public void ShouldMapOptionNoneToOptionNone() => Result.Success<Option<int>, string>(Option.None<int>()).SelectIfSome(IsEven).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public void ShouldDoNothingOnFailure() => Result.Failure<Option<int>, string>("some error").SelectIfSome(IsEven).Should().BeFaulted();

						private static Option<bool> IsEven(int i) => Option.Some(i % 2 == 0);
					}

					public class OfNone
					{
						[Fact]
						public void ShouldMapOptionSomeToOptionNone() => Result.Success<Option<int>, string>(Option.Some(1337)).SelectIfSome(IsEven).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public void ShouldMapOptionNoneToOptionNone() => Result.Success<Option<int>, string>(Option.None<int>()).SelectIfSome(IsEven).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public void ShouldDoNothingOnFailure() => Result.Failure<Option<int>, string>("some error").SelectIfSome(IsEven).Should().BeFaulted();

						private static Option<bool> IsEven(int i) => Option.None<bool>();
					}
				}
			}

			public class AndSelectIfSomeAsync
			{
				public class OntoValueProducingFunction
				{
					[Fact]
					public async Task ShouldMapOptionSomeToOptionSome() => (await Result.Success<Option<int>, string>(Option.Some(1337)).SelectIfSomeAsync(IsEvenAsync)).Should().BeSuccessful(option => option.Should().HaveExpectedValue(false));

					[Fact]
					public async Task ShouldMapOptionNoneToOptionNone() => (await Result.Success<Option<int>, string>(Option.None<int>()).SelectIfSomeAsync(IsEvenAsync)).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public async Task ShouldDoNothingOnFailure() => (await Result.Failure<Option<int>, string>("some error").SelectIfSomeAsync(IsEvenAsync)).Should().BeFaulted();

					private static Task<bool> IsEvenAsync(int i) => Task.FromResult(i % 2 == 0);
				}

				public class OntoOptionProducingFunction
				{
					public class OfSome
					{
						[Fact]
						public async Task ShouldMapOptionSomeToOptionSome() => (await Result.Success<Option<int>, string>(Option.Some(1337)).SelectIfSomeAsync(IsEvenAsync)).Should().BeSuccessful(option => option.Should().HaveExpectedValue(false));

						[Fact]
						public async Task ShouldMapOptionNoneToOptionNone() => (await Result.Success<Option<int>, string>(Option.None<int>()).SelectIfSomeAsync(IsEvenAsync)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldDoNothingOnFailure() => (await Result.Failure<Option<int>, string>("some error").SelectIfSomeAsync(IsEvenAsync)).Should().BeFaulted();

						private static Task<Option<bool>> IsEvenAsync(int i) => Task.FromResult(Option.Some(i % 2 == 0));
					}

					public class OfNone
					{
						[Fact]
						public async Task ShouldMapOptionSomeToOptionNone() => (await Result.Success<Option<int>, string>(Option.Some(1337)).SelectIfSomeAsync(IsEvenAsync)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldMapOptionNoneToOptionNone() => (await Result.Success<Option<int>, string>(Option.None<int>()).SelectIfSomeAsync(IsEvenAsync)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldDoNothingOnFailure() => (await Result.Failure<Option<int>, string>("some error").SelectIfSomeAsync(IsEvenAsync)).Should().BeFaulted();

						private static Task<Option<bool>> IsEvenAsync(int i) => Task.FromResult(Option.None<bool>());
					}
				}
			}

			public class AndBindIfSome
			{
				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public void ShouldMapOptionSomeToOptionSome() => Result.Success<Option<int>, string>(Option.Some(1337)).BindIfSome(IsEvenResult).Should().BeSuccessful(option => option.Should().HaveExpectedValue(false));

					[Fact]
					public void ShouldMapOptionNoneToOptionNone() => Result.Success<Option<int>, string>(Option.None<int>()).BindIfSome(IsEvenResult).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public void ShouldDoNothingOnFailure() => Result.Failure<Option<int>, string>("some error").BindIfSome(IsEvenResult).Should().BeFaulted();

					private static Result<bool, string> IsEvenResult(int i) => Result.Success<bool, string>(i % 2 == 0);
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public void ShouldMapOptionSomeToFaultedResult() => Result.Success<Option<int>, string>(Option.Some(1337)).BindIfSome(ErrorResult).Should().BeFaultedWithExpectedValue(ERROR);

					[Fact]
					public void ShouldMapOptionNoneToOptionNone() => Result.Success<Option<int>, string>(Option.None<int>()).BindIfSome(ErrorResult).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public void ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						Result.Failure<Option<int>, string>(EXISTING_ERROR).BindIfSome(ErrorResult).Should().BeFaultedWithExpectedValue(EXISTING_ERROR);
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
					public async Task ShouldMapOptionSomeToOptionSome() => (await Result.Success<Option<int>, string>(Option.Some(1337)).BindIfSomeAsync(IsEvenResultAsync)).Should().BeSuccessful(option => option.Should().HaveExpectedValue(false));

					[Fact]
					public async Task ShouldMapOptionNoneToOptionNone() => (await Result.Success<Option<int>, string>(Option.None<int>()).BindIfSomeAsync(IsEvenResultAsync)).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public async Task ShouldDoNothingOnFailure() => (await Result.Failure<Option<int>, string>("some error").BindIfSomeAsync(IsEvenResultAsync)).Should().BeFaulted();

					private static Task<Result<bool, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<bool, string>(i % 2 == 0));
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public async Task ShouldMapOptionSomeToFaultedResult() => (await Result.Success<Option<int>, string>(Option.Some(1337)).BindIfSomeAsync(ErrorResult)).Should().BeFaultedWithExpectedValue(ERROR);

					[Fact]
					public async Task ShouldMapOptionNoneToOptionNone() => (await Result.Success<Option<int>, string>(Option.None<int>()).BindIfSomeAsync(ErrorResult)).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public async Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						(await Result.Failure<Option<int>, string>(EXISTING_ERROR).BindIfSomeAsync(ErrorResult)).Should().BeFaultedWithExpectedValue(EXISTING_ERROR);
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
						public void ShouldMapOptionSomeToOptionSome() => Result.Success<Option<int>, string>(Option.Some(1337)).BindIfSome(IsEvenResult).Should().BeSuccessful(option => option.Should().HaveExpectedValue(false));

						[Fact]
						public void ShouldMapOptionNoneToOptionNone() => Result.Success<Option<int>, string>(Option.None<int>()).BindIfSome(IsEvenResult).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public void ShouldDoNothingOnFailure() => Result.Failure<Option<int>, string>("some error").BindIfSome(IsEvenResult).Should().BeFaulted();

						private static Result<Option<bool>, string> IsEvenResult(int i) => Result.Success<Option<bool>, string>(Option.Some(i % 2 == 0));
					}

					public class OfNone
					{
						[Fact]
						public void ShouldMapOptionSomeToOptionNone() => Result.Success<Option<int>, string>(Option.Some(1337)).BindIfSome(IsNoneResult).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public void ShouldMapOptionNoneToOptionNone() => Result.Success<Option<int>, string>(Option.None<int>()).BindIfSome(IsNoneResult).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public void ShouldDoNothingOnFailure() => Result.Failure<Option<int>, string>("some error").BindIfSome(IsNoneResult).Should().BeFaulted();

						private static Result<Option<bool>, string> IsNoneResult(int i) => Result.Success<Option<bool>, string>(Option.None<bool>());
					}
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public void ShouldMapOptionSomeToFaultedResult() => Result.Success<Option<int>, string>(Option.Some(1337)).BindIfSome(ErrorResult).Should().BeFaultedWithExpectedValue(ERROR);

					[Fact]
					public void ShouldMapOptionNoneToOptionNone() => Result.Success<Option<int>, string>(Option.None<int>()).BindIfSome(ErrorResult).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public void ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						Result.Failure<Option<int>, string>(EXISTING_ERROR).BindIfSome(ErrorResult).Should().BeFaultedWithExpectedValue(EXISTING_ERROR);
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
						public async Task ShouldMapOptionSomeToOptionSome() => (await Result.Success<Option<int>, string>(Option.Some(1337)).BindIfSomeAsync(IsEvenResultAsync)).Should().BeSuccessful(option => option.Should().HaveExpectedValue(false));

						[Fact]
						public async Task ShouldMapOptionNoneToOptionNone() => (await Result.Success<Option<int>, string>(Option.None<int>()).BindIfSomeAsync(IsEvenResultAsync)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldDoNothingOnFailure() => (await Result.Failure<Option<int>, string>("some error").BindIfSomeAsync(IsEvenResultAsync)).Should().BeFaulted();

						private static Task<Result<Option<bool>, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<Option<bool>, string>(Option.Some(i % 2 == 0)));
					}

					public class OfNone
					{
						[Fact]
						public async Task ShouldMapOptionSomeToOptionNone() => (await Result.Success<Option<int>, string>(Option.Some(1337)).BindIfSomeAsync(IsEvenResultAsync)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldMapOptionNoneToOptionNone() => (await Result.Success<Option<int>, string>(Option.None<int>()).BindIfSomeAsync(IsEvenResultAsync)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldDoNothingOnFailure() => (await Result.Failure<Option<int>, string>("some error").BindIfSomeAsync(IsEvenResultAsync)).Should().BeFaulted();

						private static Task<Result<Option<bool>, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<Option<bool>, string>(Option.None<bool>()));
					}
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public async Task ShouldMapOptionSomeToFaultedResult() => (await Result.Success<Option<int>, string>(Option.Some(1337)).BindIfSomeAsync(ErrorResult)).Should().BeFaultedWithExpectedValue(ERROR);

					[Fact]
					public async Task ShouldMapOptionNoneToOptionNone() => (await Result.Success<Option<int>, string>(Option.None<int>()).BindIfSomeAsync(ErrorResult)).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public async Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						(await Result.Failure<Option<int>, string>(EXISTING_ERROR).BindIfSomeAsync(ErrorResult)).Should().BeFaultedWithExpectedValue(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<Option<bool>, string>> ErrorResult(int i) => Task.FromResult(Result.Failure<Option<bool>, string>(ERROR));
				}
			}
		}

		public class WhenTaskOfResultOfOption
		{
			public class AndMatch
			{
				[Fact]
				public async Task ShouldMapOptionSomeToFirstValue() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).Match(First, Second, Third)).Should().Be("1337");

				[Fact]
				public async Task ShouldMapOptionNoneToSecondValue() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>()).Match(First, Second, Third))).Should().Be("none");

				[Fact]
				public async Task ShouldMapOptionNoneToThirdValue() => (await Task.FromResult(Result.Failure<Option<int>, string>("error").Match(First, Second, Third))).Should().Be("error");

				private static string First(int i) => i.ToString();
				private static string Second() => "none";
				private static string Third(string s) => s;
			}

			public class AndMatchAsync
			{
				[Fact]
				public async Task ShouldMapOptionSomeToFirstValue() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).MatchAsync(First, Second, Third)).Should().Be("1337");

				[Fact]
				public async Task ShouldMapOptionNoneToSecondValue() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).MatchAsync(First, Second, Third)).Should().Be("none");

				[Fact]
				public async Task ShouldMapOptionNoneToThirdValue() => (await Task.FromResult(Result.Failure<Option<int>, string>("error")).MatchAsync(First, Second, Third)).Should().Be("error");

				private static Task<string> First(int i) => Task.FromResult(i.ToString());
				private static Task<string> Second() => Task.FromResult("none");
				private static Task<string> Third(string s) => Task.FromResult(s);
			}

			public class AndSelectIfSome
			{
				public class OntoValueProducingFunction
				{
					[Fact]
					public async Task ShouldMapOptionSomeToOptionSome() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).SelectIfSome(ToString)).Should().BeSuccessful(option => option.Should().HaveExpectedValue("1337"));

					[Fact]
					public async Task ShouldMapOptionNoneToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).SelectIfSome(ToString)).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public async Task ShouldDoNothingOnFailure() => (await Task.FromResult(Result.Failure<Option<int>, string>("some error")).SelectIfSome(ToString)).Should().BeFaulted();

					private static string ToString(int i) => i.ToString();
				}

				public class OntoOptionProducingFunction
				{
					public class OfSome
					{
						[Fact]
						public async Task ShouldMapOptionSomeToOptionSome() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).SelectIfSome(ToString)).Should().BeSuccessful(option => option.Should().HaveExpectedValue("1337"));

						[Fact]
						public async Task ShouldMapOptionNoneToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).SelectIfSome(ToString)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldDoNothingOnFailure() => (await Task.FromResult(Result.Failure<Option<int>, string>("some error")).SelectIfSome(ToString)).Should().BeFaulted();

						private static Option<string> ToString(int i) => Option.Some(i.ToString());
					}

					public class OfNone
					{
						[Fact]
						public async Task ShouldMapOptionSomeToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).SelectIfSome(ToString)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldMapOptionNoneToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).SelectIfSome(ToString)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldDoNothingOnFailure() => (await Task.FromResult(Result.Failure<Option<int>, string>("some error")).SelectIfSome(ToString)).Should().BeFaulted();

						private static Option<string> ToString(int i) => Option.None<string>();
					}
				}
			}

			public class AndSelectIfSomeAsync
			{
				public class OntoValueProducingFunction
				{
					[Fact]
					public async Task ShouldMapOptionSomeToOptionSome() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).SelectIfSomeAsync(i => Task.FromResult(i.ToString()))).Should().BeSuccessful(option => option.Should().HaveExpectedValue("1337"));

					[Fact]
					public async Task ShouldMapOptionNoneToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).SelectIfSomeAsync(i => Task.FromResult(i.ToString()))).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public async Task ShouldDoNothingOnFailure() => (await Task.FromResult(Result.Failure<Option<int>, string>("some error")).SelectIfSomeAsync(i => Task.FromResult(i.ToString()))).Should().BeFaulted();
				}

				public class OntoOptionProducingFunction
				{
					public class OfSome
					{
						[Fact]
						public async Task ShouldMapOptionSomeToOptionSome() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).SelectIfSomeAsync(ToString)).Should().BeSuccessful(option => option.Should().HaveExpectedValue("1337"));

						[Fact]
						public async Task ShouldMapOptionNoneToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).SelectIfSomeAsync(ToString)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldDoNothingOnFailure() => (await Task.FromResult(Result.Failure<Option<int>, string>("some error")).SelectIfSomeAsync(ToString)).Should().BeFaulted();

						private static Task<Option<string>> ToString(int i) => Task.FromResult(Option.Some(i.ToString()));
					}

					public class OfNone
					{
						[Fact]
						public async Task ShouldMapOptionSomeToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).SelectIfSomeAsync(ToString)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldMapOptionNoneToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).SelectIfSomeAsync(ToString)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldDoNothingOnFailure() => (await Task.FromResult(Result.Failure<Option<int>, string>("some error")).SelectIfSomeAsync(ToString)).Should().BeFaulted();

						private static Task<Option<string>> ToString(int i) => Task.FromResult(Option.None<string>());
					}
				}
			}

			public class AndBindIfSome
			{
				public class AndFunctionProducesSuccessfulResult
				{
					[Fact]
					public async Task ShouldMapOptionSomeToOptionSome() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).BindIfSome(IsEvenResult)).Should().BeSuccessful(option => option.Should().HaveExpectedValue(false));

					[Fact]
					public async Task ShouldMapOptionNoneToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).BindIfSome(IsEvenResult)).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public async Task ShouldDoNothingOnFailure() => (await Task.FromResult(Result.Failure<Option<int>, string>("some error")).BindIfSome(IsEvenResult)).Should().BeFaulted();

					private static Result<bool, string> IsEvenResult(int i) => Result.Success<bool, string>(i % 2 == 0);
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public async Task ShouldMapOptionSomeToFaultedResult() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).BindIfSome(ErrorResult)).Should().BeFaultedWithExpectedValue(ERROR);

					[Fact]
					public async Task ShouldMapOptionNoneToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).BindIfSome(ErrorResult)).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public async Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						(await Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR)).BindIfSome(ErrorResult)).Should().BeFaultedWithExpectedValue(EXISTING_ERROR);
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
					public async Task ShouldMapOptionSomeToOptionSome() => (await (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))).BindIfSomeAsync(IsEvenResultAsync)).Should().BeSuccessful(option => option.Should().HaveExpectedValue(false));

					[Fact]
					public async Task ShouldMapOptionNoneToOptionNone() => (await (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))).BindIfSomeAsync(IsEvenResultAsync)).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public async Task ShouldDoNothingOnFailure() => (await (await Task.FromResult(Result.Failure<Option<int>, string>("some error"))).BindIfSomeAsync(IsEvenResultAsync)).Should().BeFaulted();

					private static Task<Result<bool, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<bool, string>(i % 2 == 0));
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public async Task ShouldMapOptionSomeToFaultedResult() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).BindIfSomeAsync(ErrorResult)).Should().BeFaultedWithExpectedValue(ERROR);

					[Fact]
					public async Task ShouldMapOptionNoneToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).BindIfSomeAsync(ErrorResult)).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public async Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						(await Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR)).BindIfSomeAsync(ErrorResult)).Should().BeFaultedWithExpectedValue(EXISTING_ERROR);
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
						public async Task ShouldMapOptionSomeToOptionSome() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).BindIfSome(IsEvenResult)).Should().BeSuccessful(option => option.Should().HaveExpectedValue(false));

						[Fact]
						public async Task ShouldMapOptionNoneToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).BindIfSome(IsEvenResult)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldDoNothingOnFailure() => (await Task.FromResult(Result.Failure<Option<int>, string>("some error")).BindIfSome(IsEvenResult)).Should().BeFaulted();

						private static Result<Option<bool>, string> IsEvenResult(int i) => Result.Success<Option<bool>, string>(Option.Some(i % 2 == 0));
					}

					public class OfNone
					{
						[Fact]
						public async Task ShouldMapOptionSomeToOptionSome() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).BindIfSome(IsNoneResult)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldMapOptionNoneToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).BindIfSome(IsNoneResult)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldDoNothingOnFailure() => (await Task.FromResult(Result.Failure<Option<int>, string>("some error")).BindIfSome(IsNoneResult)).Should().BeFaulted();

						private static Result<Option<bool>, string> IsNoneResult(int i) => Result.Success<Option<bool>, string>(Option.None<bool>());
					}
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public async Task ShouldMapOptionSomeToFaultedResult() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).BindIfSome(ErrorResult)).Should().BeFaultedWithExpectedValue(ERROR);

					[Fact]
					public async Task ShouldMapOptionNoneToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).BindIfSome(ErrorResult)).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public async Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						(await Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR)).BindIfSome(ErrorResult)).Should().BeFaultedWithExpectedValue(EXISTING_ERROR);
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
						public async Task ShouldMapOptionSomeToOptionSome() => (await (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))).BindIfSomeAsync(IsEvenResultAsync)).Should().BeSuccessful(option => option.Should().HaveExpectedValue(false));

						[Fact]
						public async Task ShouldMapOptionNoneToOptionNone() => (await (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))).BindIfSomeAsync(IsEvenResultAsync)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldDoNothingOnFailure() => (await (await Task.FromResult(Result.Failure<Option<int>, string>("some error"))).BindIfSomeAsync(IsEvenResultAsync)).Should().BeFaulted();

						private static Task<Result<Option<bool>, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<Option<bool>, string>(Option.Some(i % 2 == 0)));
					}

					public class OfNone
					{
						[Fact]
						public async Task ShouldMapOptionSomeToOptionSome() => (await (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))).BindIfSomeAsync(IsEvenResultAsync)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldMapOptionNoneToOptionNone() => (await (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))).BindIfSomeAsync(IsEvenResultAsync)).Should().BeSuccessful(option => option.Should().NotHaveValue());

						[Fact]
						public async Task ShouldDoNothingOnFailure() => (await (await Task.FromResult(Result.Failure<Option<int>, string>("some error"))).BindIfSomeAsync(IsEvenResultAsync)).Should().BeFaulted();

						private static Task<Result<Option<bool>, string>> IsEvenResultAsync(int i) => Task.FromResult(Result.Success<Option<bool>, string>(Option.None<bool>()));
					}
				}

				public class AndFunctionProducesFaultedResult
				{
					[Fact]
					public async Task ShouldMapOptionSomeToFaultedResult() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).BindIfSomeAsync(ErrorResult)).Should().BeFaultedWithExpectedValue(ERROR);

					[Fact]
					public async Task ShouldMapOptionNoneToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).BindIfSomeAsync(ErrorResult)).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public async Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						(await Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR)).BindIfSomeAsync(ErrorResult)).Should().BeFaultedWithExpectedValue(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<Option<bool>, string>> ErrorResult(int i) => Task.FromResult(Result.Failure<Option<bool>, string>(ERROR));
				}
			}
		}
	}
}
