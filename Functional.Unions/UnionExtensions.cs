using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class UnionExtensions
	{
		public static TUnionType AsUnion<TUnionType, TUnionDefinition, TOne>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne>)union).GetUnion();

		public static async Task<TUnionType> AsUnion<TUnionType, TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne>)await union).GetUnion();

		public static TUnionType AsUnion<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne, TTwo>)union).GetUnion();

		public static async Task<TUnionType> AsUnion<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne, TTwo>)await union).GetUnion();

		public static TUnionType AsUnion<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree>)union).GetUnion();

		public static async Task<TUnionType> AsUnion<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree>)await union).GetUnion();

		public static TUnionType AsUnion<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>)union).GetUnion();

		public static async Task<TUnionType> AsUnion<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>)await union).GetUnion();

		public static TUnionType AsUnion<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>)union).GetUnion();

		public static async Task<TUnionType> AsUnion<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>)await union).GetUnion();

		public static TUnionType AsUnion<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>)union).GetUnion();

		public static async Task<TUnionType> AsUnion<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>)await union).GetUnion();

		public static TUnionType AsUnion<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>)union).GetUnion();

		public static async Task<TUnionType> AsUnion<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>)await union).GetUnion();

		public static TUnionType AsUnion<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
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
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>)union).GetUnion();

		public static async Task<TUnionType> AsUnion<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
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
			=> ((UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>)await union).GetUnion();
	}
}
