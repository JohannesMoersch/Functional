using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Options
{
	public class OptionFactoryTests
	{
		[Fact]
		public Task SomeAsync()
			=> Option
				.SomeAsync(Helpers.DelayedTask(10))
				.AssertSome()
				.Should()
				.Be(10);

		[Fact]
		public void FromNullableClassHasValue()
			=> Option
				.FromNullable("abc")
				.AssertSome()
				.Should()
				.Be("abc");

		[Fact]
		public void FromNullableClassIsNull()
			=> Option
				.FromNullable((string)null)
				.AssertNone();

		[Fact]
		public void FromNullableStructHasValue()
			=> Option
				.FromNullable((int?)10)
				.AssertSome()
				.Should()
				.Be(10);

		[Fact]
		public void FromNullableStructIsNull()
			=> Option
				.FromNullable((int?)null)
				.AssertNone();

		[Fact]
		public Task FromNullableAsyncClassHasValue()
			=> Option
				.FromNullableAsync(Helpers.DelayedTask("abc"))
				.AssertSome()
				.Should()
				.Be("abc");

		[Fact]
		public Task FromNullableAsyncClassIsNull()
			=> Option
				.FromNullableAsync(Helpers.DelayedTask((string)null))
				.AssertNone();

		[Fact]
		public Task FromNullableAsyncStructHasValue()
			=> Option
				.FromNullableAsync(Helpers.DelayedTask((int?)10))
				.AssertSome()
				.Should()
				.Be(10);

		[Fact]
		public Task FromNullableAsyncStructIsNull()
			=> Option
				.FromNullableAsync(Helpers.DelayedTask((int?)null))
				.AssertNone();

		[Fact]
		public void CreateTrue()
			=> Option
				.Create(true, 10)
				.AssertSome()
				.Should()
				.Be(10);

		[Fact]
		public void CreateFalse()
			=> Option
				.Create(false, 10)
				.AssertNone();

		[Fact]
		public void CreateDelegateTrue()
			=> Option
				.Create(true, () => 10)
				.AssertSome()
				.Should()
				.Be(10);

		[Fact]
		public void CreateDelegateFalse()
			=> Option
				.Create(false, () => 10)
				.AssertNone();

		[Fact]
		public Task CreateAsyncDelegateTrue()
			=> Option
				.CreateAsync(true, () => Helpers.DelayedTask(10))
				.AssertSome()
				.Should()
				.Be(10);

		[Fact]
		public Task CreateAsyncDelegateFalse()
			=> Option
				.CreateAsync(false, () => Helpers.DelayedTask(10))
				.AssertNone();

		[Fact]
		public void Unit()
			=> Option
				.Unit()
				.AssertSome()
				.Should()
				.Be(Functional.Unit.Value);

		[Fact]
		public void WhereTrue()
			=> Option
				.Where(true)
				.AssertSome()
				.Should()
				.Be(Functional.Unit.Value);

		[Fact]
		public void WhereFalse()
			=> Option
				.Where(false)
				.AssertNone();
	}
}
