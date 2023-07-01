namespace Functional.Unions;

public struct Result<TSuccess, TFailure>
	where TSuccess : notnull
	where TFailure : notnull
{
	private readonly bool? _isSuccess;

	private readonly TSuccess _success;

	private readonly TFailure _failure;

	internal Result(bool isSuccess, TSuccess success, TFailure failure)
	{
		_isSuccess = isSuccess;
		_success = success;
		_failure = failure;
	}

	internal bool IsSuccess()
		=> _isSuccess ?? throw new Exception("Result not initialized.");

	public TResult Match<TResult>(Func<TSuccess, TResult> success, Func<TFailure, TResult> failure)
	{
		if (success == null)
			throw new ArgumentNullException(nameof(success));

		if (failure == null)
			throw new ArgumentNullException(nameof(failure));

		return IsSuccess() ? success.Invoke(_success) : failure.Invoke(_failure);
	}

	public bool TryGetValue(out TSuccess success, out TFailure failure)
	{
		success = _success;
		failure = _failure;

		return IsSuccess();
	}

#pragma warning disable CS8604 // Possible null reference argument.
	public static implicit operator Result<TSuccess, TFailure>(TSuccess success)
		=> new(true, success, default);

	public static implicit operator Result<TSuccess, TFailure>(TFailure failure)
		=> new(false, default, failure);
#pragma warning restore CS8604 // Possible null reference argument.
}
