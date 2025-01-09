using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Text.Json;

namespace Functional.Tests;

public static partial class TestInput
{
	public class XunitSerializer : IXunitSerializer
	{
		public bool IsSerializable(Type type, object? value, [NotNullWhen(false)]out string? failureReason)
		{
			failureReason = null;
			return true;
		}

		public object Deserialize(Type type, string serializedValue)
			=> JsonSerializer.Deserialize(serializedValue, type) ?? throw new JsonException("Deserialized to null.");

		public string Serialize(object value)
			=> JsonSerializer.Serialize(value);
	}
}
