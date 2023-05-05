namespace Functional;

internal static class BasicAsyncIterator
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

	public static IAsyncEnumerator<TResult> Create<TSource, TResult, TContext>(IAsyncEnumerable<TSource> source, TContext context, Func<TSource, int, TContext, (ContinuationType type, TResult? current)> onNext, CancellationToken cancellationToken)
		=> new BasicAsyncIterator<TSource, TResult, TContext>(source, context, State.Started, onNext, cancellationToken);

	public static IAsyncEnumerator<TResult> Create<TSource, TResult, TContext>(IAsyncEnumerable<TSource> source, TContext context, State initialState, Func<TSource, int, TContext, (ContinuationType type, TResult? current)> onNext, CancellationToken cancellationToken)
		=> new BasicAsyncIterator<TSource, TResult, TContext>(source, context, initialState, onNext, cancellationToken);
}

internal class BasicAsyncIterator<TSource, TResult, TContext> : IAsyncEnumerator<TResult>
{
	private readonly IAsyncEnumerator<TSource> _enumerator;
	private readonly TContext _context;
	private readonly Func<TSource, int, TContext, (BasicAsyncIterator.ContinuationType type, TResult? current)> _moveNext;
	private readonly CancellationToken _cancellationToken;

	private int _count;
	private BasicAsyncIterator.State _state;

	public TResult Current { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public BasicAsyncIterator(IAsyncEnumerable<TSource> source, TContext context, BasicAsyncIterator.State initialState, Func<TSource, int, TContext, (BasicAsyncIterator.ContinuationType type, TResult? current)> onNext, CancellationToken cancellationToken)
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

		if (_state == BasicAsyncIterator.State.Stopped)
			return false;

		while (await _enumerator.MoveNextAsync())
		{
			_cancellationToken.ThrowIfCancellationRequested();

			var (type, current) = _moveNext.Invoke(_enumerator.Current, _count++, _context);

#pragma warning disable CS8601 // Possible null reference assignment.
			switch (type)
			{
				case BasicAsyncIterator.ContinuationType.Start:
					_state = BasicAsyncIterator.State.Started;
					Current = current;
					return true;
				case BasicAsyncIterator.ContinuationType.Take:
					if (_state == BasicAsyncIterator.State.Started)
					{
						Current = current;
						return true;
					}
					continue;
				case BasicAsyncIterator.ContinuationType.Skip:
					continue;
				case BasicAsyncIterator.ContinuationType.Stop:
					_state = BasicAsyncIterator.State.Stopped;
					Current = default;
					return false;
			}
#pragma warning restore CS8601 // Possible null reference assignment.
			break;
		}
		
		_cancellationToken.ThrowIfCancellationRequested();

		return false;
	}
}
