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
		public static IUnionFactory<TUnionDefinition> FromDefinition<TUnionDefinition>()
			where TUnionDefinition : IUnionDefinition
			=> UnionFactory<TUnionDefinition>.Instance;

		public static IUnionFactory<TOne, TTwo> FromTypes<TOne, TTwo>()
			=> UnionFactory<TOne, TTwo>.Instance;

		public static IUnionFactory<TOne, TTwo, TThree> FromTypes<TOne, TTwo, TThree>()
			=> UnionFactory<TOne, TTwo, TThree>.Instance;

		public static IUnionFactory<TOne, TTwo, TThree, TFour> FromTypes<TOne, TTwo, TThree, TFour>()
			=> UnionFactory<TOne, TTwo, TThree, TFour>.Instance;

		public static IUnionFactory<TOne, TTwo, TThree, TFour, TFive> FromTypes<TOne, TTwo, TThree, TFour, TFive>()
			=> UnionFactory<TOne, TTwo, TThree, TFour, TFive>.Instance;

		public static IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix> FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix>()
			=> UnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix>.Instance;

		public static IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>()
			=> UnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>.Instance;

		public static IUnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>()
			=> UnionFactory<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>.Instance;
	}
}
