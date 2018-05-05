using System;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	public interface IUnionFactory<out TUnionDefintion>
	{
	}

	internal class UnionFactory<TUnionDefinition> : IUnionFactory<TUnionDefinition>
		where TUnionDefinition : IUnionDefinition
	{
		internal static UnionFactory<TUnionDefinition> Instance { get; } = new UnionFactory<TUnionDefinition>();

		private UnionFactory() { }
	}
}
