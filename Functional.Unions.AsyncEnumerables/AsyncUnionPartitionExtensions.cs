using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class AsyncUnionPartitionExtensions
	{
		private class ReplayableAsyncEnumerableData<T>
		{
			private readonly IAsyncEnumerator<T> _enumerator;

			private readonly List<T> _values = new List<T>();

			private bool _complete;

			public ReplayableAsyncEnumerableData(IAsyncEnumerator<T> enumerator)
				=> _enumerator = enumerator;

			public async Task<(bool hasValue, T value)> TryGetValue(int index)
			{
				if (index < _values.Count)
					return (true, _values[index]);

				if (!_complete)
				{
					if (await _enumerator.MoveNext())
					{
						_values.Add(_enumerator.Current);
						return (true, _enumerator.Current);
					}
					else
						_complete = true;
				}

				return (false, default);
			}
		}

		private class ReplayableAsyncEnumerator<T> : DisposableBase, IAsyncEnumerator<T>
		{
			public T Current { get; private set; }

			private readonly ReplayableAsyncEnumerableData<T> _data;

			private int _index = 0;

			public ReplayableAsyncEnumerator(ReplayableAsyncEnumerableData<T> data)
				=> _data = data;

			protected override void DisposeResources()
			{
				throw new NotImplementedException();
			}

			public async Task<bool> MoveNext()
			{
				var value = await _data.TryGetValue(_index++);
				if (_index >= 0 && value.hasValue)
				{
					Current = value.value;
					return true;
				}

				Current = default;
				return false;
			}

			public void Reset()
				=> _index = 0;
		}

		private class ReplayableAsyncEnumerable<T> : IAsyncEnumerable<T>
		{
			private readonly ReplayableAsyncEnumerableData<T> _data;

			public ReplayableAsyncEnumerable(IAsyncEnumerable<T> data)
				=> _data = new ReplayableAsyncEnumerableData<T>(data.GetEnumerator());

			public IAsyncEnumerator<T> GetEnumerator()
				=> new ReplayableAsyncEnumerator<T>(_data);
		}

		public static AsyncUnionPartition<TOne, TTwo> Partition<TUnionType, TUnionDefinition, TOne, TTwo>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
		{
			var values = new ReplayableAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>>(source);

			return new AsyncUnionPartition<TOne, TTwo>
			(
				values.WhereOne(),
				values.WhereTwo()
			);
		}

		public static AsyncUnionPartition<TOne, TTwo, TThree> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
		{
			var values = new ReplayableAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>>(source);

			return new AsyncUnionPartition<TOne, TTwo, TThree>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree()
			);
		}

		public static AsyncUnionPartition<TOne, TTwo, TThree, TFour> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
		{
			var values = new ReplayableAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>>(source);

			return new AsyncUnionPartition<TOne, TTwo, TThree, TFour>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour()
			);
		}

		public static AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
		{
			var values = new ReplayableAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>>(source);

			return new AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour(),
				values.WhereFive()
			);
		}

		public static AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
		{
			var values = new ReplayableAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>>(source);

			return new AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour(),
				values.WhereFive(),
				values.WhereSix()
			);
		}

		public static AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
		{
			var values = new ReplayableAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>>(source);

			return new AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour(),
				values.WhereFive(),
				values.WhereSix(),
				values.WhereSeven()
			);
		}

		public static AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
		{
			var values = new ReplayableAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>>(source);

			return new AsyncUnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour(),
				values.WhereFive(),
				values.WhereSix(),
				values.WhereSeven(),
				values.WhereEight()
			);
		}
	}
}
