namespace Functional;

public struct AsyncPartition<T>
{
	public IAsyncEnumerable<T> Matches { get; }

	public IAsyncEnumerable<T> NonMatches { get; }

	internal AsyncPartition(IAsyncEnumerable<T> matches, IAsyncEnumerable<T> nonMatches)
	{
		Matches = matches ?? throw new ArgumentNullException(nameof(matches));
		NonMatches = nonMatches ?? throw new ArgumentNullException(nameof(nonMatches));
	}

	public void Deconstruct(out IAsyncEnumerable<T> matches, out IAsyncEnumerable<T> nonMatches)
	{
		matches = Matches;
		nonMatches = NonMatches;
	}
}
