namespace Functional;

internal class EnumerableToAsyncEnumerable<TSource> : IAsyncEnumerable<TSource>
{
	private readonly IEnumerable<TSource> _source;

	public EnumerableToAsyncEnumerable(IEnumerable<TSource> source) 
		=> _source = source;

	public IAsyncEnumerator<TSource> GetAsyncEnumerator(CancellationToken cancellationToken = default)
		=> new Enumerator(_source.GetEnumerator(), cancellationToken);

	private class Enumerator : IAsyncEnumerator<TSource>
	{
		private readonly IEnumerator<TSource> _enumerator;
		private readonly CancellationToken _cancellationToken;

		public TSource Current => _enumerator.Current;

		public Enumerator(IEnumerator<TSource> enumerator, CancellationToken cancellationToken)
		{
			_enumerator = enumerator;
			_cancellationToken = cancellationToken;
		}

		public ValueTask DisposeAsync()
		{
			_enumerator.Dispose();

			return ValueTask.CompletedTask;
		}

		public ValueTask<bool> MoveNextAsync()
		{
			_cancellationToken.ThrowIfCancellationRequested();

			return ValueTask.FromResult(_enumerator.MoveNext());
		}
	}
}
