using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	public interface IUnionDefinition
	{
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo> : IUnionDefinition
		where TUnionDefinition : IUnionDefinition
	{
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree> : IUnionDefinition
		where TUnionDefinition : IUnionDefinition
	{
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour> : IUnionDefinition
		where TUnionDefinition : IUnionDefinition
	{
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : IUnionDefinition
		where TUnionDefinition : IUnionDefinition
	{
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : IUnionDefinition
		where TUnionDefinition : IUnionDefinition
	{
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : IUnionDefinition
		where TUnionDefinition : IUnionDefinition
	{
	}

	public abstract class UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : IUnionDefinition
		where TUnionDefinition : IUnionDefinition
	{
	}
}
