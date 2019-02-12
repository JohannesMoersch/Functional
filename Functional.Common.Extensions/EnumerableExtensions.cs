using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class EnumerableExtensions
    {
	    public static void Apply<T>(this IEnumerable<T> source, Action<T> action)
	    {
		    foreach (var item in source)
			    action(item);
	    }

		public static IEnumerable<T> WhereSome<T>(this IEnumerable<Option<T>> source)
			=> source
				.Where(option => option.Match(_ => true, () => false))
				.Select(option => option.Match(o => o, () => default));

		public static async Task<IEnumerable<T>> WhereSome<T>(this Task<IEnumerable<Option<T>>> source)
			=> (await source)
				.Where(option => option.Match(_ => true, () => false))
				.Select(option => option.Match(o => o, () => default));

		public static Result<TSuccess[], TFailure> TakeUntilFailure<TSuccess, TFailure>(this IEnumerable<Result<TSuccess, TFailure>> source)
		{	
			TSuccess[] successes;

			if (source is ICollection<Result<TSuccess, TFailure>> collection)
				successes = new TSuccess[collection.Count];
			else if (source is IReadOnlyCollection<Result<TSuccess, TFailure>> readOnlyCollecton)
				successes = new TSuccess[readOnlyCollecton.Count];
			else
				successes = new TSuccess[4];

			int index = 0;
			foreach (var value in source)	
			{
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

		public static async Task<Result<TSuccess[], TFailure>> TakeUntilFailure<TSuccess, TFailure>(this Task<IEnumerable<Result<TSuccess, TFailure>>> source)
			=> (await source).TakeUntilFailure();

		public static async Task<Result<TSuccess[], TFailure>> TakeUntilFailure<TSuccess, TFailure>(this IEnumerable<Task<Result<TSuccess, TFailure>>> source)
		{
			TSuccess[] successes;

			if (source is ICollection<Result<TSuccess, TFailure>> collection)
				successes = new TSuccess[collection.Count];
			else if (source is IReadOnlyCollection<Result<TSuccess, TFailure>> readOnlyCollecton)
				successes = new TSuccess[readOnlyCollecton.Count];
			else
				successes = new TSuccess[4];

			int index = 0;
			foreach (var valueTask in source)
			{
				var value = await valueTask;

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

		public static Option<T> TryFirst<T>(this IEnumerable<T> source)
			=> source.Any() ? Option.Some(source.First()) : Option.None<T>();

		public static async Task<Option<T>> TryFirst<T>(this Task<IEnumerable<T>> source)
			=> (await source).TryFirst();

		public static Option<T> TryFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			foreach (var element in source)
			{
				if (predicate.Invoke(element))
					return Option.Some(element);
			}

			return Option.None<T>();
		}

		public static async Task<Option<T>> TryFirst<T>(this Task<IEnumerable<T>> source, Func<T, bool> predicate)
			=> (await source).TryFirst(predicate);

		public static Option<T> TryLast<T>(this IEnumerable<T> source)
			=> source.Any() ? Option.Some(source.Last()) : Option.None<T>();

		public static async Task<Option<T>> TryLast<T>(this Task<IEnumerable<T>> source)
			=> (await source).TryLast();

		public static Option<T> TryLast<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));

			var result = Option.None<T>();

			foreach (var element in source)
			{
				if (predicate.Invoke(element))
					result = Option.Some(element);
			}

			return result;
		}

		public static async Task<Option<T>> TryLast<T>(this Task<IEnumerable<T>> source, Func<T, bool> predicate)
			=> (await source).TryLast(predicate);
	}
}
