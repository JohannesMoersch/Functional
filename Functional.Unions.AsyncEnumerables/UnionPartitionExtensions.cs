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
		public static UnionPartition<TOne, TTwo> Partition<TUnionType, TUnionDefinition, TOne, TTwo>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>>(source);

			return new UnionPartition<TOne, TTwo>
			(
				values.WhereOne(),
				values.WhereTwo()
			);
		}

		public static async Task<UnionPartition<TOne, TTwo>> Partition<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionTask<IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
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
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
		{
			var values = new ReplayableEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>>(source);

			return new UnionPartition<TOne, TTwo, TThree>
			(
				values.WhereOne(),
				values.WhereTwo(),
				values.WhereThree()
			);
		}

		public static async Task<UnionPartition<TOne, TTwo, TThree>> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
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
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
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

		public static async Task<UnionPartition<TOne, TTwo, TThree, TFour>> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
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
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
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

		public static async Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive>> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
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
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
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

		public static async Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix>> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
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
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
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

		public static async Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
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
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
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

		public static async Task<UnionPartition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Partition<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
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
