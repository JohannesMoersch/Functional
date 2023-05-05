namespace Functional;

internal static class BasicTaskAsyncIterator
{
	public enum State : byte
	{
		Pending,
		Started,
		Stopped
	}

	public enum ContinuationType : byte
	{
		Start,
		Take,
		Skip,
		Stop
	}

	public static IAsyncEnumerator<TResult> Create<TSource, TResult, TContext>(IAsyncEnumerable<TSource> source, TContext context, Func<TSource, int, TContext, Task<(ContinuationType type, TResult? current)>> onNext, CancellationToken cancellationToken)
		=> new BasicTaskAsyncIterator<TSource, TResult, TContext>(source, context, State.Started, onNext, cancellationToken);

	public static IAsyncEnumerator<TResult> Create<TSource, TResult, TContext>(IAsyncEnumerable<TSource> source, TContext context, State initialState, Func<TSource, int, TContext, Task<(ContinuationType type, TResult? current)>> onNext, CancellationToken cancellationToken)
		=> new BasicTaskAsyncIterator<TSource, TResult, TContext>(source, context, initialState, onNext, cancellationToken);
}

internal class BasicTaskAsyncIterator<TSource, TResult, TContext> : IAsyncEnumerator<TResult>
{
	private readonly IAsyncEnumerator<TSource> _enumerator;
	private readonly TContext _context;
	private readonly Func<TSource, int, TContext, Task<(BasicTaskAsyncIterator.ContinuationType type, TResult? current)>> _moveNext;
	private readonly CancellationToken _cancellationToken;

	private int _count;
	private BasicTaskAsyncIterator.State _state;

	public TResult Current { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public BasicTaskAsyncIterator(IAsyncEnumerable<TSource> source, TContext context, BasicTaskAsyncIterator.State initialState, Func<TSource, int, TContext, Task<(BasicTaskAsyncIterator.ContinuationType type, TResult? current)>> onNext, CancellationToken cancellationToken)
	{
		_enumerator = (source ?? throw new ArgumentNullException(nameof(source))).GetAsyncEnumerator();
		_context = context;
		_state = initialState;
		_moveNext = onNext ?? throw new ArgumentNullException(nameof(onNext));
		_cancellationToken = cancellationToken;
	}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	public ValueTask DisposeAsync()
		=> _enumerator.DisposeAsync();

	public async ValueTask<bool> MoveNextAsync()
	{
		_cancellationToken.ThrowIfCancellationRequested();

		if (_state == BasicTaskAsyncIterator.State.Stopped)
			return false;

		while (await _enumerator.MoveNextAsync())
		{
			_cancellationToken.ThrowIfCancellationRequested();

			var (type, current) = await _moveNext.Invoke(_enumerator.Current, _count++, _context);
			
			_cancellationToken.ThrowIfCancellationRequested();

#pragma warning disable CS8601 // Possible null reference assignment.
			switch (type)
			{
				case BasicTaskAsyncIterator.ContinuationType.Start:
					_state = BasicTaskAsyncIterator.State.Started;
					Current = current;
					return true;
				case BasicTaskAsyncIterator.ContinuationType.Take:
					if (_state == BasicTaskAsyncIterator.State.Started)
					{
						Current = current;
						return true;
					}
					continue;
				case BasicTaskAsyncIterator.ContinuationType.Skip:
					continue;
				case BasicTaskAsyncIterator.ContinuationType.Stop:
					_state = BasicTaskAsyncIterator.State.Stopped;
					Current = default;
					return false;
			}
#pragma warning restore CS8601 // Possible null reference assignment.
			break;
		}

		return false;
	}
}
