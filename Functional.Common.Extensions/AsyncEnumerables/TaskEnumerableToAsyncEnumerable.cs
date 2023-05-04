namespace Functional;

internal class TaskEnumerableToAsyncEnumerable<TSource> : IAsyncEnumerable<TSource>
{
	private readonly Task<IEnumerable<TSource>> _source;

	public TaskEnumerableToAsyncEnumerable(Task<IEnumerable<TSource>> source)
		=> _source = source;

	public IAsyncEnumerator<TSource> GetAsyncEnumerator(CancellationToken cancellationToken = default)
		=> new Enumerator(_source.GetEnumerator(), cancellationToken);

	private class Enumerator : IAsyncEnumerator<TSource>
	{
		private readonly Task<IEnumerator<TSource>> _enumerator;
		private readonly CancellationToken _cancellationToken;

#pragma warning disable CS8603 // Possible null reference return.
		public TSource Current => _enumerator.Status == TaskStatus.RanToCompletion ? _enumerator.Result.Current : default;
#pragma warning restore CS8603 // Possible null reference return.

		public Enumerator(Task<IEnumerator<TSource>> enumerator, CancellationToken cancellationToken)
		{
			_enumerator = enumerator;
			_cancellationToken = cancellationToken;
		}

		public ValueTask DisposeAsync()
		{
			_enumerator.Dispose();

			return ValueTask.CompletedTask;
		}

		public async ValueTask<bool> MoveNextAsync()
		{
			_cancellationToken.ThrowIfCancellationRequested();

			var enumerator = _enumerator.Status == TaskStatus.RanToCompletion ? _enumerator.Result : await _enumerator;

			return enumerator.MoveNext();
		}
	}
}
