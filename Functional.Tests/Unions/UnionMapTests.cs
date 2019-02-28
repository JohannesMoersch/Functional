using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Functional.Unions.Mappers;

namespace Functional.Tests.Unions
{
	public static class UnionMapExtensions
	{
		public static UnionMapperOneTwoThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition> To<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, IUnionFactory<UnionDefinition<TTargetUnionDefinition, TOne, TTwo, TThree>> factory)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TTargetUnionDefinition : UnionDefinition<TTargetUnionDefinition, TOne, TTwo, TThree>
			=> new UnionMapperOneTwoThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(union, factory);

		public static UnionMapperOneThreeTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition> To<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, IUnionFactory<UnionDefinition<TTargetUnionDefinition, TOne, TThree, TTwo>> factory)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TTargetUnionDefinition : UnionDefinition<TTargetUnionDefinition, TOne, TThree, TTwo>
			=> new UnionMapperOneThreeTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(union, factory);

		public static UnionMapperTwoOneThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition> To<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, IUnionFactory<UnionDefinition<TTargetUnionDefinition, TTwo, TOne, TThree>> factory)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TTargetUnionDefinition : UnionDefinition<TTargetUnionDefinition, TTwo, TOne, TThree>
			=> new UnionMapperTwoOneThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(union, factory);

		public static UnionMapperTwoThreeOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition> To<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, IUnionFactory<UnionDefinition<TTargetUnionDefinition, TTwo, TThree, TOne>> factory)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TTargetUnionDefinition : UnionDefinition<TTargetUnionDefinition, TTwo, TThree, TOne>
			=> new UnionMapperTwoThreeOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(union, factory);

		public static UnionMapperThreeOneTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition> To<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, IUnionFactory<UnionDefinition<TTargetUnionDefinition, TThree, TOne, TTwo>> factory)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TTargetUnionDefinition : UnionDefinition<TTargetUnionDefinition, TThree, TOne, TTwo>
			=> new UnionMapperThreeOneTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(union, factory);

		public static UnionMapperThreeTwoOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition> To<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, IUnionFactory<UnionDefinition<TTargetUnionDefinition, TThree, TTwo, TOne>> factory)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TTargetUnionDefinition : UnionDefinition<TTargetUnionDefinition, TThree, TTwo, TOne>
			=> new UnionMapperThreeTwoOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(union, factory);

		public static UnionMapperTwoThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition> To<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, IUnionFactory<UnionDefinition<TTargetUnionDefinition, TTwo, TThree>> factory)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TTargetUnionDefinition : UnionDefinition<TTargetUnionDefinition, TTwo, TThree>
			=> new UnionMapperTwoThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(union, factory);

		public static UnionMapperOneThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition> To<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, IUnionFactory<UnionDefinition<TTargetUnionDefinition, TOne, TThree>> factory)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TTargetUnionDefinition : UnionDefinition<TTargetUnionDefinition, TOne, TThree>
			=> new UnionMapperOneThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(union, factory);

		public static UnionMapperOneTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition> To<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, IUnionFactory<UnionDefinition<TTargetUnionDefinition, TOne, TTwo>> factory)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TTargetUnionDefinition : UnionDefinition<TTargetUnionDefinition, TOne, TTwo>
			=> new UnionMapperOneTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(union, factory);

		public static UnionMapperThreeTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition> To<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, IUnionFactory<UnionDefinition<TTargetUnionDefinition, TThree, TTwo>> factory)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TTargetUnionDefinition : UnionDefinition<TTargetUnionDefinition, TThree, TTwo>
			=> new UnionMapperThreeTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(union, factory);

		public static UnionMapperThreeOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition> To<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, IUnionFactory<UnionDefinition<TTargetUnionDefinition, TThree, TOne>> factory)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TTargetUnionDefinition : UnionDefinition<TTargetUnionDefinition, TThree, TOne>
			=> new UnionMapperThreeOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(union, factory);

		public static UnionMapperTwoOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition> To<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> union, IUnionFactory<UnionDefinition<TTargetUnionDefinition, TTwo, TOne>> factory)
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			where TTargetUnionDefinition : UnionDefinition<TTargetUnionDefinition, TTwo, TOne>
			=> new UnionMapperTwoOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TTargetUnionDefinition>(union, factory);
	}

	public class TestA : UnionDefinition<TestA, int, string, float>
	{
	}

	public class TestB : UnionDefinition<TestB, string, float>
	{
	}

	public class TestC : UnionDefinition<TestC, string, int, float>
	{
	}

	public class UnionMapTests
	{
		public static void Blah()
		{
			var a = Union.FromDefinition<TestA>().Create(1);
			var b = a.Value().To(Union.FromDefinition<TestB>()).Map(i => 1.0f);
			var c = a.Value().To(Union.FromDefinition<TestC>()).Map();
			var d = a.Value().To(Union.FromDefinition<TestA>()).Map();
		}
	}
}
