namespace Functional;

internal class ReplayableAsyncEnumerable<T> : IAsyncEnumerable<T>
{
	private readonly IAsyncEnumerator<T> _enumerator;

	private volatile int _count = 0;
	private T[] _values = new T[4];
	private int _accessCounter = 0;
	private SemaphoreSlim? _semaphore;
	private Exception? _exception;

	public ReplayableAsyncEnumerable(IAsyncEnumerable<T> enumerable)
		=> _enumerator = enumerable.GetAsyncEnumerator();

	public async ValueTask<(bool isSet, T value)> TryGetValue(int index)
	{
		if (TryGetValueWithoutEnumeration(index, _count) is (bool, T) result)
			return result;

		if (Interlocked.Increment(ref _accessCounter) > 1)
			await GetSemaphore().WaitAsync();

		var localCount = _count;

		try
		{
			if (!IsComplete(localCount)) // Not Complete
			{
				while (localCount <= index)
				{
					if (await MoveNext())
					{
						EnsureArrayHasCapacity(localCount);

						_values[localCount] = _enumerator.Current;
						++localCount;
					}
					else
					{
						localCount |= unchecked((int)0x80000000);
						break;
					}
				}

				_count = localCount;
			}
		}
		finally
		{
			if (Interlocked.Decrement(ref _accessCounter) > 0)
				GetSemaphore().Release();
		}

		return TryGetValueWithoutEnumeration(index, localCount) ?? throw new Exception($"Unexpected failure occurred in {nameof(ReplayableAsyncEnumerable<T>)}.");
	}

	private (bool isSet, T value)? TryGetValueWithoutEnumeration(int index, int currentCount)
	{
		if (index < (currentCount & 0x7FFFFFFF))
			return (true, _values[index]);

#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
		if (IsComplete(currentCount))
		{
			if (_exception != null)
				throw new AggregateException(_exception);

			return (false, default);
		}
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.

		return null;
	}

	private void EnsureArrayHasCapacity(int currentCount)
	{
		if (_values.Length == currentCount)
		{
			var newCapacity = _values.Length * 2;
			if (newCapacity > Array.MaxLength)
				newCapacity = Array.MaxLength;

			var newArray = new T[newCapacity];
			Array.Copy(_values, newArray, _values.Length);
			Volatile.Write(ref _values, newArray);
		}
	}

	private async Task<bool> MoveNext()
	{
		try
		{
			return await _enumerator.MoveNextAsync();
		}
		catch (Exception ex)
		{
			_exception = ex;
			return false;
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

	private static bool IsComplete(int count)
		=> (count & 0x80000000) == 0x80000000;

	public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
	{
		int count = 0;
		(bool isSet, T value) result;
		while ((result = await TryGetValue(count++)).isSet)
			yield return result.value;
	}
}