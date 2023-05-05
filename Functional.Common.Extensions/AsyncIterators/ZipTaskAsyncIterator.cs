namespace Functional;

internal class ZipTaskAsyncIterator<TFirst, TSecond, TResult> : IAsyncEnumerator<TResult>
{
	private readonly IAsyncEnumerator<TFirst> _enumeratorOne;
	private readonly IAsyncEnumerator<TSecond> _enumeratorTwo;
	private readonly Func<TFirst, TSecond, Task<TResult>> _resultSelector;
	private readonly CancellationToken _cancellationToken;

	private bool _complete;

	public TResult Current { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public ZipTaskAsyncIterator(IAsyncEnumerable<TFirst> first, IAsyncEnumerable<TSecond> second, Func<TFirst, TSecond, Task<TResult>> resultSelector, CancellationToken cancellationToken)
	{
		_enumeratorOne = (first ?? throw new ArgumentNullException(nameof(first))).GetAsyncEnumerator();
		_enumeratorTwo = (second ?? throw new ArgumentNullException(nameof(second))).GetAsyncEnumerator();
		_resultSelector = resultSelector ?? throw new ArgumentNullException(nameof(resultSelector));
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
		if (_complete)
			return false;

		if (await _enumeratorOne.MoveNextAsync() && await _enumeratorTwo.MoveNextAsync())
		{
			Current = await _resultSelector.Invoke(_enumeratorOne.Current, _enumeratorTwo.Current);
			return true;
		}
		else
			_complete = true;

		return false;
	}
}
