using System.Diagnostics.CodeAnalysis;

namespace Functional.Tests;

public static class AssertionException
{
	[DoesNotReturn]
	public static void Throw(object? expectedValue, object? actualValue)
		=> throw new XunitException($"Expected {expectedValue ?? "null"} but found {actualValue ?? "null"}.");
}
