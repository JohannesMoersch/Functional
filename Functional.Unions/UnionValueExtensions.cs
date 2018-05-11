using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class UnionValueExtensions
    {
		public static IUnionValue<TUnionDefinition> Value<TUnionDefinition>(this Union<TUnionDefinition> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Value;

		public static IUnionTask<IUnionValue<TUnionDefinition>> Value<TUnionDefinition>(this Task<Union<TUnionDefinition>> union)
			where TUnionDefinition : IUnionDefinition
			=> new UnionTask<IUnionValue<TUnionDefinition>>(union.ContinueWith(t => t.Result.Value, TaskContinuationOptions.OnlyOnRanToCompletion));

		public static IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Value<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> union)
			=> union.Value;

		public static IUnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> Value<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this Task<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
			=> new UnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>>(union.ContinueWith(t => t.Result.Value, TaskContinuationOptions.OnlyOnRanToCompletion));
	}
}
