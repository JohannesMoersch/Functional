using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Functional
{
	public interface IUnionValue<out TUnionDefinition>
		where TUnionDefinition : IUnionDefinition
	{
	}

	[Serializable]
	internal class UnionValue<TUnionType, TUnionDefinition, TOne> : IUnionValue<TUnionDefinition>, IEquatable<UnionValue<TUnionType, TUnionDefinition, TOne>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public TOne One { get; }

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
		{
			One = one;
			_unionFactory = unionFactory;
		}

		private UnionValue(SerializationInfo info, StreamingContext context)
		{
			One = (TOne)info.GetValue(nameof(One), typeof(TOne));
			_unionFactory = UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>();
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) 
			=> info.AddValue(nameof(One), One);

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);

		public bool Equals(UnionValue<TUnionType, TUnionDefinition, TOne> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValue<TUnionType, TUnionDefinition, TOne> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal abstract class UnionValue<TUnionType, TUnionDefinition, TOne, TTwo> : IUnionValue<TUnionDefinition>
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public abstract int State { get; }

		public abstract TOne One { get; }

		public abstract TTwo Two { get; }

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory) 
			=> _unionFactory = unionFactory;

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);
	}

	[Serializable]
	internal class UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo>, IEquatable<UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 0;

		public override TOne One { get; }

		public override TTwo Two => default;

		public UnionValueOne(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory) 
			=> One = one;

		private UnionValueOne(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>()) 
			=> One = (TOne)info.GetValue(nameof(One), typeof(TOne));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(One), One);

		public bool Equals(UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal class UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo>, IEquatable<UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 1;

		public override TOne One => default;

		public override TTwo Two { get; }

		public UnionValueTwo(TTwo two, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory) 
			=> Two = two;

		private UnionValueTwo(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Two = (TTwo)info.GetValue(nameof(Two), typeof(TTwo));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Two), Two);

		public bool Equals(UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo> other)
			=> other != null && Equals(Two, other.Two);

		public override int GetHashCode()
			=> Two.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo> value && Equals(value);

		public override string ToString()
			=> $"Two:{Two}";
	}

	[Serializable]
	internal abstract class UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree> : IUnionValue<TUnionDefinition>
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public abstract int State { get; }

		public abstract TOne One { get; }

		public abstract TTwo Two { get; }

		public abstract TThree Three { get; }

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			=> _unionFactory = unionFactory;

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);
	}

	[Serializable]
	internal class UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree>, IEquatable<UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 0;

		public override TOne One { get; }

		public override TTwo Two => default;

		public override TThree Three => default;

		public UnionValueOne(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> One = one;

		private UnionValueOne(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> One = (TOne)info.GetValue(nameof(One), typeof(TOne));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(One), One);

		public bool Equals(UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal class UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree>, IEquatable<UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 1;

		public override TOne One => default;

		public override TTwo Two { get; }

		public override TThree Three => default;

		public UnionValueTwo(TTwo two, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Two = two;

		private UnionValueTwo(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Two = (TTwo)info.GetValue(nameof(Two), typeof(TTwo));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Two), Two);

		public bool Equals(UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree> other)
			=> other != null && Equals(Two, other.Two);

		public override int GetHashCode()
			=> Two.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree> value && Equals(value);

		public override string ToString()
			=> $"Two:{Two}";
	}

	[Serializable]
	internal class UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree>, IEquatable<UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 2;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three { get; }

		public UnionValueThree(TThree three, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Three = three;

		private UnionValueThree(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Three = (TThree)info.GetValue(nameof(Three), typeof(TThree));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Three), Three);

		public bool Equals(UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree> other)
			=> other != null && Equals(Three, other.Three);

		public override int GetHashCode()
			=> Three.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree> value && Equals(value);

		public override string ToString()
			=> $"Three:{Three}";
	}

	[Serializable]
	internal abstract class UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> : IUnionValue<TUnionDefinition>
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public abstract int State { get; }

		public abstract TOne One { get; }

		public abstract TTwo Two { get; }

		public abstract TThree Three { get; }

		public abstract TFour Four { get; }

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory) 
			=> _unionFactory = unionFactory;

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);
	}

	[Serializable]
	internal class UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>, IEquatable<UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 0;

		public override TOne One { get; }

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four => default;

		public UnionValueOne(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> One = one;

		private UnionValueOne(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> One = (TOne)info.GetValue(nameof(One), typeof(TOne));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(One), One);

		public bool Equals(UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal class UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>, IEquatable<UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 1;

		public override TOne One => default;

		public override TTwo Two { get; }

		public override TThree Three => default;

		public override TFour Four => default;

		public UnionValueTwo(TTwo two, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Two = two;

		private UnionValueTwo(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Two = (TTwo)info.GetValue(nameof(Two), typeof(TTwo));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Two), Two);

		public bool Equals(UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> other)
			=> other != null && Equals(Two, other.Two);

		public override int GetHashCode()
			=> Two.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> value && Equals(value);

		public override string ToString()
			=> $"Two:{Two}";
	}

	[Serializable]
	internal class UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>, IEquatable<UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 2;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three { get; }

		public override TFour Four => default;

		public UnionValueThree(TThree three, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Three = three;

		private UnionValueThree(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Three = (TThree)info.GetValue(nameof(Three), typeof(TThree));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Three), Three);

		public bool Equals(UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> other)
			=> other != null && Equals(Three, other.Three);

		public override int GetHashCode()
			=> Three.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> value && Equals(value);

		public override string ToString()
			=> $"Three:{Three}";
	}

	[Serializable]
	internal class UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>, IEquatable<UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 3;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four { get; }

		public UnionValueFour(TFour four, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Four = four;

		private UnionValueFour(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Four = (TFour)info.GetValue(nameof(Four), typeof(TFour));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Four), Four);

		public bool Equals(UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> other)
			=> other != null && Equals(Four, other.Four);

		public override int GetHashCode()
			=> Four.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> value && Equals(value);

		public override string ToString()
			=> $"Four:{Four}";
	}

	[Serializable]
	internal abstract class UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : IUnionValue<TUnionDefinition>
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public abstract int State { get; }

		public abstract TOne One { get; }

		public abstract TTwo Two { get; }

		public abstract TThree Three { get; }

		public abstract TFour Four { get; }

		public abstract TFive Five { get; }

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory) 
			=> _unionFactory = unionFactory;

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);
	}

	[Serializable]
	internal class UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>, IEquatable<UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 0;

		public override TOne One { get; }

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five => default;

		public UnionValueOne(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> One = one;

		private UnionValueOne(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> One = (TOne)info.GetValue(nameof(One), typeof(TOne));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(One), One);

		public bool Equals(UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal class UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>, IEquatable<UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 1;

		public override TOne One => default;

		public override TTwo Two { get; }

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five => default;

		public UnionValueTwo(TTwo two, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Two = two;

		private UnionValueTwo(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Two = (TTwo)info.GetValue(nameof(Two), typeof(TTwo));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Two), Two);

		public bool Equals(UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> other)
			=> other != null && Equals(Two, other.Two);

		public override int GetHashCode()
			=> Two.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> value && Equals(value);

		public override string ToString()
			=> $"Two:{Two}";
	}

	[Serializable]
	internal class UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>, IEquatable<UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 2;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three { get; }

		public override TFour Four => default;

		public override TFive Five => default;

		public UnionValueThree(TThree three, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Three = three;

		private UnionValueThree(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Three = (TThree)info.GetValue(nameof(Three), typeof(TThree));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Three), Three);

		public bool Equals(UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> other)
			=> other != null && Equals(Three, other.Three);

		public override int GetHashCode()
			=> Three.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> value && Equals(value);

		public override string ToString()
			=> $"Three:{Three}";
	}

	[Serializable]
	internal class UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>, IEquatable<UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 3;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four { get; }

		public override TFive Five => default;

		public UnionValueFour(TFour four, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Four = four;

		private UnionValueFour(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Four = (TFour)info.GetValue(nameof(Four), typeof(TFour));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Four), Four);

		public bool Equals(UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> other)
			=> other != null && Equals(Four, other.Four);

		public override int GetHashCode()
			=> Four.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> value && Equals(value);

		public override string ToString()
			=> $"Four:{Four}";
	}

	[Serializable]
	internal class UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>, IEquatable<UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 4;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five { get; }

		public UnionValueFive(TFive five, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Five = five;

		private UnionValueFive(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Five = (TFive)info.GetValue(nameof(Five), typeof(TFive));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Five), Five);

		public bool Equals(UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> other)
			=> other != null && Equals(Five, other.Five);

		public override int GetHashCode()
			=> Five.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> value && Equals(value);

		public override string ToString()
			=> $"Five:{Five}";
	}

	[Serializable]
	internal abstract class UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : IUnionValue<TUnionDefinition>
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public abstract int State { get; }

		public abstract TOne One { get; }

		public abstract TTwo Two { get; }

		public abstract TThree Three { get; }

		public abstract TFour Four { get; }

		public abstract TFive Five { get; }

		public abstract TSix Six { get; }

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			=> _unionFactory = unionFactory;

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);
	}

	[Serializable]
	internal class UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>, IEquatable<UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 0;

		public override TOne One { get; }

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five => default;

		public override TSix Six => default;

		public UnionValueOne(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> One = one;

		private UnionValueOne(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> One = (TOne)info.GetValue(nameof(One), typeof(TOne));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(One), One);

		public bool Equals(UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal class UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>, IEquatable<UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 1;

		public override TOne One => default;

		public override TTwo Two { get; }

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five => default;

		public override TSix Six => default;

		public UnionValueTwo(TTwo two, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Two = two;

		private UnionValueTwo(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Two = (TTwo)info.GetValue(nameof(Two), typeof(TTwo));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Two), Two);

		public bool Equals(UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> other)
			=> other != null && Equals(Two, other.Two);

		public override int GetHashCode()
			=> Two.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> value && Equals(value);

		public override string ToString()
			=> $"Two:{Two}";
	}

	[Serializable]
	internal class UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>, IEquatable<UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 2;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three { get; }

		public override TFour Four => default;

		public override TFive Five => default;

		public override TSix Six => default;

		public UnionValueThree(TThree three, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Three = three;

		private UnionValueThree(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Three = (TThree)info.GetValue(nameof(Three), typeof(TThree));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Three), Three);

		public bool Equals(UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> other)
			=> other != null && Equals(Three, other.Three);

		public override int GetHashCode()
			=> Three.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> value && Equals(value);

		public override string ToString()
			=> $"Three:{Three}";
	}

	[Serializable]
	internal class UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>, IEquatable<UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 3;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four { get; }

		public override TFive Five => default;

		public override TSix Six => default;

		public UnionValueFour(TFour four, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Four = four;

		private UnionValueFour(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Four = (TFour)info.GetValue(nameof(Four), typeof(TFour));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Four), Four);

		public bool Equals(UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> other)
			=> other != null && Equals(Four, other.Four);

		public override int GetHashCode()
			=> Four.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> value && Equals(value);

		public override string ToString()
			=> $"Four:{Four}";
	}

	[Serializable]
	internal class UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>, IEquatable<UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 4;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five { get; }

		public override TSix Six => default;

		public UnionValueFive(TFive five, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Five = five;

		private UnionValueFive(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Five = (TFive)info.GetValue(nameof(Five), typeof(TFive));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Five), Five);

		public bool Equals(UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> other)
			=> other != null && Equals(Five, other.Five);

		public override int GetHashCode()
			=> Five.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> value && Equals(value);

		public override string ToString()
			=> $"Five:{Five}";
	}

	[Serializable]
	internal class UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>, IEquatable<UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 5;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five => default;

		public override TSix Six { get; }

		public UnionValueSix(TSix six, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Six = six;

		private UnionValueSix(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Six = (TSix)info.GetValue(nameof(Six), typeof(TSix));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Six), Six);

		public bool Equals(UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> other)
			=> other != null && Equals(Six, other.Six);

		public override int GetHashCode()
			=> Six.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> value && Equals(value);

		public override string ToString()
			=> $"Six:{Six}";
	}

	[Serializable]
	internal abstract class UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : IUnionValue<TUnionDefinition>
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public abstract int State { get; }

		public abstract TOne One { get; }

		public abstract TTwo Two { get; }

		public abstract TThree Three { get; }

		public abstract TFour Four { get; }

		public abstract TFive Five { get; }

		public abstract TSix Six { get; }

		public abstract TSeven Seven { get; }

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			=> _unionFactory = unionFactory;

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);
	}

	[Serializable]
	internal class UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, IEquatable<UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 0;

		public override TOne One { get; }

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five => default;

		public override TSix Six => default;

		public override TSeven Seven => default;

		public UnionValueOne(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> One = one;

		private UnionValueOne(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> One = (TOne)info.GetValue(nameof(One), typeof(TOne));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(One), One);

		public bool Equals(UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal class UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, IEquatable<UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 1;

		public override TOne One => default;

		public override TTwo Two { get; }

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five => default;

		public override TSix Six => default;

		public override TSeven Seven => default;

		public UnionValueTwo(TTwo two, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Two = two;

		private UnionValueTwo(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Two = (TTwo)info.GetValue(nameof(Two), typeof(TTwo));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Two), Two);

		public bool Equals(UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
			=> other != null && Equals(Two, other.Two);

		public override int GetHashCode()
			=> Two.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> value && Equals(value);

		public override string ToString()
			=> $"Two:{Two}";
	}

	[Serializable]
	internal class UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, IEquatable<UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 2;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three { get; }

		public override TFour Four => default;

		public override TFive Five => default;

		public override TSix Six => default;

		public override TSeven Seven => default;

		public UnionValueThree(TThree three, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Three = three;

		private UnionValueThree(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Three = (TThree)info.GetValue(nameof(Three), typeof(TThree));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Three), Three);

		public bool Equals(UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
			=> other != null && Equals(Three, other.Three);

		public override int GetHashCode()
			=> Three.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> value && Equals(value);

		public override string ToString()
			=> $"Three:{Three}";
	}

	[Serializable]
	internal class UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, IEquatable<UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 3;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four { get; }

		public override TFive Five => default;

		public override TSix Six => default;

		public override TSeven Seven => default;

		public UnionValueFour(TFour four, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Four = four;

		private UnionValueFour(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Four = (TFour)info.GetValue(nameof(Four), typeof(TFour));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Four), Four);

		public bool Equals(UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
			=> other != null && Equals(Four, other.Four);

		public override int GetHashCode()
			=> Four.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> value && Equals(value);

		public override string ToString()
			=> $"Four:{Four}";
	}

	[Serializable]
	internal class UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, IEquatable<UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 4;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five { get; }

		public override TSix Six => default;

		public override TSeven Seven => default;

		public UnionValueFive(TFive five, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Five = five;

		private UnionValueFive(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Five = (TFive)info.GetValue(nameof(Five), typeof(TFive));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Five), Five);

		public bool Equals(UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
			=> other != null && Equals(Five, other.Five);

		public override int GetHashCode()
			=> Five.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> value && Equals(value);

		public override string ToString()
			=> $"Five:{Five}";
	}

	[Serializable]
	internal class UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, IEquatable<UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 5;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five => default;

		public override TSix Six { get; }

		public override TSeven Seven => default;

		public UnionValueSix(TSix six, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Six = six;

		private UnionValueSix(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Six = (TSix)info.GetValue(nameof(Six), typeof(TSix));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Six), Six);

		public bool Equals(UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
			=> other != null && Equals(Six, other.Six);

		public override int GetHashCode()
			=> Six.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> value && Equals(value);

		public override string ToString()
			=> $"Six:{Six}";
	}

	[Serializable]
	internal class UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, IEquatable<UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 6;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five => default;

		public override TSix Six => default;

		public override TSeven Seven { get; }

		public UnionValueSeven(TSeven seven, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Seven = seven;

		private UnionValueSeven(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Seven = (TSeven)info.GetValue(nameof(Seven), typeof(TSeven));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Seven), Seven);

		public bool Equals(UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> other)
			=> other != null && Equals(Seven, other.Seven);

		public override int GetHashCode()
			=> Seven.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> value && Equals(value);

		public override string ToString()
			=> $"Seven:{Seven}";
	}

	[Serializable]
	internal abstract class UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : IUnionValue<TUnionDefinition>
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public abstract int State { get; }

		public abstract TOne One { get; }

		public abstract TTwo Two { get; }

		public abstract TThree Three { get; }

		public abstract TFour Four { get; }

		public abstract TFive Five { get; }

		public abstract TSix Six { get; }

		public abstract TSeven Seven { get; }

		public abstract TEight Eight { get; }

		private readonly Func<IUnionValue<TUnionDefinition>, TUnionType> _unionFactory;

		public UnionValue(Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory) 
			=> _unionFactory = unionFactory;

		public TUnionType GetUnion()
			=> _unionFactory.Invoke(this);
	}

	[Serializable]
	internal class UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 0;

		public override TOne One { get; }

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five => default;

		public override TSix Six => default;

		public override TSeven Seven => default;

		public override TEight Eight => default;

		public UnionValueOne(TOne one, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> One = one;

		private UnionValueOne(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> One = (TOne)info.GetValue(nameof(One), typeof(TOne));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(One), One);

		public bool Equals(UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(One, other.One);

		public override int GetHashCode()
			=> One.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"One:{One}";
	}

	[Serializable]
	internal class UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 1;

		public override TOne One => default;

		public override TTwo Two { get; }

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five => default;

		public override TSix Six => default;

		public override TSeven Seven => default;

		public override TEight Eight => default;

		public UnionValueTwo(TTwo two, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Two = two;

		private UnionValueTwo(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Two = (TTwo)info.GetValue(nameof(Two), typeof(TTwo));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Two), Two);

		public bool Equals(UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(Two, other.Two);

		public override int GetHashCode()
			=> Two.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"Two:{Two}";
	}

	[Serializable]
	internal class UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 2;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three { get; }

		public override TFour Four => default;

		public override TFive Five => default;

		public override TSix Six => default;

		public override TSeven Seven => default;

		public override TEight Eight => default;

		public UnionValueThree(TThree three, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Three = three;

		private UnionValueThree(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Three = (TThree)info.GetValue(nameof(Three), typeof(TThree));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Three), Three);

		public bool Equals(UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(Three, other.Three);

		public override int GetHashCode()
			=> Three.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"Three:{Three}";
	}

	[Serializable]
	internal class UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 3;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four { get; }

		public override TFive Five => default;

		public override TSix Six => default;

		public override TSeven Seven => default;

		public override TEight Eight => default;

		public UnionValueFour(TFour four, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Four = four;

		private UnionValueFour(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Four = (TFour)info.GetValue(nameof(Four), typeof(TFour));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Four), Four);

		public bool Equals(UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(Four, other.Four);

		public override int GetHashCode()
			=> Four.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"Four:{Four}";
	}

	[Serializable]
	internal class UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 4;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five { get; }

		public override TSix Six => default;

		public override TSeven Seven => default;

		public override TEight Eight => default;

		public UnionValueFive(TFive five, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Five = five;

		private UnionValueFive(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Five = (TFive)info.GetValue(nameof(Five), typeof(TFive));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Five), Five);

		public bool Equals(UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(Five, other.Five);

		public override int GetHashCode()
			=> Five.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"Five:{Five}";
	}

	[Serializable]
	internal class UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 5;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five => default;

		public override TSix Six { get; }

		public override TSeven Seven => default;

		public override TEight Eight => default;

		public UnionValueSix(TSix six, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Six = six;

		private UnionValueSix(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Six = (TSix)info.GetValue(nameof(Six), typeof(TSix));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Six), Six);

		public bool Equals(UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(Six, other.Six);

		public override int GetHashCode()
			=> Six.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"Six:{Six}";
	}

	[Serializable]
	internal class UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 6;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five => default;

		public override TSix Six => default;

		public override TSeven Seven { get; }

		public override TEight Eight => default;

		public UnionValueSeven(TSeven seven, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Seven = seven;

		private UnionValueSeven(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Seven = (TSeven)info.GetValue(nameof(Seven), typeof(TSeven));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Seven), Seven);

		public bool Equals(UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(Seven, other.Seven);

		public override int GetHashCode()
			=> Seven.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"Seven:{Seven}";
	}

	[Serializable]
	internal class UnionValueEight<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> : UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, IEquatable<UnionValueEight<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>, ISerializable
		where TUnionType : struct
		where TUnionDefinition : IUnionDefinition
	{
		public override int State => 7;

		public override TOne One => default;

		public override TTwo Two => default;

		public override TThree Three => default;

		public override TFour Four => default;

		public override TFive Five => default;

		public override TSix Six => default;

		public override TSeven Seven => default;

		public override TEight Eight { get; }

		public UnionValueEight(TEight eight, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			: base(unionFactory)
			=> Eight = eight;

		private UnionValueEight(SerializationInfo info, StreamingContext context)
			: base(UnionValueUtility.CreateUnionFactory<TUnionType, TUnionDefinition>())
			=> Eight = (TEight)info.GetValue(nameof(Eight), typeof(TEight));

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			=> info.AddValue(nameof(Eight), Eight);

		public bool Equals(UnionValueEight<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> other)
			=> other != null && Equals(Eight, other.Eight);

		public override int GetHashCode()
			=> Eight.GetHashCode() * 31 + 7;

		public override bool Equals(object obj)
			=> obj is UnionValueEight<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> value && Equals(value);

		public override string ToString()
			=> $"Eight:{Eight}";
	}
}
