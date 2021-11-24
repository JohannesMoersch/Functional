using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class UnionEnumerableWhereExtensions
	{
#pragma warning disable CS8603 // Possible null reference return.
		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
			=> source.Where(union => union.Match(_ => true)).Select(union => union.Match(_ => _));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			where TOne : notnull
			=> source.Where(union => union.Match(_ => true)).Select(union => union.Match(_ => _));

		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> source.Where(union => union.Match(_ => true, _ => false)).Select(union => union.Match(_ => _, _ => default));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> source.Where(union => union.Match(_ => true, _ => false)).Select(union => union.Match(_ => _, _ => default));

		public static IEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> source.Where(union => union.Match(_ => false, _ => true)).Select(union => union.Match(_ => default, _ => _));

		public static IAsyncEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			where TOne : notnull
			where TTwo : notnull
			=> source.Where(union => union.Match(_ => false, _ => true)).Select(union => union.Match(_ => default, _ => _));

		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default));

		public static IEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default));

		public static IAsyncEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default));

		public static IEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => _));

		public static IAsyncEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => _));

		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default));

		public static IEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default));

		public static IAsyncEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default));

		public static IEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default));

		public static IAsyncEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default));

		public static IEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _));

		public static IAsyncEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _));

		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default));

		public static IEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default));

		public static IAsyncEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default));

		public static IEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default));

		public static IAsyncEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default));

		public static IEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _));

		public static IAsyncEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _));

		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default, _ => default));

		public static IEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default, _ => default));

		public static IAsyncEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default, _ => default));

		public static IEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _, _ => default));

		public static IAsyncEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _, _ => default));

		public static IEnumerable<TSix> WhereSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => _));

		public static IAsyncEnumerable<TSix> WhereSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => _));

		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default, _ => default, _ => default));

		public static IEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _, _ => default, _ => default));

		public static IAsyncEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _, _ => default, _ => default));

		public static IEnumerable<TSix> WhereSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => _, _ => default));

		public static IAsyncEnumerable<TSix> WhereSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => _, _ => default));

		public static IEnumerable<TSeven> WhereSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => _));

		public static IAsyncEnumerable<TSeven> WhereSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : notnull, UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => _));

		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _, _ => default, _ => default, _ => default));

		public static IEnumerable<TSix> WhereSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => _, _ => default, _ => default));

		public static IAsyncEnumerable<TSix> WhereSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => _, _ => default, _ => default));

		public static IEnumerable<TSeven> WhereSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => _, _ => default));

		public static IAsyncEnumerable<TSeven> WhereSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => _, _ => default));

		public static IEnumerable<TEight> WhereEight<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => _));

		public static IAsyncEnumerable<TEight> WhereEight<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
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
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => _));
#pragma warning restore CS8603 // Possible null reference return.
	}
}