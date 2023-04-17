namespace Functional;

internal static class ResultFactoryHelpers
{
	public static TSuccess SuccessUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> source.Match(static _ => _, static _ => throw new InvalidOperationException("Not a successful result!"));

	public static TFailure FailureUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> source.Match(static _ => throw new InvalidOperationException("Not a faulted result!"), static _ => _);
}
