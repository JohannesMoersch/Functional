using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	internal class BasicTaskAsyncIterator<TSource, TResult> : IAsyncEnumerator<TResult>
	{
		private readonly IAsyncEnumerator<TSource> _enumerator;
		private readonly Func<(TSource current, int index), Task<(BasicIteratorContinuationType type, TResult? current)>> _moveNext;

		private int _count;

		public TResult Current { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public BasicTaskAsyncIterator(IAsyncEnumerable<TSource> source, Func<(TSource current, int index), Task<(BasicIteratorContinuationType type, TResult? current)>> onNext)
		{
			_enumerator = (source ?? throw new ArgumentNullException(nameof(source))).GetAsyncEnumerator();
			_moveNext = onNext ?? throw new ArgumentNullException(nameof(onNext));
		}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		public ValueTask DisposeAsync()
			=> _enumerator.DisposeAsync();

		public async ValueTask<bool> MoveNextAsync()
		{
			while (await _enumerator.MoveNextAsync())
			{
				var (type, current) = await _moveNext.Invoke((_enumerator.Current, _count++));

#pragma warning disable CS8601 // Possible null reference assignment.
				switch (type)
				{
					case BasicIteratorContinuationType.Take:
						Current = current;
						return true;
					case BasicIteratorContinuationType.Skip:
						continue;
				}
#pragma warning restore CS8601 // Possible null reference assignment.
				break;
			}

			return false;
		}
	}
}
