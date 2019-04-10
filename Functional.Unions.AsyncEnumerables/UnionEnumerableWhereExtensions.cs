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
		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			=> source.Where(union => union.Match(_ => true)).Select(union => union.Match(_ => _));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
			=> source.Where(union => union.Match(_ => true)).Select(union => union.Match(_ => _));

		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			=> source.Where(union => union.Match(_ => true, _ => false)).Select(union => union.Match(_ => _, _ => default));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			=> source.Where(union => union.Match(_ => true, _ => false)).Select(union => union.Match(_ => _, _ => default));

		public static IEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			=> source.Where(union => union.Match(_ => false, _ => true)).Select(union => union.Match(_ => default, _ => _));

		public static IAsyncEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			=> source.Where(union => union.Match(_ => false, _ => true)).Select(union => union.Match(_ => default, _ => _));

		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default));

		public static IEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default));

		public static IAsyncEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default));

		public static IEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => _));

		public static IAsyncEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => _));

		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default));

		public static IEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default));

		public static IAsyncEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default));

		public static IEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default));

		public static IAsyncEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default));

		public static IEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _));

		public static IAsyncEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _));

		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default));

		public static IEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default));

		public static IAsyncEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default));

		public static IEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default));

		public static IAsyncEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default));

		public static IEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _));

		public static IAsyncEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _));

		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default, _ => default));

		public static IEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default, _ => default));

		public static IAsyncEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default, _ => default));

		public static IEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _, _ => default));

		public static IAsyncEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _, _ => default));

		public static IEnumerable<TSix> WhereSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => _));

		public static IAsyncEnumerable<TSix> WhereSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => _));

		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default, _ => default, _ => default));

		public static IEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _, _ => default, _ => default));

		public static IAsyncEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _, _ => default, _ => default));

		public static IEnumerable<TSix> WhereSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => _, _ => default));

		public static IAsyncEnumerable<TSix> WhereSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => _, _ => default));

		public static IEnumerable<TSeven> WhereSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => _));

		public static IAsyncEnumerable<TSeven> WhereSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => _));

		public static IEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TOne> WhereOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => _, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TTwo> WhereTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => _, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TThree> WhereThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => _, _ => default, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TFour> WhereFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => _, _ => default, _ => default, _ => default, _ => default));

		public static IEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _, _ => default, _ => default, _ => default));

		public static IAsyncEnumerable<TFive> WhereFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => _, _ => default, _ => default, _ => default));

		public static IEnumerable<TSix> WhereSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => _, _ => default, _ => default));

		public static IAsyncEnumerable<TSix> WhereSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => _, _ => default, _ => default));

		public static IEnumerable<TSeven> WhereSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => _, _ => default));

		public static IAsyncEnumerable<TSeven> WhereSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true, _ => false)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => _, _ => default));

		public static IEnumerable<TEight> WhereEight<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => _));

		public static IAsyncEnumerable<TEight> WhereEight<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IAsyncEnumerable<IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> source)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> source.Where(union => union.Match(_ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => false, _ => true)).Select(union => union.Match(_ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => default, _ => _));
	}
}