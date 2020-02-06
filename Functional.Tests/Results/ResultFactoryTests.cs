using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Results
{
	public class ResultFactoryTests
	{
		private static readonly bool _true = true;

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
	}
}
