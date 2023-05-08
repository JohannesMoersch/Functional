namespace Functional;

public static partial class EnumerableExtensions
{
	public static Task<IEnumerator<TSource>> GetEnumerator<TSource>(this Task<IEnumerable<TSource>> source)
		=> source.ContinueWith(t => t.Result.GetEnumerator(), TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);

	public static Task<IEnumerator<TSource>> GetEnumerator<TSource>(this Task<IOrderedEnumerable<TSource>> source)
		=> source.ContinueWith(t => t.Result.GetEnumerator(), TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);
}
