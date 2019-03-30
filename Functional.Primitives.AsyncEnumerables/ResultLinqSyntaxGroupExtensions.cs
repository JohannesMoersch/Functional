using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ResultLinqSyntaxGroupExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<IGrouping<TKey, TSuccess>, TFailure> GroupBy<TKey, TSuccess, TFailure>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, TKey> keySelector)
			=> new ResultGroupByEnumerable<TKey, TSuccess, TSuccess, TFailure>(source, keySelector, _ => _);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IResultEnumerable<IGrouping<TKey, TElement>, TFailure> GroupBy<TKey, TSuccess, TElement, TFailure>(this IResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, TKey> keySelector, Func<TSuccess, TElement> elementSelector)
			=> new ResultGroupByEnumerable<TKey, TSuccess, TElement, TFailure>(source, keySelector, elementSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<IGrouping<TKey, TSuccess>, TFailure> GroupBy<TKey, TSuccess, TFailure>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, TKey> keySelector)
			=> new AsyncResultGroupByEnumerable<TKey, TSuccess, TSuccess, TFailure>(source, keySelector, _ => _);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncResultEnumerable<IGrouping<TKey, TElement>, TFailure> GroupBy<TKey, TSuccess, TElement, TFailure>(this IAsyncResultEnumerable<TSuccess, TFailure> source, Func<TSuccess, TKey> keySelector, Func<TSuccess, TElement> elementSelector)
			=> new AsyncResultGroupByEnumerable<TKey, TSuccess, TElement, TFailure>(source, keySelector, elementSelector);

		private class ResultGroupByEnumerable<TKey, TSuccess, TElement, TFailure> : IResultEnumerable<IGrouping<TKey, TElement>, TFailure>
		{
			private readonly IResultEnumerable<TSuccess, TFailure> _successEnumerable;
			private readonly Func<TSuccess, TKey> _keySelector;
			private readonly Func<TSuccess, TElement> _elementSelector;

			public ResultGroupByEnumerable(IResultEnumerable<TSuccess, TFailure> successEnumerable, Func<TSuccess, TKey> keySelector, Func<TSuccess, TElement> elementSelector)
			{
				_successEnumerable = successEnumerable;
				_keySelector = keySelector;
				_elementSelector = elementSelector;
			}

			public IEnumerator<Result<IGrouping<TKey, TElement>, TFailure>> GetEnumerator()
				=> new ResultGroupByEnumerator<TKey, TSuccess, TElement, TFailure>(_successEnumerable.GetEnumerator(), _keySelector, _elementSelector);

			IEnumerator IEnumerable.GetEnumerator()
				=> new ResultGroupByEnumerator<TKey, TSuccess, TElement, TFailure>(_successEnumerable.GetEnumerator(), _keySelector, _elementSelector);
		}

		private class ResultGroupByEnumerator<TKey, TSuccess, TElement, TFailure> : IEnumerator<Result<IGrouping<TKey, TElement>, TFailure>>
		{
			private class Grouping : IGrouping<TKey, TElement>
			{
				private readonly IReadOnlyList<TElement> _list;

				public TKey Key { get; }

				public Grouping(TKey key, IReadOnlyList<TElement> list)
				{
					Key = key;
					_list = list;
				}

				public IEnumerator<TElement> GetEnumerator()
					=> _list.GetEnumerator();

				IEnumerator IEnumerable.GetEnumerator()
					=> _list.GetEnumerator();
			}

			private readonly IEnumerator<Result<TSuccess, TFailure>> _successEnumerator;
			private readonly Func<TSuccess, TKey> _keySelector;
			private readonly Func<TSuccess, TElement> _elementSelector;

			private readonly Dictionary<TKey, List<TElement>> _groupings = new Dictionary<TKey, List<TElement>>();

			private IEnumerator<KeyValuePair<TKey, List<TElement>>> _groupingEnumerator;

			public Result<IGrouping<TKey, TElement>, TFailure> Current { get; private set; }

			object IEnumerator.Current => Current;

			public ResultGroupByEnumerator(IEnumerator<Result<TSuccess, TFailure>> successEnumerator, Func<TSuccess, TKey> keySelector, Func<TSuccess, TElement> elementSelector)
			{
				_successEnumerator = successEnumerator;
				_keySelector = keySelector;
				_elementSelector = elementSelector;
			}

			public void Dispose()
				=> _groupingEnumerator?.Dispose();

			public bool MoveNext()
			{
				if (_groupingEnumerator == null)
				{
					while (_successEnumerator.MoveNext())
					{
						var isFailure = _successEnumerator
							.Current
							.Select(success => (key: _keySelector.Invoke(success), element: _elementSelector.Invoke(success)))
							.Match
							(
								success =>
								{
									if (!_groupings.TryGetValue(success.key, out var items))
									{
										items = new List<TElement>();
										_groupings.Add(success.key, items);
									}

									items.Add(success.element);

									return false;
								},
								failure =>
								{
									Current = Result.Failure<IGrouping<TKey, TElement>, TFailure>(failure);

									return true;
								}
							);

						if (isFailure)
							return true;
					}

					_groupingEnumerator = _groupings.GetEnumerator();
				}

				while (_groupingEnumerator.MoveNext())
				{
					Current = Result.Success<IGrouping<TKey, TElement>, TFailure>(new Grouping(_groupingEnumerator.Current.Key, _groupingEnumerator.Current.Value));

					return true;
				}

				return false;
			}

			public void Reset()
			{
				_successEnumerator.Reset();
				_groupings.Clear();
				_groupingEnumerator = null;
				Current = default;
			}
		}

		private class AsyncResultGroupByEnumerable<TKey, TSuccess, TElement, TFailure> : IAsyncResultEnumerable<IGrouping<TKey, TElement>, TFailure>
		{
			private readonly IAsyncResultEnumerable<TSuccess, TFailure> _successEnumerable;
			private readonly Func<TSuccess, TKey> _keySelector;
			private readonly Func<TSuccess, TElement> _elementSelector;

			public AsyncResultGroupByEnumerable(IAsyncResultEnumerable<TSuccess, TFailure> successEnumerable, Func<TSuccess, TKey> keySelector, Func<TSuccess, TElement> elementSelector)
			{
				_successEnumerable = successEnumerable;
				_keySelector = keySelector;
				_elementSelector = elementSelector;
			}

			public IAsyncEnumerator<Result<IGrouping<TKey, TElement>, TFailure>> GetEnumerator()
				=> new AsyncResultGroupByEnumerator<TKey, TSuccess, TElement, TFailure>(_successEnumerable.GetEnumerator(), _keySelector, _elementSelector);
		}

		private class AsyncResultGroupByEnumerator<TKey, TSuccess, TElement, TFailure> : IAsyncEnumerator<Result<IGrouping<TKey, TElement>, TFailure>>
		{
			private class Grouping : IGrouping<TKey, TElement>
			{
				private readonly IReadOnlyList<TElement> _list;

				public TKey Key { get; }

				public Grouping(TKey key, IReadOnlyList<TElement> list)
				{
					Key = key;
					_list = list;
				}

				public IEnumerator<TElement> GetEnumerator()
					=> _list.GetEnumerator();

				IEnumerator IEnumerable.GetEnumerator()
					=> _list.GetEnumerator();
			}

			private readonly IAsyncEnumerator<Result<TSuccess, TFailure>> _successEnumerator;
			private readonly Func<TSuccess, TKey> _keySelector;
			private readonly Func<TSuccess, TElement> _elementSelector;

			private readonly Dictionary<TKey, List<TElement>> _groupings = new Dictionary<TKey, List<TElement>>();

			private IEnumerator<KeyValuePair<TKey, List<TElement>>> _groupingEnumerator;

			public Result<IGrouping<TKey, TElement>, TFailure> Current { get; private set; }

			public AsyncResultGroupByEnumerator(IAsyncEnumerator<Result<TSuccess, TFailure>> successEnumerator, Func<TSuccess, TKey> keySelector, Func<TSuccess, TElement> elementSelector)
			{
				_successEnumerator = successEnumerator;
				_keySelector = keySelector;
				_elementSelector = elementSelector;
			}

			public void Dispose()
				=> _groupingEnumerator?.Dispose();

			public async Task<bool> MoveNext()
			{
				if (_groupingEnumerator == null)
				{
					while (await _successEnumerator.MoveNext())
					{
						var isFailure = _successEnumerator
							.Current
							.Select(success => (key: _keySelector.Invoke(success), element: _elementSelector.Invoke(success)))
							.Match
							(
								success =>
								{
									if (!_groupings.TryGetValue(success.key, out var items))
									{
										items = new List<TElement>();
										_groupings.Add(success.key, items);
									}

									items.Add(success.element);

									return false;
								},
								failure =>
								{
									Current = Result.Failure<IGrouping<TKey, TElement>, TFailure>(failure);

									return true;
								}
							);

						if (isFailure)
							return true;
					}

					_groupingEnumerator = _groupings.GetEnumerator();
				}

				while (_groupingEnumerator.MoveNext())
				{
					Current = Result.Success<IGrouping<TKey, TElement>, TFailure>(new Grouping(_groupingEnumerator.Current.Key, _groupingEnumerator.Current.Value));

					return true;
				}

				return false;
			}
		}
	}
}
