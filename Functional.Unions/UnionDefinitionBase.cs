using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	public interface IUnionDefinition
	{
	}

	public abstract class UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : IUnionDefinition
		where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
	{
    }
}
