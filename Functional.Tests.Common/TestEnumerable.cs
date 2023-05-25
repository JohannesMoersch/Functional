namespace Functional.Tests;

public record TestEnumerable<T>(EnumerableType Type, object? Enumerable, IReadOnlyList<T> Reference);
