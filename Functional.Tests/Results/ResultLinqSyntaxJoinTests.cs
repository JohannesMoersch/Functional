using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Tests.Results
{
	public static class ResultExtensions
	{
		public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IAsyncEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		// ------------------------- //

		public static IResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Task<IEnumerable<TInner>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Result<IEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Result<IAsyncEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Result<TInner[], TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IResultEnumerable<TOuter, TFailure> outer, Task<Result<TInner[], TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IEnumerable<TOuter> outer, Result<IEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IEnumerable<TOuter> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IEnumerable<TOuter> outer, Result<IAsyncEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IEnumerable<TOuter> outer, Result<TInner[], TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this IEnumerable<TOuter> outer, Task<Result<TInner[], TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this Task<IEnumerable<TOuter>> outer, Result<IEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this Task<IEnumerable<TOuter>> outer, Task<Result<IEnumerable<TInner>, TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this Task<IEnumerable<TOuter>> outer, Result<IAsyncEnumerable<TInner>, TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this Task<IEnumerable<TOuter>> outer, Result<TInner[], TFailure> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncResultEnumerable<TResult, TFailure> Join<TOuter, TInner, TKey, TResult, TFailure>(this Task<IEnumerable<TOuter>> outer, Task<Result<TInner[], TFailure>> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
			=> throw new NotImplementedException();

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

		public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

		public static IAsyncEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this Task<IEnumerable<TOuter>> outer, IAsyncEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
			=> throw new NotImplementedException();

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

	public class ResultLinqSyntaxJoinTests
	{
		public class StandardData : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator() => new List<object[]>() 
			{
				new object[] { new[] { 0, 1 }, new[] { 4, 5, 6 }, new (int, int)?[] { (0, 4), (0, 6), (1, 5) } },
				new object[] { new[] { 7, 8, 9 }, new[] { 4, 5, 6 }, new (int, int)?[0] },
				new object[] { new int[0], new[] { 4, 5, 6 }, new (int, int)?[0] },
				new object[] { new[] { 0, 1 }, new int[0], new (int, int)?[0] }

			}.GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		public class FailureData : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator() => new List<object[]>()
			{
				new object[] { null, new[] { 4, 5, 6 }, new (int, int)?[] { null } },
				new object[] { new[] { 0, 1 }, null, new (int, int)?[] { null } },
				new object[] { null, null, new (int, int)?[] { null, null } }
			}.GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		private static readonly Func<IEnumerable<int>, IEnumerable<int>> _source = values => values;

		private static readonly Func<IEnumerable<int>, Task<IEnumerable<int>>> _taskSource = values => Task.FromResult(values);

		private static readonly Func<IEnumerable<int>, IAsyncEnumerable<int>> _asyncSource = values => values.AsAsyncEnumerable();

		private static readonly Func<IEnumerable<int>, IResultEnumerable<int, string>> _resultSource = 
			values =>
				from value in Result.Create(values != null, () => values, () => "Failure")
				from result in value
				select result;

		private static readonly Func<IEnumerable<int>, IAsyncResultEnumerable<int, string>> _asyncResultSource =
			values => 
				from value in Result.Create(values != null, () => Task.FromResult(values), () => Task.FromResult("Failure"))
				from result in value
				select result;

		private static readonly Func<IEnumerable<int>, IEnumerable<int>> _join = values => values;

		private static readonly Func<IEnumerable<int>, Task<IEnumerable<int>>> _taskJoin = values => Task.FromResult(values);

		private static readonly Func<IEnumerable<int>, IAsyncEnumerable<int>> _asyncJoin = values => values.AsAsyncEnumerable();

		private static readonly Func<IEnumerable<int>, Result<IEnumerable<int>, string>> _resultJoin = values => Result.Create(values != null, () => values, () => "Failure");

		private static readonly Func<IEnumerable<int>, Task<Result<IEnumerable<int>, string>>> _taskResultJoin = values => Result.Create(values != null, () => Task.FromResult(values), () => Task.FromResult("Failure"));

		private static readonly Func<IEnumerable<int>, Result<IAsyncEnumerable<int>, string>> _asyncResultJoin = values => Result.Create(values != null, () => values.AsAsyncEnumerable(), () => "Failure");

		private static readonly Func<IEnumerable<int>, Result<int[], string>> _resultJoinArray = values => Result.Create(values != null, () => values.ToArray(), () => "Failure");

		private static readonly Func<IEnumerable<int>, Task<Result<int[], string>>> _taskResultJoinArray = values => Result.Create(values != null, () => Task.FromResult(values.ToArray()), () => Task.FromResult("Failure"));

		private static readonly Func<IEnumerable<(int, int)?>, IEnumerable<(int, int)>> _output = values => values.Select(i => i ?? default);

		private static readonly Func<IEnumerable<(int, int)?>, IEnumerable<Result<(int, int), string>>> _resultOutput = values => values.Select(i => Option.FromNullable(i).ToResult(() => "Failure"));

		[Theory]
		[ClassData(typeof(StandardData))]
		public void EnumerableJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task EnumerableJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task EnumerableJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public void EnumerableJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task EnumerableJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task EnumerableJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public void EnumerableJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task EnumerableJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task TaskEnumerableJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task TaskEnumerableJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task TaskEnumerableJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task TaskEnumerableJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task TaskEnumerableJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task TaskEnumerableJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task TaskEnumerableJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task TaskEnumerableJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task AsyncEnumerableJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task AsyncEnumerableJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task AsyncEnumerableJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncEnumerableJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncEnumerableJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncEnumerableJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncEnumerableJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncEnumerableJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public void ResultEnumerableJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task ResultEnumerableJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task ResultEnumerableJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public void ResultEnumerableJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task ResultEnumerableJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task ResultEnumerableJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public void ResultEnumerableJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task ResultEnumerableJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2
				select (sourceValue, joinValue)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public void EnumerableGroupJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task EnumerableGroupJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task EnumerableGroupJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public void EnumerableGroupJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task EnumerableGroupJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task EnumerableGroupJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public void EnumerableGroupJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task EnumerableGroupJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _source.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task TaskEnumerableGroupJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task TaskEnumerableGroupJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task TaskEnumerableGroupJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task TaskEnumerableGroupJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task TaskEnumerableGroupJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task TaskEnumerableGroupJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task TaskEnumerableGroupJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task TaskEnumerableGroupJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _taskSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task AsyncEnumerableGroupJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task AsyncEnumerableGroupJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		public Task AsyncEnumerableGroupJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_output.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncEnumerableGroupJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncEnumerableGroupJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncEnumerableGroupJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncEnumerableGroupJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncEnumerableGroupJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public void ResultEnumerableGroupJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task ResultEnumerableGroupJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task ResultEnumerableGroupJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public void ResultEnumerableGroupJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task ResultEnumerableGroupJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task ResultEnumerableGroupJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public void ResultEnumerableGroupJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task ResultEnumerableGroupJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _resultSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableGroupJoinedAgainstEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _join.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableGroupJoinedAgainstTaskEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _taskJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableGroupJoinedAgainstAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _asyncJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableGroupJoinedAgainstResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _resultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableGroupJoinedAgainstTaskResultOfEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _taskResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableGroupJoinedAgainstResultOfAsyncEnumerable(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _asyncResultJoin.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableGroupJoinedAgainstResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _resultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));

		[Theory]
		[ClassData(typeof(StandardData))]
		[ClassData(typeof(FailureData))]
		public Task AsyncResultEnumerableGroupJoinedAgainstTaskResultOfArray(IEnumerable<int> source, IEnumerable<int> joiner, IEnumerable<(int, int)?> output)
			=>
			(
				from sourceValue in _asyncResultSource.Invoke(source)
				join joinValue in _taskResultJoinArray.Invoke(joiner) on sourceValue equals joinValue % 2 into joinedSet
				from value in joinedSet
				select (sourceValue, value)
			)
			.Should()
			.BeEquivalentTo(_resultOutput.Invoke(output));
	}
}
