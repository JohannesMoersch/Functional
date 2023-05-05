using System;
namespace Functional;

internal class AppendTaskAsyncIterator<TSource> : IAsyncEnumerator<TSource>
{
	private readonly IAsyncEnumerator<TSource> _enumerator;
	private readonly Task<TSource> _element;
	private readonly CancellationToken _cancellationToken;

	private int _state = 0;

	public TSource Current { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public AppendTaskAsyncIterator(IAsyncEnumerable<TSource> source, Task<TSource> element, CancellationToken cancellationToken)
	{
		_enumerator = (source ?? throw new ArgumentNullException(nameof(source))).GetAsyncEnumerator();
		_element = element;
		_cancellationToken = cancellationToken;
	}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	public async ValueTask DisposeAsync()
	{
		await _element;

		await _enumerator.DisposeAsync();
	}

	public async ValueTask<bool> MoveNextAsync()
	{
		_cancellationToken.ThrowIfCancellationRequested();

		if (_state == 0)
		{
			if (await _enumerator.MoveNextAsync())
			{
				_cancellationToken.ThrowIfCancellationRequested();

				Current = _enumerator.Current;
				return true;
			}
			else
				_state = 1;
		}
		
		_cancellationToken.ThrowIfCancellationRequested();

		if (_state == 1)
		{
			_state = 2;

			Current = await _element;
			_cancellationToken.ThrowIfCancellationRequested();
			return true;
		}

		return false;
	}
}
