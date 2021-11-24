using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class OptionLinqSyntaxJoinExtensions
	{
		private static class OptionJoinEnumerable
		{
			public static IOptionEnumerable<TValue> Create<TOuter, TInner, TKey, TValue>(IOptionEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
				where TOuter : notnull
				where TValue : notnull
				=> new OptionGroupJoinEnumerable<TOuter, TInner, TKey>(outer, inner, outerKeySelector, innerKeySelector)
					.SelectMany(option => option.Match(some => some.inner.Select(value => optionSelector.Invoke(some.outer, value)).Select(Option.Some), () => new[] { Option.None<TValue>() }))
					.AsOptionEnumerable();

			public static async Task<IOptionEnumerable<TValue>> Create<TOuter, TInner, TKey, TValue>(IOptionEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
				where TOuter : notnull
				where TValue : notnull
				=> new OptionGroupJoinEnumerable<TOuter, TInner, TKey>(outer, await inner, outerKeySelector, innerKeySelector)
					.SelectMany(option => option.Match(some => some.inner.Select(value => optionSelector.Invoke(some.outer, value)).Select(Option.Some), () => new[] { Option.None<TValue>() }))
					.AsOptionEnumerable();
		}

		private static class OptionGroupJoinEnumerable
		{
			public static IOptionEnumerable<TValue> Create<TOuter, TInner, TKey, TValue>(IOptionEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
				where TOuter : notnull
				where TValue : notnull
				=> new OptionGroupJoinEnumerable<TOuter, TInner, TKey>(outer, inner, outerKeySelector, innerKeySelector)
					.Select(option => option.Match(value => Option.Some(optionSelector.Invoke(value.outer, value.inner)), Option.None<TValue>))
					.AsOptionEnumerable();

			public static async Task<IOptionEnumerable<TValue>> Create<TOuter, TInner, TKey, TValue>(IOptionEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
				where TOuter : notnull
				where TValue : notnull
				=> new OptionGroupJoinEnumerable<TOuter, TInner, TKey>(outer, await inner, outerKeySelector, innerKeySelector)
					.Select(option => option.Match(value => Option.Some(optionSelector.Invoke(value.outer, value.inner)), Option.None<TValue>))
					.AsOptionEnumerable();
		}

		private class OptionGroupJoinEnumerable<TOuter, TInner, TKey> : IOptionEnumerable<(TOuter outer, IEnumerable<TInner> inner)>
			where TOuter : notnull
		{
			public readonly IOptionEnumerable<TOuter> _outer;
			public readonly IEnumerable<TInner> _inner;
			public readonly Func<TOuter, TKey> _outerKeySelector;
			public readonly Func<TInner, TKey> _innerKeySelector;

			public OptionGroupJoinEnumerable(IOptionEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector)
			{
				_outer = outer ?? throw new ArgumentNullException(nameof(outer));
				_inner = inner ?? throw new ArgumentNullException(nameof(inner));
				_outerKeySelector = outerKeySelector ?? throw new ArgumentNullException(nameof(outerKeySelector));
				_innerKeySelector = innerKeySelector ?? throw new ArgumentNullException(nameof(innerKeySelector));
			}

			public IEnumerator<Option<(TOuter outer, IEnumerable<TInner> inner)>> GetEnumerator()
				=> new OptionGroupJoinEnumerator<TOuter, TInner, TKey>(_outer.GetEnumerator(), _inner, _outerKeySelector, _innerKeySelector);

			IEnumerator IEnumerable.GetEnumerator()
				=> GetEnumerator();
		}

		private class OptionGroupJoinEnumerator<TOuter, TInner, TKey> : IEnumerator<Option<(TOuter outer, IEnumerable<TInner> inner)>>
			where TOuter : notnull
		{
			private readonly IEnumerator<Option<TOuter>> _outer;
			private readonly IEnumerable<TInner> _inner;
			private readonly Func<TOuter, TKey> _outerKeySelector;
			private readonly Func<TInner, TKey> _innerKeySelector;

			public Option<(TOuter outer, IEnumerable<TInner> inner)> Current { get; private set; }

			object IEnumerator.Current => Current;

			private ILookup<TKey, TInner>? _lookup;
			private ILookup<TKey, TInner> GetLookup()
				=> _lookup ?? (_lookup = _inner.ToLookup(_innerKeySelector));

			public OptionGroupJoinEnumerator(IEnumerator<Option<TOuter>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector)
			{
				_outer = outer ?? throw new ArgumentNullException(nameof(outer));
				_inner = inner ?? throw new ArgumentNullException(nameof(inner));
				_outerKeySelector = outerKeySelector ?? throw new ArgumentNullException(nameof(outerKeySelector));
				_innerKeySelector = innerKeySelector ?? throw new ArgumentNullException(nameof(innerKeySelector));
			}

			public void Dispose()
				=> _outer.Dispose();

			public bool MoveNext()
			{
				if (_outer.MoveNext())
				{
					Current = _outer
					   .Current
					   .Map(outerValue => (outerValue, GetLookup()[_outerKeySelector.Invoke(outerValue)]));

					return true;
				}
				else
				{
					Current = default;
					return false;
				}
			}

			public void Reset()
			{
				_lookup = null;
				_outer.Reset();
			}
		}

		private static class AsyncOptionJoinEnumerable
		{
			public static IAsyncOptionEnumerable<TValue> Create<TOuter, TInner, TKey, TValue>(IAsyncOptionEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
				where TOuter : notnull
				where TValue : notnull
				=> new AsyncOptionGroupJoinEnumerable<TOuter, TInner, TKey>(outer, Task.FromResult(inner), outerKeySelector, innerKeySelector)
					.SelectMany(option => option.Match(some => some.inner.Select(value => optionSelector.Invoke(some.outer, value)).Select(value => Option.Some(value)), () => new[] { Option.None<TValue>() }))
					.AsAsyncOptionEnumerable();

			public static IAsyncOptionEnumerable<TValue> Create<TOuter, TInner, TKey, TValue>(IAsyncOptionEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
				where TOuter : notnull
				where TValue : notnull
				=> new AsyncOptionGroupJoinEnumerable<TOuter, TInner, TKey>(outer, inner, outerKeySelector, innerKeySelector)
					.SelectMany(option => option.Match(some => some.inner.Select(value => optionSelector.Invoke(some.outer, value)).Select(value => Option.Some(value)), () => new[] { Option.None<TValue>() }))
					.AsAsyncOptionEnumerable();

			public static IAsyncOptionEnumerable<TValue> Create<TOuter, TInner, TKey, TValue>(IAsyncOptionEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
				where TOuter : notnull
				where TValue : notnull
				=> new AsyncOptionGroupJoinEnumerable<TOuter, TInner, TKey>(outer, inner.AsEnumerable(), outerKeySelector, innerKeySelector)
					.SelectMany(option => option.Match(some => some.inner.Select(value => optionSelector.Invoke(some.outer, value)).Select(value => Option.Some(value)), () => new[] { Option.None<TValue>() }))
					.AsAsyncOptionEnumerable();
		}

		private static class AsyncOptionGroupJoinEnumerable
		{
			public static IAsyncOptionEnumerable<TValue> Create<TOuter, TInner, TKey, TValue>(IAsyncOptionEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
				where TOuter : notnull
				where TValue : notnull
				=> new AsyncOptionGroupJoinEnumerable<TOuter, TInner, TKey>(outer, Task.FromResult(inner), outerKeySelector, innerKeySelector)
					.Select(option => option.Match(value => Option.Some(optionSelector.Invoke(value.outer, value.inner)), Option.None<TValue>))
					.AsAsyncOptionEnumerable();

			public static IAsyncOptionEnumerable<TValue> Create<TOuter, TInner, TKey, TValue>(IAsyncOptionEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
				where TOuter : notnull
				where TValue : notnull
				=> new AsyncOptionGroupJoinEnumerable<TOuter, TInner, TKey>(outer, inner, outerKeySelector, innerKeySelector)
					.Select(option => option.Match(value => Option.Some(optionSelector.Invoke(value.outer, value.inner)), Option.None<TValue>))
					.AsAsyncOptionEnumerable();

			public static IAsyncOptionEnumerable<TValue> Create<TOuter, TInner, TKey, TValue>(IAsyncOptionEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
				where TOuter : notnull
				where TValue : notnull
				=> new AsyncOptionGroupJoinEnumerable<TOuter, TInner, TKey>(outer, inner.AsEnumerable(), outerKeySelector, innerKeySelector)
					.Select(option => option.Match(value => Option.Some(optionSelector.Invoke(value.outer, value.inner)), Option.None<TValue>))
					.AsAsyncOptionEnumerable();
		}

		private class AsyncOptionGroupJoinEnumerable<TOuter, TInner, TKey> : IAsyncOptionEnumerable<(TOuter outer, IEnumerable<TInner> inner)>
				where TOuter : notnull
		{
			public readonly IAsyncOptionEnumerable<TOuter> _outer;
			public readonly Task<IEnumerable<TInner>> _inner;
			public readonly Func<TOuter, TKey> _outerKeySelector;
			public readonly Func<TInner, TKey> _innerKeySelector;

			public AsyncOptionGroupJoinEnumerable(IAsyncOptionEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector)
			{
				_outer = outer ?? throw new ArgumentNullException(nameof(outer));
				_inner = inner ?? throw new ArgumentNullException(nameof(inner));
				_outerKeySelector = outerKeySelector ?? throw new ArgumentNullException(nameof(outerKeySelector));
				_innerKeySelector = innerKeySelector ?? throw new ArgumentNullException(nameof(innerKeySelector));
			}

			public IAsyncEnumerator<Option<(TOuter outer, IEnumerable<TInner> inner)>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
				=> new AsyncOptionGroupJoinEnumerator<TOuter, TInner, TKey>(_outer.GetAsyncEnumerator(cancellationToken), _inner, _outerKeySelector, _innerKeySelector);
		}

		private class AsyncOptionGroupJoinEnumerator<TOuter, TInner, TKey> : IAsyncEnumerator<Option<(TOuter outer, IEnumerable<TInner> inner)>>
				where TOuter : notnull
		{
			private readonly IAsyncEnumerator<Option<TOuter>> _outer;
			private readonly Task<IEnumerable<TInner>> _inner;
			private readonly Func<TOuter, TKey> _outerKeySelector;
			private readonly Func<TInner, TKey> _innerKeySelector;

			public Option<(TOuter outer, IEnumerable<TInner> inner)> Current { get; private set; }

			private ILookup<TKey, TInner>? _lookup;
			private async Task<ILookup<TKey, TInner>> GetLookup()
				=> _lookup ?? (_lookup = (await _inner).ToLookup(_innerKeySelector));

			public AsyncOptionGroupJoinEnumerator(IAsyncEnumerator<Option<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector)
			{
				_outer = outer ?? throw new ArgumentNullException(nameof(outer));
				_inner = inner ?? throw new ArgumentNullException(nameof(inner));
				_outerKeySelector = outerKeySelector ?? throw new ArgumentNullException(nameof(outerKeySelector));
				_innerKeySelector = innerKeySelector ?? throw new ArgumentNullException(nameof(innerKeySelector));
			}

			public async ValueTask DisposeAsync()
			{
				if (_lookup == null)
					await _inner;

				await _outer.DisposeAsync();
			}

			public async ValueTask<bool> MoveNextAsync()
			{
				if (await _outer.MoveNextAsync())
				{
					Current = await _outer
					   .Current
					   .MapAsync(async outerValue => (outerValue, (await GetLookup())[_outerKeySelector.Invoke(outerValue)]));

					return true;
				}
				else
				{
					Current = default;
					return false;
				}
			}
		}

		// ------------------------- //

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> OptionJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> OptionJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> OptionJoinEnumerable.Create(outer, inner.AsEnumerable(), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, Option<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.Join(value, outerKeySelector, innerKeySelector, optionSelector),
					() => outer
						.Where(option => option.Match(_ => false, () => true))
						.Select(option => option.Match(_ => default, Option.None<TValue>))
						.Concat(new[] { Option.None<TValue>() })
						.AsOptionEnumerable()
				);

		private static async Task<IOptionEnumerable<TValue>> DoJoin<TOuter, TInner, TKey, TValue>(IOptionEnumerable<TOuter> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> outer.Join(await inner, outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoJoin(outer, inner, outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, Option<IAsyncEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoJoin(outer, inner.MatchAsync(async value => Option.Some<IEnumerable<TInner>>(await value.AsEnumerable()), () => Task.FromResult(Option.None<IEnumerable<TInner>>())), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, Option<TInner[]> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> outer.Join(inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, Task<Option<TInner[]>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoJoin(outer, inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IEnumerable<TOuter> outer, Option<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.Join(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
					() => new[] { Option.None<TValue>() }
				)
				.AsOptionEnumerable();

		private static async Task<IOptionEnumerable<TValue>> DoJoin<TOuter, TInner, TKey, TValue>(IEnumerable<TOuter> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> outer.Join(await inner, outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IEnumerable<TOuter> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoJoin(outer, inner, outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IEnumerable<TOuter> outer, Option<IAsyncEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoJoin(outer, inner.MatchAsync(async value => Option.Some<IEnumerable<TInner>>(await value.AsEnumerable()), () => Task.FromResult(Option.None<IEnumerable<TInner>>())), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IEnumerable<TOuter> outer, Option<TInner[]> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> outer.Join(inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IEnumerable<TOuter> outer, Task<Option<TInner[]>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoJoin(outer, inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		private static Task<IEnumerable<Option<TValue>>> DoJoin<TOuter, TInner, TKey, TValue>(Task<IEnumerable<TOuter>> outer, Option<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.MatchAsync
				(
					value => outer.Join(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
					() => Task.FromResult(new[] { Option.None<TValue>() }.AsEnumerable())
				);

		private static Task<IEnumerable<Option<TValue>>> DoJoin<TOuter, TInner, TKey, TValue>(Task<IEnumerable<TOuter>> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.MatchAsync
				(
					value => outer.Join(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
					() => Task.FromResult(new[] { Option.None<TValue>() }.AsEnumerable())
				);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this Task<IEnumerable<TOuter>> outer, Option<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoJoin(outer, inner, outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this Task<IEnumerable<TOuter>> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoJoin(outer, inner, outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this Task<IEnumerable<TOuter>> outer, Option<IAsyncEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoJoin(outer, inner.MatchAsync(async value => Option.Some<IEnumerable<TInner>>(await value.AsEnumerable()), () => Task.FromResult(Option.None<IEnumerable<TInner>>())), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this Task<IEnumerable<TOuter>> outer, Option<TInner[]> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoJoin(outer, inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this Task<IEnumerable<TOuter>> outer, Task<Option<TInner[]>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoJoin(outer, inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		// ------------------------- //

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> AsyncOptionJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> AsyncOptionJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> AsyncOptionJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, Option<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.Join(value, outerKeySelector, innerKeySelector, optionSelector),
					() => outer
						.Where(option => option.Match(_ => false, () => true))
						.Select(option => option.Match(_ => default, Option.None<TValue>))
						.Concat(new[] { Option.None<TValue>() })
						.AsAsyncOptionEnumerable()
				);

		private static async Task<IAsyncOptionEnumerable<TValue>> DoJoin<TOuter, TInner, TKey, TValue>(IAsyncOptionEnumerable<TOuter> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> outer.Join(await inner, outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoJoin(outer, inner, outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, Option<IAsyncEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.Join(value, outerKeySelector, innerKeySelector, optionSelector),
					() => outer
						.Where(option => option.Match(_ => false, () => true))
						.Select(option => option.Match(_ => default, Option.None<TValue>))
						.Concat(new[] { Option.None<TValue>() })
						.AsAsyncOptionEnumerable()
				);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, Option<TInner[]> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> outer.Join(inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, Task<Option<TInner[]>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> outer.Join(inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IAsyncEnumerable<TOuter> outer, Option<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.Join(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
					() => new[] { Option.None<TValue>() }.AsAsyncEnumerable()
				)
				.AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IAsyncEnumerable<TOuter> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.Join(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
					() => new[] { Option.None<TValue>() }.AsAsyncEnumerable()
				)
				.AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IAsyncEnumerable<TOuter> outer, Option<IAsyncEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.Join(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
					() => new[] { Option.None<TValue>() }.AsAsyncEnumerable()
				)
				.AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IAsyncEnumerable<TOuter> outer, Option<TInner[]> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.Join(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
					() => new[] { Option.None<TValue>() }.AsAsyncEnumerable()
				)
				.AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> Join<TOuter, TInner, TKey, TValue>(this IAsyncEnumerable<TOuter> outer, Task<Option<TInner[]>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.Join(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
					() => new[] { Option.None<TValue>() }.AsAsyncEnumerable()
				)
				.AsAsyncOptionEnumerable();

		// ------------------------- //

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> OptionGroupJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> OptionGroupJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> OptionGroupJoinEnumerable.Create(outer, inner.AsEnumerable(), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, Option<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.GroupJoin(value, outerKeySelector, innerKeySelector, optionSelector),
					() => outer
						.Where(option => option.Match(_ => false, () => true))
						.Select(option => option.Match(_ => default, Option.None<TValue>))
						.Concat(new[] { Option.None<TValue>() })
						.AsOptionEnumerable()
				);

		private static async Task<IOptionEnumerable<TValue>> DoGroupJoin<TOuter, TInner, TKey, TValue>(IOptionEnumerable<TOuter> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> outer.GroupJoin(await inner, outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoGroupJoin(outer, inner, outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, Option<IAsyncEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoGroupJoin(outer, inner.MatchAsync(async value => Option.Some<IEnumerable<TInner>>(await value.AsEnumerable()), () => Task.FromResult(Option.None<IEnumerable<TInner>>())), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, Option<TInner[]> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> outer.GroupJoin(inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IOptionEnumerable<TOuter> outer, Task<Option<TInner[]>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoGroupJoin(outer, inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IEnumerable<TOuter> outer, Option<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.GroupJoin(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
					() => new[] { Option.None<TValue>() }
				)
				.AsOptionEnumerable();

		private static async Task<IOptionEnumerable<TValue>> DoGroupJoin<TOuter, TInner, TKey, TValue>(IEnumerable<TOuter> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> outer.GroupJoin(await inner, outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IEnumerable<TOuter> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoGroupJoin(outer, inner, outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IEnumerable<TOuter> outer, Option<IAsyncEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoGroupJoin(outer, inner.MatchAsync(async value => Option.Some<IEnumerable<TInner>>(await value.AsEnumerable()), () => Task.FromResult(Option.None<IEnumerable<TInner>>())), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IEnumerable<TOuter> outer, Option<TInner[]> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> outer.GroupJoin(inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IEnumerable<TOuter> outer, Task<Option<TInner[]>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoGroupJoin(outer, inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		private static Task<IEnumerable<Option<TValue>>> DoGroupJoin<TOuter, TInner, TKey, TValue>(Task<IEnumerable<TOuter>> outer, Option<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.MatchAsync
				(
					value => outer.GroupJoin(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
					() => Task.FromResult(new[] { Option.None<TValue>() }.AsEnumerable())
				);

		private static Task<IEnumerable<Option<TValue>>> DoGroupJoin<TOuter, TInner, TKey, TValue>(Task<IEnumerable<TOuter>> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.MatchAsync
				(
					value => outer.GroupJoin(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
					() => Task.FromResult(new[] { Option.None<TValue>() }.AsEnumerable())
				);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this Task<IEnumerable<TOuter>> outer, Option<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoGroupJoin(outer, inner, outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this Task<IEnumerable<TOuter>> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoGroupJoin(outer, inner, outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this Task<IEnumerable<TOuter>> outer, Option<IAsyncEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoGroupJoin(outer, inner.MatchAsync(async value => Option.Some<IEnumerable<TInner>>(await value.AsEnumerable()), () => Task.FromResult(Option.None<IEnumerable<TInner>>())), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this Task<IEnumerable<TOuter>> outer, Option<TInner[]> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoGroupJoin(outer, inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this Task<IEnumerable<TOuter>> outer, Task<Option<TInner[]>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoGroupJoin(outer, inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		// ------------------------- //

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> AsyncOptionGroupJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> AsyncOptionGroupJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> AsyncOptionGroupJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, Option<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.GroupJoin(value, outerKeySelector, innerKeySelector, optionSelector),
					() => outer
						.Where(option => option.Match(_ => false, () => true))
						.Select(option => option.Match(_ => default, Option.None<TValue>))
						.Concat(new[] { Option.None<TValue>() })
						.AsAsyncOptionEnumerable()
				);

		private static async Task<IAsyncOptionEnumerable<TValue>> DoGroupJoin<TOuter, TInner, TKey, TValue>(IAsyncOptionEnumerable<TOuter> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> outer.GroupJoin(await inner, outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> DoGroupJoin(outer, inner, outerKeySelector, innerKeySelector, optionSelector).AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, Option<IAsyncEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.GroupJoin(value, outerKeySelector, innerKeySelector, optionSelector),
					() => outer
						.Where(option => option.Match(_ => false, () => true))
						.Select(option => option.Match(_ => default, Option.None<TValue>))
						.Concat(new[] { Option.None<TValue>() })
						.AsAsyncOptionEnumerable()
				);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, Option<TInner[]> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> outer.GroupJoin(inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IAsyncOptionEnumerable<TOuter> outer, Task<Option<TInner[]>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> outer.GroupJoin(inner.Map(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, optionSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IAsyncEnumerable<TOuter> outer, Option<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.GroupJoin(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
					() => new[] { Option.None<TValue>() }.AsAsyncEnumerable()
				)
				.AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IAsyncEnumerable<TOuter> outer, Task<Option<IEnumerable<TInner>>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.GroupJoin(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
					() => new[] { Option.None<TValue>() }.AsAsyncEnumerable()
				)
				.AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IAsyncEnumerable<TOuter> outer, Option<IAsyncEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
				=> inner
					.Match
					(
						value => outer.GroupJoin(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
						() => new[] { Option.None<TValue>() }.AsAsyncEnumerable()
					)
					.AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IAsyncEnumerable<TOuter> outer, Option<TInner[]> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.GroupJoin(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
					() => new[] { Option.None<TValue>() }.AsAsyncEnumerable()
				)
				.AsAsyncOptionEnumerable();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<TValue> GroupJoin<TOuter, TInner, TKey, TValue>(this IAsyncEnumerable<TOuter> outer, Task<Option<TInner[]>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TValue> optionSelector)
			where TOuter : notnull
			where TValue : notnull
			=> inner
				.Match
				(
					value => outer.GroupJoin(value, outerKeySelector, innerKeySelector, optionSelector).Select(Option.Some),
					() => new[] { Option.None<TValue>() }.AsAsyncEnumerable()
				)
				.AsAsyncOptionEnumerable();
	}
}