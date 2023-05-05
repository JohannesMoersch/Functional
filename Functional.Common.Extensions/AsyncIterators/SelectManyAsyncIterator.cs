namespace Functional;

internal static class SelectManyAsyncIterator
{
	public static IAsyncEnumerator<TResult> Create<TSource, TCollection, TResult, TContext>(IAsyncEnumerable<TSource> source, TContext context, Func<TSource, int, TContext, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TContext, TResult> resultSelector, CancellationToken cancellationToken)
		=> new SelectManyAsyncIterator<TSource, TCollection, TResult, TContext>(source, context, collectionSelector, resultSelector, cancellationToken);
}

internal class SelectManyAsyncIterator<TSource, TCollection, TResult, TContext> : IAsyncEnumerator<TResult>
{
	private readonly IAsyncEnumerator<TSource> _enumerator;
	private readonly TContext _context;
	private readonly Func<TSource, int, TContext, IAsyncEnumerable<TCollection>> _collectionSelector;
	private readonly Func<TSource, TCollection, TContext, TResult> _resultSelector;
	private readonly CancellationToken _cancellationToken;

	private int _count;
	private IAsyncEnumerator<TCollection>? _subEnumerator;

	public TResult Current { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public SelectManyAsyncIterator(IAsyncEnumerable<TSource> source, TContext context, Func<TSource, int, TContext, IAsyncEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TContext, TResult> resultSelector, CancellationToken cancellationToken)
	{
		_enumerator = (source ?? throw new ArgumentNullException(nameof(source))).GetAsyncEnumerator();
		_context = context;
		_collectionSelector = collectionSelector ?? throw new ArgumentNullException(nameof(collectionSelector));
		_resultSelector = resultSelector ?? throw new ArgumentNullException(nameof(resultSelector));
		_cancellationToken = cancellationToken;
	}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	public async ValueTask DisposeAsync()
	{
		if (_subEnumerator != null)
			await _subEnumerator.DisposeAsync();

		await _enumerator.DisposeAsync();
	}

	public async ValueTask<bool> MoveNextAsync()
	{
		_cancellationToken.ThrowIfCancellationRequested();

		while (_subEnumerator == null || !await _subEnumerator.MoveNextAsync())
		{
			if (!await _enumerator.MoveNextAsync())
			{
				_cancellationToken.ThrowIfCancellationRequested();
				return false;
			}

			if (_subEnumerator != null)
				await _subEnumerator.DisposeAsync();

			_subEnumerator = _collectionSelector.Invoke(_enumerator.Current, _count++, _context).GetAsyncEnumerator();
		}

		Current = _resultSelector.Invoke(_enumerator.Current, _subEnumerator.Current, _context);

		return true;
	}
}
