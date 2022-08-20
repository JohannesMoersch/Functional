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
#pragma warning disable CS8603 // Possible null reference return.
		public static IEnumerable<T> WhereSome<T>(this IEnumerable<Option<T>> source)
			where T : notnull
			=> source
				.Where(option => option.Match(_ => true, () => false))
				.Select(option => option.Match(o => o, () => default));
#pragma warning restore CS8603 // Possible null reference return.

#pragma warning disable CS8603 // Possible null reference return.
		public static async Task<IEnumerable<T>> WhereSome<T>(this Task<IEnumerable<Option<T>>> source)
			where T : notnull
			=> (await source)
				.Where(option => option.Match(_ => true, () => false))
				.Select(option => option.Match(o => o, () => default));
#pragma warning restore CS8603 // Possible null reference return.

#pragma warning disable CS8603 // Possible null reference return.
		public static Result<TSuccess[], TFailure> TakeUntilFailure<TSuccess, TFailure>(this IEnumerable<Result<TSuccess, TFailure>> source)
			where TSuccess : notnull
			where TFailure : notnull
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
#pragma warning restore CS8603 // Possible null reference return.

		public static async Task<Result<TSuccess[], TFailure>> TakeUntilFailure<TSuccess, TFailure>(this Task<IEnumerable<Result<TSuccess, TFailure>>> source)
			where TSuccess : notnull
			where TFailure : notnull
			=> (await source).TakeUntilFailure();

#pragma warning disable CS8603 // Possible null reference return.
		public static async Task<Result<TSuccess[], TFailure>> TakeUntilFailure<TSuccess, TFailure>(this IEnumerable<Task<Result<TSuccess, TFailure>>> source)
			where TSuccess : notnull
			where TFailure : notnull
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
#pragma warning restore CS8603 // Possible null reference return.

		public static Result<TSuccess[], TFailure[]> TakeAll<TSuccess, TFailure>(this IEnumerable<Result<TSuccess, TFailure>> source)
			where TSuccess : notnull
			where TFailure : notnull
		{
			TSuccess[] successes;

			if (source is ICollection<Result<TSuccess, TFailure>> collection)
				successes = new TSuccess[collection.Count];
			else if (source is IReadOnlyCollection<Result<TSuccess, TFailure>> readOnlyCollecton)
				successes = new TSuccess[readOnlyCollecton.Count];
			else
				successes = new TSuccess[4];

			List<TFailure>? failures = null;

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
			where TSuccess : notnull
			where TFailure : notnull
			=> (await source).TakeAll();

		public static async Task<Result<TSuccess[], TFailure[]>> TakeAll<TSuccess, TFailure>(this IEnumerable<Task<Result<TSuccess, TFailure>>> source)
			where TSuccess : notnull
			where TFailure : notnull
		{
			TSuccess[] successes;

			if (source is ICollection<Result<TSuccess, TFailure>> collection)
				successes = new TSuccess[collection.Count];
			else if (source is IReadOnlyCollection<Result<TSuccess, TFailure>> readOnlyCollection)
				successes = new TSuccess[readOnlyCollection.Count];
			else
				successes = new TSuccess[4];

			List<TFailure>? failures = null;

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

		public static ResultPartition<TSuccess, TFailure> Partition<TSuccess, TFailure>(this IEnumerable<Result<TSuccess, TFailure>> source)
			where TSuccess : notnull
			where TFailure : notnull
		{
			var successCollection = new List<TSuccess>();
			var failureCollection = new List<TFailure>();

			foreach (var item in source)
			{
				item.Match(
					success =>
					{
						successCollection.Add(success);
						return true;
					},
					failure =>
					{
						failureCollection.Add(failure);
						return false;
					});
			}

			return new ResultPartition<TSuccess, TFailure>(successCollection, failureCollection);
		}

		public static async Task<ResultPartition<TSuccess, TFailure>> Partition<TSuccess, TFailure>(this Task<IEnumerable<Result<TSuccess, TFailure>>> source)
			where TSuccess : notnull
			where TFailure : notnull
			=> (await source).Partition();

		public static async Task<ResultPartition<TSuccess, TFailure>> Partition<TSuccess, TFailure>(this IEnumerable<Task<Result<TSuccess, TFailure>>> source)
			where TSuccess : notnull
			where TFailure : notnull
		{
			var successCollection = new List<TSuccess>();
			var failureCollection = new List<TFailure>();

			foreach (var item in source)
			{
				(await item).Match(
					success =>
					{
						successCollection.Add(success);
						return true;
					},
					failure =>
					{
						failureCollection.Add(failure);
						return false;
					});
			}

			return new ResultPartition<TSuccess, TFailure>(successCollection, failureCollection);
		}

		public static Option<T> TryFirst<T>(this IEnumerable<T> source)
			where T : notnull
			=> source.Any() ? Option.Some(source.First()) : Option.None<T>();

		public static async Task<Option<T>> TryFirst<T>(this Task<IEnumerable<T>> source)
			where T : notnull
			=> (await source).TryFirst();

		public static Option<T> TryFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
			where T : notnull
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
			where T : notnull
			=> (await source).TryFirst(predicate);

		public static Option<T> TryLast<T>(this IEnumerable<T> source)
			where T : notnull
			=> source.Any() ? Option.Some(source.Last()) : Option.None<T>();

		public static async Task<Option<T>> TryLast<T>(this Task<IEnumerable<T>> source)
			where T : notnull
			=> (await source).TryLast();

		public static Option<T> TryLast<T>(this IEnumerable<T> source, Func<T, bool> predicate)
			where T : notnull
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
			where T : notnull
			=> (await source).TryLast(predicate);

#pragma warning disable CS8603 // Possible null reference return.
		public static async Task<Option<TValue[]>> TakeUntilNone<TValue>(this IEnumerable<Task<Option<TValue>>> source)
			where TValue : notnull
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
#pragma warning restore CS8603 // Possible null reference return.

#pragma warning disable CS8603 // Possible null reference return.
		public static Option<TValue[]> TakeUntilNone<TValue>(this IEnumerable<Option<TValue>> source)
			where TValue : notnull
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
#pragma warning restore CS8603 // Possible null reference return.

		public static async Task<Option<TValue[]>> TakeUntilNone<TValue>(this Task<IEnumerable<Option<TValue>>> source)
			where TValue : notnull
			=> (await source).TakeUntilNone();
	}
}
