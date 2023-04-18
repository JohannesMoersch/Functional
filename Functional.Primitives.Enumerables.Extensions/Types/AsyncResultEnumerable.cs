namespace Functional;

public interface IAsyncResultEnumerable<TSuccess, TFailure> : IAsyncEnumerable<Result<TSuccess, TFailure>>
	where TSuccess : notnull
	where TFailure : notnull
{
}

internal class AsyncResultEnumerable<TSuccess, TFailure> : IAsyncResultEnumerable<TSuccess, TFailure>
	where TSuccess : notnull
	where TFailure : notnull
{
	private readonly IAsyncEnumerable<Result<TSuccess, TFailure>> _source;

	public AsyncResultEnumerable(IAsyncEnumerable<Result<TSuccess, TFailure>> source) 
		=> _source = source ?? throw new ArgumentNullException(nameof(source));

	public IAsyncEnumerator<Result<TSuccess, TFailure>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
		=> _source.GetAsyncEnumerator(cancellationToken);
}

internal static class AsyncResultEnumerable
{
	public static IAsyncResultEnumerable<TSuccess, TFailure> AsAsyncResultEnumerable<TSuccess, TFailure>(this IAsyncEnumerable<Result<TSuccess, TFailure>> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> new AsyncResultEnumerable<TSuccess, TFailure>(source);

	public static IAsyncResultEnumerable<TSuccess, TFailure> AsAsyncResultEnumerable<TSuccess, TFailure>(this Task<IResultEnumerable<TSuccess, TFailure>> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> ConvertEnumerable(source)
			.AsAsyncEnumerable()
			.AsAsyncResultEnumerable();

	public static IAsyncResultEnumerable<TSuccess, TFailure> AsAsyncResultEnumerable<TSuccess, TFailure>(this Task<IEnumerable<Result<TSuccess, TFailure>>> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> source
			.AsAsyncEnumerable()
			.AsAsyncResultEnumerable();

	public static IAsyncResultEnumerable<TSuccess, TFailure> AsAsyncResultEnumerable<TSuccess, TFailure>(this Task<IAsyncResultEnumerable<TSuccess, TFailure>> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> ConvertAsyncEnumerable(source)
			.AsAsyncEnumerable()
			.AsAsyncResultEnumerable();

	public static IAsyncResultEnumerable<TSuccess, TFailure> AsAsyncResultEnumerable<TSuccess, TFailure>(this Task<IAsyncEnumerable<Result<TSuccess, TFailure>>> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> source
			.AsAsyncEnumerable()
			.AsAsyncResultEnumerable();

	private static async Task<IEnumerable<Result<TSuccess, TFailure>>> ConvertEnumerable<TSuccess, TFailure>(Task<IResultEnumerable<TSuccess, TFailure>> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> await source;

	private static async Task<IAsyncEnumerable<Result<TSuccess, TFailure>>> ConvertAsyncEnumerable<TSuccess, TFailure>(Task<IAsyncResultEnumerable<TSuccess, TFailure>> source)
		where TSuccess : notnull
		where TFailure : notnull
		=> await source;
}
