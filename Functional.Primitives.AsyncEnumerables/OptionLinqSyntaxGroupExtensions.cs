using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class OptionLinqSyntaxGroupExtensions
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IOptionEnumerable<IGrouping<TKey, TSuccess>> GroupBy<TKey, TSuccess>(this IOptionEnumerable<TSuccess> source, Func<TSuccess, TKey> keySelector)
			=> new OptionGroupByEnumerable<TKey, TSuccess, TSuccess>(source, keySelector, _ => _);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IOptionEnumerable<IGrouping<TKey, TElement>> GroupBy<TKey, TSuccess, TElement>(this IOptionEnumerable<TSuccess> source, Func<TSuccess, TKey> keySelector, Func<TSuccess, TElement> elementSelector)
			=> new OptionGroupByEnumerable<TKey, TSuccess, TElement>(source, keySelector, elementSelector);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<IGrouping<TKey, TSuccess>> GroupBy<TKey, TSuccess>(this IAsyncOptionEnumerable<TSuccess> source, Func<TSuccess, TKey> keySelector)
			=> new AsyncOptionGroupByEnumerable<TKey, TSuccess, TSuccess>(source, keySelector, _ => _);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IAsyncOptionEnumerable<IGrouping<TKey, TElement>> GroupBy<TKey, TSuccess, TElement>(this IAsyncOptionEnumerable<TSuccess> source, Func<TSuccess, TKey> keySelector, Func<TSuccess, TElement> elementSelector)
			=> new AsyncOptionGroupByEnumerable<TKey, TSuccess, TElement>(source, keySelector, elementSelector);

		private class OptionGroupByEnumerable<TKey, TSuccess, TElement> : IOptionEnumerable<IGrouping<TKey, TElement>>
		{
			private readonly IOptionEnumerable<TSuccess> _successEnumerable;
			private readonly Func<TSuccess, TKey> _keySelector;
			private readonly Func<TSuccess, TElement> _elementSelector;

			public OptionGroupByEnumerable(IOptionEnumerable<TSuccess> successEnumerable, Func<TSuccess, TKey> keySelector, Func<TSuccess, TElement> elementSelector)
			{
				_successEnumerable = successEnumerable;
				_keySelector = keySelector;
				_elementSelector = elementSelector;
			}

			public IEnumerator<Option<IGrouping<TKey, TElement>>> GetEnumerator()
				=> new OptionGroupByEnumerator<TKey, TSuccess, TElement>(_successEnumerable.GetEnumerator(), _keySelector, _elementSelector);

			IEnumerator IEnumerable.GetEnumerator()
				=> new OptionGroupByEnumerator<TKey, TSuccess, TElement>(_successEnumerable.GetEnumerator(), _keySelector, _elementSelector);
		}

		private class OptionGroupByEnumerator<TKey, TSuccess, TElement> : IEnumerator<Option<IGrouping<TKey, TElement>>>
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

			private readonly IEnumerator<Option<TSuccess>> _successEnumerator;
			private readonly Func<TSuccess, TKey> _keySelector;
			private readonly Func<TSuccess, TElement> _elementSelector;

			private readonly Dictionary<TKey, List<TElement>> _groupings = new Dictionary<TKey, List<TElement>>();

			private IEnumerator<KeyValuePair<TKey, List<TElement>>>? _groupingEnumerator;

			public Option<IGrouping<TKey, TElement>> Current { get; private set; }

			object IEnumerator.Current => Current;

			public OptionGroupByEnumerator(IEnumerator<Option<TSuccess>> successEnumerator, Func<TSuccess, TKey> keySelector, Func<TSuccess, TElement> elementSelector)
			{
				_successEnumerator = successEnumerator;
				_keySelector = keySelector;
				_elementSelector = elementSelector;
			}

			public void Dispose()
			{
				_groupingEnumerator?.Dispose();

				_successEnumerator.Dispose();
			}

			public bool MoveNext()
			{
				if (_groupingEnumerator == null)
				{
					while (_successEnumerator.MoveNext())
					{
						var isFailure = _successEnumerator
							.Current
							.Map(success => (key: _keySelector.Invoke(success), element: _elementSelector.Invoke(success)))
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
								() =>
								{
									Current = Option.None<IGrouping<TKey, TElement>>();

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
					Current = Option.Some<IGrouping<TKey, TElement>>(new Grouping(_groupingEnumerator.Current.Key, _groupingEnumerator.Current.Value));

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

		private class AsyncOptionGroupByEnumerable<TKey, TSuccess, TElement> : IAsyncOptionEnumerable<IGrouping<TKey, TElement>>
		{
			private readonly IAsyncOptionEnumerable<TSuccess> _successEnumerable;
			private readonly Func<TSuccess, TKey> _keySelector;
			private readonly Func<TSuccess, TElement> _elementSelector;

			public AsyncOptionGroupByEnumerable(IAsyncOptionEnumerable<TSuccess> successEnumerable, Func<TSuccess, TKey> keySelector, Func<TSuccess, TElement> elementSelector)
			{
				_successEnumerable = successEnumerable;
				_keySelector = keySelector;
				_elementSelector = elementSelector;
			}

			public IAsyncEnumerator<Option<IGrouping<TKey, TElement>>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
				=> new AsyncOptionGroupByEnumerator<TKey, TSuccess, TElement>(_successEnumerable.GetAsyncEnumerator(cancellationToken), _keySelector, _elementSelector);
		}

		private class AsyncOptionGroupByEnumerator<TKey, TSuccess, TElement> : IAsyncEnumerator<Option<IGrouping<TKey, TElement>>>
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

			private readonly IAsyncEnumerator<Option<TSuccess>> _successEnumerator;
			private readonly Func<TSuccess, TKey> _keySelector;
			private readonly Func<TSuccess, TElement> _elementSelector;

			private readonly Dictionary<TKey, List<TElement>> _groupings = new Dictionary<TKey, List<TElement>>();

			private IEnumerator<KeyValuePair<TKey, List<TElement>>>? _groupingEnumerator;

			public Option<IGrouping<TKey, TElement>> Current { get; private set; }

			public AsyncOptionGroupByEnumerator(IAsyncEnumerator<Option<TSuccess>> successEnumerator, Func<TSuccess, TKey> keySelector, Func<TSuccess, TElement> elementSelector)
			{
				_successEnumerator = successEnumerator;
				_keySelector = keySelector;
				_elementSelector = elementSelector;
			}

			public ValueTask DisposeAsync()
			{
				_groupingEnumerator?.Dispose();

				return _successEnumerator.DisposeAsync();
			}

			public async ValueTask<bool> MoveNextAsync()
			{
				if (_groupingEnumerator == null)
				{
					while (await _successEnumerator.MoveNextAsync())
					{
						var isFailure = _successEnumerator
							.Current
							.Map(success => (key: _keySelector.Invoke(success), element: _elementSelector.Invoke(success)))
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
								() =>
								{
									Current = Option.None<IGrouping<TKey, TElement>>();

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
					Current = Option.Some<IGrouping<TKey, TElement>>(new Grouping(_groupingEnumerator.Current.Key, _groupingEnumerator.Current.Value));

					return true;
				}

				return false;
			}
		}
	}
}
