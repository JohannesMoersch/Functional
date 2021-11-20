using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class UnionEnumerableValueExtensions
	{
		public static IEnumerable<IUnionValue<TUnionDefinition>> Value<TUnionDefinition>(this IEnumerable<Union<TUnionDefinition>> source)
			where TUnionDefinition : notnull, IUnionDefinition
			=> source.Select(union => union.Value());

		public static IUnionTask<IEnumerable<IUnionValue<TUnionDefinition>>> Value<TUnionDefinition>(this Task<IEnumerable<Union<TUnionDefinition>>> source)
			where TUnionDefinition : notnull, IUnionDefinition
			=> new UnionPartitionTask<IEnumerable<IUnionValue<TUnionDefinition>>>(source.Select(union => union.Value()));

		public static IAsyncEnumerable<IUnionValue<TUnionDefinition>> Value<TUnionDefinition>(this IAsyncEnumerable<Union<TUnionDefinition>> source)
			where TUnionDefinition : notnull, IUnionDefinition
			=> source.Select(union => union.Value());

		public static IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo>>> Value<TOne, TTwo>(this IEnumerable<Union<TOne, TTwo>> source)
			where TOne : notnull
			where TTwo : notnull
			=> source.Select(union => union.Value());

		public static IUnionTask<IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo>>>> Value<TOne, TTwo>(this Task<IEnumerable<Union<TOne, TTwo>>> source)
			where TOne : notnull
			where TTwo : notnull
			=> new UnionPartitionTask<IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo>>>>(source.Select(union => union.Value()));

		public static IAsyncEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo>>> Value<TOne, TTwo>(this IAsyncEnumerable<Union<TOne, TTwo>> source)
			where TOne : notnull
			where TTwo : notnull
			=> source.Select(union => union.Value());

		public static IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>>> Value<TOne, TTwo, TThree>(this IEnumerable<Union<TOne, TTwo, TThree>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> source.Select(union => union.Value());

		public static IUnionTask<IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>>>> Value<TOne, TTwo, TThree>(this Task<IEnumerable<Union<TOne, TTwo, TThree>>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> new UnionPartitionTask<IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>>>>(source.Select(union => union.Value()));

		public static IAsyncEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>>> Value<TOne, TTwo, TThree>(this IAsyncEnumerable<Union<TOne, TTwo, TThree>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> source.Select(union => union.Value());

		public static IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>>> Value<TOne, TTwo, TThree, TFour>(this IEnumerable<Union<TOne, TTwo, TThree, TFour>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> source.Select(union => union.Value());

		public static IUnionTask<IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>>>> Value<TOne, TTwo, TThree, TFour>(this Task<IEnumerable<Union<TOne, TTwo, TThree, TFour>>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> new UnionPartitionTask<IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>>>>(source.Select(union => union.Value()));

		public static IAsyncEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>>> Value<TOne, TTwo, TThree, TFour>(this IAsyncEnumerable<Union<TOne, TTwo, TThree, TFour>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> source.Select(union => union.Value());

		public static IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>>> Value<TOne, TTwo, TThree, TFour, TFive>(this IEnumerable<Union<TOne, TTwo, TThree, TFour, TFive>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> source.Select(union => union.Value());

		public static IUnionTask<IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>>>> Value<TOne, TTwo, TThree, TFour, TFive>(this Task<IEnumerable<Union<TOne, TTwo, TThree, TFour, TFive>>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> new UnionPartitionTask<IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>>>>(source.Select(union => union.Value()));

		public static IAsyncEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>>> Value<TOne, TTwo, TThree, TFour, TFive>(this IAsyncEnumerable<Union<TOne, TTwo, TThree, TFour, TFive>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> source.Select(union => union.Value());

		public static IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>>> Value<TOne, TTwo, TThree, TFour, TFive, TSix>(this IEnumerable<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> source.Select(union => union.Value());

		public static IUnionTask<IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>>>> Value<TOne, TTwo, TThree, TFour, TFive, TSix>(this Task<IEnumerable<Union<TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> new UnionPartitionTask<IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>>>>(source.Select(union => union.Value()));

		public static IAsyncEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>>> Value<TOne, TTwo, TThree, TFour, TFive, TSix>(this IAsyncEnumerable<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> source.Select(union => union.Value());

		public static IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> Value<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Select(union => union.Value());

		public static IUnionTask<IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>>> Value<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<IEnumerable<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> new UnionPartitionTask<IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>>>(source.Select(union => union.Value()));

		public static IAsyncEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> Value<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Select(union => union.Value());

		public static IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> Value<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
			=> source.Select(union => union.Value());

		public static IUnionTask<IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>>> Value<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Task<IEnumerable<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
			=> new UnionPartitionTask<IEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>>>(source.Select(union => union.Value()));

		public static IAsyncEnumerable<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> Value<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> source)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
			=> source.Select(union => union.Value());
	}
}
