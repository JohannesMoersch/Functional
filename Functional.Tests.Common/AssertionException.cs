using System.Diagnostics.CodeAnalysis;

namespace Functional.Tests;

public static class AssertionException
{
	private static readonly Type _exceptionType = Assembly.Load(new AssemblyName("xunit.assert")).GetType("Xunit.Sdk.XunitException") ?? throw new Exception("Couldn't load xunit exception type.");

	[DoesNotReturn]
	public static void Throw(object? expectedValue, object? actualValue)
		=> throw Activator.CreateInstance(_exceptionType, $"Expected {expectedValue ?? "null"} but found {actualValue ?? "null"}.") as Exception ?? new Exception("Failed to create xunit exception.");
}
