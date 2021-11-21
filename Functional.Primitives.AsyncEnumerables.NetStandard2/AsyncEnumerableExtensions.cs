using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class AsyncEnumerableExtensions
    {
#pragma warning disable CS8603 // Possible null reference return.
		public static IAsyncEnumerable<T> WhereSome<T>(this IAsyncEnumerable<Option<T>> source)
			=> source
				.Where(option => option.Match(_ => true, () => false))
				.Select(option => option.Match(o => o, () => default));
#pragma warning restore CS8603 // Possible null reference return.

#pragma warning disable CS8603 // Possible null reference return.
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
#pragma warning restore CS8603 // Possible null reference return.

		public static async Task<Result<TSuccess[], TFailure[]>> TakeAll<TSuccess, TFailure>(this IAsyncEnumerable<Result<TSuccess, TFailure>> source)
		{
			var successes = new TSuccess[4];

			List<TFailure>? failures = null;

			var enumerator = source.GetEnumerator();

			var index = 0;
			while (await enumerator.MoveNext())
			{
				enumerator
					.Current
					.Match
					(
						success =>
						{
							if (failures == null)
							{
								if (index == successes.Length)
								{
									var old = successes;
									successes = new TSuccess[old.Length * 2];
									Array.Copy(old, successes, old.Length);
								}
								successes[index++] = success;
							}
							return false;
						},
						failure =>
						{
							if (failures == null)
								failures = new List<TFailure>();
							failures.Add(failure);
							return false;
						}
					);
			}

			if (failures != null)
				return Result.Failure<TSuccess[], TFailure[]>(failures.ToArray());

			if (index != successes.Length)
			{
				var old = successes;
				successes = new TSuccess[index];
				Array.Copy(old, successes, index);
			}

			return Result.Success<TSuccess[], TFailure[]>(successes);
		}

		public static async Task<Option<T>> TryFirst<T>(this IAsyncEnumerable<T> source)
			=> (await source.Any()) ? Option.Some(await source.First()) : Option.None<T>();

		public static async Task<Option<T>> TryFirst<T>(this IAsyncEnumerable<T> source, Func<T, bool> predicate)
			=> (await source.Any(predicate)) ? Option.Some(await source.First(predicate)) : Option.None<T>();

#pragma warning disable CS8603 // Possible null reference return.
		public static async Task<Option<TValue[]>> TakeUntilNone<TValue>(this IAsyncEnumerable<Option<TValue>> source)
		{
			var values = new TValue[4];

			var enumerator = source.GetEnumerator();

			var index = 0;
			while (await enumerator.MoveNext())
			{
				var value = enumerator.Current;

				if (value.Match(_ => false, () => true))
					return Option.None<TValue[]>();

				if (index == values.Length)
				{
					var old = values;
					values = new TValue[old.Length * 2];
					Array.Copy(old, values, old.Length);
				}
				values[index++] = value.Match(success => success, () => default);
			}

			if (index != values.Length)
			{
				var old = values;
				values = new TValue[index];
				Array.Copy(old, values, index);
			}

			return Option.Some(values);
		}
#pragma warning restore CS8603 // Possible null reference return.
	}
}
