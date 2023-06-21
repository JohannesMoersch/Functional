using System;
namespace Functional.Tests;

public static class TestEnumerableExtensions
{
	public static object ToEnumerableType<T>(this IEnumerable<T> enumerable, EnumerableType type)
		=> type switch
		{
			EnumerableType.IEnumerable => enumerable,
			EnumerableType.TaskOfIEnumerable => Task.FromResult(enumerable),
			EnumerableType.TaskOfIOrderedEnumerable => Task.FromResult(OrderedEnumerable.Create(enumerable)),
			EnumerableType.IAsyncEnumerable => AsyncEnumerable.Create(enumerable),
			_ => throw new ArgumentException("Enumerable type not valid.")
		};

	public static T? ValueIfNotNull<T>(this bool[] isNull, int index, T value)
		=> index >= isNull.Length || !isNull[index] ? value : default;
}
