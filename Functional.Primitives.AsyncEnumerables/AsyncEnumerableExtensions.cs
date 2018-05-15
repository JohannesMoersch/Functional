using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class AsyncEnumerableExtensions
    {
		public static IAsyncEnumerable<T> WhereSome<T>(this IAsyncEnumerable<Option<T>> source)
			=> source
				.Where(option => option.Match(_ => true, () => false))
				.Select(option => option.Match(o => o, () => default(T)));

		public static async Task<Result<IEnumerable<TSuccess>, TFailure>> TakeUntilFailure<TSuccess, TFailure>(this IAsyncEnumerable<Result<TSuccess, TFailure>> source)
		{
			var successes = new List<TSuccess>();

			var enumerator = source.GetEnumerator();

			while (await enumerator.MoveNext())
			{
				var value = enumerator.Current;

				if (value.Match(_ => false, _ => true))
					return Result.Failure<IEnumerable<TSuccess>, TFailure>(value.Match(_ => default(TFailure), failure => failure));

				successes.Add(value.Match(success => success, _ => default(TSuccess)));
			}

			return Result.Success<IEnumerable<TSuccess>, TFailure>(successes);
		}

		public static async Task<Option<T>> TryFirst<T>(this IAsyncEnumerable<T> source)
			=> (await source.Any()) ? Option.Some(await source.First()) : Option.None<T>();

		public static async Task<Option<T>> TryFirst<T>(this IAsyncEnumerable<T> source, Func<T, bool> predicate)
			=> (await source.Any(predicate)) ? Option.Some(await source.First(predicate)) : Option.None<T>();
	}
}
