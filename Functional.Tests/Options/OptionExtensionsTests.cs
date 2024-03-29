﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Options
{
	public class OptionExtensionsTests
	{
		public class WhenOptionIsSome
		{
			private const int IntValue = 10;
			private static Option<int> Value => Option.Some(IntValue);

			[Fact]
			public void HasValue()
				=> Value
					.HasValue()
					.Should()
					.BeTrue();

			[Fact]
			public void Select()
				=> Value
					.Map(i => i * 2)
					.AssertSome()
					.Should()
					.Be(20);

			[Fact]
			public void BindSome()
				=> Value
					.Bind(i => Option.Some(i))
					.AssertSome()
					.Should()
					.Be(IntValue);

			[Fact]
			public void BindNone()
				=> Value
					.Bind(i => Option.None<int>())
					.AssertNone();

			[Fact]
			public void ValueOrDefault()
				=> Value
					.ValueOrDefault(5)
					.Should()
					.Be(10);

			[Fact]
			public void ValueOrDefaultFactory()
				=> Value
					.ValueOrDefault(() => 5)
					.Should()
					.Be(10);

			[Fact]
			public void BindOnNone()
				=> Value
					.BindOnNone(() => Option.Some(20))
					.AssertSome()
					.Should()
					.Be(IntValue);

			[Fact]
			public void ValueOrEmptyForCollection()
				=> Option.Some(Enumerable.Range(1, 10))
					.ValueOrEmpty()
					.Should()
					.BeEquivalentTo(Enumerable.Range(1, 10));
			
			[Fact]
			public void ValueOrEmptyForEmptyCollection()
				=> Option.Some(Enumerable.Empty<int>())
					.ValueOrEmpty()
					.Should()
					.BeEmpty();

			[Fact]
			public void OfTypeMatching()
				=> Option
					.Some<object>(10)
					.OfType<int>()
					.AssertSome()
					.Should()
					.Be(10);

			[Fact]
			public void OfTypeNotMatching()
				=> Option
					.Some<object>(10)
					.OfType<float>()
					.AssertNone();

			[Fact]
			public void WhereTrue()
				=> Value
					.Where(i => true)
					.AssertSome()
					.Should()
					.Be(10);

			[Fact]
			public void WhereFalse()
				=> Value
					.Where(i => false)
					.AssertNone();

			[Fact]
			public void ToNullable()
				=> Value
					.ToNullable()
					.Should()
					.Be(10);

			[Fact]
			public void ToResult()
				=> Value
					.ToResult(() => "abc")
					.AssertSuccess()
					.Should()
					.Be(10);

			[Fact]
			public void DoWithOneParameter()
			{
				bool some = false;
				Value.Do(_ => some = true);
				some
					.Should()
					.BeTrue();
			}

			[Fact]
			public void DoWithTwoParameters()
			{
				bool some = false, none = false;
				Value.Do(_ => some = true, () => none = true);
				some
					.Should()
					.BeTrue();
				none
					.Should()
					.BeFalse();
			}

			[Fact]
			public void DoOnNone()
			{
				bool none = false;
				Value.DoOnNone(() => none = true);
				none
					.Should()
					.BeFalse();
			}

			[Fact]
			public void Apply()
			{
				bool some = false, none = false;
				Value.Apply(_ => some = true, () => none = true);
				some
					.Should()
					.BeTrue();
				none
					.Should()
					.BeFalse();
			}

			[Fact]
			public void ToEnumerableProducesCollectionWithSingleExpectedElement()
				=> Value.ToEnumerable().Should().NotBeEmpty().And.HaveElementAt(0, IntValue);

			[Fact]
			public void ToArrayProducesCollectionWithSingleExpectedElement()
				=> Value.ToArray().Should().NotBeEmpty().And.HaveElementAt(0, IntValue);

			[Fact]
			public void DoesNotThrow()
				=> Value.ThrowOnNone(() => new InvalidOperationException());
		}

		public class WhenTaskOptionIsSome
		{
			private const int IntValue = 10;
			private Task<Option<int>> Value => Task.FromResult(Option.Some(IntValue));

			[Fact]
			public Task HasValue()
				=> Value
					.HasValue()
					.Should()
					.BeTrue();

			[Fact]
			public Task Select()
				=> Value
					.Map(i => i * 2)
					.AssertSome()
					.Should()
					.Be(20);

			[Fact]
			public Task BindSome()
				=> Value
					.Bind(i => Option.Some(i))
					.AssertSome()
					.Should()
					.Be(IntValue);

			[Fact]
			public Task BindNone()
				=> Value
					.Bind(i => Option.None<int>())
					.AssertNone();

			[Fact]
			public Task ValueOrDefault()
				=> Value
					.ValueOrDefault(5)
					.Should()
					.Be(10);

			[Fact]
			public Task ValueOrDefaultFactory()
				=> Value
					.ValueOrDefault(() => 5)
					.Should()
					.Be(10);

			[Fact]
			public void ValueOrEmpty()
				=> Option.None<IEnumerable<int>>()
					.ValueOrEmpty()
					.Should()
					.BeEmpty();

			[Fact]
			public Task OfTypeMatching()
				=> Task
					.FromResult(Option
						.Some<object>(10)
					)
					.OfType<int>()
					.AssertSome()
					.Should()
					.Be(10);

			[Fact]
			public Task OfTypeNotMatching()
				=> Task
					.FromResult(Option
						.Some<object>(10)
					)
					.OfType<float>()
					.AssertNone();

			[Fact]
			public Task WhereTrue()
				=> Value
					.Where(i => true)
					.AssertSome()
					.Should()
					.Be(IntValue);

			[Fact]
			public Task WhereFalse()
				=> Value
					.Where(i => false)
					.AssertNone();

			[Fact]
			public Task ToNullable()
				=> Value
					.ToNullable()
					.Should()
					.Be(IntValue);

			[Fact]
			public Task ToResult()
				=> Value
					.ToResult(() => "abc")
					.AssertSuccess()
					.Should()
					.Be(IntValue);

			[Fact]
			public async Task DoWithOneParameter()
			{
				bool some = false;
				await Value.Do(_ => some = true);
				some
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task DoWithTwoParameters()
			{
				bool some = false, none = false;
				await Value.Do(_ => some = true, () => none = true);
				some
					.Should()
					.BeTrue();
				none
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task DoOnNone()
			{
				bool none = false;
				await Value.DoOnNone(() => none = true);
				none
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task Apply()
			{
				bool some = false, none = false;
				await Value.Apply(_ => some = true, () => none = true);
				some
					.Should()
					.BeTrue();
				none
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task ToEnumerableProducesCollectionWithSingleExpectedElement()
				=> (await Value.ToEnumerable()).Should().NotBeEmpty().And.HaveElementAt(0, IntValue);

			[Fact]
			public async Task ToArrayProducesCollectionWithSingleExpectedElement()
				=> (await Value.ToArray()).Should().NotBeEmpty().And.HaveElementAt(0, IntValue);

			[Fact]
			public async Task DoesNotThrow()
				=> await Value.ThrowOnNone(() => new InvalidOperationException());
		}

		public class WhenOptionIsNone
		{
			private Option<int> Value => Option.None<int>();

			[Fact]
			public void HasValue()
				=> Value
					.HasValue()
					.Should()
					.BeFalse();

			[Fact]
			public void Select()
				=> Value
					.Map(i => i * 2)
					.AssertNone();

			[Fact]
			public void BindSome()
				=> Value
					.Bind(i => Option.Some(i))
					.AssertNone();

			[Fact]
			public void BindNone()
				=> Value
					.Bind(i => Option.None<int>())
					.AssertNone();

			[Fact]
			public void ValueOrDefault()
				=> Value
					.ValueOrDefault(5)
					.Should()
					.Be(5);

			[Fact]
			public void ValueOrDefaultFactory()
				=> Value
					.ValueOrDefault(() => 5)
					.Should()
					.Be(5);

			[Fact]
			public void BindOnNone()
				=> Value
					.BindOnNone(() => Option.Some(20))
					.AssertSome()
					.Should()
					.Be(20);

			[Fact]
			public void OfTypeMatching()
				=> Option
					.None<object>()
					.OfType<int>()
					.AssertNone();

			[Fact]
			public void OfTypeNotMatching()
				=> Option
					.None<object>()
					.OfType<float>()
					.AssertNone();

			[Fact]
			public void WhereTrue()
				=> Value
					.Where(i => true)
					.AssertNone();

			[Fact]
			public void WhereFalse()
				=> Value
					.Where(i => false)
					.AssertNone();

			[Fact]
			public void ToNullable()
				=> Value
					.ToNullable()
					.Should()
					.BeNull();

			[Fact]
			public void ToResult()
				=> Value
					.ToResult(() => "abc")
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public void DoWithOneParameter()
			{
				bool some = false;
				Value.Do(_ => some = true);
				some
					.Should()
					.BeFalse();
			}

			[Fact]
			public void DoWithTwoParameters()
			{
				bool some = false, none = false;
				Value.Do(_ => some = true, () => none = true);
				some
					.Should()
					.BeFalse();
				none
					.Should()
					.BeTrue();
			}

			[Fact]
			public void DoOnNone()
			{
				bool none = false;
				Value.DoOnNone(() => none = true);
				none
					.Should()
					.BeTrue();
			}

			[Fact]
			public void Apply()
			{
				bool some = false, none = false;
				Value.Apply(_ => some = true, () => none = true);
				some
					.Should()
					.BeFalse();
				none
					.Should()
					.BeTrue();
			}

			[Fact]
			public void ToEnumerableProducesEmptyCollection()
				=> Value.ToEnumerable().Should().BeEmpty();

			[Fact]
			public void ToArrayProducesEmptyCollection()
				=> Value.ToArray().Should().BeEmpty();

			[Fact]
			public void Throws()
			{
				const string ERROR_MESSAGE = "error";
				try
				{
					Value.ThrowOnNone(() => new InvalidOperationException(ERROR_MESSAGE));
					throw new Exception("Expected to throw 'InvalidOperationException'");
				}
				catch (InvalidOperationException e)
				{
					e.Message.Should().Be(ERROR_MESSAGE);
				}
			}
		}

		public class WhenTaskOptionIsNone
		{
			private Task<Option<int>> Value => Task.FromResult(Option.None<int>());

			[Fact]
			public Task HasValue()
				=> Value
					.HasValue()
					.Should()
					.BeFalse();

			[Fact]
			public Task Select()
				=> Value
					.Map(i => i * 2)
					.AssertNone();

			[Fact]
			public Task BindSome()
				=> Value
					.Bind(i => Option.Some(i))
					.AssertNone();

			[Fact]
			public Task BindNone()
				=> Value
					.Bind(i => Option.None<int>())
					.AssertNone();

			[Fact]
			public Task ValueOrDefault()
				=> Value
					.ValueOrDefault(5)
					.Should()
					.Be(5);

			[Fact]
			public Task ValueOrDefaultFactory()
				=> Value
					.ValueOrDefault(() => 5)
					.Should()
					.Be(5);

			[Fact]
			public Task OfTypeMatching()
				=> Task
					.FromResult(Option
						.None<object>()
					)
					.OfType<int>()
					.AssertNone();

			[Fact]
			public Task OfTypeNotMatching()
				=> Task
					.FromResult(Option
						.None<object>()
					)
					.OfType<float>()
					.AssertNone();

			[Fact]
			public Task WhereTrue()
				=> Value
					.Where(i => true)
					.AssertNone();

			[Fact]
			public Task WhereFalse()
				=> Value
					.Where(i => false)
					.AssertNone();

			[Fact]
			public Task ToNullable()
				=> Value
					.ToNullable()
					.Should()
					.BeNull();

			[Fact]
			public Task ToResult()
				=> Value
					.ToResult(() => "abc")
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public async Task DoWithOneParameter()
			{
				bool some = false;
				await Value.Do(_ => some = true);
				some
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task DoWithTwoParameters()
			{
				bool some = false, none = false;
				await Value.Do(_ => some = true, () => none = true);
				some
					.Should()
					.BeFalse();
				none
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task DoOnNone()
			{
				bool none = false;
				await Value.DoOnNone(() => none = true);
				none
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task Apply()
			{
				bool some = false, none = false;
				await Value.Apply(_ => some = true, () => none = true);
				some
					.Should()
					.BeFalse();
				none
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task ToEnumerableProducesEmptyCollection()
				=> (await Value.ToEnumerable()).Should().BeEmpty();

			[Fact]
			public async Task ToArrayProducesEmptyCollection()
				=> (await Value.ToArray()).Should().BeEmpty();

			[Fact]
			public async Task Throws()
			{
				const string ERROR_MESSAGE = "error";
				try
				{
					await Value.ThrowOnNone(() => new InvalidOperationException(ERROR_MESSAGE));
					throw new Exception("Expected to throw 'InvalidOperationException'");
				}
				catch (InvalidOperationException e)
				{
					e.Message.Should().Be(ERROR_MESSAGE);
				}
			}
		}
	}
}
