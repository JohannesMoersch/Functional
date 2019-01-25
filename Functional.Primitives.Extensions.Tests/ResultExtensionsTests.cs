using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Primitives.Extensions.Tests
{
	public class ResultExtensionsTests
	{
		public class WhenResultOfOption
		{
			public class AndSelectIfSome
			{
				[Fact]
				public void ShouldMapOptionSomeToOptionSome() => Result.Success<Option<int>, string>(Option.Some(1337)).SelectIfSome(IsEven).Should().BeSuccessful(option => option.Should().HaveExpectedValue(false));

				[Fact]
				public void ShouldMapOptionNoneToOptionNone() => Result.Success<Option<int>, string>(Option.None<int>()).SelectIfSome(IsEven).Should().BeSuccessful(option => option.Should().NotHaveValue());

				[Fact]
				public void ShouldDoNothingOnFailure() => Result.Failure<Option<int>, string>("some error").SelectIfSome(IsEven).Should().BeFaulted();

				private static bool IsEven(int i) => i % 2 == 0;
			}

			public class AndSelectIfSomeAsync
			{
				[Fact]
				public async Task ShouldMapOptionSomeToOptionSome() => (await Result.Success<Option<int>, string>(Option.Some(1337)).SelectIfSomeAsync(IsEvenAsync)).Should().BeSuccessful(option => option.Should().HaveExpectedValue(false));

				[Fact]
				public async Task ShouldMapOptionNoneToOptionNone() => (await Result.Success<Option<int>, string>(Option.None<int>()).SelectIfSomeAsync(IsEvenAsync)).Should().BeSuccessful(option => option.Should().NotHaveValue());

				[Fact]
				public async Task ShouldDoNothingOnFailure() => (await Result.Failure<Option<int>, string>("some error").SelectIfSomeAsync(IsEvenAsync)).Should().BeFaulted();

				private static Task<bool> IsEvenAsync(int i) => Task.FromResult(i % 2 == 0);
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
		}

		public class WhenTaskOfResultOfOption
		{
			public class AndSelectIfSome
			{
				[Fact]
				public async Task ShouldMapOptionSomeToOptionSome() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))).SelectIfSome(i => i.ToString()).Should().BeSuccessful(option => option.Should().HaveExpectedValue("1337"));

				[Fact]
				public async Task ShouldMapOptionNoneToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))).SelectIfSome(i => i.ToString()).Should().BeSuccessful(option => option.Should().NotHaveValue());

				[Fact]
				public async Task ShouldDoNothingOnFailure() => (await Task.FromResult(Result.Failure<Option<int>, string>("some error"))).SelectIfSome(i => i.ToString()).Should().BeFaulted();
			}

			public class AndSelectIfSomeAsync
			{
				[Fact]
				public async Task ShouldMapOptionSomeToOptionSome() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337))).SelectIfSomeAsync(i => Task.FromResult(i.ToString()))).Should().BeSuccessful(option => option.Should().HaveExpectedValue("1337"));

				[Fact]
				public async Task ShouldMapOptionNoneToOptionNone() => (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>())).SelectIfSomeAsync(i => Task.FromResult(i.ToString()))).Should().BeSuccessful(option => option.Should().NotHaveValue());

				[Fact]
				public async Task ShouldDoNothingOnFailure() => (await Task.FromResult(Result.Failure<Option<int>, string>("some error")).SelectIfSomeAsync(i => Task.FromResult(i.ToString()))).Should().BeFaulted();
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
					public async Task ShouldMapOptionSomeToFaultedResult() => (await (await Task.FromResult(Result.Success<Option<int>, string>(Option.Some(1337)))).BindIfSomeAsync(ErrorResult)).Should().BeFaultedWithExpectedValue(ERROR);

					[Fact]
					public async Task ShouldMapOptionNoneToOptionNone() => (await (await Task.FromResult(Result.Success<Option<int>, string>(Option.None<int>()))).BindIfSomeAsync(ErrorResult)).Should().BeSuccessful(option => option.Should().NotHaveValue());

					[Fact]
					public async Task ShouldDoNothingOnFailure()
					{
						const string EXISTING_ERROR = "something strange happened";
						(await (await Task.FromResult(Result.Failure<Option<int>, string>(EXISTING_ERROR))).BindIfSomeAsync(ErrorResult)).Should().BeFaultedWithExpectedValue(EXISTING_ERROR);
					}

					private const string ERROR = "error";
					private static Task<Result<bool, string>> ErrorResult(int i) => Task.FromResult(Result.Failure<bool, string>(ERROR));
				}
			}
		}
	}
}
