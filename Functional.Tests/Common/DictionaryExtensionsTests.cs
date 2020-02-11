using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

		[Fact]
		public void TryRemoveValueWhenKeyPresentAndIntegerValueNotNull()
		{
			var dictionary = new ConcurrentDictionary<int, int?>();
			dictionary.TryAdd(1, 1);
			
			dictionary
				.TryRemove(1)
				.AssertSome()
				.Should()
				.Be(1);

			dictionary.ContainsKey(1).Should().BeFalse();
		}

		[Fact]
		public void TryRemoveValueWhenKeyPresentAndIntegerValueNull()
		{
			var dictionary = new ConcurrentDictionary<int, int?>();
			dictionary.TryAdd(1, null);

			dictionary
				.TryRemove(1)
				.AssertNone();

			dictionary.ContainsKey(1).Should().BeFalse();
		}
	}

	public class One
	{
		[Fact]
		public void TestA() => Thread.Sleep(1000);

		[Fact]
		public void TestB() => Thread.Sleep(1000);
	}

	public class Two
	{
		[Fact]
		public void TestA() => Thread.Sleep(1000);

		[Fact]
		public void TestB() => Thread.Sleep(1000);
	}

	public class Three
	{
		[Fact]
		public void TestA() => Thread.Sleep(1000);

		[Fact]
		public void TestB() => Thread.Sleep(1000);
	}

	public class Four
	{
		[Fact]
		public void TestA() => Thread.Sleep(1000);

		[Fact]
		public void TestB() => Thread.Sleep(1000);
	}
}
