namespace Functional.Tests;

public interface ITestInput
{
	T? GetArgument<T>(int index, T value);
}

public interface ITestInput<TOneReference, TOneTest> : ITestInput
{
	Type OneType { get; }
	object? GetOne(TOneReference one);
}

public interface ITestInput<TOneReference, TOneTest, TTwoReference, TTwoTest> : ITestInput
{
	Type OneType { get; }
	Type TwoType { get; }
	object? GetOne(TOneReference one);
	object? GetTwo(TTwoReference two);
}

public class TestArgument<TReference>
{
	public Type Type { get; }

	private readonly Func<TReference, object?> _getter;

	public TestArgument(Type type, Func<TReference, object?> getter)
	{
		Type = type;
		_getter = getter;
	}

	public object? GetValue(TReference reference)
		=> _getter.Invoke(reference);
}