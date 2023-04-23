namespace Functional;

public static partial class ResultExtensions
{
	private static class DelegateCache<T>
	{
		public static readonly Func<T, bool> True = _ => true;
		public static readonly Func<T, bool> False = _ => false;
		public static readonly Func<T, T> Passthrough = _ => _;
	}

#pragma warning disable CS8603 // Possible null reference return.
	private static class DelegateCache<TIn, TOut>
	{
		public static readonly Func<TIn, TOut> Default = _ => default;
	}
#pragma warning restore CS8603 // Possible null reference return.

	public static bool TryGetValue<TSuccess, TFailure>(this Result<TSuccess, TFailure> result, [MaybeNullWhen(false)] out TSuccess success, [MaybeNullWhen(true)] out TFailure failure)
		where TSuccess : notnull
		where TFailure : notnull
	{
		success = result.Match(DelegateCache<TSuccess>.Passthrough, DelegateCache<TFailure, TSuccess>.Default);

		failure = result.Match(DelegateCache<TSuccess, TFailure>.Default, DelegateCache<TFailure>.Passthrough);

		return result.Match(DelegateCache<TSuccess>.True, DelegateCache<TFailure>.False);
	}
}
