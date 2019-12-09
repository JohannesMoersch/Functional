using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Options
{
	public class OptionAsyncExtensionsTests
	{
		public class WhenOptionIsSome
		{
			private static Option<int> Value => Option.Some(10);
			private static Option<int> NoValue => Option.None<int>();

			[Fact]
			public Task Select()
				=> Value
					.MapAsync(i => Task.FromResult(i * 2))
					.AssertSome()
					.Should()
					.Be(20);

			[Fact]
			public Task BindSome()
				=> Value
					.BindAsync(i => Task.FromResult(Option.Some(i)))
					.AssertSome()
					.Should()
					.Be(10);

			[Fact]
			public Task BindNone()
				=> Value
					.BindAsync(i => Task.FromResult(Option.None<int>()))
					.AssertNone();

			[Fact]
			public Task BindOnNoneWhenSome()
				=> Value
					.BindOnNoneAsync(() => Task.FromResult(Option.Some(20)))
					.AssertSome()
					.Should()
					.Be(10);

			[Fact]
			public Task BindOnNoneWhenNone()
				=> NoValue
					.BindOnNoneAsync(() => Task.FromResult(Option.Some(20)))
					.AssertSome()
					.Should()
					.Be(20);

			[Fact]
			public Task WhereTrue()
				=> Value
					.WhereAsync(i => Task.FromResult(true))
					.AssertSome()
					.Should()
					.Be(10);

			[Fact]
			public Task WhereFalse()
				=> Value
					.WhereAsync(i => Task.FromResult(false))
					.AssertNone();

			[Fact]
			public Task ToResult()
				=> Value
					.ToResultAsync(() => Task.FromResult("abc"))
					.AssertSuccess()
					.Should()
					.Be(10);

			[Fact]
			public async Task DoWithOneParameter()
			{
				bool some = false;
				await Value.DoAsync(_ => Task.FromResult(some = true));
				some
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task DoWithTwoParameters()
			{
				bool some = false, none = false;
				await Value.DoAsync(_ => Task.FromResult(some = true), () => Task.FromResult(none = true));
				some
					.Should()
					.BeTrue();
				none
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task ApplyWithOneParameter()
			{
				bool some = false;
				await Value.ApplyAsync(_ => Task.FromResult(some = true));
				some
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task ApplyWithTwoParameters()
			{
				bool some = false, none = false;
				await Value.ApplyAsync(_ => Task.FromResult(some = true), () => Task.FromResult(none = true));
				some
					.Should()
					.BeTrue();
				none
					.Should()
					.BeFalse();
			}
		}

		public class WhenTaskOptionIsSome
		{
			private Task<Option<int>> Value => Task.FromResult(Option.Some(10));

			[Fact]
			public Task Select()
				=> Value
					.MapAsync(i => Task.FromResult(i * 2))
					.AssertSome()
					.Should()
					.Be(20);

			[Fact]
			public Task BindSome()
				=> Value
					.BindAsync(i => Task.FromResult(Option.Some(i)))
					.AssertSome()
					.Should()
					.Be(10);

			[Fact]
			public Task BindNone()
				=> Value
					.BindAsync(i => Task.FromResult(Option.None<int>()))
					.AssertNone();

			[Fact]
			public Task WhereTrue()
				=> Value
					.WhereAsync(i => Task.FromResult(true))
					.AssertSome()
					.Should()
					.Be(10);

			[Fact]
			public Task WhereFalse()
				=> Value
					.WhereAsync(i => Task.FromResult(false))
					.AssertNone();

			[Fact]
			public Task ToResult()
				=> Value
					.ToResultAsync(() => Task.FromResult("abc"))
					.AssertSuccess()
					.Should()
					.Be(10);

			[Fact]
			public async Task DoWithOneParameter()
			{
				bool some = false;
				await Value.DoAsync(_ => Task.FromResult(some = true));
				some
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task DoWithTwoParameters()
			{
				bool some = false, none = false;
				await Value.DoAsync(_ => Task.FromResult(some = true), () => Task.FromResult(none = true));
				some
					.Should()
					.BeTrue();
				none
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task ApplyWithOneParameter()
			{
				bool some = false;
				await Value.ApplyAsync(_ => Task.FromResult(some = true));
				some
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task ApplyWithTwoParameters()
			{
				bool some = false, none = false;
				await Value.ApplyAsync(_ => Task.FromResult(some = true), () => Task.FromResult(none = true));
				some
					.Should()
					.BeTrue();
				none
					.Should()
					.BeFalse();
			}
		}

		public class WhenOptionIsNone
		{
			private Option<int> Value => Option.None<int>();

			[Fact]
			public Task Select()
				=> Value
					.MapAsync(i => Task.FromResult(i * 2))
					.AssertNone();

			[Fact]
			public Task BindSome()
				=> Value
					.BindAsync(i => Task.FromResult(Option.Some(i)))
					.AssertNone();

			[Fact]
			public Task BindNone()
				=> Value
					.BindAsync(i => Task.FromResult(Option.None<int>()))
					.AssertNone();

			[Fact]
			public Task WhereTrue()
				=> Value
					.WhereAsync(i => Task.FromResult(true))
					.AssertNone();

			[Fact]
			public Task WhereFalse()
				=> Value
					.WhereAsync(i => Task.FromResult(false))
					.AssertNone();

			[Fact]
			public Task ToResult()
				=> Value
					.ToResultAsync(() => Task.FromResult("abc"))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public async Task DoWithOneParameter()
			{
				bool some = false;
				await Value.DoAsync(_ => Task.FromResult(some = true));
				some
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task DoWithTwoParameters()
			{
				bool some = false, none = false;
				await Value.DoAsync(_ => Task.FromResult(some = true), () => Task.FromResult(none = true));
				some
					.Should()
					.BeFalse();
				none
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task ApplyWithOneParameter()
			{
				bool some = false;
				await Value.ApplyAsync(_ => Task.FromResult(some = true));
				some
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task ApplyWithTwoParameters()
			{
				bool some = false, none = false;
				await Value.ApplyAsync(_ => Task.FromResult(some = true), () => Task.FromResult(none = true));
				some
					.Should()
					.BeFalse();
				none
					.Should()
					.BeTrue();
			}
		}

		public class WhenTaskOptionIsNone
		{
			private Task<Option<int>> Value => Task.FromResult(Option.None<int>());

			[Fact]
			public Task Select()
				=> Value
					.MapAsync(i => Task.FromResult(i * 2))
					.AssertNone();

			[Fact]
			public Task BindSome()
				=> Value
					.BindAsync(i => Task.FromResult(Option.Some(i)))
					.AssertNone();

			[Fact]
			public Task BindNone()
				=> Value
					.BindAsync(i => Task.FromResult(Option.None<int>()))
					.AssertNone();

			[Fact]
			public Task WhereTrue()
				=> Value
					.WhereAsync(i => Task.FromResult(true))
					.AssertNone();

			[Fact]
			public Task WhereFalse()
				=> Value
					.WhereAsync(i => Task.FromResult(false))
					.AssertNone();

			[Fact]
			public Task ToResult()
				=> Value
					.ToResultAsync(() => Task.FromResult("abc"))
					.AssertFailure()
					.Should()
					.Be("abc");

			[Fact]
			public async Task DoWithOneParameter()
			{
				bool some = false;
				await Value.DoAsync(_ => Task.FromResult(some = true));
				some
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task DoWithTwoParameters()
			{
				bool some = false, none = false;
				await Value.DoAsync(_ => Task.FromResult(some = true), () => Task.FromResult(none = true));
				some
					.Should()
					.BeFalse();
				none
					.Should()
					.BeTrue();
			}

			[Fact]
			public async Task ApplyWithOneParameter()
			{
				bool some = false;
				await Value.ApplyAsync(_ => Task.FromResult(some = true));
				some
					.Should()
					.BeFalse();
			}

			[Fact]
			public async Task ApplyWithTwoParameters()
			{
				bool some = false, none = false;
				await Value.ApplyAsync(_ => Task.FromResult(some = true), () => Task.FromResult(none = true));
				some
					.Should()
					.BeFalse();
				none
					.Should()
					.BeTrue();
			}
		}
	}
}
