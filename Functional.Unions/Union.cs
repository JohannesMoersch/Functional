using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Functional
{
	public struct Union<TUnionDefinition> : IEquatable<Union<TUnionDefinition>>
		where TUnionDefinition : IUnionDefinition
	{
		internal IUnionValue<TUnionDefinition> _value;
		internal IUnionValue<TUnionDefinition> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<TUnionDefinition> value)
			=> _value = value;

		public bool Equals(Union<TUnionDefinition> other)
			=> Equals(_value, other._value);

		public override int GetHashCode()
			=> _value?.GetHashCode() ?? 0;

		public override bool Equals(object obj)
			=> obj is Union<TUnionDefinition> union && Equals(union);

		public override string ToString()
			=> Value.ToString();

		public static bool operator ==(Union<TUnionDefinition> left, Union<TUnionDefinition> right)
			=> left.Equals(right);

		public static bool operator !=(Union<TUnionDefinition> left, Union<TUnionDefinition> right)
			=> !left.Equals(right);
	}

	public static class Union
	{
		public static IUnionFactory<TUnionDefinition> OfType<TUnionDefinition>()
			where TUnionDefinition : IUnionDefinition
			=> UnionFactory<TUnionDefinition>.Instance;
	}
}
