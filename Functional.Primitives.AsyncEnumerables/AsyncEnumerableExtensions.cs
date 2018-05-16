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

		public static async Task<Result<TSuccess[], TFailure>> TakeUntilFailure<TSuccess, TFailure>(this IAsyncEnumerable<Result<TSuccess, TFailure>> source)
		{
			var successes = new TSuccess[4];

			var enumerator = source.GetEnumerator();

			var index = 0;
			while (await enumerator.MoveNext())
			{
				var value = enumerator.Current;

				if (value.Match(_ => false, _ => true))
					return Result.Failure<TSuccess[], TFailure>(value.Match(_ => default, failure => failure));

				if (index == successes.Length)
				{
					var old = successes;
					successes = new TSuccess[old.Length * 2];
					Array.Copy(old, successes, old.Length);
				}
				successes[index++] = value.Match(success => success, _ => default);
			}

			if (index != successes.Length)
			{
				var old = successes;
				successes = new TSuccess[index];
				Array.Copy(old, successes, index);
			}

			return Result.Success<TSuccess[], TFailure>(successes);
		}

		public static async Task<Option<T>> TryFirst<T>(this IAsyncEnumerable<T> source)
			=> (await source.Any()) ? Option.Some(await source.First()) : Option.None<T>();

		public static async Task<Option<T>> TryFirst<T>(this IAsyncEnumerable<T> source, Func<T, bool> predicate)
			=> (await source.Any(predicate)) ? Option.Some(await source.First(predicate)) : Option.None<T>();
	}
}
