using System;
using System.Threading.Tasks;
using FluentAssertions;
using Functional;
using Xunit;

namespace Functional.Tests.Enumerables
{
	public class WhereSomeExtensionsTests
	{
		private readonly Option<int>[] AllSome = new[] {
			Option.Some(1),
			Option.Some(2),
			Option.Some(3),
		};

		private readonly Option<int>[] NoneTwoThree = new[] {
			Option.None<int>(),
			Option.Some(2),
			Option.Some(3),
		};

		private readonly Option<int>[] NoneTwoNone = new[] {
			Option.None<int>(),
			Option.Some(2),
			Option.None<int>(),
		};

		private readonly Option<int>[] AllNone = new[] {
			Option.None<int>(),
			Option.None<int>(),
			Option.None<int>(),
		};

		[Fact]
		public void EnumerableWhereAllSome()
			=> AllSome
			.WhereSome()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public void EnumerableWhereSomeAreNone()
			=> NoneTwoNone
			.WhereSome()
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public void EnumerableWhereAllAreNone()
			=> AllNone
			.WhereSome()
			.Should()
			.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public Task TaskOfEnumerableWhereAllSome()
			=> AllSome
			.AsAsyncEnumerable()
			.WhereSome()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task TaskOfEnumerableWhereSomeAreNone()
			=> NoneTwoNone
			.AsAsyncEnumerable()
			.WhereSome()
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public Task TaskOfEnumerableWhereAllAreNone()
			=> AllNone
			.AsAsyncEnumerable()
			.WhereSome()
			.Should()
			.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public void EnumerableWhereAllSomeWithPredicate()
			=> AllSome
			.WhereSome(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public void EnumerableWhereSomeAreNoneWithPredicate()
			=> NoneTwoThree
			.WhereSome(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public void EnumerableWhereAllAreNoneWithPredicate()
			=> AllNone
			.WhereSome(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public Task TaskOfEnumerableWhereAllSomeWithPredicate()
			=> AllSome
			.AsAsyncEnumerable()
			.WhereSome(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public Task TaskOfEnumerableWhereSomeAreNoneWithPredicate()
			=> NoneTwoThree
			.AsAsyncEnumerable()
			.WhereSome(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public Task TaskOfEnumerableWhereAllAreNoneWithPredicate()
			=> AllNone
			.AsAsyncEnumerable()
			.WhereSome(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(Array.Empty<int>());
	}

	public class WhereSuccessExtensionsTests
	{
		private readonly Result<int, Unit>[] AllSuccess = new[] {
			Result.Success<int, Unit>(1),
			Result.Success<int, Unit>(2),
			Result.Success<int, Unit>(3),
		};

		private readonly Result<int, Unit>[] FailTwoThree = new[] {
			Result.Failure<int, Unit>(Unit.Value),
			Result.Success<int, Unit>(2),
			Result.Success<int, Unit>(3),
		};

		private readonly Result<int, Unit>[] FailTwoFail = new[] {
			Result.Failure<int, Unit>(Unit.Value),
			Result.Success<int, Unit>(2),
			Result.Failure<int, Unit>(Unit.Value),
		};

		private readonly Result<int, Unit>[] AllFail = new[] {
			Result.Failure<int, Unit>(Unit.Value),
			Result.Failure<int,Unit>(Unit.Value),
			Result.Failure <int,Unit>(Unit.Value),
		};

		[Fact]
		public void EnumerableWhereAllSuccess()
			=> AllSuccess
			.WhereSuccess()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public void EnumerableWhereSomeAreFailure()
			=> FailTwoFail
			.WhereSuccess()
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public void EnumerableWhereAllAreFailure()
			=> AllFail
			.WhereSuccess()
			.Should()
			.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public Task TaskOfEnumerableWhereAllSuccess()
			=> AllSuccess
			.AsAsyncEnumerable()
			.WhereSuccess()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task TaskOfEnumerableWhereSomeAreFailure()
			=> FailTwoFail
			.AsAsyncEnumerable()
			.WhereSuccess()
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public Task TaskOfEnumerableWhereAllAreFailure()
			=> AllFail
			.AsAsyncEnumerable()
			.WhereSuccess()
			.Should()
			.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public void EnumerableWhereAllSuccessWithPredicate()
			=> AllSuccess
			.WhereSuccess(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public void EnumerableWhereSomeAreFailureWithPredicate()
			=> FailTwoThree
			.WhereSuccess(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public void EnumerableWhereAllAreFailureWithPredicate()
			=> AllFail
			.WhereSuccess(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public Task TaskOfEnumerableWhereAllSuccessWithPredicate()
			=> AllSuccess
			.AsAsyncEnumerable()
			.WhereSuccess(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public Task TaskOfEnumerableWhereSomeAreFailureWithPredicate()
			=> FailTwoThree
			.AsAsyncEnumerable()
			.WhereSuccess(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public Task TaskOfEnumerableWhereAllAreFailureWithPredicate()
			=> AllFail
			.AsAsyncEnumerable()
			.WhereSuccess(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(Array.Empty<int>());
	}

	public class WhereFailureExtensionsTests
	{
		private readonly Result<Unit, int>[] AllSuccess = new[] {
			Result.Success<Unit, int>(Unit.Value),
			Result.Success<Unit, int>(Unit.Value),
			Result.Success<Unit, int>(Unit.Value),
		};

		private readonly Result<Unit, int>[] SuccessTwoThree = new[] {
			Result.Success<Unit, int>(Unit.Value),
			Result.Failure<Unit, int>(2),
			Result.Failure<Unit, int>(3),
		};

		private readonly Result<Unit, int>[] SuccessTwoSuccess = new[] {
			Result.Success<Unit, int>(Unit.Value),
			Result.Failure<Unit, int>(2),
			Result.Success<Unit, int>(Unit.Value),
		};

		private readonly Result<Unit, int>[] AllFail = new[] {
			Result.Failure<Unit, int>(1),
			Result.Failure<Unit, int>(2),
			Result.Failure <Unit, int>(3),
		};

		[Fact]
		public void EnumerableWhereAllSuccess()
			=> AllSuccess
			.WhereFailure()
			.Should()
			.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public void EnumerableWhereSomeAreFailure()
			=> SuccessTwoSuccess
			.WhereFailure()
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public void EnumerableWhereAllAreFailure()
			=> AllFail
			.WhereFailure()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public Task TaskOfEnumerableWhereAllSuccess()
			=> AllSuccess
			.AsAsyncEnumerable()
			.WhereFailure()
			.Should()
			.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public Task TaskOfEnumerableWhereSomeAreFailure()
			=> SuccessTwoSuccess
			.AsAsyncEnumerable()
			.WhereFailure()
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public Task TaskOfEnumerableWhereAllAreFailure()
			=> AllFail
			.AsAsyncEnumerable()
			.WhereFailure()
			.Should()
			.BeEquivalentTo(new[] { 1, 2, 3 });

		[Fact]
		public void EnumerableWhereAllSuccessWithPredicate()
			=> AllSuccess
			.WhereFailure(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public void EnumerableWhereSomeAreFailureWithPredicate()
			=> SuccessTwoThree
			.WhereFailure(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public void EnumerableWhereAllAreFailureWithPredicate()
			=> AllFail
			.WhereFailure(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public Task TaskOfEnumerableWhereAllSuccessWithPredicate()
			=> AllSuccess
			.AsAsyncEnumerable()
			.WhereFailure(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(Array.Empty<int>());

		[Fact]
		public Task TaskOfEnumerableWhereSomeAreFailureWithPredicate()
			=> SuccessTwoThree
			.AsAsyncEnumerable()
			.WhereFailure(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(new[] { 2 });

		[Fact]
		public Task TaskOfEnumerableWhereAllAreFailureWithPredicate()
			=> AllFail
			.AsAsyncEnumerable()
			.WhereFailure(i => i % 2 == 0)
			.Should()
			.BeEquivalentTo(new[] { 2 });
	}
}
