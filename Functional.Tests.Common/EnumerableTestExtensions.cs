namespace Functional.Tests;

public static class EnumerableTestExtensions
{
	public static IEnumerable<EnumerableType> ToIndividualEnumerableTypes(this EnumerableType enumerableTypes)
		=> new[]
		{
			EnumerableType.IEnumerable,
			EnumerableType.TaskOfIEnumerable,
			EnumerableType.TaskOfIOrderedEnumerable,
			EnumerableType.IAsyncEnumerable
		}
		.Where(type => enumerableTypes.HasFlag(type));
}
