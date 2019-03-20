using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Options
{
	public class OptionSerializationTests
	{
		[Fact]
		public void SomeCanSerializeAndDeserialize()
		{
			var value = Option.Some("Some Test Value");

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void NoneCanSerializeAndDeserialize()
		{
			var value = Option.None<string>();

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void SomeInterfaceCanSerializeAndDeserialize()
		{
			var value = Option.Some<ITestInterface>(new TestImplementation());

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		public interface ITestInterface { }

		[Serializable]
		public class TestImplementation : ITestInterface
		{
			public override int GetHashCode() => 0;

			public override bool Equals(object obj) => obj is TestImplementation;
		}
	}
}
