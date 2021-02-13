using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Options
{
	public class OptionOfStringExtensionsTests
	{
		public class Sync
		{
			[Theory]
			[InlineData(null)]
			[InlineData("")]
			public void ReturnsNoneForEmptyString(string value)
				=> Option.FromNullable(value)
					.WhereNonEmpty()
					.AssertNone();

			[Theory, AutoData]
			public void ReturnsSomeForNonEmptyString(string value)
				=> Option.FromNullable(value)
					.WhereNonEmpty()
					.AssertSome()
					.Should()
					.Be(value);

			[Theory]
			[InlineData(null)]
			[InlineData("")]
			[InlineData(" ")]
			[InlineData("     ")]
			[InlineData("\t")]
			[InlineData("\n")]
			public void ReturnsNoneForWhiteSpaceString(string value)
				=> Option.FromNullable(value)
					.WhereNonWhiteSpace()
					.AssertNone();

			[Theory, AutoData]
			public void ReturnsSomeForNonWhiteSpaceString(string value)
				=> Option.FromNullable(value)
					.WhereNonEmpty()
					.AssertSome()
					.Should()
					.Be(value);
		}

		public class Async
		{
			[Theory]
			[InlineData(null)]
			[InlineData("")]
			public async Task ReturnsNoneForEmptyString(string value)
				=> await Task.FromResult(Option.FromNullable(value))
					.WhereNonEmpty()
					.AssertNone();

			[Theory, AutoData]
			public async Task ReturnsSomeForNonEmptyString(string value)
				=> await Task.FromResult(Option.FromNullable(value))
					.WhereNonEmpty()
					.AssertSome()
					.Should()
					.Be(value);

			[Theory]
			[InlineData(null)]
			[InlineData("")]
			[InlineData(" ")]
			[InlineData("     ")]
			[InlineData("\t")]
			[InlineData("\n")]
			public async Task ReturnsNoneForWhiteSpaceString(string value)
				=> await Task.FromResult(Option.FromNullable(value))
					.WhereNonWhiteSpace()
					.AssertNone();

			[Theory, AutoData]
			public async Task ReturnsSomeForNonWhiteSpaceString(string value)
				=> await Task.FromResult(Option.FromNullable(value))
					.WhereNonEmpty()
					.AssertSome()
					.Should()
					.Be(value);
		}
	}
}
