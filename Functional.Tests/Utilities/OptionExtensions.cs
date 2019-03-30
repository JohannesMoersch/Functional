using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static class OptionExtensions
	{
		public static Option<TSuccess[]> TakeUntilNone<TSuccess>(this IEnumerable<Option<TSuccess>> source)
		{
			TSuccess[] successes;

			if (source is ICollection<Option<TSuccess>> collection)
				successes = new TSuccess[collection.Count];
			else if (source is IReadOnlyCollection<Option<TSuccess>> readOnlyCollecton)
				successes = new TSuccess[readOnlyCollecton.Count];
			else
				successes = new TSuccess[4];

			int index = 0;
			foreach (var value in source)
			{
				if (value.Match(_ => false, () => true))
					return Option.None<TSuccess[]>();

				if (index == successes.Length)
				{
					var old = successes;
					successes = new TSuccess[old.Length * 2];
					Array.Copy(old, successes, old.Length);
				}
				successes[index++] = value.ValueOrDefault();
			}

			if (index != successes.Length)
			{
				var old = successes;
				successes = new TSuccess[index];
				Array.Copy(old, successes, index);
			}

			return Option.Some(successes);
		}

		public static async Task<Option<TSuccess[]>> TakeUntilNone<TSuccess>(this IAsyncEnumerable<Option<TSuccess>> source)
		{
			var successes = new TSuccess[4];

			var enumerator = source.GetEnumerator();

			var index = 0;
			while (await enumerator.MoveNext())
			{
				var value = enumerator.Current;

				if (value.Match(_ => false, () => true))
					return Option.None<TSuccess[]>();

				if (index == successes.Length)
				{
					var old = successes;
					successes = new TSuccess[old.Length * 2];
					Array.Copy(old, successes, old.Length);
				}
				successes[index++] = value.ValueOrDefault();
			}

			if (index != successes.Length)
			{
				var old = successes;
				successes = new TSuccess[index];
				Array.Copy(old, successes, index);
			}

			return Option.Some(successes);
		}
	}
}
