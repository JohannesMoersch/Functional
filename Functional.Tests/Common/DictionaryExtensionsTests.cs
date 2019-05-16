using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Common
{
	public class DictionaryExtensionsTests
	{
		[Fact]
		public void TryGetValueWhenKeyPresentAndStringValueNotNull()
			=> new Dictionary<int, string>() { { 1, "1" } }
				.TryGetValue(1)
				.AssertSome()
				.Should()
				.Be("1");

		[Fact]
		public void TryGetValueWhenKeyPresentAndStringValueNull()
			=> new Dictionary<int, string>() { { 1, null } }
				.TryGetValue(1)
				.AssertNone();

		[Fact]
		public void TryGetValueWhenKeyNotPresent()
			=> new Dictionary<int, string>()
				.TryGetValue(1)
				.AssertNone();

		[Fact]
		public void TryGetValueWhenKeyPresentAndIntegerValueNotNull()
			=> new Dictionary<int, int?>() { { 1, 1 } }
				.TryGetValue(1)
				.AssertSome()
				.Should()
				.Be(1);

		[Fact]
		public void TryGetValueWhenKeyPresentAndIntegerValueNull()
			=> new Dictionary<int, int?>() { { 1, null } }
				.TryGetValue(1)
				.AssertNone();
	}
}
