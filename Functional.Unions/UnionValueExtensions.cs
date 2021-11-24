using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class UnionValueExtensions
    {
		public static IUnionValue<TUnionDefinition> Value<TUnionDefinition>(this Union<TUnionDefinition> union)
			where TUnionDefinition : notnull, IUnionDefinition
			=> union.Value;

		public static IUnionTask<IUnionValue<TUnionDefinition>> Value<TUnionDefinition>(this Task<Union<TUnionDefinition>> union)
			where TUnionDefinition : notnull, IUnionDefinition
			=> new UnionTask<IUnionValue<TUnionDefinition>>(union.ContinueWith(t => t.Result.Value, TaskContinuationOptions.OnlyOnRanToCompletion));

		public static IUnionValue<AdhocUnionDefinition<TOne, TTwo>> Value<TOne, TTwo>(this Union<TOne, TTwo> union)
			where TOne : notnull
			where TTwo : notnull
			=> union.Value;

		public static IUnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo>>> Value<TOne, TTwo>(this Task<Union<TOne, TTwo>> union)
			where TOne : notnull
			where TTwo : notnull
			=> new UnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo>>>(union.ContinueWith(t => t.Result.Value, TaskContinuationOptions.OnlyOnRanToCompletion));

		public static IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>> Value<TOne, TTwo, TThree>(this Union<TOne, TTwo, TThree> union)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> union.Value;

		public static IUnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>>> Value<TOne, TTwo, TThree>(this Task<Union<TOne, TTwo, TThree>> union)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> new UnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>>>(union.ContinueWith(t => t.Result.Value, TaskContinuationOptions.OnlyOnRanToCompletion));

		public static IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>> Value<TOne, TTwo, TThree, TFour>(this Union<TOne, TTwo, TThree, TFour> union)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> union.Value;

		public static IUnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>>> Value<TOne, TTwo, TThree, TFour>(this Task<Union<TOne, TTwo, TThree, TFour>> union)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> new UnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>>>(union.ContinueWith(t => t.Result.Value, TaskContinuationOptions.OnlyOnRanToCompletion));

		public static IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>> Value<TOne, TTwo, TThree, TFour, TFive>(this Union<TOne, TTwo, TThree, TFour, TFive> union)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> union.Value;

		public static IUnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>>> Value<TOne, TTwo, TThree, TFour, TFive>(this Task<Union<TOne, TTwo, TThree, TFour, TFive>> union)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> new UnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>>>(union.ContinueWith(t => t.Result.Value, TaskContinuationOptions.OnlyOnRanToCompletion));

		public static IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>> Value<TOne, TTwo, TThree, TFour, TFive, TSix>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix> union)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Value;

		public static IUnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>>> Value<TOne, TTwo, TThree, TFour, TFive, TSix>(this Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix>> union)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> new UnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>>>(union.ContinueWith(t => t.Result.Value, TaskContinuationOptions.OnlyOnRanToCompletion));

		public static IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Value<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> union)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Value;

		public static IUnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> Value<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> new UnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>>(union.ContinueWith(t => t.Result.Value, TaskContinuationOptions.OnlyOnRanToCompletion));

		public static IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Value<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> union)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
			=> union.Value;

		public static IUnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> Value<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
			=> new UnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>>(union.ContinueWith(t => t.Result.Value, TaskContinuationOptions.OnlyOnRanToCompletion));
	}
}
