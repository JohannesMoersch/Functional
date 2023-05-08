namespace Functional;

public static partial class EnumerableQuerySyntaxExtensions
{
	private static class AsyncJoinEnumerable
	{
		public static IAsyncEnumerable<TResult> Create<TOuter, TInner, TKey, TResult>(IAsyncEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> new AsyncGroupJoinEnumerable<TOuter, TInner, TKey>(outer, Task.FromResult(inner), outerKeySelector, innerKeySelector)
				.SelectMany(result => result.inner.Select(value => resultSelector.Invoke(result.outer, value)));

		public static IAsyncEnumerable<TResult> Create<TOuter, TInner, TKey, TResult>(IAsyncEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> new AsyncGroupJoinEnumerable<TOuter, TInner, TKey>(outer, inner, outerKeySelector, innerKeySelector)
				.SelectMany(result => result.inner.Select(value => resultSelector.Invoke(result.outer, value)));

		public static IAsyncEnumerable<TResult> Create<TOuter, TInner, TKey, TResult>(IAsyncEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> new AsyncGroupJoinEnumerable<TOuter, TInner, TKey>(outer, inner.AsEnumerable(), outerKeySelector, innerKeySelector)
				.SelectMany(result => result.inner.Select(value => resultSelector.Invoke(result.outer, value)));
	}

	private static async Task<IEnumerable<TResult>> DoJoin<TOuter, TInner, TKey, TResult>(Task<IEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> DoJoin(Task.FromResult(outer), inner.AsEnumerable(), outerKeySelector, innerKeySelector, resultSelector).AsAsyncEnumerable();

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> DoJoin(outer, inner.AsEnumerable(), outerKeySelector, innerKeySelector, resultSelector).AsAsyncEnumerable();

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> AsyncJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> AsyncJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
		=> AsyncJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, resultSelector);
}
