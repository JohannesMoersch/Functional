using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Results
{
	public class ResultFactoryTests
	{
		private static readonly bool _true = true;

		private static void ThrowTestException()
			=> throw new TestException();

		private static void ThrowException()
			=> throw new Exception();

		private static int IntThrowTestException()
			=> throw new TestException();

		private static int IntThrowException()
			=> throw new Exception();

		[Fact]
		public Task SuccessAsync()
			=> Result
				.SuccessAsync<int, string>(Helpers.DelayedTask(10))
				.AssertSuccess()
				.Should()
				.Be(10);

		[Fact]
		public Task FailureAsync()
			=> Result
				.FailureAsync<int, string>(Helpers.DelayedTask("abc"))
				.AssertFailure()
				.Should()
				.Be("abc");

		[Fact]
		public void CreateTrue()
			=> Result
				.Create(true, 10, "abc")
				.AssertSuccess()
				.Should()
				.Be(10);

		[Fact]
		public void CreateFalse()
			=> Result
				.Create(false, 10, "abc")
				.AssertFailure()
				.Should()
				.Be("abc");

		[Fact]
		public void CreateSuccessDelegateTrue()
			=> Result
				.Create(true, () => 10, "abc")
				.AssertSuccess()
				.Should()
				.Be(10);

		[Fact]
		public void CreateSuccessDelegateFalse()
			=> Result
				.Create(false, () => 10, "abc")
				.AssertFailure()
				.Should()
				.Be("abc");

		[Fact]
		public void CreateFailureDelegateTrue()
			=> Result
				.Create(true, 10, () => "abc")
				.AssertSuccess()
				.Should()
				.Be(10);

		[Fact]
		public void CreateFailureDelegateFalse()
			=> Result
				.Create(false, 10, () => "abc")
				.AssertFailure()
				.Should()
				.Be("abc");

		[Fact]
		public void CreateSuccessDelegateFailureDelegateTrue()
			=> Result
				.Create(true, () => 10, () => "abc")
				.AssertSuccess()
				.Should()
				.Be(10);

		[Fact]
		public void CreateSuccessDelegateFailureDelegateFalse()
			=> Result
				.Create(false, () => 10, () => "abc")
				.AssertFailure()
				.Should()
				.Be("abc");

		[Fact]
		public Task CreateSuccessAsyncDelegateTrue()
			=> Result
				.CreateAsync(true, () => Helpers.DelayedTask(10), "abc")
				.AssertSuccess()
				.Should()
				.Be(10);

		[Fact]
		public Task CreateSuccessAsyncDelegateFalse()
			=> Result
				.CreateAsync(false, () => Helpers.DelayedTask(10), "abc")
				.AssertFailure()
				.Should()
				.Be("abc");

		[Fact]
		public Task CreateFailureAsyncDelegateTrue()
			=> Result
				.CreateAsync(true, 10, () => Helpers.DelayedTask("abc"))
				.AssertSuccess()
				.Should()
				.Be(10);

		[Fact]
		public Task CreateFailureAsyncDelegateFalse()
			=> Result
				.CreateAsync(false, 10, () => Helpers.DelayedTask("abc"))
				.AssertFailure()
				.Should()
				.Be("abc");

		[Fact]
		public Task CreateSuccessDelegateFailureAsyncDelegateTrue()
			=> Result
				.CreateAsync(true, () => 10, () => Helpers.DelayedTask("abc"))
				.AssertSuccess()
				.Should()
				.Be(10);

		[Fact]
		public Task CreateSuccessDelegateFailureAsyncDelegateFalse()
			=> Result
				.CreateAsync(false, () => 10, () => Helpers.DelayedTask("abc"))
				.AssertFailure()
				.Should()
				.Be("abc");

		[Fact]
		public Task CreateSuccessAsyncDelegateFailureDelegateTrue()
			=> Result
				.CreateAsync(true, () => Helpers.DelayedTask(10), () => "abc")
				.AssertSuccess()
				.Should()
				.Be(10);

		[Fact]
		public Task CreateSuccessAsyncDelegateFailureDelegateFalse()
			=> Result
				.CreateAsync(false, () => Helpers.DelayedTask(10), () => "abc")
				.AssertFailure()
				.Should()
				.Be("abc");

		[Fact]
		public Task CreateSuccessAsyncDelegateFailureAsyncDelegateTrue()
			=> Result
				.CreateAsync(true, () => Helpers.DelayedTask(10), () => Helpers.DelayedTask("abc"))
				.AssertSuccess()
				.Should()
				.Be(10);

		[Fact]
		public Task CreateSuccessAsyncDelegateFailureAsyncDelegateFalse()
			=> Result
				.CreateAsync(false, () => Helpers.DelayedTask(10), () => Helpers.DelayedTask("abc"))
				.AssertFailure()
				.Should()
				.Be("abc");

		[Fact]
		public void TryUnitExceptionWhenSucceeds()
			=> Result
				.Try(() => { })
				.AssertSuccess()
				.Should()
				.Be(Functional.Unit.Value);

		[Fact]
		public void TryUnitExceptionWhenThrows()
			=> Result
				.Try(() => { if (_true) throw new TestException(); return; })
				.AssertFailure()
				.Should()
				.BeOfType<TestException>();

		[Fact]
		public void TryUnitFailureWhenSucceeds()
			=> Result
				.Try(() => { }, ex => ex.Message)
				.AssertSuccess()
				.Should()
				.Be(Functional.Unit.Value);

		[Fact]
		public void TryUnitFailureWhenThrows()
			=> Result
				.Try(() => { if (_true) throw new TestException("abc"); return; }, ex => ex.Message)
				.AssertFailure()
				.Should()
				.Be("abc");

		[Fact]
		public void TryUnitGenericExceptionWhenSucceeds()
			=> Result
				.Try<TestException>(() => { })
				.AssertSuccess()
				.Should()
				.Be(Functional.Unit.Value);

		[Fact]
		public void TryUnitGenericExceptionWhenThrowsGeneric()
			=> Result
				.Try<TestException>(ThrowTestException)
				.AssertFailure()
				.Should()
				.BeOfType<TestException>();

		[Fact]
		public void TryUnitGenericExceptionWhenThrowsException()
			=> Assert.Throws<Exception>(
				() => Result.Try<TestException>(ThrowException)
			);

		[Fact]
		public void TryGenericExceptionWhenSucceeds()
			=> Result
				.Try<int, TestException>(() => 42)
				.AssertSuccess()
				.Should()
				.Be(42);

		[Fact]
		public void TryGenericExceptionWhenThrowsGeneric()
			=> Result
				.Try<int, TestException>(IntThrowTestException)
				.AssertFailure()
				.Should()
				.BeOfType<TestException>();

		[Fact]
		public void TryGenericExceptionWhenThrowsException()
			=> Assert.Throws<Exception>(
				() => Result.Try<int, TestException>(IntThrowException)
			);

		[Fact]
		public Task TryAsyncUnitExceptionWhenSucceeds()
			=> Result
				.TryAsync(() => Helpers.DelayedTask())
				.AssertSuccess()
				.Should()
				.Be(Functional.Unit.Value);

		[Fact]
		public Task TryAsyncUnitExceptionWhenThrows()
			=> Result
				.TryAsync(() => { if (_true) throw new TestException("abc"); return Helpers.DelayedTask(); })
				.AssertFailure()
				.Should()
				.BeOfType<TestException>();

		[Fact]
		public Task TryAsyncUnitFailureWhenSucceeds()
			=> Result
				.TryAsync(() => Helpers.DelayedTask(), ex => ex.Message)
				.AssertSuccess()
				.Should()
				.Be(Functional.Unit.Value);

		[Fact]
		public Task TryAsyncUnitFailureWhenThrows()
			=> Result
				.TryAsync(() => { if (_true) throw new TestException("abc"); return Helpers.DelayedTask(); }, ex => ex.Message)
				.AssertFailure()
				.Should()
				.Be("abc");

		[Fact]
		public void TryExceptionWhenSucceeds()
			=> Result
				.Try(() => 10)
				.AssertSuccess()
				.Should()
				.Be(10);

		[Fact]
		public void TryExceptionWhenThrows()
			=> Result
				.Try(() => { if (_true) throw new TestException(); return 10; })
				.AssertFailure()
				.Should()
				.BeOfType<TestException>();

		[Fact]
		public void TryFailureWhenSucceeds()
			=> Result
				.Try(() => 10, ex => ex.Message)
				.AssertSuccess()
				.Should()
				.Be(10);

		[Fact]
		public void TryFailureWhenThrows()
			=> Result
				.Try(() => { if (_true) throw new TestException("abc"); return 10; }, ex => ex.Message)
				.AssertFailure()
				.Should()
				.Be("abc");

		[Fact]
		public Task TryAsyncExceptionWhenSucceeds()
			=> Result
				.TryAsync(() => Helpers.DelayedTask(10))
				.AssertSuccess()
				.Should()
				.Be(10);

		[Fact]
		public Task TryAsyncExceptionWhenThrows()
			=> Result
				.TryAsync(() => { if (_true) throw new TestException("abc"); return Helpers.DelayedTask(10); })
				.AssertFailure()
				.Should()
				.BeOfType<TestException>();

		[Fact]
		public Task TryAsyncFailureWhenSucceeds()
			=> Result
				.TryAsync(() => Helpers.DelayedTask(10), ex => ex.Message)
				.AssertSuccess()
				.Should()
				.Be(10);

		[Fact]
		public Task TryAsyncFailureWhenThrows()
			=> Result
				.TryAsync(() => { if (_true) throw new TestException("abc"); return Helpers.DelayedTask(10); }, ex => ex.Message)
				.AssertFailure()
				.Should()
				.Be("abc");

		[Fact]
		public void Unit()
			=> Result
				.Unit<string>()
				.AssertSuccess()
				.Should()
				.Be(Functional.Unit.Value);

		[Fact]
		public void WhereTrue()
			=> Result
				.Where(true, "abc")
				.AssertSuccess()
				.Should()
				.Be(Functional.Unit.Value);

		[Fact]
		public void WhereFalse()
			=> Result
				.Where(false, "abc")
				.AssertFailure()
				.Should()
				.Be("abc");

		[Fact]
		public void WhereDelegateTrue()
			=> Result
				.Where(true, () => "abc")
				.AssertSuccess()
				.Should()
				.Be(Functional.Unit.Value);

		[Fact]
		public void WhereDelegateFalse()
			=> Result
				.Where(false, () => "abc")
				.AssertFailure()
				.Should()
				.Be("abc");

		public class WhenZip2
		{
			[Fact]
			public void ReturnsSuccessWhenAllSuccess()
			{
				var result1 = Result.Success<int, string>(1);
				var result2 = Result.Success<int, string>(2);

				Result.Zip(result1, result2)
					.AssertSuccess()
					.Should()
					.Be((1, 2));
			}

			[Theory]
			[ResultZip2ReturnsFailureArrangement]
			public void ReturnsFailureWhenAtLeastOneFailure(Result<int, string>[] resultCollection)
				=> Result.Zip(
						resultCollection[0],
						resultCollection[1])
					.AssertFailure()
					.Should()
					.Match(errorCollection
						=> errorCollection.Count() == resultCollection.Count(r => !r.IsSuccess())
						   && resultCollection.Where(r => !r.IsSuccess()).Select(r => r.Failure()).WhereSome().All(errorCollection.Contains));

			#region Arrangements

			private class ResultZip2ReturnsFailureArrangement : AutoDataAttribute
			{
				public override IEnumerable<object[]> GetData(MethodInfo testMethod)
				{
					for (var i = 0; i < (1 << 2) - 1; ++i)
					{
						var result1 = Result.Create((i & 1) == 1, () => 13, () => "error 1");
						var result2 = Result.Create(((i >> 1) & 1) == 1, () => 17, () => "error 2");

						yield return new object[] { new[] { result1, result2 } };
					}
				}
			}

			#endregion
		}

		public class WhenZip3
		{
			[Fact]
			public void ReturnsSuccessWhenAllSuccess()
			{
				var result1 = Result.Success<int, string>(1);
				var result2 = Result.Success<int, string>(2);
				var result3 = Result.Success<int, string>(3);
				
				Result.Zip(result1, result2, result3)
					.AssertSuccess()
					.Should()
					.Be((1, 2, 3));
			}

			[Theory]
			[ResultZip3ReturnsFailureArrangement]
			public void ReturnsFailureWhenAtLeastOneFailure(Result<int, string>[] resultCollection)
				=> Result.Zip(
						resultCollection[0],
						resultCollection[1],
						resultCollection[2])
					.AssertFailure()
					.Should()
					.Match(errorCollection
						=> errorCollection.Count() == resultCollection.Count(r => !r.IsSuccess())
						   && resultCollection.Where(r => !r.IsSuccess()).Select(r => r.Failure()).WhereSome().All(errorCollection.Contains));

			#region Arrangements

			private class ResultZip3ReturnsFailureArrangement : AutoDataAttribute
			{
				public override IEnumerable<object[]> GetData(MethodInfo testMethod)
				{
					for (var i = 0; i < (1 << 3) - 1; ++i)
					{
						var result1 = Result.Create((i & 1) == 1, () => 13, () => "error 1");
						var result2 = Result.Create(((i >> 1) & 1) == 1, () => 17, () => "error 2");
						var result3 = Result.Create(((i >> 2) & 1) == 1, () => 25, () => "error 3");

						yield return new object[] { new[] { result1, result2, result3 } };
					}
				}
			}

			#endregion
		}

		public class WhenZip4
		{
			[Fact]
			public void ReturnsSuccessWhenAllSuccess()
			{
				var result1 = Result.Success<int, string>(1);
				var result2 = Result.Success<int, string>(2);
				var result3 = Result.Success<int, string>(3);
				var result4 = Result.Success<int, string>(4);

				Result.Zip(result1, result2, result3, result4)
					.AssertSuccess()
					.Should()
					.Be((1, 2, 3, 4));
			}

			[Theory]
			[ResultZip4ReturnsFailureArrangement]
			public void ReturnsFailureWhenAtLeastOneFailure(Result<int, string>[] resultCollection)
				=> Result.Zip(
						resultCollection[0],
						resultCollection[1],
						resultCollection[2],
						resultCollection[3])
					.AssertFailure()
					.Should()
					.Match(errorCollection
						=> errorCollection.Count() == resultCollection.Count(r => !r.IsSuccess())
						   && resultCollection.Where(r => !r.IsSuccess()).Select(r => r.Failure()).WhereSome().All(errorCollection.Contains));

			#region Arrangements

			private class ResultZip4ReturnsFailureArrangement : AutoDataAttribute
			{
				public override IEnumerable<object[]> GetData(MethodInfo testMethod)
				{
					for (var i = 0; i < (1 << 4) - 1; ++i)
					{
						var result1 = Result.Create((i & 1) == 1, () => 13, () => "error 1");
						var result2 = Result.Create(((i >> 1) & 1) == 1, () => 17, () => "error 2");
						var result3 = Result.Create(((i >> 2) & 1) == 1, () => 25, () => "error 3");
						var result4 = Result.Create(((i >> 3) & 1) == 1, () => -5, () => "error 4");

						yield return new object[] { new[] { result1, result2, result3, result4 } };
					}
				}
			}

			#endregion
		}

		public class WhenZip5
		{
			[Fact]
			public void ReturnsSuccessWhenAllSuccess()
			{
				var result1 = Result.Success<int, string>(1);
				var result2 = Result.Success<int, string>(2);
				var result3 = Result.Success<int, string>(3);
				var result4 = Result.Success<int, string>(4);
				var result5 = Result.Success<int, string>(5);

				Result.Zip(result1, result2, result3, result4, result5)
					.AssertSuccess()
					.Should()
					.Be((1, 2, 3, 4, 5));
			}

			[Theory]
			[ResultZip5ReturnsFailureArrangement]
			public void ReturnsFailureWhenAtLeastOneFailure(Result<int, string>[] resultCollection)
				=> Result.Zip(
						resultCollection[0],
						resultCollection[1],
						resultCollection[2],
						resultCollection[3],
						resultCollection[4])
					.AssertFailure()
					.Should()
					.Match(errorCollection
						=> errorCollection.Count() == resultCollection.Count(r => !r.IsSuccess())
						   && resultCollection.Where(r => !r.IsSuccess()).Select(r => r.Failure()).WhereSome().All(errorCollection.Contains));

			#region Arrangements

			private class ResultZip5ReturnsFailureArrangement : AutoDataAttribute
			{
				public override IEnumerable<object[]> GetData(MethodInfo testMethod)
				{
					for (var i = 0; i < (1 << 5) - 1; ++i)
					{
						var result1 = Result.Create((i & 1) == 1, () => 13, () => "error 1");
						var result2 = Result.Create(((i >> 1) & 1) == 1, () => 17, () => "error 2");
						var result3 = Result.Create(((i >> 2) & 1) == 1, () => 25, () => "error 3");
						var result4 = Result.Create(((i >> 3) & 1) == 1, () => -5, () => "error 4");
						var result5 = Result.Create(((i >> 4) & 1) == 1, () => 99, () => "error 5");

						yield return new object[] { new[] { result1, result2, result3, result4, result5 } };
					}
				}
			}

			#endregion
		}

		public class WhenZip6
		{
			[Fact]
			public void ReturnsSuccessWhenAllSuccess()
			{
				var result1 = Result.Success<int, string>(1);
				var result2 = Result.Success<int, string>(2);
				var result3 = Result.Success<int, string>(3);
				var result4 = Result.Success<int, string>(4);
				var result5 = Result.Success<int, string>(5);
				var result6 = Result.Success<int, string>(6);

				Result.Zip(result1, result2, result3, result4, result5, result6)
					.AssertSuccess()
					.Should()
					.Be((1, 2, 3, 4, 5, 6));
			}

			[Theory]
			[ResultZip6ReturnsFailureArrangement]
			public void ReturnsFailureWhenAtLeastOneFailure(Result<int, string>[] resultCollection)
				=> Result.Zip(
						resultCollection[0],
						resultCollection[1],
						resultCollection[2],
						resultCollection[3],
						resultCollection[4],
						resultCollection[5])
					.AssertFailure()
					.Should()
					.Match(errorCollection
						=> errorCollection.Count() == resultCollection.Count(r => !r.IsSuccess())
						   && resultCollection.Where(r => !r.IsSuccess()).Select(r => r.Failure()).WhereSome().All(errorCollection.Contains));

			#region Arrangements

			private class ResultZip6ReturnsFailureArrangement : AutoDataAttribute
			{
				public override IEnumerable<object[]> GetData(MethodInfo testMethod)
				{
					for (var i = 0; i < (1 << 6) - 1; ++i)
					{
						var result1 = Result.Create((i & 1) == 1, () => 13, () => "error 1");
						var result2 = Result.Create(((i >> 1) & 1) == 1, () => 17, () => "error 2");
						var result3 = Result.Create(((i >> 2) & 1) == 1, () => 25, () => "error 3");
						var result4 = Result.Create(((i >> 3) & 1) == 1, () => -5, () => "error 4");
						var result5 = Result.Create(((i >> 4) & 1) == 1, () => 99, () => "error 5");
						var result6 = Result.Create(((i >> 5) & 1) == 1, () => 36, () => "error 6");

						yield return new object[] { new[] { result1, result2, result3, result4, result5, result6 } };
					}
				}
			}

			#endregion
		}

		public class WhenZip7
		{
			[Fact]
			public void ReturnsSuccessWhenAllSuccess()
			{
				var result1 = Result.Success<int, string>(1);
				var result2 = Result.Success<int, string>(2);
				var result3 = Result.Success<int, string>(3);
				var result4 = Result.Success<int, string>(4);
				var result5 = Result.Success<int, string>(5);
				var result6 = Result.Success<int, string>(6);
				var result7 = Result.Success<int, string>(7);

				Result.Zip(result1, result2, result3, result4, result5, result6, result7)
					.AssertSuccess()
					.Should()
					.Be((1, 2, 3, 4, 5, 6, 7));
			}

			[Theory]
			[ResultZip7ReturnsFailureArrangement]
			public void ReturnsFailureWhenAtLeastOneFailure(Result<int, string>[] resultCollection)
				=> Result.Zip(
						resultCollection[0],
						resultCollection[1],
						resultCollection[2],
						resultCollection[3],
						resultCollection[4],
						resultCollection[5],
						resultCollection[6])
					.AssertFailure()
					.Should()
					.Match(errorCollection
						=> errorCollection.Count() == resultCollection.Count(r => !r.IsSuccess())
						   && resultCollection.Where(r => !r.IsSuccess()).Select(r => r.Failure()).WhereSome().All(errorCollection.Contains));

			#region Arrangements

			private class ResultZip7ReturnsFailureArrangement : AutoDataAttribute
			{
				public override IEnumerable<object[]> GetData(MethodInfo testMethod)
				{
					for (var i = 0; i < (1 << 7) - 1; ++i)
					{
						var result1 = Result.Create((i & 1) == 1, () => 13, () => "error 1");
						var result2 = Result.Create(((i >> 1) & 1) == 1, () => 17, () => "error 2");
						var result3 = Result.Create(((i >> 2) & 1) == 1, () => 25, () => "error 3");
						var result4 = Result.Create(((i >> 3) & 1) == 1, () => -5, () => "error 4");
						var result5 = Result.Create(((i >> 4) & 1) == 1, () => 99, () => "error 5");
						var result6 = Result.Create(((i >> 5) & 1) == 1, () => 36, () => "error 6");
						var result7 = Result.Create(((i >> 6) & 1) == 1, () => 20, () => "error 7");

						yield return new object[] { new[] { result1, result2, result3, result4, result5, result6, result7 } };
					}
				}
			}

			#endregion
		}

		public class WhenZip8
		{
			[Fact]
			public void ReturnsSuccessWhenAllSuccess()
			{
				var result1 = Result.Success<int, string>(1);
				var result2 = Result.Success<int, string>(2);
				var result3 = Result.Success<int, string>(3);
				var result4 = Result.Success<int, string>(4);
				var result5 = Result.Success<int, string>(5);
				var result6 = Result.Success<int, string>(6);
				var result7 = Result.Success<int, string>(7);
				var result8 = Result.Success<int, string>(8);

				Result.Zip(result1, result2, result3, result4, result5, result6, result7, result8)
					.AssertSuccess()
					.Should()
					.Be((1, 2, 3, 4, 5, 6, 7, 8));
			}

			[Theory]
			[ResultZip8ReturnsFailureArrangement]
			public void ReturnsFailureWhenAtLeastOneFailure(Result<int, string>[] resultCollection)
				=> Result.Zip(
						resultCollection[0],
						resultCollection[1],
						resultCollection[2],
						resultCollection[3],
						resultCollection[4],
						resultCollection[5],
						resultCollection[6],
						resultCollection[7])
					.AssertFailure()
					.Should()
					.Match(errorCollection
						=> errorCollection.Count() == resultCollection.Count(r => !r.IsSuccess())
						   && resultCollection.Where(r => !r.IsSuccess()).Select(r => r.Failure()).WhereSome().All(errorCollection.Contains));

			#region Arrangements

			private class ResultZip8ReturnsFailureArrangement : AutoDataAttribute
			{
				public override IEnumerable<object[]> GetData(MethodInfo testMethod)
				{
					for (var i = 0; i < (1 << 8) - 1; ++i)
					{
						var result1 = Result.Create((i & 1) == 1, () => 13, () => "error 1");
						var result2 = Result.Create(((i >> 1) & 1) == 1, () => 17, () => "error 2");
						var result3 = Result.Create(((i >> 2) & 1) == 1, () => 25, () => "error 3");
						var result4 = Result.Create(((i >> 3) & 1) == 1, () => -5, () => "error 4");
						var result5 = Result.Create(((i >> 4) & 1) == 1, () => 99, () => "error 5");
						var result6 = Result.Create(((i >> 5) & 1) == 1, () => 36, () => "error 6");
						var result7 = Result.Create(((i >> 6) & 1) == 1, () => 20, () => "error 7");
						var result8 = Result.Create(((i >> 7) & 1) == 1, () => 11, () => "error 8");

						yield return new object[] { new[] { result1, result2, result3, result4, result5, result6, result7, result8 } };
					}
				}
			}

			#endregion
		}

		public class WhenZip9
		{
			[Fact]
			public void ReturnsSuccessWhenAllSuccess()
			{
				var result1 = Result.Success<int, string>(1);
				var result2 = Result.Success<int, string>(2);
				var result3 = Result.Success<int, string>(3);
				var result4 = Result.Success<int, string>(4);
				var result5 = Result.Success<int, string>(5);
				var result6 = Result.Success<int, string>(6);
				var result7 = Result.Success<int, string>(7);
				var result8 = Result.Success<int, string>(8);
				var result9 = Result.Success<int, string>(9);

				Result.Zip(result1, result2, result3, result4, result5, result6, result7, result8, result9)
					.AssertSuccess()
					.Should()
					.Be((1, 2, 3, 4, 5, 6, 7, 8, 9));
			}

			[Theory]
			[ResultZip9ReturnsFailureArrangement]
			public void ReturnsFailureWhenAtLeastOneFailure(Result<int, string>[] resultCollection)
				=> Result.Zip(
						resultCollection[0],
						resultCollection[1],
						resultCollection[2],
						resultCollection[3],
						resultCollection[4],
						resultCollection[5],
						resultCollection[6],
						resultCollection[7],
						resultCollection[8])
					.AssertFailure()
					.Should()
					.Match(errorCollection
						=> errorCollection.Count() == resultCollection.Count(r => !r.IsSuccess())
						   && resultCollection.Where(r => !r.IsSuccess()).Select(r => r.Failure()).WhereSome().All(errorCollection.Contains));

			#region Arrangements

			private class ResultZip9ReturnsFailureArrangement : AutoDataAttribute
			{
				public override IEnumerable<object[]> GetData(MethodInfo testMethod)
				{
					for (var i = 0; i < (1 << 9) - 1; ++i)
					{
						var result1 = Result.Create((i & 1) == 1, () => 13, () => "error 1");
						var result2 = Result.Create(((i >> 1) & 1) == 1, () => 17, () => "error 2");
						var result3 = Result.Create(((i >> 2) & 1) == 1, () => 25, () => "error 3");
						var result4 = Result.Create(((i >> 3) & 1) == 1, () => -5, () => "error 4");
						var result5 = Result.Create(((i >> 4) & 1) == 1, () => 99, () => "error 5");
						var result6 = Result.Create(((i >> 5) & 1) == 1, () => 36, () => "error 6");
						var result7 = Result.Create(((i >> 6) & 1) == 1, () => 20, () => "error 7");
						var result8 = Result.Create(((i >> 7) & 1) == 1, () => 11, () => "error 8");
						var result9 = Result.Create(((i >> 8) & 1) == 1, () => 69, () => "error 9");

						yield return new object[] { new[] { result1, result2, result3, result4, result5, result6, result7, result8, result9 } };
					}
				}
			}

			#endregion
		}
	}
}
