using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public abstract class UnionDefinition<TUnionDefinition, TOne> : UnionDefinitionBase<Union<TUnionDefinition>, TUnionDefinition, TOne>
		where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne>
	{
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo> : UnionDefinitionBase<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo>
		where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
	{
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree> : UnionDefinitionBase<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>
		where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
	{
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour> : UnionDefinitionBase<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>
		where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
	{
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : UnionDefinitionBase<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
		where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
	{
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : UnionDefinitionBase<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
		where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
	{
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionDefinitionBase<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
		where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
	{
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionDefinitionBase<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
		where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
	{
	}
}
