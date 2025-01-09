using System;
using System.Threading.Tasks;
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
			public void ReturnsNoneForEmptyString(string? value)
				=> Option.FromNullable(value)
					.WhereNotEmpty()
					.AssertNone();

			[Theory]
			[InlineData("value")]
			public void ReturnsSomeForNonEmptyString(string value)
				=> Option.Some(value)
					.WhereNotEmpty()
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
			public void ReturnsNoneForWhiteSpaceString(string? value)
				=> Option.FromNullable(value)
					.WhereNotWhiteSpace()
					.AssertNone();

			[Theory]
			[InlineData("value")]
			public void ReturnsSomeForNonWhiteSpaceString(string value)
				=> Option.Some(value)
					.WhereNotEmpty()
					.AssertSome()
					.Should()
					.Be(value);
		}

		public class Async
		{
			[Theory]
			[InlineData(null)]
			[InlineData("")]
			public async Task ReturnsNoneForEmptyString(string? value)
				=> await Task.FromResult(Option.FromNullable(value))
					.WhereNotEmpty()
					.AssertNone();

			[Theory]
			[InlineData("value")]
			public async Task ReturnsSomeForNonEmptyString(string value)
				=> await Task.FromResult(Option.Some(value))
					.WhereNotEmpty()
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
			public async Task ReturnsNoneForWhiteSpaceString(string? value)
				=> await Task.FromResult(Option.FromNullable(value))
					.WhereNotWhiteSpace()
					.AssertNone();

			[Theory]
			[InlineData("value")]
			public async Task ReturnsSomeForNonWhiteSpaceString(string value)
				=> await Task.FromResult(Option.Some(value))
					.WhereNotEmpty()
					.AssertSome()
					.Should()
					.Be(value);
		}
	}
}
