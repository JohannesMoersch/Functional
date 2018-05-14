using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class EnumerableExtensions
    {
		public static IEnumerable<T> WhereSome<T>(this IEnumerable<Option<T>> source)
			=> source
				.Where(option => option.Match(_ => true, () => false))
				.Select(option => option.Match(o => o, () => default(T)));

		public static async Task<IEnumerable<T>> WhereSome<T>(this Task<IEnumerable<Option<T>>> source)
			=> (await source)
				.Where(option => option.Match(_ => true, () => false))
				.Select(option => option.Match(o => o, () => default(T)));

		public static Result<IEnumerable<TSuccess>, TFailure> TakeUntilFailure<TSuccess, TFailure>(this IEnumerable<Result<TSuccess, TFailure>> source)
		{	
			List<TSuccess> successes;

			if (source is ICollection<Result<TSuccess, TFailure>> collection)
				successes = new List<TSuccess>(collection.Count);
			else if (source is IReadOnlyCollection<Result<TSuccess, TFailure>> readOnlyCollecton)
				successes = new List<TSuccess>(readOnlyCollecton.Count);
			else
				successes = new List<TSuccess>();	
	
			foreach (var value in source)	
			{
				if (value.Match(_ => false, _ => true))	
					return Result.Failure<IEnumerable<TSuccess>, TFailure>(value.Match(_ => default(TFailure), failure => failure));	
	
				successes.Add(value.Match(success => success, _ => default(TSuccess)));	
			}	
	
			return Result.Success<IEnumerable<TSuccess>, TFailure>(successes);	
		}

		public static async Task<Result<IEnumerable<TSuccess>, TFailure>> TakeUntilFailure<TSuccess, TFailure>(this Task<IEnumerable<Result<TSuccess, TFailure>>> source)
			=> (await source).TakeUntilFailure();

		public static async Task<Result<IEnumerable<TSuccess>, TFailure>> TakeUntilFailure<TSuccess, TFailure>(this IEnumerable<Task<Result<TSuccess, TFailure>>> source)
		{
			List<TSuccess> successes;

			if (source is ICollection<Result<TSuccess, TFailure>> collection)
				successes = new List<TSuccess>(collection.Count);
			else if (source is IReadOnlyCollection<Result<TSuccess, TFailure>> readOnlyCollecton)
				successes = new List<TSuccess>(readOnlyCollecton.Count);
			else
				successes = new List<TSuccess>();

			foreach (var valueTask in source)
			{
				var value = await valueTask;

				if (value.Match(_ => false, _ => true))
					return Result.Failure<IEnumerable<TSuccess>, TFailure>(value.Match(_ => default(TFailure), failure => failure));

				successes.Add(value.Match(success => success, _ => default(TSuccess)));
			}

			return Result.Success<IEnumerable<TSuccess>, TFailure>(successes);
		}

		public static Option<T> TryFirst<T>(this IEnumerable<T> source)
			=> source.Any() ? Option.Some(source.First()) : Option.None<T>();

		public static async Task<Option<T>> TryFirst<T>(this Task<IEnumerable<T>> source)
			=> (await source).TryFirst();

		public static Option<T> TryLast<T>(this IEnumerable<T> source)
			=> source.Any() ? Option.Some(source.Last()) : Option.None<T>();

		public static async Task<Option<T>> TryLast<T>(this Task<IEnumerable<T>> source)
			=> (await source).TryLast();

		public static Option<T> TrySingle<T>(this IEnumerable<T> source)
			=> source.Take(2).Count() == 1 ? Option.Some(source.Single()) : Option.None<T>();

		public static async Task<Option<T>> TrySingle<T>(this Task<IEnumerable<T>> source)
			=> (await source).TrySingle();
	}
}
