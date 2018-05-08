using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static class UnionExtensions
	{
		public static Union<TUnionDefinition> AsUnion<TUnionDefinition, TOne>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne>)union);

		public static async Task<Union<TUnionDefinition>> AsUnion<TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne>>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne>)(await union));

		public static Union<TUnionDefinition> AsUnion<TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne, TTwo>)union);

		public static async Task<Union<TUnionDefinition>> AsUnion<TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne, TTwo>)(await union));

		public static Union<TUnionDefinition> AsUnion<TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne, TTwo, TThree>)union);

		public static async Task<Union<TUnionDefinition>> AsUnion<TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne, TTwo, TThree>)(await union));

		public static Union<TUnionDefinition> AsUnion<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>)union);

		public static async Task<Union<TUnionDefinition>> AsUnion<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour>)(await union));

		public static Union<TUnionDefinition> AsUnion<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>)union);

		public static async Task<Union<TUnionDefinition>> AsUnion<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>)(await union));

		public static Union<TUnionDefinition> AsUnion<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>)union);

		public static async Task<Union<TUnionDefinition>> AsUnion<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>)(await union));

		public static Union<TUnionDefinition> AsUnion<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>)union);

		public static async Task<Union<TUnionDefinition>> AsUnion<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>)(await union));

		public static Union<TUnionDefinition> AsUnion<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>)union);

		public static async Task<Union<TUnionDefinition>> AsUnion<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
			where TUnionDefinition : IUnionDefinition
			=> new Union<TUnionDefinition>((UnionValue<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>)(await union));
	}
}
