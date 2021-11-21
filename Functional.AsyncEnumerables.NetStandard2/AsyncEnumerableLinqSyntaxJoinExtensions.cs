using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class AsyncEnumerableLinqSyntaxJoinExtensions
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

		private static class AsyncGroupJoinEnumerable
		{
			public static IAsyncEnumerable<TResult> Create<TOuter, TInner, TKey, TResult>(IAsyncEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
				=> new AsyncGroupJoinEnumerable<TOuter, TInner, TKey>(outer, Task.FromResult(inner), outerKeySelector, innerKeySelector)
					.Select(result => resultSelector.Invoke(result.outer, result.inner));

			public static IAsyncEnumerable<TResult> Create<TOuter, TInner, TKey, TResult>(IAsyncEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
				=> new AsyncGroupJoinEnumerable<TOuter, TInner, TKey>(outer, inner, outerKeySelector, innerKeySelector)
					.Select(result => resultSelector.Invoke(result.outer, result.inner));

			public static IAsyncEnumerable<TResult> Create<TOuter, TInner, TKey, TResult>(IAsyncEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
				=> new AsyncGroupJoinEnumerable<TOuter, TInner, TKey>(outer, inner.AsEnumerable(), outerKeySelector, innerKeySelector)
					.Select(result => resultSelector.Invoke(result.outer, result.inner));
		}

		private class AsyncGroupJoinEnumerable<TOuter, TInner, TKey> : IAsyncEnumerable<(TOuter outer, IEnumerable<TInner> inner)>
		{
			public readonly IAsyncEnumerable<TOuter> _outer;
			public readonly Task<IEnumerable<TInner>> _inner;
			public readonly Func<TOuter, TKey> _outerKeySelector;
			public readonly Func<TInner, TKey> _innerKeySelector;

			public AsyncGroupJoinEnumerable(IAsyncEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector)
			{
				_outer = outer ?? throw new ArgumentNullException(nameof(outer));
				_inner = inner ?? throw new ArgumentNullException(nameof(inner));
				_outerKeySelector = outerKeySelector ?? throw new ArgumentNullException(nameof(outerKeySelector));
				_innerKeySelector = innerKeySelector ?? throw new ArgumentNullException(nameof(innerKeySelector));
			}

			public IAsyncEnumerator<(TOuter outer, IEnumerable<TInner> inner)> GetEnumerator()
				=> new AsyncGroupJoinEnumerator<TOuter, TInner, TKey>(_outer.GetEnumerator(), _inner, _outerKeySelector, _innerKeySelector);
		}

		private class AsyncGroupJoinEnumerator<TOuter, TInner, TKey> : IAsyncEnumerator<(TOuter outer, IEnumerable<TInner> inner)>
		{
			private readonly IAsyncEnumerator<TOuter> _outer;
			private readonly Task<IEnumerable<TInner>> _inner;
			private readonly Func<TOuter, TKey> _outerKeySelector;
			private readonly Func<TInner, TKey> _innerKeySelector;

			public (TOuter outer, IEnumerable<TInner> inner) Current { get; private set; }

			private ILookup<TKey, TInner>? _lookup;
			private async Task<ILookup<TKey, TInner>> GetLookup()
				=> _lookup ?? (_lookup = (await _inner).ToLookup(_innerKeySelector));

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
			public AsyncGroupJoinEnumerator(IAsyncEnumerator<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector)
			{
				_outer = outer ?? throw new ArgumentNullException(nameof(outer));
				_inner = inner ?? throw new ArgumentNullException(nameof(inner));
				_outerKeySelector = outerKeySelector ?? throw new ArgumentNullException(nameof(outerKeySelector));
				_innerKeySelector = innerKeySelector ?? throw new ArgumentNullException(nameof(innerKeySelector));
			}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

			public async Task<bool> MoveNext()
			{
				if (await _outer.MoveNext())
				{
					Current = (_outer.Current, (await GetLookup())[_outerKeySelector.Invoke(_outer.Current)]);

					return true;
				}
				else
				{
					Current = default;
					return false;
				}
			}
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

		private static async Task<IEnumerable<TResult>> DoGroupJoin<TOuter, TInner, TKey, TResult>(Task<IEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> (await outer).GroupJoin(await inner, outerKeySelector, innerKeySelector, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> DoGroupJoin(Task.FromResult(outer), inner.AsEnumerable(), outerKeySelector, innerKeySelector, resultSelector).AsAsyncEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> DoGroupJoin(outer, inner.AsEnumerable(), outerKeySelector, innerKeySelector, resultSelector).AsAsyncEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> AsyncGroupJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> AsyncGroupJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> AsyncGroupJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, resultSelector);
	}
}
