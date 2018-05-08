using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class UnionValueExtensions
    {
		public static Option<TOne> One<TUnionDefinition, TOne>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some);

		public static Task<Option<TOne>> One<TUnionDefinition, TOne>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some);

		public static Option<TOne> One<TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some, _ => Option.None<TOne>());

		public static Task<Option<TOne>> One<TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some, _ => Option.None<TOne>());

		public static Option<TTwo> Two<TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TTwo>(), Option.Some);

		public static Task<Option<TTwo>> Two<TUnionDefinition, TOne, TTwo>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TTwo>(), Option.Some);

		public static Option<TOne> One<TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Task<Option<TOne>> One<TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Option<TTwo> Two<TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>());

		public static Task<Option<TTwo>> Two<TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>());

		public static Option<TThree> Three<TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some);

		public static Task<Option<TThree>> Three<TUnionDefinition, TOne, TTwo, TThree>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some);

		public static Option<TOne> One<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Task<Option<TOne>> One<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Option<TTwo> Two<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Task<Option<TTwo>> Two<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Option<TThree> Three<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>());

		public static Task<Option<TThree>> Three<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>());

		public static Option<TFour> Four<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some);

		public static Task<Option<TFour>> Four<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some);

		public static Option<TOne> One<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Task<Option<TOne>> One<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Option<TTwo> Two<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Task<Option<TTwo>> Two<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Option<TThree> Three<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Task<Option<TThree>> Three<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Option<TFour> Four<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>());

		public static Task<Option<TFour>> Four<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>());

		public static Option<TFive> Five<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some);

		public static Task<Option<TFive>> Five<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some);

		public static Option<TOne> One<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Task<Option<TOne>> One<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Option<TTwo> Two<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Task<Option<TTwo>> Two<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Option<TThree> Three<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Task<Option<TThree>> Three<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Option<TFour> Four<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>(), _ => Option.None<TFour>());

		public static Task<Option<TFour>> Four<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>(), _ => Option.None<TFour>());

		public static Option<TFive> Five<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some, _ => Option.None<TFive>());

		public static Task<Option<TFive>> Five<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some, _ => Option.None<TFive>());

		public static Option<TSix> Six<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), Option.Some);

		public static Task<Option<TSix>> Six<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), Option.Some);

		public static Option<TOne> One<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Task<Option<TOne>> One<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Option<TTwo> Two<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Task<Option<TTwo>> Two<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Option<TThree> Three<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Task<Option<TThree>> Three<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Option<TFour> Four<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>());

		public static Task<Option<TFour>> Four<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>());

		public static Option<TFive> Five<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some, _ => Option.None<TFive>(), _ => Option.None<TFive>());

		public static Task<Option<TFive>> Five<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some, _ => Option.None<TFive>(), _ => Option.None<TFive>());

		public static Option<TSix> Six<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), Option.Some, _ => Option.None<TSix>());

		public static Task<Option<TSix>> Six<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), Option.Some, _ => Option.None<TSix>());

		public static Option<TSeven> Seven<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), Option.Some);

		public static Task<Option<TSeven>> Seven<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), Option.Some);

		public static Option<TOne> One<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Task<Option<TOne>> One<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(Option.Some, _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>(), _ => Option.None<TOne>());

		public static Option<TTwo> Two<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Task<Option<TTwo>> Two<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TTwo>(), Option.Some, _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>(), _ => Option.None<TTwo>());

		public static Option<TThree> Three<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Task<Option<TThree>> Three<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TThree>(), _ => Option.None<TThree>(), Option.Some, _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>(), _ => Option.None<TThree>());

		public static Option<TFour> Four<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>());

		public static Task<Option<TFour>> Four<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), Option.Some, _ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>(), _ => Option.None<TFour>());

		public static Option<TFive> Five<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some, _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>());

		public static Task<Option<TFive>> Five<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>(), Option.Some, _ => Option.None<TFive>(), _ => Option.None<TFive>(), _ => Option.None<TFive>());

		public static Option<TSix> Six<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), Option.Some, _ => Option.None<TSix>(), _ => Option.None<TSix>());

		public static Task<Option<TSix>> Six<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), _ => Option.None<TSix>(), Option.Some, _ => Option.None<TSix>(), _ => Option.None<TSix>());

		public static Option<TSeven> Seven<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), Option.Some, _ => Option.None<TSeven>());

		public static Task<Option<TSeven>> Seven<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), _ => Option.None<TSeven>(), Option.Some, _ => Option.None<TSeven>());

		public static Option<TEight> Eight<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), Option.Some);

		public static Task<Option<TEight>> Eight<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> union)
			where TUnionDefinition : IUnionDefinition
			=> union.Match(_ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), _ => Option.None<TEight>(), Option.Some);
	}
}
