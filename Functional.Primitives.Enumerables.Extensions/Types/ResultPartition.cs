namespace Functional;

public readonly struct ResultPartition<TSuccess, TFailure>
	where TSuccess : notnull
	where TFailure : notnull
{
	internal ResultPartition(IEnumerable<TSuccess> successes, IEnumerable<TFailure> failures)
	{
		Successes = successes ?? throw new ArgumentNullException(nameof(successes));
		Failures = failures ?? throw new ArgumentNullException(nameof(failures));
	}

	public IEnumerable<TSuccess> Successes { get; }
	public IEnumerable<TFailure> Failures { get; }

	public void Deconstruct(out IEnumerable<TSuccess> successes, out IEnumerable<TFailure> failures)
	{
		successes = Successes;
		failures = Failures;
	}
}