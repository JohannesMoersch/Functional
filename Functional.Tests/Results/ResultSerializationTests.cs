using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Results
{
	public class ResultSerializationTests
	{
		[Fact]
		public void SuccessCanSerializeAndDeserialize()
		{
			var value = Result.Success<string, string>("Some Test Value");

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}

		[Fact]
		public void FailureCanSerializeAndDeserialize()
		{
			var value = Result.Failure<string, string>("Some Test Value");

			SerializationUtility
				.CloneViaSerialization(value)
				.Should()
				.BeEquivalentTo(value);
		}
	}
}
