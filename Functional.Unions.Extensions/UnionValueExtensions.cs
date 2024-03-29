﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class UnionValueExtensions
    {
		public static Option<TOne> One<TUnionType, TUnionDefinition, TOne>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
			=> union.Match(Option.Some);

		public static Task<Option<TOne>> One<TUnionType, TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
			=> union.Match(Option.Some);

		public static Option<TOne> One<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> union.Match(Option.Some, _ => Option.None<TOne>());

		public static Task<Option<TOne>> One<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> union.Match(Option.Some, _ => Option.None<TOne>());

		public static Option<TTwo> Two<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> union.Match(_ => Option.None<TTwo>(), Option.Some);

		public static Task<Option<TTwo>> Two<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> union.Match(_ => Option.None<TTwo>(), Option.Some);

		public static Option<TOne> One<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Task<Option<TOne>> One<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Option<TTwo> Two<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>());

		public static Task<Option<TTwo>> Two<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>());

		public static Option<TThree> Three<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some);

		public static Task<Option<TThree>> Three<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some);

		public static Option<TOne> One<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Task<Option<TOne>> One<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Option<TTwo> Two<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Task<Option<TTwo>> Two<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Option<TThree> Three<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>());

		public static Task<Option<TThree>> Three<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>());

		public static Option<TFour> Four<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some);

		public static Task<Option<TFour>> Four<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some);

		public static Option<TOne> One<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Task<Option<TOne>> One<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Option<TTwo> Two<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Task<Option<TTwo>> Two<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Option<TThree> Three<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Task<Option<TThree>> Three<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Option<TFour> Four<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>());

		public static Task<Option<TFour>> Four<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>());

		public static Option<TFive> Five<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some);

		public static Task<Option<TFive>> Five<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some);

		public static Option<TOne> One<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Task<Option<TOne>> One<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Option<TTwo> Two<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Task<Option<TTwo>> Two<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Option<TThree> Three<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Task<Option<TThree>> Three<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Option<TFour> Four<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>(), _ => Option.None<TFour>());

		public static Task<Option<TFour>> Four<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>(), _ => Option.None<TFour>());

		public static Option<TFive> Five<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some, _ => Option.None<TFive>());

		public static Task<Option<TFive>> Five<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some, _ => Option.None<TFive>());

		public static Option<TSix> Six<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Match(_ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), Option.Some);

		public static Task<Option<TSix>> Six<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> union.Match(_ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), Option.Some);

		public static Option<TOne> One<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Task<Option<TOne>> One<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Option<TTwo> Two<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Task<Option<TTwo>> Two<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Option<TThree> Three<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Task<Option<TThree>> Three<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Option<TFour> Four<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>());

		public static Task<Option<TFour>> Four<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>());

		public static Option<TFive> Five<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some, _ => Option.None<TFive>(), _ => Option.None<TFive>());

		public static Task<Option<TFive>> Five<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some, _ => Option.None<TFive>(), _ => Option.None<TFive>());

		public static Option<TSix> Six<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(_ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), Option.Some, _ => Option.None<TSix>());

		public static Task<Option<TSix>> Six<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(_ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), Option.Some, _ => Option.None<TSix>());

		public static Option<TSeven> Seven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(_ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), Option.Some);

		public static Task<Option<TSeven>> Seven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> union.Match(_ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), Option.Some);

		public static Option<TOne> One<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
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
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Task<Option<TOne>> One<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
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
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Option<TTwo> Two<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
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
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Task<Option<TTwo>> Two<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
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
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Option<TThree> Three<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
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
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Task<Option<TThree>> Three<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
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
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Option<TFour> Four<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
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
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>());

		public static Task<Option<TFour>> Four<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
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
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>());

		public static Option<TFive> Five<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
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
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some, _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>());

		public static Task<Option<TFive>> Five<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
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
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some, _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>());

		public static Option<TSix> Six<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
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
			=> union.Match(_ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), Option.Some, _ => Option.None<TSix>(), _ => Option.None<TSix>());

		public static Task<Option<TSix>> Six<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
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
			=> union.Match(_ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), Option.Some, _ => Option.None<TSix>(), _ => Option.None<TSix>());

		public static Option<TSeven> Seven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
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
			=> union.Match(_ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), Option.Some, _ => Option.None<TSeven>());

		public static Task<Option<TSeven>> Seven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
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
			=> union.Match(_ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), Option.Some, _ => Option.None<TSeven>());

		public static Option<TEight> Eight<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
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
			=> union.Match(_ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), Option.Some);

		public static Task<Option<TEight>> Eight<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
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
			=> union.Match(_ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), Option.Some);
	}
}
