namespace Functional;

internal class BatchAsyncIterator<T> : IAsyncEnumerator<IReadOnlyList<T>>
{
	public IReadOnlyList<T> Current { get; private set; }

	private readonly IAsyncEnumerator<T> _enumerator;
	private readonly int _batchSize;
	private readonly CancellationToken _cancellationToken;

	private bool _ended;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public BatchAsyncIterator(IAsyncEnumerable<T> enumerator, int batchSize, CancellationToken cancellationToken)
	{
		_enumerator = (enumerator ?? throw new ArgumentNullException(nameof(enumerator))).GetAsyncEnumerator();
		_batchSize = batchSize;
		_cancellationToken = cancellationToken;
		if (_batchSize <= 0)
			throw new ArgumentOutOfRangeException(nameof(batchSize), "Value must be greater than zero.");
	}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	public ValueTask DisposeAsync()
		=> _enumerator.DisposeAsync();

	public async ValueTask<bool> MoveNextAsync()
	{
		_cancellationToken.ThrowIfCancellationRequested();

		if (_ended)
			return false;

		var batch = new T[_batchSize];
		int count = 0;
		while (count < _batchSize && await _enumerator.MoveNextAsync())
		{
			_cancellationToken.ThrowIfCancellationRequested();

			batch[count++] = _enumerator.Current;
		}

		_cancellationToken.ThrowIfCancellationRequested();

		if (count > 0)
		{
			if (count < _batchSize)
			{
				var temp = new T[count];
				Array.Copy(batch, temp, count);
				batch = temp;
			}

			Current = batch;
			return true;
		}

		_ended = true;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Current = default;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
		return false;
	}
}
