namespace Functional.Tests;

public static partial class TestInputExtensions
{
	private static Task<Option<IEnumerable<T>>> ConvertToEnumerable<T>(IEnumerable<T> source)
		=> Task.FromResult(Option.FromNullable(source));

	private static async Task<Option<IEnumerable<T>>> ConvertToEnumerable<T>(Task<IEnumerable<T>> source)
		=> Option.FromNullable(await source);

	private static async Task<Option<IEnumerable<T>>> ConvertToEnumerable<T>(Task<IOrderedEnumerable<T>> source)
		=> Option.FromNullable<IEnumerable<T>>(await source);

	private static async Task<Option<IEnumerable<T>>> ConvertToEnumerable<T>(IAsyncEnumerable<T> source)
	{
		await using var enumerator = source.GetAsyncEnumerator();

		var results = new List<T>();
		while (await enumerator.MoveNextAsync())
			results.Add(enumerator.Current);

		return Option.FromNullable<IEnumerable<T>>(results);
	}
}
