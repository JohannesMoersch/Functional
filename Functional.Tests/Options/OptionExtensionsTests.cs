using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Functional.Tests.Utilities.Assertions;
using Xunit;

namespace Functional.Tests.Options
{
	public class OptionExtensionsTests
	{
		public class OrElse
		{
			public class SyncAndSync
			{
				[Fact]
				public void ShouldHaveInitialValue() => Option.Some(13).OrElse(() => Option.Some(666)).Should().HaveExpectedValue(13);

				[Fact]
				public void ShouldHaveOtherValue() => Option.None<int>().OrElse(() => Option.Some(666)).Should().HaveExpectedValue(666);

				[Fact]
				public void ShouldHaveNoValue() => Option.None<int>().OrElse(Option.None<int>).Should().NotHaveValue();
			}

			public class AsyncAndSync
			{
				[Fact]
				public async Task ShouldHaveInitialValue() => (await Task.FromResult(Option.Some(13)).OrElse(() => Option.Some(666))).Should().HaveExpectedValue(13);

				[Fact]
				public async Task ShouldHaveOtherValue() => (await Task.FromResult(Option.None<int>()).OrElse(() => Option.Some(666))).Should().HaveExpectedValue(666);

				[Fact]
				public async Task ShouldHaveNoValue() => (await Task.FromResult(Option.None<int>()).OrElse(Option.None<int>)).Should().NotHaveValue();
			}

			public class SyncAndAsync
			{
				[Fact]
				public async Task ShouldHaveInitialValue() => (await Option.Some(13).OrElseAsync(() => Task.FromResult(Option.Some(666)))).Should().HaveExpectedValue(13);

				[Fact]
				public async Task ShouldHaveOtherValue() => (await Option.None<int>().OrElseAsync(() => Task.FromResult(Option.Some(666)))).Should().HaveExpectedValue(666);

				[Fact]
				public async Task ShouldHaveNoValue() => (await Option.None<int>().OrElseAsync(() => Task.FromResult(Option.None<int>()))).Should().NotHaveValue();
			}

			public class AsyncAndAsync
			{
				[Fact]
				public async Task ShouldHaveInitialValue() => (await Task.FromResult(Option.Some(13)).OrElseAsync(() => Task.FromResult(Option.Some(666)))).Should().HaveExpectedValue(13);

				[Fact]
				public async Task ShouldHaveOtherValue() => (await Task.FromResult(Option.None<int>()).OrElseAsync(() => Task.FromResult(Option.Some(666)))).Should().HaveExpectedValue(666);

				[Fact]
				public async Task ShouldHaveNoValue() => (await Task.FromResult(Option.None<int>()).OrElseAsync(() => Task.FromResult(Option.None<int>()))).Should().NotHaveValue();
			}
		}
	}
}
