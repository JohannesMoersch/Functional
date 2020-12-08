using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class EnumerableExtensions
    {
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

		public static Result<TSuccess[], TFailure[]> TakeAll<TSuccess, TFailure>(this IEnumerable<Result<TSuccess, TFailure>> source)
		{
			TSuccess[] successes;

			if (source is ICollection<Result<TSuccess, TFailure>> collection)
				successes = new TSuccess[collection.Count];
			else if (source is IReadOnlyCollection<Result<TSuccess, TFailure>> readOnlyCollecton)
				successes = new TSuccess[readOnlyCollecton.Count];
			else
				successes = new TSuccess[4];

			List<TFailure> failures = null;

			int index = 0;
			foreach (var value in source)
			{
				value
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

		public static async Task<Result<TSuccess[], TFailure[]>> TakeAll<TSuccess, TFailure>(this Task<IEnumerable<Result<TSuccess, TFailure>>> source)
			=> (await source).TakeAll();

		public static async Task<Result<TSuccess[], TFailure[]>> TakeAll<TSuccess, TFailure>(this IEnumerable<Task<Result<TSuccess, TFailure>>> source)
		{
			TSuccess[] successes;

			if (source is ICollection<Result<TSuccess, TFailure>> collection)
				successes = new TSuccess[collection.Count];
			else if (source is IReadOnlyCollection<Result<TSuccess, TFailure>> readOnlyCollecton)
				successes = new TSuccess[readOnlyCollecton.Count];
			else
				successes = new TSuccess[4];

			List<TFailure> failures = null;

			int index = 0;
			foreach (var value in source)
			{
				(await value)
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

		public static async Task<Option<TValue[]>> TakeUntilNone<TValue>(this IEnumerable<Task<Option<TValue>>> source)
		{
			TValue[] values;

			if (source is ICollection<Option<TValue>> collection)
				values = new TValue[collection.Count];
			else if (source is IReadOnlyCollection<Option<TValue>> readOnlyCollecton)
				values = new TValue[readOnlyCollecton.Count];
			else
				values = new TValue[4];

			var index = 0;
			foreach (var valueTask in source)
			{
				var value = await valueTask;

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

		public static Option<TValue[]> TakeUntilNone<TValue>(this IEnumerable<Option<TValue>> source)
		{
			TValue[] values;

			if (source is ICollection<Option<TValue>> collection)
				values = new TValue[collection.Count];
			else if (source is IReadOnlyCollection<Option<TValue>> readOnlyCollecton)
				values = new TValue[readOnlyCollecton.Count];
			else
				values = new TValue[4];

			var index = 0;
			foreach (var value in source)
			{
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

		public static async Task<Option<TValue[]>> TakeUntilNone<TValue>(this Task<IEnumerable<Option<TValue>>> source)
			=> (await source).TakeUntilNone();
	}
}
