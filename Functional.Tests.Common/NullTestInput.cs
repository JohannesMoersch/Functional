using System;
using static Functional.PartialOption;

namespace Functional.Tests;

public static class NullTestInput
{
	public record OneEnumerable<TOne>(EnumerableType One, bool[] IsNull) : ITestInput<IEnumerable<TOne>, Task<IEnumerable<TOne>>>
	{
		public Type OneType => One.GetTypeFromEnumerableType<TOne>();

		public object? GetOne(IEnumerable<TOne> one)
			=> GetArgument(0, one.ToEnumerableType(One));

		public T? GetArgument<T>(int index, T value)
			=> IsNull.ValueIfNotNull(index, value);

		public override string ToString()
			=> $"({IsNull.ValueIfNotNull<object>(0, One) ?? $"{One}:null"})";
	}

	public record TwoEnumerables<TOne, TTwo>(EnumerableType One, EnumerableType Two, bool[] IsNull) : ITestInput<IEnumerable<TOne>, Task<IEnumerable<TOne>>, IEnumerable<TTwo>, Task<IEnumerable<TTwo>>>
	{
		public Type OneType => One.GetTypeFromEnumerableType<TOne>();

		public Type TwoType => Two.GetTypeFromEnumerableType<TTwo>();

		public object? GetOne(IEnumerable<TOne> one)
			=> GetArgument(0, one.ToEnumerableType(One));

		public object? GetTwo(IEnumerable<TTwo> two)
			=> GetArgument(1, two.ToEnumerableType(Two));

		public T? GetArgument<T>(int index, T value)
			=> IsNull.ValueIfNotNull(index, value);

		public override string ToString()
			=> $"({IsNull.ValueIfNotNull<object>(0, One) ?? $"{One}:null"}, {IsNull.ValueIfNotNull<object>(1, Two) ?? $"{Two}:null"})";
	}
}
