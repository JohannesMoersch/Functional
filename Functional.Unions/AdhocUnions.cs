using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[Serializable]
	public struct Union<TOne, TTwo> : IEquatable<Union<TOne, TTwo>>, ISerializable
			where TOne : notnull
			where TTwo : notnull
	{
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo>> _value;
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo>> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<AdhocUnionDefinition<TOne, TTwo>> value)
			=> _value = value;

		private Union(SerializationInfo info, StreamingContext context)
			=> _value = UnionSerializationHelpers.CreateUnionValue<Union<TOne, TTwo>, AdhocUnionDefinition<TOne, TTwo>, TOne, TTwo>(info, UnionFactoryExtensions.CreateUnionFromTypes);

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> UnionSerializationHelpers.Serialize(info, (IUnionValue)Value);

		public bool Equals(Union<TOne, TTwo> other)
			=> Equals(_value, other._value);

		public override int GetHashCode()
			=> _value?.GetHashCode() ?? 0;

		public override bool Equals(object obj)
			=> obj is Union<TOne, TTwo> union && Equals(union);

		public override string ToString()
			=> Value.ToString();

		public static bool operator ==(Union<TOne, TTwo> left, Union<TOne, TTwo> right)
			=> left.Equals(right);

		public static bool operator !=(Union<TOne, TTwo> left, Union<TOne, TTwo> right)
			=> !left.Equals(right);

		public static implicit operator Union<TOne, TTwo>(TOne one)
			=> Union.FromTypes<TOne, TTwo>().Create(one);

		public static implicit operator Union<TOne, TTwo>(TTwo one)
			=> Union.FromTypes<TOne, TTwo>().Create(one);
	}

	[Serializable]
	public struct Union<TOne, TTwo, TThree> : IEquatable<Union<TOne, TTwo, TThree>>, ISerializable
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
	{
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>> _value;
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>> value)
			=> _value = value;

		private Union(SerializationInfo info, StreamingContext context)
			=> _value = UnionSerializationHelpers.CreateUnionValue<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree>(info, UnionFactoryExtensions.CreateUnionFromTypes);

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> UnionSerializationHelpers.Serialize(info, (IUnionValue)Value);

		public bool Equals(Union<TOne, TTwo, TThree> other)
			=> Equals(_value, other._value);

		public override int GetHashCode()
			=> _value?.GetHashCode() ?? 0;

		public override bool Equals(object obj)
			=> obj is Union<TOne, TTwo, TThree> union && Equals(union);

		public override string ToString()
			=> Value.ToString();

		public static bool operator ==(Union<TOne, TTwo, TThree> left, Union<TOne, TTwo, TThree> right)
			=> left.Equals(right);

		public static bool operator !=(Union<TOne, TTwo, TThree> left, Union<TOne, TTwo, TThree> right)
			=> !left.Equals(right);

		public static implicit operator Union<TOne, TTwo, TThree>(TOne one)
			=> Union.FromTypes<TOne, TTwo, TThree>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree>(TTwo one)
			=> Union.FromTypes<TOne, TTwo, TThree>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree>(TThree one)
			=> Union.FromTypes<TOne, TTwo, TThree>().Create(one);
	}

	[Serializable]
	public struct Union<TOne, TTwo, TThree, TFour> : IEquatable<Union<TOne, TTwo, TThree, TFour>>, ISerializable
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
	{
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>> _value;
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>> value)
			=> _value = value;

		private Union(SerializationInfo info, StreamingContext context)
			=> _value = UnionSerializationHelpers.CreateUnionValue<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(info, UnionFactoryExtensions.CreateUnionFromTypes);

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> UnionSerializationHelpers.Serialize(info, (IUnionValue)Value);

		public bool Equals(Union<TOne, TTwo, TThree, TFour> other)
			=> Equals(_value, other._value);

		public override int GetHashCode()
			=> _value?.GetHashCode() ?? 0;

		public override bool Equals(object obj)
			=> obj is Union<TOne, TTwo, TThree, TFour> union && Equals(union);

		public override string ToString()
			=> Value.ToString();

		public static bool operator ==(Union<TOne, TTwo, TThree, TFour> left, Union<TOne, TTwo, TThree, TFour> right)
			=> left.Equals(right);

		public static bool operator !=(Union<TOne, TTwo, TThree, TFour> left, Union<TOne, TTwo, TThree, TFour> right)
			=> !left.Equals(right);

		public static implicit operator Union<TOne, TTwo, TThree, TFour>(TOne one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour>(TTwo one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour>(TThree one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour>(TFour one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour>().Create(one);
	}

	[Serializable]
	public struct Union<TOne, TTwo, TThree, TFour, TFive> : IEquatable<Union<TOne, TTwo, TThree, TFour, TFive>>, ISerializable
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
	{
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>> _value;
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>> value)
			=> _value = value;

		private Union(SerializationInfo info, StreamingContext context)
			=> _value = UnionSerializationHelpers.CreateUnionValue<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(info, UnionFactoryExtensions.CreateUnionFromTypes);

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> UnionSerializationHelpers.Serialize(info, (IUnionValue)Value);

		public bool Equals(Union<TOne, TTwo, TThree, TFour, TFive> other)
			=> Equals(_value, other._value);

		public override int GetHashCode()
			=> _value?.GetHashCode() ?? 0;

		public override bool Equals(object obj)
			=> obj is Union<TOne, TTwo, TThree, TFour, TFive> union && Equals(union);

		public override string ToString()
			=> Value.ToString();

		public static bool operator ==(Union<TOne, TTwo, TThree, TFour, TFive> left, Union<TOne, TTwo, TThree, TFour, TFive> right)
			=> left.Equals(right);

		public static bool operator !=(Union<TOne, TTwo, TThree, TFour, TFive> left, Union<TOne, TTwo, TThree, TFour, TFive> right)
			=> !left.Equals(right);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive>(TOne one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive>(TTwo one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive>(TThree one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive>(TFour one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive>(TFive one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive>().Create(one);
	}

	[Serializable]
	public struct Union<TOne, TTwo, TThree, TFour, TFive, TSix> : IEquatable<Union<TOne, TTwo, TThree, TFour, TFive, TSix>>, ISerializable
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
	{
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>> _value;
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>> value)
			=> _value = value;

		private Union(SerializationInfo info, StreamingContext context)
			=> _value = UnionSerializationHelpers.CreateUnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(info, UnionFactoryExtensions.CreateUnionFromTypes);

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> UnionSerializationHelpers.Serialize(info, (IUnionValue)Value);

		public bool Equals(Union<TOne, TTwo, TThree, TFour, TFive, TSix> other)
			=> Equals(_value, other._value);

		public override int GetHashCode()
			=> _value?.GetHashCode() ?? 0;

		public override bool Equals(object obj)
			=> obj is Union<TOne, TTwo, TThree, TFour, TFive, TSix> union && Equals(union);

		public override string ToString()
			=> Value.ToString();

		public static bool operator ==(Union<TOne, TTwo, TThree, TFour, TFive, TSix> left, Union<TOne, TTwo, TThree, TFour, TFive, TSix> right)
			=> left.Equals(right);

		public static bool operator !=(Union<TOne, TTwo, TThree, TFour, TFive, TSix> left, Union<TOne, TTwo, TThree, TFour, TFive, TSix> right)
			=> !left.Equals(right);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix>(TOne one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix>(TTwo one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix>(TThree one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix>(TFour one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix>(TFive one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix>(TSix one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix>().Create(one);
	}

	[Serializable]
	public struct Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : IEquatable<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, ISerializable
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
	{
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> _value;
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> value)
			=> _value = value;

		private Union(SerializationInfo info, StreamingContext context)
			=> _value = UnionSerializationHelpers.CreateUnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(info, UnionFactoryExtensions.CreateUnionFromTypes);

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> UnionSerializationHelpers.Serialize(info, (IUnionValue)Value);

		public bool Equals(Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
			=> Equals(_value, other._value);

		public override int GetHashCode()
			=> _value?.GetHashCode() ?? 0;

		public override bool Equals(object obj)
			=> obj is Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> union && Equals(union);

		public override string ToString()
			=> Value.ToString();

		public static bool operator ==(Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> left, Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> right)
			=> left.Equals(right);

		public static bool operator !=(Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> left, Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> right)
			=> !left.Equals(right);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(TOne one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(TTwo one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(TThree one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(TFour one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(TFive one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(TSix one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(TSeven one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>().Create(one);
	}

	[Serializable]
	public struct Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : IEquatable<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, ISerializable
			where TOne : notnull
			where TTwo : notnull
			where TThree : notnull
			where TFour : notnull
			where TFive : notnull
			where TSix : notnull
			where TSeven : notnull
			where TEight : notnull
	{
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> _value;
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> value)
			=> _value = value;

		private Union(SerializationInfo info, StreamingContext context)
			=> _value = UnionSerializationHelpers.CreateUnionValue<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(info, UnionFactoryExtensions.CreateUnionFromTypes);

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> UnionSerializationHelpers.Serialize(info, (IUnionValue)Value);

		public bool Equals(Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> Equals(_value, other._value);

		public override int GetHashCode()
			=> _value?.GetHashCode() ?? 0;

		public override bool Equals(object obj)
			=> obj is Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> union && Equals(union);

		public override string ToString()
			=> Value.ToString();

		public static bool operator ==(Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> left, Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> right)
			=> left.Equals(right);

		public static bool operator !=(Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> left, Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> right)
			=> !left.Equals(right);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(TOne one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(TTwo one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(TThree one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(TFour one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(TFive one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(TSix one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(TSeven one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>().Create(one);

		public static implicit operator Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(TEight one)
			=> Union.FromTypes<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>().Create(one);
	}
}
