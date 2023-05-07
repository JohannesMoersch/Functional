namespace Functional;

internal class NewReplayableEnumerable<T> : IAsyncEnumerable<T>
{
	private readonly IEnumerator<T> _enumerator;

	private volatile int _count = 0;
	private T[] _values = new T[4];
	private int _accessCounter = 0;
	private SemaphoreSlim? _semaphore;
	private bool _isComplete;
	private Exception? _exception;

	public NewReplayableEnumerable(IEnumerable<T> enumerable)
		=> _enumerator = enumerable.GetEnumerator();

	public async ValueTask<(bool isSet, T value)> TryGetValue(int index)
	{
		if (index < _count)
			return (true, _values[index]);

		if (Interlocked.Increment(ref _accessCounter) > 1)
			await GetSemaphore().WaitAsync();
		
		try
		{
			while (_count < index)
			{
				if (_enumerator.MoveNext())
				{
					if (_values.Length == _count)
					{
						var newCapacity = _values.Length * 2;
						if (newCapacity > Array.MaxLength)
							newCapacity = Array.MaxLength;

						var newArray = new T[newCapacity];
						Array.Copy(_values, newArray, _values.Length);
						Volatile.Write(ref _values, newArray);
					}

					_values[_count] = _enumerator.Current;
					++_count;
				}
			}

			// Handle complete, exception, and return
		}
		finally
		{
			if (Interlocked.Decrement(ref _accessCounter) > 0)
				GetSemaphore().Release();
		}
	}

	private SemaphoreSlim GetSemaphore()
	{
		if (_semaphore is SemaphoreSlim semaphore)
			return semaphore;

#pragma warning disable CS8603 // Possible null reference return.
		return Interlocked.CompareExchange(ref _semaphore, null, new SemaphoreSlim(0));
#pragma warning restore CS8603 // Possible null reference return.
	}

	public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
	{
		int count = 0;
		(bool isSet, T value) result;
		while ((result = await TryGetValue(count++)).isSet)
			yield return result.value;
	}
}

internal class ReplayableEnumerableData<T>
{
	private readonly IEnumerator<T> _enumerator;

	private readonly List<T> _values = new();

	private bool _complete;
	private Exception _exception;
	private int _exceptionIndex;

	public ReplayableEnumerableData(IEnumerator<T> enumerator)
		=> _enumerator = enumerator;

	public bool TryGetValue(int index, out T value)
	{
		if (index < _values.Count)
		{
			value = _values[index];
			return true;
		}

		// FIX / REDESIGN THIS. DO PROPER ERROR HANDLING.
		if (!_complete)
		{
			try
			{
				if (_enumerator.MoveNext())
				{
					value = _enumerator.Current;
					_values.Add(value);
					return true;
				}
				else
					_complete = true;
			}
			catch (Exception ex)
			{
				_exception = ex;
				_exceptionIndex = _va
			}
		}

#pragma warning disable CS8601 // Possible null reference assignment.
		value = default;
#pragma warning restore CS8601 // Possible null reference assignment.
		return false;
	}
}

internal class ReplayableEnumerator<T> : IEnumerator<T>
{
	public T Current { get; private set; }

#pragma warning disable CS8603 // Possible null reference return.
	object IEnumerator.Current => Current;
#pragma warning restore CS8603 // Possible null reference return.

	private readonly ReplayableEnumerableData<T> _data;

	private int _index = 0;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public ReplayableEnumerator(ReplayableEnumerableData<T> data)
		=> _data = data;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	public void Dispose() { }

	public bool MoveNext()
	{
		if (_index >= 0 && _data.TryGetValue(_index++, out var value))
		{
			Current = value;
			return true;
		}

#pragma warning disable CS8601 // Possible null reference assignment.
		Current = default;
#pragma warning restore CS8601 // Possible null reference assignment.
		return false;
	}

	public void Reset()
		=> _index = 0;
}

internal class ReplayableEnumerable<T> : IEnumerable<T>
{
	private readonly ReplayableEnumerableData<T> _data;

	public ReplayableEnumerable(IEnumerable<T> data)
		=> _data = new ReplayableEnumerableData<T>(data.GetEnumerator());

	public IEnumerator<T> GetEnumerator()
		=> new ReplayableEnumerator<T>(_data);

	IEnumerator IEnumerable.GetEnumerator()
		=> new ReplayableEnumerator<T>(_data);
}
