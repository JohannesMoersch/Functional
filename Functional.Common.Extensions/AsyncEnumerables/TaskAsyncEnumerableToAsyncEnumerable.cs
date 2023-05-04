namespace Functional;

internal class TaskAsyncEnumerableToAsyncEnumerable<TSource> : IAsyncEnumerable<TSource>
{
	private readonly Task<IAsyncEnumerable<TSource>> _source;

	public TaskAsyncEnumerableToAsyncEnumerable(Task<IAsyncEnumerable<TSource>> source)
		=> _source = source;

	public IAsyncEnumerator<TSource> GetAsyncEnumerator(CancellationToken cancellationToken = default)
		=> new Enumerator(_source.ContinueWith(t => t.Result.GetAsyncEnumerator(), TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously), cancellationToken);

	private class Enumerator : IAsyncEnumerator<TSource>
	{
		private readonly Task<IAsyncEnumerator<TSource>> _enumerator;
		private readonly CancellationToken _cancellationToken;

#pragma warning disable CS8603 // Possible null reference return.
		public TSource Current => _enumerator.Status == TaskStatus.RanToCompletion ? _enumerator.Result.Current : default;
#pragma warning restore CS8603 // Possible null reference return.

		public Enumerator(Task<IAsyncEnumerator<TSource>> enumerator, CancellationToken cancellationToken)
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

			return await enumerator.MoveNextAsync();
		}
	}
}
