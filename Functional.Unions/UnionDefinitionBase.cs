using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	public interface IUnionDefinition
	{
	}

	public abstract class UnionDefinitionBase<TUnionType, TUnionDefinition, TOne> : IUnionDefinition
		where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne>
	{
	}

	public abstract class UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo> : IUnionDefinition
		where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
	{
	}

	public abstract class UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree> : IUnionDefinition
		where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
	{
	}

	public abstract class UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> : IUnionDefinition
		where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
	{
	}

	public abstract class UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : IUnionDefinition
		where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
	{
	}

	public abstract class UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : IUnionDefinition
		where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
	{
	}

	public abstract class UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : IUnionDefinition
		where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
	{
	}

	public abstract class UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : IUnionDefinition
		where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
	{
    }
}
