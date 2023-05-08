namespace Functional;

public static partial class FunctionalEnumerableExtensions
{
#pragma warning disable CS8603 // Possible null reference return.
	public static IEnumerable<T> WhereSome<T>(this IEnumerable<Option<T>> source)
		where T : notnull
		=> source
			.Where(option => option.Match(_ => true, () => false))
			.Select(option => option.Match(o => o, () => default));
#pragma warning restore CS8603 // Possible null reference return.

#pragma warning disable CS8603 // Possible null reference return.
	public static async Task<IEnumerable<T>> WhereSome<T>(this Task<IEnumerable<Option<T>>> source)
		where T : notnull
		=> (await source)
			.Where(option => option.Match(_ => true, () => false))
			.Select(option => option.Match(o => o, () => default));
#pragma warning restore CS8603 // Possible null reference return.

#pragma warning disable CS8603 // Possible null reference return.
	public static IAsyncEnumerable<T> WhereSome<T>(this IAsyncEnumerable<Option<T>> source)
		where T : notnull
		=> source
			.Where(option => option.Match(_ => true, () => false))
			.Select(option => option.Match(o => o, () => default));
#pragma warning restore CS8603 // Possible null reference return.
}
