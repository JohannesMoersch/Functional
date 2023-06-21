using System;
using System.Reflection.Metadata;

namespace Functional.Tests;

public static class TestInput
{
	public record OneEnumerable<TOne>(EnumerableType One) : ITestInput<IEnumerable<TOne>, Task<IEnumerable<TOne>>>
	{
		public Type OneType => One.GetTypeFromEnumerableType<TOne>();

		public object? GetOne(IEnumerable<TOne> one)
			=> one.ToEnumerableType(One);

		public T? GetArgument<T>(int index, T value)
			=> value;

		public override string ToString()
			=> $"({One})";
	}

	public record TwoEnumerables<TOne, TTwo>(EnumerableType One, EnumerableType Two) : ITestInput<IEnumerable<TOne>, Task<IEnumerable<TOne>>, IEnumerable<TTwo>, Task<IEnumerable<TTwo>>>
	{
		public Type OneType => One.GetTypeFromEnumerableType<TOne>();

		public Type TwoType => Two.GetTypeFromEnumerableType<TTwo>();

		public object? GetOne(IEnumerable<TOne> one)
			=> one.ToEnumerableType(One);

		public object? GetTwo(IEnumerable<TTwo> two)
			=> two.ToEnumerableType(Two);

		public T? GetArgument<T>(int index, T value)
			=> value;

		public override string ToString()
			=> $"({One}, {Two})";
	}
}
