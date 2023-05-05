namespace Functional;

internal class ConcatAsyncIterator<TSource> : IAsyncEnumerator<TSource>
{
	private readonly IAsyncEnumerator<TSource> _enumeratorOne;
	private readonly IAsyncEnumerator<TSource> _enumeratorTwo;
	private readonly CancellationToken _cancellationToken;

	private int _state = 0;

	public TSource Current { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public ConcatAsyncIterator(IAsyncEnumerable<TSource> first, IAsyncEnumerable<TSource> second, CancellationToken cancellationToken)
	{
		_enumeratorOne = (first ?? throw new ArgumentNullException(nameof(first))).GetAsyncEnumerator();
		_enumeratorTwo = (second ?? throw new ArgumentNullException(nameof(second))).GetAsyncEnumerator();
		_cancellationToken = cancellationToken;
	}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	public async ValueTask DisposeAsync()
	{
		await _enumeratorOne.DisposeAsync();
		await _enumeratorTwo.DisposeAsync();
	}

	public async ValueTask<bool> MoveNextAsync()
	{
		_cancellationToken.ThrowIfCancellationRequested();

		if (_state == 0)
		{
			if (await _enumeratorOne.MoveNextAsync())
			{
				_cancellationToken.ThrowIfCancellationRequested();

				Current = _enumeratorOne.Current;
				return true;
			}
			else
				_state = 1;
		}

		if (_state == 1)
		{
			if (await _enumeratorTwo.MoveNextAsync())
			{
				_cancellationToken.ThrowIfCancellationRequested();

				Current = _enumeratorTwo.Current;
				return true;
			}
			else
				_state = 2;
		}

		_cancellationToken.ThrowIfCancellationRequested();
		return false;
	}
}
