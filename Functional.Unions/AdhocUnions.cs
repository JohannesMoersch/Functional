using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	[Serializable]
	public struct Union<TOne, TTwo> : IEquatable<Union<TOne, TTwo>>, ISerializable
	{
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo>> _value;
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo>> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<AdhocUnionDefinition<TOne, TTwo>> value)
			=> _value = value;

		private Union(SerializationInfo info, StreamingContext context)
			=> _value = (IUnionValue<AdhocUnionDefinition<TOne, TTwo>>)info.GetValue(nameof(_value), typeof(IUnionValue<AdhocUnionDefinition<TOne, TTwo>>));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(_value), Value);

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
	}

	[Serializable]
	public struct Union<TOne, TTwo, TThree> : IEquatable<Union<TOne, TTwo, TThree>>, ISerializable
	{
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>> _value;
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>> value)
			=> _value = value;

		private Union(SerializationInfo info, StreamingContext context)
			=> _value = (IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>>)info.GetValue(nameof(_value), typeof(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>>));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(_value), Value);

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
	}

	[Serializable]
	public struct Union<TOne, TTwo, TThree, TFour> : IEquatable<Union<TOne, TTwo, TThree, TFour>>, ISerializable
	{
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>> _value;
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>> value)
			=> _value = value;

		private Union(SerializationInfo info, StreamingContext context)
			=> _value = (IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>>)info.GetValue(nameof(_value), typeof(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>>));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(_value), Value);

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
	}

	[Serializable]
	public struct Union<TOne, TTwo, TThree, TFour, TFive> : IEquatable<Union<TOne, TTwo, TThree, TFour, TFive>>, ISerializable
	{
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>> _value;
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>> value)
			=> _value = value;

		private Union(SerializationInfo info, StreamingContext context)
			=> _value = (IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>>)info.GetValue(nameof(_value), typeof(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>>));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(_value), Value);

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
	}

	[Serializable]
	public struct Union<TOne, TTwo, TThree, TFour, TFive, TSix> : IEquatable<Union<TOne, TTwo, TThree, TFour, TFive, TSix>>, ISerializable
	{
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>> _value;
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>> value)
			=> _value = value;

		private Union(SerializationInfo info, StreamingContext context)
			=> _value = (IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>>)info.GetValue(nameof(_value), typeof(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>>));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(_value), Value);

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
	}

	[Serializable]
	public struct Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : IEquatable<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, ISerializable
	{
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> _value;
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> value)
			=> _value = value;

		private Union(SerializationInfo info, StreamingContext context)
			=> _value = (IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>)info.GetValue(nameof(_value), typeof(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(_value), Value);

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
	}

	[Serializable]
	public struct Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : IEquatable<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, ISerializable
	{
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> _value;
		internal IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Value => _value ?? throw new UnionNotInitializedException();

		internal Union(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> value)
			=> _value = value;

		private Union(SerializationInfo info, StreamingContext context)
			=> _value = (IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>)info.GetValue(nameof(_value), typeof(IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(_value), Value);

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
	}
}
