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
	public static class UnionPartitionExtensions
	{
		private class ReplayableEnumerableData<T>
		{
			private readonly IEnumerator<T> _enumerator;

			private readonly List<T> _values = new List<T>();

			private bool _complete;

			public ReplayableEnumerableData(IEnumerator<T> enumerator)
				=> _enumerator = enumerator;

			public bool TryGetValue(int index, out T value)
			{
				if (index < _values.Count)
				{
					value = _values[index];
					return true;
				}

				if (!_complete)
				{
					if (_enumerator.MoveNext())
					{
						value = _enumerator.Current;
						_values.Add(value);
						return true;
					}
					else
						_complete = true;
				}

				value = default;
				return false;
			}
		}

		private class ReplayableEnumerator<T> : IEnumerator<T>
		{
			public T Current { get; private set; }

			object IEnumerator.Current => Current;

			private readonly ReplayableEnumerableData<T> _data;

			private int _index = 0;

			public ReplayableEnumerator(ReplayableEnumerableData<T> data)
				=> _data = data;

			public void Dispose() { }

			public bool MoveNext()
			{
				if (_index >= 0 && _data.TryGetValue(_index++, out var value))
				{
					Current = value;
					return true;
				}

				Current = default;
				return false;
			}

			public void Reset()
				=> _index = 0;
		}

		private class ReplayableEnumerable<T> : IEnumerable<T>
		{
			private readonly ReplayableEnumerableData<T> _data;

			public ReplayableEnumerable(IEnumerable<T> data)
				=> _data = new ReplayableEnumerableData<T>(data.GetEnumerator());

			public IEnumerator<T> GetEnumerator()
				=> new ReplayableEnumerator<T>(_data);

			IEnumerator IEnumerable.GetEnumerator()
				=> new ReplayableEnumerator<T>(_data);
		}

		public static UnionPartition<TOne, TTwo> Partition<TUnionType, TUnionDefinition, TOne, TTwo>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>>(source);

			return new UnionPartition<TOne, TTwo>
			(
				values.WhereOne(),
				values.WhereTwo()
			);
		}

		public static async Task<UnionPartition<TOne, TTwo>> Partition<TUnionType, TUnionDefinition, TOne, TTwo>(this Task<IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>>(await source);

			return new UnionPartition<TOne, TTwo>
			(
				values.WhereOne(),
				values.WhereTwo()
			);
		}

		public static UnionPartition<TOne, TTwo, TThree> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>>(source);

			return new UnionPartition<TOne, TTwo, TThree>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree()
			);
		}

		public static async Task<UnionPartition<TOne, TTwo, TThree>> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this Task<IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>>(await source);

			return new UnionPartition<TOne, TTwo, TThree>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree()
			);
		}

		public static UnionPartition<TOne, TTwo, TThree, TFour> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>>(source);

			return new UnionPartition<TOne, TTwo, TThree, TFour>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour()
			);
		}

		public static async Task<UnionPartition<TOne, TTwo, TThree, TFour>> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this Task<IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>>(await source);

			return new UnionPartition<TOne, TTwo, TThree, TFour>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour()
			);
		}

		public static UnionPartition<TOne, TTwo, TThree, TFour, TFive> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>>(source);

			return new UnionPartition<TOne, TTwo, TThree, TFour, TFive>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour(),
				values.WhereFive()
			);
		}

		public static async Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive>> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this Task<IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>>(await source);

			return new UnionPartition<TOne, TTwo, TThree, TFour, TFive>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour(),
				values.WhereFive()
			);
		}

		public static UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>>(source);

			return new UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour(),
				values.WhereFive(),
				values.WhereSix()
			);
		}

		public static async Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this Task<IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>>(await source);

			return new UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree(),
				values.WhereFour(),
				values.WhereFive(),
				values.WhereSix()
			);
		}

		public static UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>>(source);

			return new UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
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

		public static async Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>>(await source);

			return new UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
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

		public static UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>>(source);

			return new UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
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

		public static async Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Task<IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>>(await source);

			return new UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
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
