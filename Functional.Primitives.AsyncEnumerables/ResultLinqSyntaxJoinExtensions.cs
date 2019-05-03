using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static class ResultLinqSyntaxJoinExtensions
	{
		private static class ResultJoinEnumerable
		{
			public static IResultEnumerable<TResult, TFailure> Create<TOuter, TInner, TKey, TResult, TFailure>(IResultEnumerable<TOuter, TFailure> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
				=> new ResultJoinEnumerable<TOuter, TInner, TKey, TResult, TFailure>(outer, inner, outerKeySelector, innerKeySelector, resultSelector)
					.SelectMany(result => result.Match(success => success.Select(value => Result.Success<TResult, TFailure>(value)), failure => new[] { Result.Failure<TResult, TFailure>(failure) }))
					.AsResultEnumerable();

			public static async Task<IResultEnumerable<TResult, TFailure>> Create<TOuter, TInner, TKey, TResult, TFailure>(IResultEnumerable<TOuter, TFailure> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
				=> new ResultJoinEnumerable<TOuter, TInner, TKey, TResult, TFailure>(outer, await inner, outerKeySelector, innerKeySelector, resultSelector)
					.SelectMany(result => result.Match(success => success.Select(value => Result.Success<TResult, TFailure>(value)), failure => new[] { Result.Failure<TResult, TFailure>(failure) }))
					.AsResultEnumerable();
		}

		private class ResultJoinEnumerable<TOuter, TInner, TKey, TResult, TFailure> : IResultEnumerable<IEnumerable<TResult>, TFailure>
		{
			public readonly IResultEnumerable<TOuter, TFailure> _outer;
			public readonly IEnumerable<TInner> _inner;
			public readonly Func<TOuter, TKey> _outerKeySelector;
			public readonly Func<TInner, TKey> _innerKeySelector;
			public readonly Func<TOuter, TInner, TResult> _resultSelector;

			public ResultJoinEnumerable(IResultEnumerable<TOuter, TFailure> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			{
				_outer = outer ?? throw new ArgumentNullException(nameof(outer));
				_inner = inner ?? throw new ArgumentNullException(nameof(inner));
				_outerKeySelector = outerKeySelector ?? throw new ArgumentNullException(nameof(outerKeySelector));
				_innerKeySelector = innerKeySelector ?? throw new ArgumentNullException(nameof(innerKeySelector));
				_resultSelector = resultSelector ?? throw new ArgumentNullException(nameof(resultSelector));
			}

			public IEnumerator<Result<IEnumerable<TResult>, TFailure>> GetEnumerator()
				=> new ResultJoinEnumerator<TOuter, TInner, TKey, TResult, TFailure>(_outer.GetEnumerator(), _inner, _outerKeySelector, _innerKeySelector, _resultSelector);

			IEnumerator IEnumerable.GetEnumerator()
				=> GetEnumerator();
		}

		private class ResultJoinEnumerator<TOuter, TInner, TKey, TResult, TFailure> : IEnumerator<Result<IEnumerable<TResult>, TFailure>>
		{
			private readonly IEnumerator<Result<TOuter, TFailure>> _outer;
			private readonly IEnumerable<TInner> _inner;
			private readonly Func<TOuter, TKey> _outerKeySelector;
			private readonly Func<TInner, TKey> _innerKeySelector;
			private readonly Func<TOuter, TInner, TResult> _resultSelector;

			public Result<IEnumerable<TResult>, TFailure> Current { get; private set; }

			object IEnumerator.Current => Current;

			private ILookup<TKey, TInner> _lookup;
			private ILookup<TKey, TInner> Lookup => _lookup ?? (_lookup = _inner.ToLookup(_innerKeySelector));

			public ResultJoinEnumerator(IEnumerator<Result<TOuter, TFailure>> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			{
				_outer = outer ?? throw new ArgumentNullException(nameof(outer));
				_inner = inner ?? throw new ArgumentNullException(nameof(inner));
				_outerKeySelector = outerKeySelector ?? throw new ArgumentNullException(nameof(outerKeySelector));
				_innerKeySelector = innerKeySelector ?? throw new ArgumentNullException(nameof(innerKeySelector));
				_resultSelector = resultSelector ?? throw new ArgumentNullException(nameof(resultSelector));
			}

			public void Dispose()
				=> _outer.Dispose();

			public bool MoveNext()
			{
				if (_outer.MoveNext())
				{
					Current = _outer
					   .Current
					   .Select(outerValue => Lookup[_outerKeySelector.Invoke(outerValue)].Select(innerValue => _resultSelector.Invoke(outerValue, innerValue)));

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

		// ------------------------- //

		private static async Task<IEnumerable<TResult>> DoJoin<TOuter, TInner, TKey, TResult>(Task<IEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> (await outer).Join(await inner, outerKeySelector, innerKeySelector, resultSelector);

		public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> DoJoin(Task.FromResult(outer), inner.AsEnumerable(), outerKeySelector, innerKeySelector, resultSelector).AsAsyncEnumerable();

		public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> DoJoin(outer, inner.AsEnumerable(), outerKeySelector, innerKeySelector, resultSelector).AsAsyncEnumerable();

		public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		// ------------------------- //

		public static IResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> ResultJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, resultSelector);

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> ResultJoinEnumerable.Create(outer, inner, outerKeySelector, innerKeySelector, resultSelector).AsAsyncResultEnumerable();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> ResultJoinEnumerable.Create(outer, inner.AsEnumerable(), outerKeySelector, innerKeySelector, resultSelector).AsAsyncResultEnumerable();

		public static IResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Result<IEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> inner
				.Match
				(
					success => outer.Join(success, outerKeySelector, innerKeySelector, resultSelector),
					failure => outer
						.Where(result => result.Match(_ => false, f => true))
						.Select(result => result.Match(_ => default, Result.Failure<TResult, TFailure>))
						.Concat(new[] { Result.Failure<TResult, TFailure>(failure) })
						.AsResultEnumerable()
				);

		private static async Task<IResultEnumerable<TResult, TFailure>> DoJoin<TOuter, TInner, TKey, TResult, TFailure>(IResultEnumerable<TOuter, TFailure> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> outer.Join(await inner, outerKeySelector, innerKeySelector, resultSelector);

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> DoJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector).AsAsyncResultEnumerable();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Result<IAsyncEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> DoJoin(outer, inner.MatchAsync(async success => Result.Success<IEnumerable<TInner>, TFailure>(await success.AsEnumerable()), failure => Task.FromResult(Result.Failure<IEnumerable<TInner>, TFailure>(failure))), outerKeySelector, innerKeySelector, resultSelector).AsAsyncResultEnumerable();

		public static IResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Result<TInner[], TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> outer.Join(inner.Select(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, resultSelector);

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Task<Result<TInner[], TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> DoJoin(outer, inner.Select(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, resultSelector).AsAsyncResultEnumerable();

		public static IResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IEnumerable<TOuter> outer, Result<IEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> inner
				.Match
				(
					success => outer.Join(success, outerKeySelector, innerKeySelector, resultSelector).Select(Result.Success<TResult, TFailure>),
					failure => new[] { Result.Failure<TResult, TFailure>(failure) }
				)
				.AsResultEnumerable();

		private static async Task<IResultEnumerable<TResult, TFailure>> DoJoin<TOuter, TInner, TKey, TResult, TFailure>(IEnumerable<TOuter> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> outer.Join(await inner, outerKeySelector, innerKeySelector, resultSelector);

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IEnumerable<TOuter> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> DoJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector).AsAsyncResultEnumerable();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IEnumerable<TOuter> outer, Result<IAsyncEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> DoJoin(outer, inner.MatchAsync(async success => Result.Success<IEnumerable<TInner>, TFailure>(await success.AsEnumerable()), failure => Task.FromResult(Result.Failure<IEnumerable<TInner>, TFailure>(failure))), outerKeySelector, innerKeySelector, resultSelector).AsAsyncResultEnumerable();

		public static IResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IEnumerable<TOuter> outer, Result<TInner[], TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> outer.Join(inner.Select(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, resultSelector);

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IEnumerable<TOuter> outer, Task<Result<TInner[], TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> DoJoin(outer, inner.Select(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, resultSelector).AsAsyncResultEnumerable();

		public static Task<IEnumerable<Result<TResult, TFailure>>> DoJoin<TOuter, TInner, TKey, TResult, TFailure>(Task<IEnumerable<TOuter>> outer, Result<IEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> inner
				.MatchAsync
				(
					success => outer.Join(success, outerKeySelector, innerKeySelector, resultSelector).Select(Result.Success<TResult, TFailure>),
					failure => Task.FromResult(new[] { Result.Failure<TResult, TFailure>(failure) }.AsEnumerable())
				);

		public static Task<IEnumerable<Result<TResult, TFailure>>> DoJoin<TOuter, TInner, TKey, TResult, TFailure>(Task<IEnumerable<TOuter>> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> inner
				.MatchAsync
				(
					success => outer.Join(success, outerKeySelector, innerKeySelector, resultSelector).Select(Result.Success<TResult, TFailure>),
					failure => Task.FromResult(new[] { Result.Failure<TResult, TFailure>(failure) }.AsEnumerable())
				);

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this Task<IEnumerable<TOuter>> outer, Result<IEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> DoJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector).AsAsyncResultEnumerable();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this Task<IEnumerable<TOuter>> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> DoJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector).AsAsyncResultEnumerable();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this Task<IEnumerable<TOuter>> outer, Result<IAsyncEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> DoJoin(outer, inner.MatchAsync(async success => Result.Success<IEnumerable<TInner>, TFailure>(await success.AsEnumerable()), failure => Task.FromResult(Result.Failure<IEnumerable<TInner>, TFailure>(failure))), outerKeySelector, innerKeySelector, resultSelector).AsAsyncResultEnumerable();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this Task<IEnumerable<TOuter>> outer, Result<TInner[], TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> DoJoin(outer, inner.Select(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, resultSelector).AsAsyncResultEnumerable();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this Task<IEnumerable<TOuter>> outer, Task<Result<TInner[], TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> DoJoin(outer, inner.Select(arr => arr.AsEnumerable()), outerKeySelector, innerKeySelector, resultSelector).AsAsyncResultEnumerable();

		// ------------------------- //

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, Result<IEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, Result<IAsyncEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, Result<TInner[], TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, Task<Result<TInner[], TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncEnumerable<TOuter> outer, Result<IEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncEnumerable<TOuter> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncEnumerable<TOuter> outer, Result<IAsyncEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncEnumerable<TOuter> outer, Result<TInner[], TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncEnumerable<TOuter> outer, Task<Result<TInner[], TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		// ------------------------- //

		private static async Task<IEnumerable<TResult>> DoGroupJoin<TOuter, TInner, TKey, TResult>(Task<IEnumerable<TOuter>> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> (await outer).GroupJoin(await inner, outerKeySelector, innerKeySelector, resultSelector);

		public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> DoGroupJoin(Task.FromResult(outer), inner.AsEnumerable(), outerKeySelector, innerKeySelector, resultSelector).AsAsyncEnumerable();

		public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> DoGroupJoin(outer, inner.AsEnumerable(), outerKeySelector, innerKeySelector, resultSelector).AsAsyncEnumerable();

		public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		// ------------------------- //

		public static IResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Result<IEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Result<IAsyncEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Result<TInner[], TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Task<Result<TInner[], TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IEnumerable<TOuter> outer, Result<IEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IEnumerable<TOuter> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IEnumerable<TOuter> outer, Result<IAsyncEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IEnumerable<TOuter> outer, Result<TInner[], TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IEnumerable<TOuter> outer, Task<Result<TInner[], TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this Task<IEnumerable<TOuter>> outer, Result<IEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this Task<IEnumerable<TOuter>> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this Task<IEnumerable<TOuter>> outer, Result<IAsyncEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this Task<IEnumerable<TOuter>> outer, Result<TInner[], TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this Task<IEnumerable<TOuter>> outer, Task<Result<TInner[], TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		// ------------------------- //

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, Result<IEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, Result<IAsyncEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, Result<TInner[], TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncResultEnumerable<TOuter, TFailure> outer, Task<Result<TInner[], TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncEnumerable<TOuter> outer, Result<IEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncEnumerable<TOuter> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncEnumerable<TOuter> outer, Result<IAsyncEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncEnumerable<TOuter> outer, Result<TInner[], TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> GroupJoin<TOuter, TInner, TKey, TResult, TFailure>(this IAsyncEnumerable<TOuter> outer, Task<Result<TInner[], TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();
	}
}